using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using projeto_final.Data;
using projeto_final.Models;
using projeto_final.Models.ViewModels;
using projeto_final.Services;

namespace projeto_final.Areas.Admin.Controllers
{
    [Area("Admin")]    
    public class ProdutosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly CategoriaService _categoriaService;
        private readonly MarcaService _marcaService;
        private readonly ProdutoService _produtoService;

        //Define uma instância de IHostingEnvironment
        IHostingEnvironment _appEnvironment;


        public ProdutosController(ApplicationDbContext context, CategoriaService categoriaService, MarcaService marcaService, ProdutoService produtoService, IHostingEnvironment env)
        {
            _context = context;
            _categoriaService = categoriaService;
            _marcaService = marcaService;
            _produtoService = produtoService;


            _appEnvironment = env;
        }

        // GET: Produtos
        public IActionResult Index()
        {
            //retorna uma lista
            var list = _produtoService.FindAll();
            return View(list);
        }

        // GET: Produtos/Details/5
        public IActionResult Details(int id)
        {
            var produto = _produtoService.FindById(id);

            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // GET: Produtos/Create
        public IActionResult Create()
        {
            List<Categoria> categorias = _categoriaService.FindAll();
            List<Marca> marcas = _marcaService.FindAll();

            //Instância nosso ViewModel
            var viewModel = new ProdutoFormViewModel
            {
                Categorias = categorias,
                Marcas = marcas
            };
            //Encaminha os dados para a view
            //Agora na tela de cadastro, já vou poder acessar a lista de departamentos 
            return View(viewModel);
        }

        // POST: Produtos/Create
        [HttpPost]
        public async Task<IActionResult> Create(ProdutoFormViewModel viewModel, List<IFormFile> arquivos)
        {
            foreach (var arquivo in arquivos)
            {
                //verifica se existem arquivos 
                if (arquivo == null || arquivo.Length == 0)
                {
                    //retorna a viewdata com erro
                    ViewData["Erro"] = "Error: Arquivo(s) não selecionado(s)";
                    return View(ViewData);
                }
                // < define a pasta onde vamos salvar os arquivos >
                string pasta = "uploads";
                // Define um nome para o arquivo enviado incluindo o sufixo obtido de milesegundos
                string nomeArquivo = "produto_lista_" + DateTime.Now.Millisecond.ToString();

                //verifica qual o tipo de arquivo : jpg, gif, png, pdf ou tmp
                if (arquivo.FileName.Contains(".jpg"))
                    nomeArquivo += ".jpg";
                else if (arquivo.FileName.Contains(".webp"))
                    nomeArquivo += ".webp";
                else if (arquivo.FileName.Contains(".png"))
                    nomeArquivo += ".png";
                else
                    return NotFound();

                viewModel.Produto.Thumb = nomeArquivo;

                //< obtém o caminho físico da pasta wwwroot >
                string caminho_WebRoot = _appEnvironment.WebRootPath;
                // monta o caminho onde vamos salvar o arquivo : 
                // ~\wwwroot\images\uploads\
                string caminhoDestinoArquivo = caminho_WebRoot + "\\images\\" + pasta + "\\";
                // incluir a pasta Recebidos e o nome do arquivo enviado : 
                // ~\wwwroot\images\uploads\
                string caminhoDestinoArquivoOriginal = caminhoDestinoArquivo + nomeArquivo;
                //copia o arquivo para o local de destino original
                using (var stream = new FileStream(caminhoDestinoArquivoOriginal, FileMode.Create))
                {
                    await arquivo.CopyToAsync(stream);
                }
            }

            _produtoService.Insert(viewModel.Produto);
            return RedirectToAction(nameof(Index));
        }

        // GET: Produtos/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = _produtoService.FindById(id.Value);

            /*Verificar se o id é válido e retornou algum registro.
            Se nenhum vendedor for localizado com esse id, será retornado 
            o valor null do método FindById(int id)*/
            if (obj == null)
            {
                return NotFound();
            }

            List<Categoria> categorias = _categoriaService.FindAll();
            List<Marca> marcas = _marcaService.FindAll();

            ProdutoFormViewModel viewModel = new ProdutoFormViewModel
            {
                Produto = obj,
                Categorias = categorias,
                Marcas = marcas
            };

            return View(viewModel);
        }

        // POST: Produtos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProdutoFormViewModel viewModel, List<IFormFile> arquivos, string thumb)
        {
            if (id != viewModel.Produto.Id)
            {
                return NotFound();
            }

            try
            {
                foreach (var arquivo in arquivos)
                {
                    // se tem uma imagem relacionada
                    if (thumb != "")
                    {
                        string sourceDir = _appEnvironment.WebRootPath + "//images//uploads//";

                        // remove a imagem do produto atualizado
                        System.IO.File.Delete(sourceDir + thumb);
                    }

                    //verifica se existem arquivos 
                    if (arquivo == null || arquivo.Length == 0)
                    {
                        //retorna a viewdata com erro
                        ViewData["Erro"] = "Error: Arquivo(s) não selecionado(s)";
                        return View(ViewData);
                    }
                    // < define a pasta onde vamos salvar os arquivos >
                    string pasta = "uploads";
                    // Define um nome para o arquivo enviado incluindo o sufixo obtido de milesegundos
                    string nomeArquivo = "produto_lista_" + DateTime.Now.Millisecond.ToString();

                    //verifica qual o tipo de arquivo : jpg, gif, png, pdf ou tmp
                    if (arquivo.FileName.Contains(".jpg"))
                        nomeArquivo += ".jpg";
                    else if (arquivo.FileName.Contains(".webp"))
                        nomeArquivo += ".webp";
                    else if (arquivo.FileName.Contains(".png"))
                        nomeArquivo += ".png";
                    else
                        return NotFound();

                    viewModel.Produto.Thumb = nomeArquivo;

                    //< obtém o caminho físico da pasta wwwroot >
                    string caminho_WebRoot = _appEnvironment.WebRootPath;
                    // monta o caminho onde vamos salvar o arquivo : 
                    // ~\wwwroot\images\uploads\
                    string caminhoDestinoArquivo = caminho_WebRoot + "\\images\\" + pasta + "\\";
                    // incluir a pasta Recebidos e o nome do arquivo enviado : 
                    // ~\wwwroot\images\uploads\
                    string caminhoDestinoArquivoOriginal = caminhoDestinoArquivo + nomeArquivo;
                    //copia o arquivo para o local de destino original
                    using (var stream = new FileStream(caminhoDestinoArquivoOriginal, FileMode.Create))
                    {
                        await arquivo.CopyToAsync(stream);
                    }
                }

                _produtoService.Update(viewModel.Produto);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProdutoExists(viewModel.Produto.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));

        }

        // GET: Produtos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produto
                .FirstOrDefaultAsync(m => m.Id == id);

            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var produto = await _context.Produto.FindAsync(id);
            string sourceDir = _appEnvironment.WebRootPath + "//images//uploads//";

            // remove a imagem do produto deletado
            System.IO.File.Delete(sourceDir + produto.Thumb);

            _context.Produto.Remove(produto);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool ProdutoExists(int id)
        {
            return _context.Produto.Any(e => e.Id == id);
        }
    }
}
