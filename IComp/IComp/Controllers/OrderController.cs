using IComp.Core.Entities;
using IComp.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace IComp.Controllers
{
    public class OrderController : Controller
    {
        private readonly IProductService _productService;

        public OrderController(IProductService productService)
        {
            _productService = productService;
        }
        public async Task<IActionResult> CheckOut(int id)
        {
            var viewModel = await _productService.FastOrder(id);

            return Ok(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(int id, Order order)
        {
            await _productService.CreateOrder(id, order);
            return RedirectToAction("Index", "Home");
        }
    }
}
