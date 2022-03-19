using IComp.Core.Entities;
using IComp.Service.DTOs.BrandDTOs;
using IComp.Service.DTOs.ProductDTOs;
using IComp.Service.Helpers;
using IComp.Service.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IComp.Areas.manage.Controllers
{
    [Area("manage")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IWebHostEnvironment _env;

        public ProductController(IProductService productService, IWebHostEnvironment env)
        {
            _productService = productService;
            _env = env;
        }

        public IActionResult Index(int? processorserieid, int? videocardserieid, int? motherboardid, int? prodtypeid, int? prodmemoryid, int? brandid, int? destinationid, int? harddiscid, int? categoryid, int? pagesize, int page = 1)
        {
            return View(_productService.FilterProd(processorserieid, videocardserieid, motherboardid, prodtypeid, prodmemoryid, brandid, destinationid, harddiscid, categoryid, pagesize, page));
        }
        public IActionResult Create()
        {

            ViewBag.Processors = _productService.GetProcessors();
            ViewBag.Brands = _productService.GetBrands();
            ViewBag.Memories = _productService.GetMemories();
            ViewBag.Categories = _productService.GetCategories();
            ViewBag.HardDiscs = _productService.GetHardDiscs();
            ViewBag.MotherBoards = _productService.GetMotherBoards();
            ViewBag.VideoCards = _productService.GetVideoCards();
            ViewBag.Destinations = _productService.GetDestinations();
            ViewBag.ProdTypes = _productService.GetProdTypes();

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProductPostDto postDto)
        {
            ViewBag.Processors = _productService.GetProcessors();
            ViewBag.Brands = _productService.GetBrands();
            ViewBag.Memories = _productService.GetMemories();
            ViewBag.Categories = _productService.GetCategories();
            ViewBag.HardDiscs = _productService.GetHardDiscs();
            ViewBag.MotherBoards = _productService.GetMotherBoards();
            ViewBag.VideoCards = _productService.GetVideoCards();
            ViewBag.Destinations = _productService.GetDestinations();
            ViewBag.ProdTypes = _productService.GetProdTypes();

            if (!ModelState.IsValid)
            {
                return View();
            }
            if (postDto.PosterFile == null)
            {
                ModelState.AddModelError("PosterFile", "PosterFile is required");
                return View();
            }
            else
            {
                if (postDto.PosterFile.ContentType != "image/jpeg" && postDto.PosterFile.ContentType != "image/png")
                {
                    ModelState.AddModelError("PosterFile", "file type must be image/jpeg or image/png");
                    return View();
                }

                if (postDto.PosterFile.Length > 2097152)
                {
                    ModelState.AddModelError("PosterFile", "file size must be less than 2mb");
                    return View();
                }
            }

            if (postDto.ImageFiles != null)
            {
                foreach (var file in postDto.ImageFiles)
                {
                    if (file.ContentType != "image/jpeg" && file.ContentType != "image/png")
                    {
                        ModelState.AddModelError("ImageFiles", "file type must be image/jpeg or image/png");
                        return View();
                    }

                    if (file.Length > 2097152)
                    {
                        ModelState.AddModelError("ImageFiles", "file size must be less than 2mb");
                        return View();
                    }
                }
            }
            postDto.ProductImages = new List<ProductImage>();

            ProductImage posterImage = new ProductImage
            {
                PosterStatus = true,
                Image = FileManager.Save(_env.WebRootPath, "uploads/products", postDto.PosterFile)
            };
            postDto.ProductImages.Add(posterImage);

            if (postDto.ImageFiles != null)
            {
                foreach (var file in postDto.ImageFiles)
                {
                    ProductImage productImage = new ProductImage
                    {
                        PosterStatus = null,
                        Image = FileManager.Save(_env.WebRootPath, "uploads/products", file)
                    };
                    postDto.ProductImages.Add(productImage);
                }
            }

            var getDto = await _productService.CreateAsync(postDto);
            return RedirectToAction("Index");
        }
    }
}
