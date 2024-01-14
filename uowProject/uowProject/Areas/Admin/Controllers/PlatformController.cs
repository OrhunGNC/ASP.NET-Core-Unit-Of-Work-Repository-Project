using Microsoft.AspNetCore.Mvc;
using uowProject.Data.Repository.IRepository;
using uowProject.Models;

namespace uowProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PlatformController : Controller
    {
        private readonly IUnitOfWork _uoWork;
        public PlatformController(IUnitOfWork uoWork)
        {
            _uoWork = uoWork;
        }
        public IActionResult Index()
        {
            IEnumerable<Platform> platformList = _uoWork.Platform.GetAll();
            return View(platformList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Platform platform)
        {
            _uoWork.Platform.Add(platform);
            _uoWork.Save();
            return RedirectToAction("Index");

        }
        public IActionResult Edit(int id)
        {
            if (id == null || id <= 0)
            {
                return NotFound();
            }
            var platform = _uoWork.Platform.GetFirstOrDefault(k => k.PlatformId== id);
            return View(platform);
        }
        [HttpPost]
        public IActionResult Edit(Platform platform)
        {
            _uoWork.Platform.Update(platform);
            _uoWork.Save();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            if (id == null || id <= 0)
            {
                return NotFound();
            }
            var platform = _uoWork.Platform.GetFirstOrDefault(k => k.PlatformId== id);
            _uoWork.Platform.Remove(platform);
            _uoWork.Save();
            return RedirectToAction("Index");
        }
    }
}
