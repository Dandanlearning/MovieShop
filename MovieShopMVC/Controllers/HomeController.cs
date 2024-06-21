using ApplicationCore.Contracts.Services;
using Infrastructure.Servies;
using Microsoft.AspNetCore.Mvc;
using MovieShopMVC.Models;
using System.Diagnostics;

namespace MovieShopMVC.Controllers
{
    public class HomeController : Controller
    {

        //this will avoid newing in each action method
        // 1. private MovieService _movieService;
        // but in this case MovieService is still deeply coupled with this controller
        // what if we want to use the same service in other controller?
        // so we use abstraction, by using interface
        private readonly IMovieService _movieService;
        // why do we make it readonly?
        // it means that you can only define it in the constructor, not in the functions
        // make it read only will prevent the function to change it.
        // (like _movieService = New MovieService())


        // this is constructor injection
        public HomeController(IMovieService movieService) { 
            // but we still need to create an new instance of this service.
            // Once the controllers become complicated, there will be bugs easily.
            // 1. _movieService = new MovieService();
            // so we use parameter, go to see Index function and GetTop30
            _movieService = movieService;
        }
        
        
        [HttpGet]
        public IActionResult Index()
        {
            // our controllers are very thin/lean
            // most of your logic should come from other dependencies, services
            // interfaces => class method => model => view
            // void method(int x, IMovieService movieservice)
            
            // this is newing; we try to avoid newing in very action method
            //var movieService = new MovieService();

            // my model data
            // this method will implement the method in class MovieService
            // although _movieService is an interface instance
            var movies = _movieService.GetTop30GrossingMovies();
            return View(movies);



            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult TopMovies()
        {
            return View("Privacy");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
