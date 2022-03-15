using IComp.Service.DTOs.ProcessorSerieDTOs;
using IComp.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace IComp.Areas.manage.Controllers
{
    [Area("manage")]
    public class ProcessorserieController : Controller
    {
        private readonly IProcessorSerieService _procSerieService;

        public ProcessorserieController(IProcessorSerieService procSerieService)
        {
            _procSerieService = procSerieService;
        }
        public IActionResult Index(int page = 1)
        {
            return View(_procSerieService.GetAllProd(page));
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProcessorSeriePostDto postDto)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            await _procSerieService.CreateAsync(postDto);
            return RedirectToAction("Index");
        }
    }
}
