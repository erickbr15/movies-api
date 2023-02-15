using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Movies.Data.Entities.TypesConfiguration;

public class GenreTypeConfiguration : IEntityTypeConfiguration<Genre>
{
    public void Configure(EntityTypeBuilder<Genre> builder)
    {
        builder.ToTable("Genres", DatabaseSchemas.Movies);
        builder.HasKey(x => x.Id);

        builder.Property(t => t.Id)
            .UseIdentityColumn()
            .HasColumnName("Id");

        builder.Property(t => t.Name).HasColumnName("Name").HasMaxLength(150);
    }
}
