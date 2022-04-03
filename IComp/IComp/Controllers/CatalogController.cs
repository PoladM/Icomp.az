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
        public IActionResult Index(decimal? minprice, decimal? maxprice, string sort, int? softwareid, int? processorserieid, int? videocardserieid, int? motherboardid, int? prodtypeid, int? memorycapacityid, int? brandid, int? destinationid, int? hddcapacityid, int? ssdcapacityid, int? categoryid, int page = 1)
        {
            ProductViewModel viewModel = null;

            var products = _productService.FilterProd(minprice, maxprice, sort, softwareid, processorserieid, videocardserieid, motherboardid, prodtypeid, memorycapacityid, brandid, destinationid, hddcapacityid, ssdcapacityid, categoryid, page);

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
                processorSerieGetDtos = new List<Service.DTOs.ProcessorSerieDTOs.ProcessorSerieGetDto>(),
                vCSerieGets = new List<Service.DTOs.VCSerieDTOs.VCSerieGetDto>(),
                motherBoardGetDtos = new List<Service.DTOs.MotherBoardDTOs.MotherBoardGetDto>(),
                prodTypeGetDtos = new List<Service.DTOs.ProdTypeDTOs.ProdTypeGetDto>(),
                mCapacityGetDtos = new List<Service.DTOs.MemoryCapacityDTOs.MCapacityGetDto>(),
                brandGetDtos = new List<Service.DTOs.BrandDTOs.BrandGetDto>(),
                destinationGetDtos = new List<Service.DTOs.DestinationDTOs.DestinationGetDto>(),
                hardDiscCapacityGetDtos = new List<Service.DTOs.HardDiscCapacityDTOs.HardDiscCapacityGetDto>(),
                SSDCapacities = new List<SSDCapacity>(),
                categoryGetDtos = new List<Service.DTOs.CategoryDTOs.CategoryGetDto>(),
                Softwares = new List<Service.DTOs.SoftwareDTOs.SoftwareGetDto>(),
                MaxPrice = _productService.FilterByPrice("max"),
                MinPrice = _productService.FilterByPrice("min")
            };

            foreach (var item in viewModel.Paginated.Items)
            {
                if (!viewModel.destinationGetDtos.Any(x => x.Id == item.DestinationId))
                {
                    viewModel.destinationGetDtos.AddRange(_productService.GetDestinations().Where(x => x.Id == item.DestinationId).ToList()); 
                }
            }
            foreach (var item in viewModel.Paginated.Items)
            {
                if (item.Processor != null)
                {
                    if (!viewModel.processorSerieGetDtos.Any(x => x.Id == item.Processor.ProcessorSerieId))
                    {
                        viewModel.processorSerieGetDtos.AddRange(_productService.GetProcessirSeries().Where(x => x.Id == item.Processor.ProcessorSerieId).ToList());
                    }
                }
            }
            foreach (var item in viewModel.Paginated.Items)
            {
                if (item.VideoCard != null)
                {
                    if (!viewModel.vCSerieGets.Any(x => x.Id == item.VideoCard.VideoCardSerieId))
                    {
                        viewModel.vCSerieGets.AddRange(_productService.GetVideoCardSeries().Where(x => x.Id == item.VideoCard.VideoCardSerieId).ToList());
                    }
                }
            }
            foreach (var item in viewModel.Paginated.Items)
            {
                if (item.MotherBoard != null)
                {
                    if (!viewModel.motherBoardGetDtos.Any(x => x.Id == item.MotherBoardId))
                    {
                        viewModel.motherBoardGetDtos.AddRange(_productService.GetMotherBoards().Where(x => x.Id == item.MotherBoardId).ToList());
                    }
                }
            }
            foreach (var item in viewModel.Paginated.Items)
            {
                if (!viewModel.prodTypeGetDtos.Any(x => x.Id == item.ProdTypeId))
                {
                    viewModel.prodTypeGetDtos.AddRange(_productService.GetProdTypes().Where(x => x.Id == item.ProdTypeId).ToList());
                }
            }
            foreach (var item in viewModel.Paginated.Items)
            {
                if (item.ProdMemory != null)
                {
                    if (!viewModel.mCapacityGetDtos.Any(x => x.Id == item.ProdMemory.MemoryCapacityId))
                    {
                        viewModel.mCapacityGetDtos.AddRange(_productService.GetMemoryCapacities().Where(x => x.Id == item.ProdMemory.MemoryCapacityId).ToList());
                    }
                }
            }
            foreach (var item in viewModel.Paginated.Items)
            {
                if (!viewModel.brandGetDtos.Any(x => x.Id == item.BrandId))
                {
                    viewModel.brandGetDtos.AddRange(_productService.GetBrands().Where(x => x.Id == item.BrandId).ToList());
                }
            }
            foreach (var item in viewModel.Paginated.Items)
            {
                if (item.HardDisc != null)
                {
                    if (!viewModel.hardDiscCapacityGetDtos.Any(x => x.Id == item.HardDisc.HDDCapacityId))
                    {
                        viewModel.hardDiscCapacityGetDtos.AddRange(_productService.GetHardDiscCapacities().Where(x => x.Id == item.HardDisc.HDDCapacityId).ToList());
                    }
                }
            }
            foreach (var item in viewModel.Paginated.Items)
            {
                if (item.SSD != null)
                {
                    if (!viewModel.SSDCapacities.Any(x => x.Id == item.SSD.SSDCapacityID))
                    {
                        viewModel.SSDCapacities.AddRange(_productService.GetSSDCapacities().Where(x => x.Id == item.SSD.SSDCapacityID).ToList());
                    }
                }
            }
            foreach (var item in viewModel.Paginated.Items)
            {
                if (item.Software != null)
                {
                    if (!viewModel.Softwares.Any(x => x.Id == item.SoftwareId))
                    {
                        viewModel.Softwares.AddRange(_productService.GetSoftwares().Where(x => x.Id == item.SoftwareId).ToList());
                    }
                }
            }

            ViewBag.FilterMaxPrice = maxprice ?? viewModel.MaxPrice;
            ViewBag.FilterMinPrice = minprice ?? viewModel.MinPrice;

            ViewBag.Sort = sort;

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
                var basketItem = await _productService.UserBasket(id, appUser);


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
            return PartialView("_SearchProductPartial", await _productService.SearchProd(searchString));
        }
    }
}
