using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class MovieShopDbContext: DbContext
    {
        // what does base option mean here?
        public MovieShopDbContext(DbContextOptions<MovieShopDbContext> options) : base(options)
        {
            
        }

        public DbSet<Genre> Genres { get; set; } 
        public DbSet<Movie> Movies { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>(ConfigureMovie);
        }
        private void ConfigureMovie(EntityTypeBuilder<Movie> builder)
        {
            // specify the rules for Movie Entity
            // 1. table name to be movie
            builder.ToTable("Movie");
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Title).HasMaxLength(256);
            builder.Property(m => m.BackdropUrl).HasMaxLength(2084);
            builder.Property(m => m.Budget).HasColumnType("decimal(18, 4)").HasDefaultValue(9.9m);
            //what is hasdefaultValueSql?
            // set it as date type
            builder.Property(m => m.CreatedDate).HasDefaultValueSql("getdate()");
            builder.Property(m => m.Overview).HasMaxLength(4096);
            builder.Property(m => m.Tagline).HasMaxLength(512);
            builder.Property(m => m.ImdbUrl).HasMaxLength(2084);
            builder.Property(m => m.OriginalLanguage).HasMaxLength(64);
            builder.Property(m => m.PosterUrl).HasMaxLength(2084);
            // set a money type value 9.9 as the defualt value for this column
            builder.Property(m => m.Price).HasColumnType("decimal(5, 2)").HasDefaultValue(9.9m);
            builder.Property(m => m.ReleaseDate).HasDefaultValueSql("getdate()");
            builder.Property(m => m.Revenue).HasColumnType("decimal(18, 4)").HasDefaultValue(9.9m);
            builder.Property(m => m.TmdbUrl).HasMaxLength(2084);
            builder.Property(m => m.UpdatedDate).HasDefaultValueSql("getdate()");
            
            // Have rating property in the movie entity but it will not be shown database
            // because it is only for the bussiness logic
            // is it a normalization of database?
            builder.Ignore(m => m.Rating);



        }
    }
}
