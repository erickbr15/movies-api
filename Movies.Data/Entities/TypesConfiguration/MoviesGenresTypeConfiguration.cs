using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Movies.Data.Entities.TypesConfiguration;

public class MoviesGenresTypeConfiguration : IEntityTypeConfiguration<MoviesGenres>
{
    public void Configure(EntityTypeBuilder<MoviesGenres> builder)
    {
        builder.ToTable("MoviesGenres", DatabaseSchemas.Movies);
        builder.HasKey(mg => new { mg.MovieId, mg.GenreId });

        builder
            .HasOne(mg => mg.Movie)
            .WithMany(m => m.MovieGenres)
            .HasForeignKey(m => m.MovieId);

        builder
            .HasOne(mg => mg.Genre)
            .WithMany(g => g.MovieGenres)
            .HasForeignKey(g => g.GenreId);
    }
}
