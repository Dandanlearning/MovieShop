using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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
    }
}
