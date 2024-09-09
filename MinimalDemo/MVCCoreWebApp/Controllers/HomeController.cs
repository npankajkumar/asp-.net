using Microsoft.AspNetCore.Mvc;
using MVCCoreWebApp.Models;
using System.Diagnostics;

namespace MVCCoreWebApp.Controllers
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
            return View();
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
        public IActionResult Pankaj()
        {
            return new ContentResult
            {
                ContentType = "text/html",
                Content = "<b>hello panakj</b>"
            };
        }
        public IActionResult Satvik()
        {
            return View();
        }
    }
}
