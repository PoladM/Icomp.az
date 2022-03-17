using IComp.Service.DTOs.CategoryDTOs;
using IComp.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace IComp.Areas.manage.Controllers
{
    [Area("manage")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public IActionResult Index(int page = 1)
        {
            return View(_categoryService.GetAllProd(page));
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CategoryPostDto postDto)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var processorPostDto = await _categoryService.CreateAsync(postDto);

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Edit(int id)
        {
            CategoryPostDto postDTO = await _categoryService.GetByIdAsync(id);
            return View(postDTO);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, CategoryPostDto postDTO)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            await _categoryService.UpdateAsync(id, postDTO);

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int id)
        {
            await _categoryService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Restore(int id)
        {
            await _categoryService.RestoreAsync(id);
            return RedirectToAction("Index");
        }
    }
}
