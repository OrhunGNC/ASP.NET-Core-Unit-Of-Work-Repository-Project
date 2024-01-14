using Microsoft.AspNetCore.Mvc;
using uowProject.Data.Repository;
using uowProject.Data.Repository.IRepository;
using uowProject.Models;

namespace uowProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PublisherController : Controller
    {
        private readonly IUnitOfWork _uoWork;
        public PublisherController(IUnitOfWork uoWork)
        {
            _uoWork = uoWork;
        }
        public IActionResult Index()
        {
            IEnumerable<Publisher> publisherList = _uoWork.Publisher.GetAll();
            return View(publisherList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Publisher publisher)
        {
            _uoWork.Publisher.Add(publisher);
            _uoWork.Save();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int? id)
        {
            if(id==null || id <= 0)
            {
                return NotFound();
            }
            var publisher = _uoWork.Publisher.GetFirstOrDefault(k => k.PublisherId == id);
            return View(publisher);
        }
        [HttpPost]
        public IActionResult Edit(Publisher publisher)
        {
            _uoWork.Publisher.Update(publisher);
            _uoWork.Save();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id <= 0)
            {
                return NotFound();
            }
            var publisher = _uoWork.Publisher.GetFirstOrDefault(k => k.PublisherId == id);
            _uoWork.Publisher.Remove(publisher);
            _uoWork.Save();
            return RedirectToAction("Index");
        }

    }
}
