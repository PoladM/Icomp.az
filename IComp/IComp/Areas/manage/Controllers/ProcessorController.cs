using IComp.Core;
using IComp.Core.Entities;
using IComp.Service.DTOs.ProcessorDTOs;
using IComp.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace IComp.Areas.manage.Controllers
{
    [Area("manage")]
    public class ProcessorController : Controller
    {
        private readonly IProcessorService _processorService;
        private readonly IUnitOfWork _unitOfWork;

        public ProcessorController(IProcessorService processorService, IUnitOfWork unitOfWork)
        {
            _processorService = processorService;
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            ViewBag.ProcSeries = _unitOfWork.ProcessorSerieRepository.GetAll();

            
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProcessorPostDTO postDTO)
        {
            var processorPostDto = await _processorService.CreateAsync(postDTO);


            return Ok(processorPostDto);
        }
    }
}
