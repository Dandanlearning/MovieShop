using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Servies
{
    public class MovieService : IMovieService
    {
        public List<MovieCardModel> GetTop30GrossingMovies()
        {
            // call MovieRepository(call the database with Dapper or EF Core)
            var movies = new List<MovieCardModel>() {
                new MovieCardModel {Id = 1, PosterUrl = "https://flxt.tmsimg.com/assets/p7825626_p_v8_af.jpg", Title = "Inception" },
                new MovieCardModel {Id = 2, PosterUrl = "https://i5.walmartimages.com/seo/Interstellar-DVD-Paramount-Sci-Fi-Fantasy_015d3dd5-5c3a-45fd-b669-310602585cf1.a6b8a3743a12d78994c3b53b08f17bb9.jpeg?odnHeight=640&odnWidth=640&odnBg=FFFFFF", Title = "Interstallar" },

            };
            return movies;
        }
    }
}
