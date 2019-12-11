using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using projeto_final.Models;
using projeto_final.Models.ViewModels;
using projeto_final.Services;

namespace projeto_final.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly ProdutoService _produtoService;
        private readonly BannerService _bannerService;
        IHostingEnvironment _appEnvironment;

        public HomeController(ProdutoService produtoService, IHostingEnvironment env, BannerService bannerService)
        {
            _produtoService = produtoService;
            _bannerService = bannerService;
            _appEnvironment = env;
        }

        public IActionResult Index()
        {
            var produtos = _produtoService.FindAll();
            var banners = _bannerService.FindAll();
            var viewModel = new HomeViewModel
            {
                Produtos = produtos,
                Uploads = _appEnvironment.WebRootPath + "\\images\\uploads\\",
                Banners = banners
            };
            return View(viewModel);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
