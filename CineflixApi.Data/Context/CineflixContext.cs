using CineflixApi.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineflixApi.Data.Context
{
    public class CineflixContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public CineflixContext (DbContextOptions<CineflixContext> opt) : base(opt)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Director>()
                .HasKey(d => d.Id);

            builder.Entity<Movie>()
                .HasOne(d => d.Director)
                .WithMany(d => d.Movies)
                .HasForeignKey(d => d.DirectorId);

            builder.Entity<Genre>()
               .HasKey(g => g.Id);

            builder.Entity<Movie>()
                .HasKey(m => m.Id);

            builder.Entity<Movie>()
                .HasOne(g => g.Genre)
                .WithMany(g => g.Movies)
                .HasForeignKey(g => g.GenreId);
        }
    }
}
