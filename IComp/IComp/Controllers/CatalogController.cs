using IComp.Core.Entities;
using IComp.Service.Exceptions;
using IComp.Service.Interfaces;
using IComp.Service.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IComp.Controllers
{
    public class CatalogController : Controller
    {
        private IProductService _productService;
        private readonly UserManager<AppUser> _userManager;

        public CatalogController(IProductService productService, UserManager<AppUser> userManager)
        {
            _productService = productService;
            _userManager = userManager;
        }
        public IActionResult Index(decimal? minprice, decimal? maxprice, string sort, int? processorserieid, int? videocardserieid, int? motherboardid, int? prodtypeid, int? memorycapacityid, int? brandid, int? destinationid, int? hddcapacityid, int? ssdcapacityid, int? categoryid, int page = 1)
        {
            ProductViewModel viewModel = null;

            var products = _productService.FilterProd(minprice, maxprice, sort, processorserieid, videocardserieid, motherboardid,  prodtypeid, memorycapacityid,  brandid,  destinationid, hddcapacityid, ssdcapacityid, categoryid, page);

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
                MaxPrice = _productService.FilterByPrice("max"),
                MinPrice = _productService.FilterByPrice("min")
            };

            ViewBag.FilterMaxPrice = maxprice ?? viewModel.MaxPrice;
            ViewBag.FilterMinPrice = minprice ?? viewModel.MinPrice;

           

            return View(viewModel);
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
