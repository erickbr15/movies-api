using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Movies.Data.Entities.TypesConfiguration;

public class MovieTypeConfiguration : IEntityTypeConfiguration<Movie>
{
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        builder.ToTable("Movies", DatabaseSchemas.Movies);
        builder.HasKey(x => x.Id);

        builder.Property(t => t.Id)
            .HasColumnName("Id")
            .IsRequired(true);

        builder.Property(t => t.Name)
            .HasColumnName("Name")
            .HasMaxLength(500)
            .IsRequired(true);

        builder.Property(t => t.ReleaseYear)
            .HasColumnName("ReleaseYear");

        builder.Property(t => t.PosterLink)
            .HasColumnName("PosterLink");
    }
}
