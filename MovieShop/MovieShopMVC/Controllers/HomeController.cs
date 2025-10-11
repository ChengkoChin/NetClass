using System.Diagnostics;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using MovieShopMVC.Models;

namespace MovieShopMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMovieService _movieService;
        private readonly int x = 1;

        public HomeController(ILogger<HomeController> logger, IMovieService movieService)
        {
            _logger = logger;
            _movieService = movieService;
            x = 2;
        }

        [HttpGet]
        public IActionResult Index()
        {
            //_movieService = new MovieService();  //it won't work bc it's 'readonly'

            //method(int x, IMoviewService movieService)
            //var movieService = new MovieService();
            //method(3, movieService)

            //var movieService1 = new MovieService();
            //method(3, movieService1)
            //ViewBag.Title = "MoviewShop Home Page Title";
            ////ViewData["Title"] = "MovieShop Home Page Title";
            //var movies = new List<MovieCard>
            //{
            //    new MovieCard { Title = "Forrest Gump", Id = 1, PosterUrl = "https://image.tmdb.org/t/p/w342/saHP97rTPS5eLmrLQEcANmKrsFl.jpg" },
            //    new MovieCard { Title = "The Dark Knight", Id = 2, PosterUrl = "https://image.tmdb.org/t/p/w342/qJ2tW6WMUDux911r6m7haRef0WH.jpg" },
            //    new MovieCard { Title = "Interstellar", Id = 3, PosterUrl = "https://image.tmdb.org/t/p/w342/rAiYTfKGqDCRIIqo664sY9XZIvQ.jpg" },
            //    new MovieCard { Title = "The Matrix", Id = 4, PosterUrl = "https://image.tmdb.org/t/p/w342/f89U3ADr1oiB1s9GkdPOEpXUk5H.jpg" },
            //    new MovieCard { Title = "Fight Club", Id = 5, PosterUrl = "https://image.tmdb.org/t/p/w342/bptfVGEQuv6vDTIMVCHjJ9Dz8PX.jpg" }
            //};


            //var movieService = new MovieService();
            //var movies = movieService.Get30HighestGrossingMovies();
            var movies = _movieService.Get30HighestGrossingMovies();
            return View(movies);
        }

        [HttpGet]
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
