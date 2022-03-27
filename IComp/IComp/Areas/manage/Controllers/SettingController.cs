using IComp.Core.Entities;
using IComp.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace IComp.Areas.manage.Controllers
{
    [Area("manage")]
    public class SettingController : Controller
    {
        private readonly ISettingService _settingService;

        public SettingController(ISettingService settingService)
        {
            _settingService = settingService;
        }
        public IActionResult Index(int page = 1)
        {
            return View(_settingService.GetAllProd(page));
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Setting setting)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (setting.ImageFile != null)
            {
                if (setting.ImageFile.ContentType != "image/jpeg" && setting.ImageFile.ContentType != "image/png")
                {
                    ModelState.AddModelError("ImageFile", "file type must be image/jpeg or image/png");
                    return View();
                }

                if (setting.ImageFile.Length > 2097152)
                {
                    ModelState.AddModelError("ImageFile", "file size must be less than 2mb");
                    return View();
                }
            }
            await _settingService.CreateAsync(setting);
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Edit(int id)
        {
            var setting = await _settingService.GetByIdAsync(id);
            return View(setting);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Setting setting)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (setting.ImageFile != null)
            {
                if (setting.ImageFile.ContentType != "image/jpeg" && setting.ImageFile.ContentType != "image/png")
                {
                    ModelState.AddModelError("ImageFile", "file type must be image/jpeg or image/png");
                    return View();
                }

                if (setting.ImageFile.Length > 2097152)
                {
                    ModelState.AddModelError("ImageFile", "file size must be less than 2mb");
                    return View();
                }
            }

            await _settingService.UpdateAsync(id, setting);
            return RedirectToAction("Index");
        }
    }
}
