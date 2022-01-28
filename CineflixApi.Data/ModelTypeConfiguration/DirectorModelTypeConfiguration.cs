using CineflixApi.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CineflixApi.Data.ModelTypeConfiguration
{
    public class DirectorModelTypeConfiguration : IEntityTypeConfiguration<Director>
    {
        public void Configure(EntityTypeBuilder<Director> builder)
        {
            builder.HasKey(d => d.Id);
            builder.Property(n => n.Name).HasMaxLength(30).IsRequired();

            builder.HasIndex(d => d.Name).IsUnique();
            // builder.ToTable("Cineastas"); altera o nome das tabelas 
        }
    }
}
