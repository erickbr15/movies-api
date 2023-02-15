namespace Movies.Data.Entities
{
    /// <summary>
    ///     The movies genres entity
    /// </summary>
    public class MoviesGenres
    {
        /// <summary>
        ///     The unique movie identifier
        /// </summary>
        public Guid MovieId { get; set; }
        
        /// <summary>
        ///     The unique genre identifier
        /// </summary>
        public int GenreId { get; set; }

        /// <summary>
        ///     The movie
        /// </summary>
        public Movie Movie { get; set; } = default!;

        /// <summary>
        ///     The Genre
        /// </summary>
        public Genre Genre { get; set; } = default!;
    }
}
