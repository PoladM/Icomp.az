using IComp.Service.DTOs.HardDiscDTOs;
using IComp.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace IComp.Areas.manage.Controllers
{
    [Area("manage")]
    public class HarddiscController : Controller
    {
        private readonly IHardDiscService _hardDiscService;
        public HarddiscController(IHardDiscService hardDiscService)
        {
            _hardDiscService = hardDiscService;
        }

        public IActionResult Index(int page = 1)
        {
            return View(_hardDiscService.GetAllProd(page));
        }
        public IActionResult GetSSD()
        {
            ViewBag.Capacity = _hardDiscService.GetCapacitiesForSSD();
            return PartialView("_HardDiscCapacityPartial");
        }
        public IActionResult GetHDD()
        {
            ViewBag.Capacity = _hardDiscService.GetCapacitiesForHDD();
            return PartialView("_HardDiscCapacityPartial");
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(HardDiscPostDto postDto)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var processorPostDto = await _hardDiscService.CreateAsync(postDto);

            return RedirectToAction("Index");
        }
    }
}
