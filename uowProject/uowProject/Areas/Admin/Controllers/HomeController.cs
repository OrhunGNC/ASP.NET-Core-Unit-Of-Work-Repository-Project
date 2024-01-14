using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using uowProject.Models;

namespace uowProject.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }

}

