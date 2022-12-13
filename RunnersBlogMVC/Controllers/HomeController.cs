using Microsoft.AspNetCore.Mvc;
using RunnersBlogMVC.Models;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace RunnersBlogMVC.Controllers
{
    [ExcludeFromCodeCoverage]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [ExcludeFromCodeCoverage]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}