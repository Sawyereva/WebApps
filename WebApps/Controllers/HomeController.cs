using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApps.Models;

namespace WebApps.Controllers
{
    public class HomeController : Controller
    {
        private MoviesContext _context;
        public HomeController(MoviesContext dataGuy) 
        {
            _context = dataGuy;
        }
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
            _context.Movies.Add(submission);
            _context.SaveChanges();

            return View("Confirmation", submission);
        }
    }
}
