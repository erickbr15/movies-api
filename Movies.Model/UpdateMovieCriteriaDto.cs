using System.Runtime.Serialization;

namespace Movies.Model
{
    /// <summary>
    ///     Criteria to update a movie
    /// </summary>
    [DataContract]
    public class UpdateMovieCriteriaDto
    {
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
        public IList<short> Genres { get; set; } = new List<short>();
    }
}
