using CineflixApi.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CineflixApi.Data.Context
{
    public class CineflixContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<User> Users { get; set; }
        public CineflixContext (DbContextOptions<CineflixContext> opt) : base(opt)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
