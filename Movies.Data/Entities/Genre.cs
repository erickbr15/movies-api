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
        public short Id { get; set; }
        
        /// <summary>
        ///     The genre name
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        ///     The movies associated to the genre
        /// </summary>
        public ICollection<MovieGenre> MovieGenres { get; set; } = new List<MovieGenre>();
    }
}
