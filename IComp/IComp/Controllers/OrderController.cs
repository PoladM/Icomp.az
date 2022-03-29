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

        public async Task<IActionResult> BasketCheckOut()
        {
            return View(await _productService.CheckOut());
        }

        [HttpPost]
        public async Task<IActionResult> CreateBasketOrder(Order order)
        {
            await _productService.CreateOrder(order);
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> CheckOut(int id)
        {
            var viewModel = await _productService.FastOrder(id);

            return PartialView("_FastOrderPartial",viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFastOrder(int productid, Order order)
        {
            if (!ModelState.IsValid)
            {
                return Ok();
            }

            await _productService.CreateOrder(productid, order);
            TempData["Success"] = "Product order pending. Our manager will contact you";
            return RedirectToAction("Index", "Home");
        }
    }
}
