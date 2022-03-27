using IComp.Core.Entities;
using IComp.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace IComp.Areas.manage.Controllers
{
    [Area("manage")]
    public class ColorController : Controller
    {
        private readonly IColorService _colorService;

        public ColorController(IColorService colorService)
        {
            _colorService = colorService;
        }
        public IActionResult Index(int page = 1)
        {
            return View(_colorService.GetAllProd(page));
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Color color)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            await _colorService.CreateAsync(color);
            return RedirectToAction("Index");
        }

        public IActionResult Edit()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Color color)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            await _colorService.UpdateAsync(id, color);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int id)
        {
            await _colorService.DeleteAsync(id);
            return RedirectToAction("Index");
        }

    }
}
