using ApplicationCore.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace MovieShopMVC.Controllers
{
    public class MoviesController : Controller
    {
        // why do we make it readonly?
        // it means that you can only define it in the constructor, not in the functions
        // make it read only will prevent the function to change it.
        // (like _movieService = New MovieService())
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieSerice)
        {
            _movieService = movieSerice;
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            // Movie service with details
            // pass movie details to view

            return View();
        }
    }
}
