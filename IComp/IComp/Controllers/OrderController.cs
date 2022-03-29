using IComp.Core.Entities;
using IComp.Service.Exceptions;
using IComp.Service.Interfaces;
using IComp.Service.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IComp.Controllers
{
    public class OrderController : Controller
    {
        private readonly IProductService _productService;
        private readonly UserManager<AppUser> _userManager;


        public OrderController(IProductService productService, UserManager<AppUser> userManager)
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
        public async Task<IActionResult> CreateFastOrder(int productid, Order order, int prodcount, int ordercount)
        {
            if (!ModelState.IsValid)
            {
                return Ok();
            }

            await _productService.CreateOrder(productid, order, prodcount, ordercount);
            TempData["Success"] = "Product order pending. Our manager will contact you";
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> AddOrderBasket(int id)
        {
            if (!await _productService.AnyProd(id))
            {
                throw new ItemNotFoundException("item not found");
            }

            AppUser appUser = null;

            if (User.Identity.IsAuthenticated)
            {
                appUser = _userManager.Users.FirstOrDefault(x => x.UserName == User.Identity.Name && !x.IsAdmin);
            }

            if (appUser == null)
            {
                string cookie = HttpContext.Request.Cookies["basket"];
                List<BasketCookieItemViewModel> cookieItems = new List<BasketCookieItemViewModel>();

                if (!string.IsNullOrWhiteSpace(cookie))
                {
                    cookieItems = JsonConvert.DeserializeObject<List<BasketCookieItemViewModel>>(cookie);
                }

                BasketCookieItemViewModel cookieItem = cookieItems.FirstOrDefault(x => x.ProductId == id);
                var product = await _productService.GetByIdAsync(id);

                if (product == null)
                {
                    throw new ItemNotFoundException("Item not found");
                }
                if (product.Count <= cookieItem.Count)
                {
                    throw new Exception();
                }
                if (cookieItem == null)
                {
                    cookieItem = new BasketCookieItemViewModel { ProductId = id, Count = 1 };
                    cookieItems.Add(cookieItem);
                }
                else
                {
                    cookieItem.Count++;
                }

                cookie = JsonConvert.SerializeObject(cookieItems);
                HttpContext.Response.Cookies.Append("basket", cookie);


                return PartialView("_OrderBasketPartial", await _productService._getBasket(cookieItems));
            }
            else
            {
                var basketItem = await _productService.UserBasket(id, appUser);


                return PartialView("_OrderBasketPartial", await _productService._getBasket(basketItem));
            }
        }

        public async Task<IActionResult> DeleteOrderBasket(int id)
        {
            return PartialView("_OrderBasketPartial", await _productService.DeleteBasket(id));
        }
    }
}
