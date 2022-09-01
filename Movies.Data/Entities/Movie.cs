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
        public string Id { get; set; }
        
        /// <summary>
        ///     The movie name
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        ///     The movie release date
        /// </summary>
        public DateTime ReleaseDate { get; set; }
        
        /// <summary>
        ///     The genres associated with the movie
        /// </summary>
        public ICollection<MovieGenre> MovieGenres { get; set; } = new List<MovieGenre>();
    }
}
