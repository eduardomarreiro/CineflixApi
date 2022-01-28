using CineflixApi.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CineflixApi.Data.ModelTypeConfiguration
{
    public class MovieModelTypeConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.HasOne(d => d.Director).WithMany(d => d.Movies).HasForeignKey(d => d.DirectorId);

            builder.HasKey(m => m.Id);

            builder.HasOne(g => g.Genre).WithMany(g => g.Movies).HasForeignKey(g => g.GenreId);
        }
    }
}
