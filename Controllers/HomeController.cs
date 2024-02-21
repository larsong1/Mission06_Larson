using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission06_Larson.Models;
using System.Diagnostics;

namespace Mission06_Larson.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private MovieContext _movieContext;

        public HomeController(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult MovieForm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult MovieForm(Movie response)
        {
            _movieContext.Movies.Add(response);
            _movieContext.SaveChanges();

            return View("SubmitMessage", response);
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

        public IActionResult Movielist()
        {
            var movies = _movieContext.Movies
                .Where(x => x.Category != "")
                .ToList();

            return View();
        }
    }
}
