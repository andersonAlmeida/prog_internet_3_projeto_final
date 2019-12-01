using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using projeto_final.Data;
using projeto_final.Models;
using projeto_final.Models.ViewModels;
using projeto_final.Services;

namespace projeto_final.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly CategoriaService _categoriaService;
        private readonly MarcaService _marcaService;
        private readonly ProdutoService _produtoService;

        public ProdutosController(ApplicationDbContext context, CategoriaService categoriaService, MarcaService marcaService, ProdutoService produtoService)
        {
            _context = context;
            _categoriaService = categoriaService;
            _marcaService = marcaService;
            _produtoService = produtoService;
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
            var viewModel = new ProdutoFormViewModel {
                Categorias = categorias,
                Marcas = marcas
            };
            //Encaminha os dados para a view
            //Agora na tela de cadastro, já vou poder acessar a lista de departamentos 
            return View(viewModel);            
        }

        // POST: Produtos/Create
        [HttpPost]
        public IActionResult Create(Produto produto)
        {          
            _produtoService.Insert(produto);
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
        public IActionResult Edit(int id, [Bind("Id,Preco,Nome,Descricao,Desconto,Estoque,Categoria,Marca")] Produto produto)
        {
            if (id != produto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _produtoService.Update(produto);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdutoExists(produto.Id))
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
            return View(produto);
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
