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
        public string Id { get; set; }

        /// <summary>
        ///     The movie name
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        ///     The movie release date
        /// </summary>
        [DataMember]
        public DateTime ReleaseDate { get; set; }

        /// <summary>
        ///     The movie genres
        /// </summary>
        [DataMember]
        public IList<GenreDto> Genres { get; set; } = new List<GenreDto>();
    }
}
