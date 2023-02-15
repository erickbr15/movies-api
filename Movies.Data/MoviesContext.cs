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
        public DbSet<MoviesGenres> MovieGenres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MoviesContext).Assembly);                        
        }
    }
}
