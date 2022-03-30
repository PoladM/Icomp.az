﻿using IComp.Core;
using IComp.Core.Entities;
using IComp.Service.Exceptions;
using IComp.Service.Interfaces;
using IComp.Service.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IComp.Controllers
{
    public class CatalogController : Controller
    {
        private IProductService _productService;
        private IUnitOfWork _unitOfWork;
        private readonly UserManager<AppUser> _userManager;
        

        public CatalogController(IProductService productService, UserManager<AppUser> userManager, IUnitOfWork unitOfWork)
        {
            _productService = productService;
            _userManager = userManager;
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index(decimal? minprice, decimal? maxprice, string sort, int? softwareid , int? processorserieid, int? videocardserieid, int? motherboardid, int? prodtypeid, int? memorycapacityid, int? brandid, int? destinationid, int? hddcapacityid, int? ssdcapacityid, int? categoryid, int page = 1)
        {
            ProductViewModel viewModel = null;

            var products = _productService.FilterProd(minprice, maxprice, sort, softwareid, processorserieid,videocardserieid, motherboardid,  prodtypeid, memorycapacityid,  brandid,  destinationid, hddcapacityid, ssdcapacityid, categoryid, page);

            ViewBag.processorserieid = processorserieid;
            ViewBag.videocardserieid = videocardserieid;
            ViewBag.motherboardid = motherboardid;
            ViewBag.prodtypeid = prodtypeid;
            ViewBag.memorycapacityid = memorycapacityid;
            ViewBag.brandid = brandid;
            ViewBag.destinationid = destinationid;
            ViewBag.categoryid = categoryid;
            ViewBag.hddcapacityid = hddcapacityid;
            ViewBag.ssdcapacityid = ssdcapacityid;
            ViewBag.softwareid = softwareid;
            ViewBag.sort = sort;



            viewModel = new ProductViewModel
            {
                Paginated = products,
                processorSerieGetDtos = _productService.GetProcessirSeries(),
                vCSerieGets = _productService.GetVideoCardSeries(),
                motherBoardGetDtos = _productService.GetMotherBoards(),
                prodTypeGetDtos = _productService.GetProdTypes(),
                mCapacityGetDtos = _productService.GetMemoryCapacities(),
                brandGetDtos = _productService.GetBrands(),
                destinationGetDtos = _productService.GetDestinations(),
                hardDiscCapacityGetDtos = _productService.GetHardDiscCapacities(),
                SSDCapacities = _productService.GetSSDCapacities(),
                categoryGetDtos = _productService.GetCategories(),
                Softwares = _productService.GetSoftwares(),
                MaxPrice = _productService.FilterByPrice("max"),
                MinPrice = _productService.FilterByPrice("min")
            };

            ViewBag.FilterMaxPrice = maxprice ?? viewModel.MaxPrice;
            ViewBag.FilterMinPrice = minprice ?? viewModel.MinPrice;

           

            return View(viewModel);
        }

        public async Task<IActionResult> GetCookie()
        {
            CommonBasketViewModel basketItems = new CommonBasketViewModel
            {
                BasketItems = new List<BasketProductViewModel>(),
                TotalPrice = 0
            };

            List<BasketCookieItemViewModel> cookieItems = new List<BasketCookieItemViewModel>();

            AppUser appUser = null;

            if (HttpContext.User.Identity.IsAuthenticated)
            {
                appUser = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == HttpContext.User.Identity.Name && !x.IsAdmin);
            }

            if (appUser == null)
            {
                string cookieItemsStr = HttpContext.Request.Cookies["basket"];

                if (!string.IsNullOrWhiteSpace(cookieItemsStr))
                {
                    cookieItems = JsonConvert.DeserializeObject<List<BasketCookieItemViewModel>>(cookieItemsStr);

                }
            }
            else
            {
                cookieItems = _unitOfWork.BasketItemRepository.GetAll(x => x.AppUserId == appUser.Id).Select(b => new BasketCookieItemViewModel { ProductId = b.ProductId, Count = b.Count }).ToList();
            }

            return Ok(cookieItems);

            foreach (var item in cookieItems)
            {
                var product = await _unitOfWork.ProductRepository.GetAsync(x => x.Id == item.ProductId, "ProductImages");

                if (product == null)
                {
                    throw new Exception("lol");
                }

                BasketProductViewModel basketProduct = new BasketProductViewModel
                {
                    Product = product,
                    Count = item.Count
                };

                basketItems.BasketItems.Add(basketProduct);
                decimal totalPrice = product.DiscountPercent > 0 ? (product.SalePrice * (1 - product.DiscountPercent / 100)) : product.SalePrice;
                basketItems.TotalPrice += totalPrice * item.Count;
            }

            return Ok(basketItems);
        }

        public async Task<IActionResult> AddBasket(int id)
        {
            if (! await _productService.AnyProd(id))
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
                if (product.Count <= cookieItem?.Count)
                {
                    throw new ItemNotFoundException("There are only " + product.Count + " products in stock");
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


                return PartialView("_BasketPartial", await _productService._getBasket(cookieItems));
            }
            else
            {
                var basketItem = await _productService.UserBasket(id,appUser);


                return PartialView("_BasketPartial", await _productService._getBasket(basketItem));
            }
        }


        public async Task<IActionResult> DeleteBasket(int id)
        {
            return PartialView("_BasketPartial", await _productService.DeleteBasket(id));
        }
        
        [HttpPost]
        public async Task<IActionResult> Search(string searchString)
        {
            return PartialView("_SearchProductPartial",await _productService.SearchProd(searchString));
        }
    }
}
