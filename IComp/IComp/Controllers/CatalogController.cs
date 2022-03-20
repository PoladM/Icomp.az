using IComp.Service.Interfaces;
using IComp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace IComp.Controllers
{
    public class CatalogController : Controller
    {
        private IProductService _productService;
        public CatalogController(IProductService productService)
        {
            _productService = productService;
        }
        public IActionResult Index(string sort, int? processorserieid, int? videocardserieid, int? motherboardid, int? prodtypeid, int? memorycapacityid, int? brandid, int? destinationid, int? hddcapacityid, int? categoryid, int? pagesize, int page = 1)
        {
            ProductViewModel viewModel = null;

            // fix values pageindex onclick
            var products = _productService.FilterProd(sort, processorserieid, videocardserieid, motherboardid,  prodtypeid, memorycapacityid,  brandid,  destinationid, hddcapacityid,  categoryid, pagesize, page);

            ViewBag.processorserieid = processorserieid;
            ViewBag.videocardserieid = videocardserieid;
            ViewBag.motherboardid = motherboardid;
            ViewBag.prodtypeid = prodtypeid;
            ViewBag.memorycapacityid = memorycapacityid;
            ViewBag.brandid = brandid;
            ViewBag.destinationid = destinationid;
            ViewBag.categoryid = categoryid;
            ViewBag.hddcapacityid = hddcapacityid;
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
                categoryGetDtos = _productService.GetCategories(),
            };

            return View(viewModel);
        }
    }
}
