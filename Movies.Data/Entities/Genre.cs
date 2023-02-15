namespace Movies.Data.Entities
{
    /// <summary>
    ///     The genre entity
    /// </summary>
    public class Genre
    {
        /// <summary>
        ///     The unique genre identifier
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        ///     The genre name
        /// </summary>
        public string Name { get; set; } = default!;
        
        /// <summary>
        ///     The movies associated to the genre
        /// </summary>
        public ICollection<MoviesGenres> MovieGenres { get; set; } = new List<MoviesGenres>();
    }
}
