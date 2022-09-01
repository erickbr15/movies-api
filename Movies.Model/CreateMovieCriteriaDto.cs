using System.Runtime.Serialization;

namespace Movies.Model
{
    /// <summary>
    ///     Criteria to create a new movie
    /// </summary>
    [DataContract]
    public class CreateMovieCriteriaDto
    {
        /// <summary>
        ///     The movie unique identifier
        /// </summary>
        [DataMember]
        public string? Id { get; set; }

        /// <summary>
        ///     The movie name
        /// </summary>
        [DataMember]
        public string? Name { get; set; }

        /// <summary>
        ///     The movie release date
        /// </summary>
        [DataMember]
        public DateTime ReleaseDate { get; set; }

        /// <summary>
        ///     The movie genres
        /// </summary>
        [DataMember]
        public IList<short> Genres { get; set; } = new List<short>();
    }
}