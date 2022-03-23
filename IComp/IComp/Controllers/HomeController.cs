using IComp.Service.Interfaces;
using IComp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace IComp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _productService;
        public HomeController(IProductService productService)
        {
            _productService = productService;
        }
        public IActionResult Index(int page = 1)
        {
            HomeViewModel viewModel = null;

            var products = _productService.GetAllProd(page);

            viewModel = new HomeViewModel
            {
                Paginated = products
            };

            return View(viewModel);
        }
    }
}
