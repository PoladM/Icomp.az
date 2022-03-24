﻿using IComp.Service.Interfaces;
using IComp.Service.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace IComp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _productService;
        public HomeController(IProductService productService, IBrandService brandService)
        {
            _productService = productService;
        }
        public IActionResult Index(int page = 1)
        {
            HomeViewModel viewModel = null;

            var products = _productService.GetAllProd(page);
            var brands = _productService.GetBrands();
            var settings = _productService.GetSettings();
            var categories = _productService.GetCategories();

            viewModel = new HomeViewModel
            {
                Paginated = products,
                Brands = brands,
                Settings = settings,
                Categories = categories
            };

            return View(viewModel);
        }
    }
}
