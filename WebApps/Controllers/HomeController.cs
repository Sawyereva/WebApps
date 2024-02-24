using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();
   
            
            return View("FormPage");
        }

        [HttpPost]
        public IActionResult FormPage(Movie submission)
        {
            _context.Movies.Add(submission);
            _context.SaveChanges();

            return View("Confirmation", submission);
        }
        [HttpGet]
        public IActionResult Movies()
        {
            var movies = _context.Movies
                .Include(m => m.Category)
                .OrderBy(x => x.Year)
                .ToList();

            return View(movies);
        }
        [HttpGet]
        public IActionResult Edit(int id) 
        { 
            var recordToEdit = _context.Movies
                .Single(x => x.MovieId == id);

            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View("FormPage", recordToEdit);
        }
        [HttpPost]
        public IActionResult Edit(Movie UpdatedMovie)
        {
            _context.Update(UpdatedMovie);
            _context.SaveChanges();

            return RedirectToAction("Movies");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var MovieToDelete = _context.Movies
                .Single(x => x.MovieId == id);

            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View(MovieToDelete);
        }
        [HttpPost]
        public IActionResult Delete(Movie MovieToDelete)
        {
            _context.Movies.Remove(MovieToDelete);
            _context.SaveChanges();

            return RedirectToAction("Movies");
        }
    }
}
