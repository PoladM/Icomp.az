using IComp.Service.Interfaces;
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

            var products = _productService.GetAllProdWithFilter(page);
            var brands = _productService.GetBrands();
            var settings = _productService.GetSettings();
            var categories = _productService.GetCategories();
            var sliders = _productService.GetSlider();

            viewModel = new HomeViewModel
            {
                Paginated = products,
                Brands = brands,
                Settings = settings,
                Categories = categories,
                Sliders = sliders,
            };

            return View(viewModel);
        }
    }
}
