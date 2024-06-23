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
        List<MovieCardModel> GetTop30GrossingMovies();
        MovieDetailsModel GetMovieDetails(int id);
    }
}
