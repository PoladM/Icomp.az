using IComp.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace IComp.Controllers
{
    public class DetailController : Controller
    {
        private IProductService _productService;
        public DetailController(IProductService productService)
        {
            _productService = productService;
        }
        public async Task<IActionResult> Index(int id)
        {
            return View(await _productService.FindByIdAsync(id));
        }

    }
}
