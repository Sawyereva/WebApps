using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApps.Models;

namespace WebApps.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetToKnow()
        {
            return View();
        }

        [HttpGet]
        public IActionResult FormPage()
        {
            return View("FormPage");
        }

        [HttpPost]
        public IActionResult FormPage(Movie submission)
        {
            return View("Confirmation", submission);
        }
    }
}
