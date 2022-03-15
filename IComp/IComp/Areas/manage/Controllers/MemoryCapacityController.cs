using IComp.Service.DTOs.MemoryCapacityDTOs;
using IComp.Service.Implementations;
using IComp.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace IComp.Areas.manage.Controllers
{
    [Area("manage")]
    public class MemoryCapacityController : Controller
    {
        private readonly IMemoryCapacityService _memoryCapacityService;
        public MemoryCapacityController(IMemoryCapacityService memoryCapacityService)
        {
            _memoryCapacityService = memoryCapacityService;
        }
        public IActionResult Index(int page = 1)
        {
            return View(_memoryCapacityService.GetAllProd(page));
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(MCapacityPostDto postDto)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            await _memoryCapacityService.CreateAsync(postDto);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int id)
        {
            await _memoryCapacityService.DeleteAsync(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            MCapacityPostDto postDto = await _memoryCapacityService.GetByIdAsync(id);
            return View(postDto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, MCapacityPostDto postDto)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            await _memoryCapacityService.UpdateAsync(id, postDto);
            return RedirectToAction("Index");
        }
    }
}
