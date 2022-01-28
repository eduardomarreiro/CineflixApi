using CineflixApi.Data.Context;
using CineflixApi.Data.Repositories;
using CineflixApi.Domain.Interfaces.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CineflixApi.Data.DataExtentions
{
    public static class Extentions
    {
        public static void AddData(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddTransient<IMovieRepository, MovieRepository>();
            services.AddTransient<IDirectorRepository, DirectorRepository>();
            services.AddTransient<IGenreRepository, GenreRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            
            services.AddDbContext<CineflixContext>(options => options.UseSqlServer(Configuration.GetConnectionString("CineflixConnection")));
            services.AddAutoMapper(Assembly.GetAssembly(typeof(CineflixContext)));

        }
    }
}
