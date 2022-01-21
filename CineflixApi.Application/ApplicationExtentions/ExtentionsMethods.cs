using CineflixApi.Application.Services;
using CineflixApi.Domain.Interfaces.IService;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineflixApi.Application.ApplicationExtentions
{
    public static class ExtentionsMethods
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddTransient<IMovieService, MovieService>();
            services.AddTransient<IDirectorService, DirectorService>();
            services.AddTransient<IGenreService, GenreService>();
            services.AddTransient<IUserService, UserService>();
        }
    }
}
