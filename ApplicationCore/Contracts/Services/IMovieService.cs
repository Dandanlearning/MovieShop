using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Services
{
    public interface IMovieService
    {
        //have all the business logic methods relating to movies
        //go to see the page, and think about what kind of methods you  need
        Task<List<MovieCardModel>> GetTop30GrossingMovies();
        Task<MovieDetailsModel> GetMovieDetails(int id);
        Task<PagedResultSet<MovieCardModel>> GetMoviesByGenrePagination(int genreId, int pageSize= 30, int pageNumber = 1);
    }
}
