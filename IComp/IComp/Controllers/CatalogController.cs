using IComp.Core;
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
using System.Globalization;
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

            var filterProd = _productService.ProductsForFilter(categoryid, brandid);

            NumberFormatInfo nfi = new NumberFormatInfo();

            nfi.NumberDecimalSeparator = ".";

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
            ViewBag.CategoryName = _productService.GetCategories().FirstOrDefault(x => x.Id == categoryid).Name;
            


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

            

            foreach (var item in filterProd)
            {
                if (!viewModel.destinationGetDtos.Any(x => x.Id == item.DestinationId))
                {
                    viewModel.destinationGetDtos.AddRange(_productService.GetDestinations().Where(x => x.Id == item.DestinationId).ToList()); 
                }
            }
            foreach (var item in filterProd)
            {
                if (item.Processor != null)
                {
                    if (!viewModel.processorSerieGetDtos.Any(x => x.Id == item.Processor.ProcessorSerieId))
                    {
                        viewModel.processorSerieGetDtos.AddRange(_productService.GetProcessirSeries().Where(x => x.Id == item.Processor.ProcessorSerieId).ToList());
                    }
                }
            }
            foreach (var item in filterProd)
            {
                if (item.VideoCard != null)
                {
                    if (!viewModel.vCSerieGets.Any(x => x.Id == item.VideoCard.VideoCardSerieId))
                    {
                        viewModel.vCSerieGets.AddRange(_productService.GetVideoCardSeries().Where(x => x.Id == item.VideoCard.VideoCardSerieId).ToList());
                    }
                }
            }
            foreach (var item in filterProd)
            {
                if (item.MotherBoard != null)
                {
                    if (!viewModel.motherBoardGetDtos.Any(x => x.Id == item.MotherBoardId))
                    {
                        viewModel.motherBoardGetDtos.AddRange(_productService.GetMotherBoards().Where(x => x.Id == item.MotherBoardId).ToList());
                    }
                }
            }
            foreach (var item in filterProd)
            {
                if (!viewModel.prodTypeGetDtos.Any(x => x.Id == item.ProdTypeId))
                {
                    viewModel.prodTypeGetDtos.AddRange(_productService.GetProdTypes().Where(x => x.Id == item.ProdTypeId).ToList());
                }
            }
            foreach (var item in filterProd)
            {
                if (item.ProdMemory != null)
                {
                    if (!viewModel.mCapacityGetDtos.Any(x => x.Id == item.ProdMemory.MemoryCapacityId))
                    {
                        viewModel.mCapacityGetDtos.AddRange(_productService.GetMemoryCapacities().Where(x => x.Id == item.ProdMemory.MemoryCapacityId).ToList());
                    }
                }
            }
            foreach (var item in filterProd)
            {
                if (!viewModel.brandGetDtos.Any(x => x.Id == item.BrandId))
                {
                    viewModel.brandGetDtos.AddRange(_productService.GetBrands().Where(x => x.Id == item.BrandId).ToList());
                }
            }
            foreach (var item in filterProd)
            {
                if (item.HardDisc != null)
                {
                    if (!viewModel.hardDiscCapacityGetDtos.Any(x => x.Id == item.HardDisc.HDDCapacityId))
                    {
                        viewModel.hardDiscCapacityGetDtos.AddRange(_productService.GetHardDiscCapacities().Where(x => x.Id == item.HardDisc.HDDCapacityId).ToList());
                    }
                }
            }
            foreach (var item in filterProd)
            {
                if (item.SSD != null)
                {
                    if (!viewModel.SSDCapacities.Any(x => x.Id == item.SSD.SSDCapacityID))
                    {
                        viewModel.SSDCapacities.AddRange(_productService.GetSSDCapacities().Where(x => x.Id == item.SSD.SSDCapacityID).ToList());
                    }
                }
            }
            foreach (var item in filterProd)
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
                if (product.IsAvailable == false || product.IsDeleted)
                {
                    throw new ItemNotFoundException("This product isn't available");
                }
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

                TempData["Success"] = "Product added to basket";
                return PartialView("_BasketPartial", await _productService._getBasket(cookieItems));
            }
            else
            {
                var basketItem = await _productService.UserBasket(id, appUser);

                TempData["Success"] = "Product added to basket";
                return PartialView("_BasketPartial", await _productService._getBasket(basketItem));
            }
        }

        public async Task<IActionResult> GetBasketItems()
        {
            AppUser appUser = null;
            if (User.Identity.IsAuthenticated)
            {
                appUser = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == User.Identity.Name);
            }
            var basketItems = await _productService.GetBasketItems(appUser);
            return PartialView("_BasketPartial", basketItems);
        }

        public async Task<IActionResult> DeleteBasket(int id)
        {
            return PartialView("_BasketPartial", await _productService.DeleteBasket(id));
        }
        public async Task<IActionResult> DeleteProdFromBasket(int id)
        {
            return PartialView("_BasketPartial", await _productService.DeleteProdFromBasket(id));
        }

        [HttpPost]
        public async Task<IActionResult> Search(string searchString)
        {
            return PartialView("_SearchProductPartial", await _productService.SearchProd(searchString));
        }
    }
}
