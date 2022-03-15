using IComp.Service.DTOs.VideoCardDTOs;
using IComp.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace IComp.Areas.manage.Controllers
{
    [Area("manage")]
    public class VideoCardController : Controller
    {
        private readonly IVideoCardService _videoCardService;

        public VideoCardController(IVideoCardService videoCardService)
        {
            _videoCardService = videoCardService;
        }

        public IActionResult Index(int page = 1)
        {
            return View(_videoCardService.GetAllProd(page));
        }

        public IActionResult Create()
        {
            ViewBag.VCSeries = _videoCardService.GetVCSeries();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult>  Create(VideoCardPostDto postDto)
        {
            ViewBag.VCSeries = _videoCardService.GetVCSeries();
            if (!ModelState.IsValid)
            {
                return View();
            }

            var vcGetDto = await _videoCardService.CreateAsync(postDto);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.ProcSeries = _videoCardService.GetVCSeries();

            VideoCardPostDto postDTO = await _videoCardService.GetByIdAsync(id);

            return View(postDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, VideoCardPostDto postDTO)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            await _videoCardService.UpdateAsync(id, postDTO);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _videoCardService.DeleteAsync(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Restore(int id)
        {
            await _videoCardService.RestoreAsync(id);
            return RedirectToAction("Index");
        }
    }
}
