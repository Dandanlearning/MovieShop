using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
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
        public async Task<IActionResult> Details(int id)
        {
            // Movie service with details
            // pass movie details to view

            // this is going to get data from remote database, and runtime is unknow
            // time can be effected by network speed time, sql server memory(whether it is busy)
            var movieDetails = await _movieService.GetMovieDetails(id);

            return View(movieDetails);
        }
        [HttpGet]
        public async Task<IActionResult> Genres(int id, int pageSize = 30, int pageNumber = 1)
        {
            var pagedMovies = await _movieService.GetMoviesByGenrePagination(id, pageSize, pageNumber);
            return View("PagedMovies",pagedMovies);
        }
    }
    }
