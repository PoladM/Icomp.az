using IComp.Core.Entities;
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
        [HttpPost]
        public async Task<IActionResult> Comment(ProductComment comment)
        {
            var Id = await _productService.Comment(comment);
            return RedirectToAction("index", new { id = Id });
        }
    }
}
