using Microsoft.AspNetCore.Mvc;
using uowProject.Data.Repository.IRepository;
using uowProject.Models;

namespace uowProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DeveloperController : Controller
    {

        private readonly IUnitOfWork _uoWork;
        public DeveloperController(IUnitOfWork uoWork)
        {
            _uoWork = uoWork;
        }
        public IActionResult Index()
        {
            IEnumerable<Developer> developerList = _uoWork.Developer.GetAll();
            return View(developerList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Developer developer)
        {
            _uoWork.Developer.Add(developer);
            _uoWork.Save();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id <= 0)
            {
                return NotFound();
            }
            var developer = _uoWork.Developer.GetFirstOrDefault(k => k.DeveloperId == id);
            return View(developer);
        }
        [HttpPost]
        public IActionResult Edit(Developer developer)
        {
            _uoWork.Developer.Update(developer);
            _uoWork.Save();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id <= 0)
            {
                return NotFound();
            }
            var developer = _uoWork.Developer.GetFirstOrDefault(k => k.DeveloperId == id);
            _uoWork.Developer.Remove(developer);
            _uoWork.Save();
            return RedirectToAction("Index");
        }
    }
}
