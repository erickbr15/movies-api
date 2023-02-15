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
        public string Name { get; set; } = default!;

        /// <summary>
        ///     The movie release date
        /// </summary>
        [DataMember]
        public short ReleaseYear { get; set; }

        /// <summary>
        ///     The movie genres
        /// </summary>
        [DataMember]
        public IList<int> GenreIds { get; set; } = new List<int>();
    }
}
