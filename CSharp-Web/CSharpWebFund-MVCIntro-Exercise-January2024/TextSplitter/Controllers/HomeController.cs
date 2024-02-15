using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TextSplitter.Models;
using TextSplitter.ViewModels;

namespace TextSplitter.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(TextSplitViewModel textViewModel)
        {
            return View(textViewModel);
        }

        [HttpPost]
        public IActionResult Split(TextSplitViewModel textViewModel) 
        {
            if (String.IsNullOrEmpty(textViewModel.TextToSplit))
            {
                return RedirectToAction("Index", new TextSplitViewModel() { SplitText = string.Empty, TextToSplit = string.Empty, });
            }

            string[] words = textViewModel.TextToSplit
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string splitText = string.Join(Environment.NewLine, words);
            textViewModel.SplitText = splitText;
            
            return RedirectToAction("Index", textViewModel);

        }
    }
}