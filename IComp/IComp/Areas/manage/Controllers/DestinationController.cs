using IComp.Core.Entities;
using IComp.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace IComp.Areas.manage.Controllers
{
    [Area("manage")]
    public class DestinationController : Controller
    {
        private readonly IDestinationService _destinationService;

        public DestinationController(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        public IActionResult Index(int page = 1)
        {
            return View(_destinationService.GetAllProd(page));
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Destination destination)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            await _destinationService.CreateAsync(destination);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int id)
        {
            await _destinationService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
        public IActionResult Edit()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Destination destination)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            await _destinationService.UpdateAsync(id,destination);
            return RedirectToAction("Index");
        }
    }
}
