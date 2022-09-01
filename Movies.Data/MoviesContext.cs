using Microsoft.EntityFrameworkCore;
using Movies.Data.Entities;

namespace Movies.Data
{
    /// <summary>
    /// 
    /// </summary>
    public class MoviesContext : DbContext
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        public MoviesContext(DbContextOptions<MoviesContext> options)
            :base(options)
        {
        }
        
        /// <summary>
        /// 
        /// </summary>
        public DbSet<Movie> Movies { get; set; }         
        
        /// <summary>
        /// 
        /// </summary>
        public DbSet<Genre> Genres { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public DbSet<MovieGenre> MovieGenres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().ToTable("Movies");
            modelBuilder.Entity<Movie>().HasKey(x => x.Id);
            modelBuilder.Entity<Movie>().Property(t => t.Id).HasColumnName("Id").HasMaxLength(150);
            modelBuilder.Entity<Movie>().Property(t => t.Name).HasColumnName("Name").HasMaxLength(500);
            modelBuilder.Entity<Movie>().Property(t => t.ReleaseDate).HasColumnName("ReleaseDate");

            modelBuilder.Entity<Genre>().ToTable("Genres");
            modelBuilder.Entity<Genre>().HasKey(x => x.Id);
            modelBuilder.Entity<Genre>().Property(t => t.Id)
                .UseIdentityColumn()
                .HasColumnName("Id");                
            modelBuilder.Entity<Genre>().Property(t => t.Name).HasColumnName("Name").HasMaxLength(150);

            modelBuilder.Entity<MovieGenre>().ToTable("MoviesGenres");
            modelBuilder.Entity<MovieGenre>().HasKey(mg => new { mg.MovieId, mg.GenreId });

            modelBuilder.Entity<MovieGenre>()
                .HasOne(mg => mg.Movie)
                .WithMany(m => m.MovieGenres)
                .HasForeignKey(m => m.MovieId);

            modelBuilder.Entity<MovieGenre>()
                .HasOne(mg => mg.Genre)
                .WithMany(g => g.MovieGenres)
                .HasForeignKey(g => g.GenreId);
        }
    }
}
