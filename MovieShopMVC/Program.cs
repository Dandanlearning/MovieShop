using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Infrastructure.Servies;
using Microsoft.EntityFrameworkCore;

namespace MovieShopMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // this mean wheneven you try to implement imovieservice, it will implement with MovieService class 
            //this is telling the container to inject movieservice class
            // where imovieservice interface is
            builder.Services.AddScoped<IMovieService, MovieService>();
            builder.Services.AddScoped<IMovieRepository, MovieRepository>();
            ////if controllername == home then for IMovieService use MovieService
            ////else controller Name == Movie then use MovieServiceMock


            ////inject the connection string to our DbContext by reading from appsettings.json file
            builder.Services.AddDbContext<MovieShopDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("MovieShopDbConnection"));
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
