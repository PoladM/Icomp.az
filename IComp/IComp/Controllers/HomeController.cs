using IComp.Service.Interfaces;
using IComp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace IComp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _productService;
        private readonly IBrandService _brandService;
        public HomeController(IProductService productService, IBrandService brandService)
        {
            _productService = productService;
            _brandService = brandService;
        }
        public IActionResult Index(int page = 1)
        {
            HomeViewModel viewModel = null;

            var products = _productService.GetAllProd(page);
            var brands = _productService.GetBrands();
            var settings = _productService.GetSettings();
            var categories = _productService.GetCategories();
            //categories

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
