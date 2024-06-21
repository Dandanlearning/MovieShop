using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Servies
{
    public class MovieServiceMock : IMovieService
    {
        public List<MovieCardModel> GetTop30GrossingMovies()
        {
            var movies = new List<MovieCardModel>() {
                new MovieCardModel {Id = 1, PosterUrl = "https://flxt.tmsimg.com/assets/p7825626_p_v8_af.jpg", Title = "Inception" },
               
            };
            return movies;
        }
    }
}
