using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ApplicationCore.Models;

namespace Infrastructure.Repositories
{
    public class MovieRepository: EfRepository<Movie>, IMovieRepository
    {
        public MovieRepository(MovieShopDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Movie>> GetTop30RevenueMovies()
        {
            //get top 30 movies by revenue
            var movies = await _dbContext.Movies.OrderByDescending(x => x.Revenue).Take(30).ToArrayAsync();
            return movies;
        }
        public override Task<Movie> GetById(int id)
        {
            // we need to use include method: is to include navigation property
            var movieDetails = _dbContext.Movies.Include(m => m.Genres).ThenInclude(m => m.Genre)
                .Include(m => m.MovieCasts).ThenInclude(m => m.Cast)
                .Include(m => m.Trailers)
                .FirstOrDefaultAsync(m => m.Id == id);
            return movieDetails;    
        }

        public async Task<PagedResultSet<Movie>> GetMoviesByGenres(int genreId, int pageSize=30, int pageNumber=1)
        {
            // 1. get total movies count from the genre you want
            // select count(*) from genre where genreid = 1
            // in LINQ
            // my code: var totalMoviesCount = await _dbContext.Genres.CountAsync(g => g.Id == genreId);
            var totalMoviesCountByGenre = await _dbContext.MovieGenres.Where(m => m.GenreId == genreId).CountAsync();

            // 2. get the actual movies from movieGenres and movie table
            if (totalMoviesCountByGenre == 0)
            {
                throw new Exception("No Movie Found for that genre");
            }
            // after Where, it is still moviegenre type. 
            var movies = await _dbContext.MovieGenres.Where(m => m.GenreId == genreId).Include(m => m.Movie)
                .OrderBy(m => m.MovieId)
                .Select(m => new Movie
                {
                    Id = m.MovieId,
                    PosterUrl = m.Movie.PosterUrl,
                    Title = m.Movie.Title
                })
                .Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

            // ^^for above statement, you must use order by function for skip and take.
            // because in sql, order by and offset statement should go together.

            var pagedMovies = new PagedResultSet<Movie> (movies, pageNumber, pageSize, totalMoviesCountByGenre);
            return pagedMovies;
        }

    }
}
