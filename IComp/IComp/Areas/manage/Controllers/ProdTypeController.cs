using IComp.Core.Entities;
using IComp.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace IComp.Areas.manage.Controllers
{
    [Area("manage")]
    public class ProdTypeController : Controller
    {
        private readonly IProdTypeService _prodTypeService;

        public ProdTypeController(IProdTypeService prodTypeService)
        {
            _prodTypeService = prodTypeService;
        }
        public IActionResult Index(int page = 1)
        {
            return View(_prodTypeService.GetAllProd(page));
        }
        public IActionResult Create() { return View(); }
        [HttpPost]
        public async Task<IActionResult> Create(ProdType prodType)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            await _prodTypeService.CreateAsync(prodType);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int id) { await _prodTypeService.DeleteAsync(id); return RedirectToAction("Index"); }

        public IActionResult Edit()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, ProdType prodType)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            await _prodTypeService.UpdateAsync(id, prodType);
            return RedirectToAction("Index");
        }
    }
}
