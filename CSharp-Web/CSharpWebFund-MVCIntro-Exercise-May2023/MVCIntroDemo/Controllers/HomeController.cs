using Microsoft.AspNetCore.Mvc;
using MVCIntroDemo.Models;
using System.Diagnostics;

namespace MVCIntroDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.Message = "Hello world from ViewBag!";
            ViewData["Msg"] = "Hello world from ViewData";
            return View();
        }
        public IActionResult About()
        {
            ViewBag.Message = "This is an ASP.NET Core MVC app.";
            return View();
        }
        public IActionResult Numbers()
        {

            return View();
        }

        [HttpGet]
        public IActionResult NumbersToN()
        {
            ViewData["Count"] = -1;
            return View();
        }

        [HttpPost]
        public IActionResult NumbersToN(int count = -1)
        {
            ViewData["Count"] = count;
            return this.View();
        }
        public IActionResult Privacy()
        {
            return View();
        }       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}