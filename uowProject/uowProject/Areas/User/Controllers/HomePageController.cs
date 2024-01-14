using Microsoft.AspNetCore.Mvc;
using uowProject.Data.Repository.IRepository;

namespace uowProject.Areas.User.Controllers
{
    [Area("User")]
    public class HomePageController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;
        public HomePageController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
        }
        
        public IActionResult Index()
        {
            var gameList = _unitOfWork.Game.GetAll();
            return View(gameList);
        }
    }
}
