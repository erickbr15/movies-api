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
        ///     The movie name
        /// </summary>
        [DataMember]
        public string? Name { get; set; }

        /// <summary>
        ///     The movie release date
        /// </summary>
        [DataMember]
        public short ReleaseYear { get; set; }

        /// <summary>
        ///     The movie genres
        /// </summary>
        [DataMember]
        public IList<short> Genres { get; set; } = new List<short>();
    }
}