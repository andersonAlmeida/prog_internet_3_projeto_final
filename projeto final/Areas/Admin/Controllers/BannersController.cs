using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using projeto_final.Data;
using projeto_final.Models;

namespace projeto_final.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BannersController : Controller
    {
        private readonly ApplicationDbContext _context;

        //Define uma instância de IHostingEnvironment
        IHostingEnvironment _appEnvironment;

        public BannersController(ApplicationDbContext context, IHostingEnvironment env)
        {
            _context = context;

            _appEnvironment = env;
        }

        // GET: Admin/Banners
        public async Task<IActionResult> Index()
        {
            return View(await _context.Banner.ToListAsync());
        }

        // GET: Admin/Banners/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var banner = await _context.Banner
                .FirstOrDefaultAsync(m => m.Id == id);
            if (banner == null)
            {
                return NotFound();
            }

            return View(banner);
        }

        // GET: Admin/Banners/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Banners/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Imagem,Ativo")] Banner banner, List<IFormFile> arquivos)
        {
            if (ModelState.IsValid)
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
                    string pasta = "banners";
                    // Define um nome para o arquivo enviado incluindo o sufixo obtido de milesegundos
                    string nomeArquivo = "banner_" + DateTime.Now.Millisecond.ToString();

                    //verifica qual o tipo de arquivo : jpg, gif, png, pdf ou tmp
                    if (arquivo.FileName.Contains(".jpg"))
                        nomeArquivo += ".jpg";
                    else if (arquivo.FileName.Contains(".webp"))
                        nomeArquivo += ".webp";
                    else if (arquivo.FileName.Contains(".png"))
                        nomeArquivo += ".png";
                    else
                        return NotFound();

                    banner.Imagem = nomeArquivo;

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

                _context.Add(banner);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(banner);
        }

        // GET: Admin/Banners/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var banner = await _context.Banner.FindAsync(id);
            if (banner == null)
            {
                return NotFound();
            }
            return View(banner);
        }

        // POST: Admin/Banners/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Imagem,Ativo")] Banner banner)
        {
            if (id != banner.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(banner);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BannerExists(banner.Id))
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
            return View(banner);
        }

        // GET: Admin/Banners/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var banner = await _context.Banner
                .FirstOrDefaultAsync(m => m.Id == id);
            if (banner == null)
            {
                return NotFound();
            }

            return View(banner);
        }

        // POST: Admin/Banners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var banner = await _context.Banner.FindAsync(id);
            _context.Banner.Remove(banner);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BannerExists(int id)
        {
            return _context.Banner.Any(e => e.Id == id);
        }
    }
}
