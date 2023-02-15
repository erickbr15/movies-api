using System.Runtime.Serialization;

namespace Movies.Model
{
    /// <summary>
    ///     Represents a movie
    /// </summary>
    [DataContract]
    public class MovieDto
    {
        /// <summary>
        ///     The movie id
        /// </summary>
        [DataMember]
        public Guid Id { get; set; }

        /// <summary>
        ///     The movie name
        /// </summary>
        [DataMember]
        public string Name { get; set; } = default!;

        /// <summary>
        ///     The movie release date
        /// </summary>
        [DataMember]
        public short? ReleaseYear { get; set; }

        /// <summary>
        ///     The movie genres
        /// </summary>
        [DataMember]
        public IList<GenreDto> Genres { get; set; } = new List<GenreDto>();
    }
}
