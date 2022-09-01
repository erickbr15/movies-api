namespace Movies.Data.Entities
{
    /// <summary>
    ///     The movies genres entity
    /// </summary>
    public class MovieGenre
    {
        /// <summary>
        ///     The unique movie identifier
        /// </summary>
        public string MovieId { get; set; }
        
        /// <summary>
        ///     The unique genre identifier
        /// </summary>
        public short GenreId { get; set; }
        
        /// <summary>
        ///     The movie
        /// </summary>
        public Movie Movie { get; set; }
        
        /// <summary>
        ///     The Genre
        /// </summary>
        public Genre Genre { get; set; }
    }
}
