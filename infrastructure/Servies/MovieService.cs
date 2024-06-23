using ApplicationCore.Contracts.Repositories;
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
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public MovieDetailsModel GetMovieDetails(int id)
        {
            throw new NotImplementedException();
        }

        public List<MovieCardModel> GetTop30GrossingMovies()
        {
            // call MovieRepository(call the database with Dapper or EF Core)
            var movies = _movieRepository.GetTop30RevenueMovies();
            var moviecards = new List<MovieCardModel>();

            // mapping entities data into  models data
            foreach (var movie in movies) {
                moviecards.Add(new MovieCardModel
                {
                    Id = movie.Id, PosterUrl = movie.PosterUrl, Title = movie.Title
                });
            }
            return moviecards;
        }
    }
}
