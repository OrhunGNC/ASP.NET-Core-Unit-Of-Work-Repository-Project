using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Hosting;
using uowProject.Data.Repository;
using uowProject.Data.Repository.IRepository;
using uowProject.Models.ViewModels;

namespace uowProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GameController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;
        public GameController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment= hostEnvironment;
        }
        public IActionResult Index()
        {
            var gameList = _unitOfWork.Game.GetAll();
            return View(gameList);
        }
        public IActionResult Crup(int? id = 0)
        {
            GameVM gameVM = new()
            {
                Game = new(),
                DeveloperList = _unitOfWork.Developer.GetAll().Select(k => new SelectListItem
                {
                    Text = k.DeveloperName,
                    Value = k.DeveloperId.ToString()
                }),
                PublisherList = _unitOfWork.Publisher.GetAll().Select(k => new SelectListItem
                {
                    Text = k.PublisherName,
                    Value = k.PublisherId.ToString()
                })
            };

            if (id == null || id <= 0)
            {
                return View(gameVM);
            }
            gameVM.Game= _unitOfWork.Game.GetFirstOrDefault(x => x.GameId == id);
            if (gameVM.Game== null)
            {
                return View(gameVM);
            }

            return View(gameVM);
        }
        [HttpPost]
        public IActionResult Crup(GameVM gameVM, IFormFile file)
        {
            string wwwRootPath = _hostEnvironment.WebRootPath;
            if (file != null)
            {
                string fileName = Guid.NewGuid().ToString();
                var uploadRoot = Path.Combine(wwwRootPath, @"img\games");
                var extension = Path.GetExtension(file.FileName);
                if (gameVM.Game.GameImage != null)
                {
                    var oldpicPath = Path.Combine(wwwRootPath, gameVM.Game.GameImage);

                    if (System.IO.File.Exists(oldpicPath))
                    {
                        System.IO.File.Delete(oldpicPath);
                    }

                }

                using (var fileStream = new FileStream(Path.Combine(uploadRoot, fileName + extension), FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                gameVM.Game.GameImage= @"\img\games\" + fileName + extension;

            }
            if (gameVM.Game.GameId <= 0)
            {
                _unitOfWork.Game.Add(gameVM.Game);
            }
            else
            {
                _unitOfWork.Game.Update(gameVM.Game);
            }
            _unitOfWork.Save();
            return RedirectToAction("Index");

        }
        public IActionResult Delete(int? id)
        {

            if (id == null || id <= 0)
            {

                return NotFound();
            }
            var product = _unitOfWork.Game.GetFirstOrDefault(x => x.GameId == id);
            _unitOfWork.Game.Remove(product);
            _unitOfWork.Save();
            return RedirectToAction("Index");


        }
    }
}
