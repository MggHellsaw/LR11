using LR11.Filters;
using LR11.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LR11.Controllers
{
    [ServiceFilter(typeof(UniqueUsersCountFilter))]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [ServiceFilter(typeof(MethodLoggingFilter))]
        public IActionResult Index()
        {
            return View();
        }
        [ServiceFilter(typeof(MethodLoggingFilter))]
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
