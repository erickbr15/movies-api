namespace Movies.Data.Entities
{
    /// <summary>
    ///     The movie entity
    /// </summary>
    public class Movie
    {
        /// <summary>
        ///     The unique movie identifier
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        ///     The movie name
        /// </summary>
        public string Name { get; set; } = default!;
        
        /// <summary>
        ///     The movie release date
        /// </summary>
        public short? ReleaseYear { get; set; }

        /// <summary>
        ///     The image unique identifier
        /// </summary>
        public string? PosterLink { get; set; }
        
        /// <summary>
        ///     The genres associated with the movie
        /// </summary>
        public ICollection<MoviesGenres> MovieGenres { get; set; } = new List<MoviesGenres>();
    }
}
