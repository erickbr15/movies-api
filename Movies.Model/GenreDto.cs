using System.Runtime.Serialization;

namespace Movies.Model
{
    /// <summary>
    ///     Represents a genre
    /// </summary>
    [DataContract]
    public class GenreDto
    {
        /// <summary>
        ///     The genre id
        /// </summary>
        [DataMember]
        public int Id { get; set; }

        /// <summary>
        ///     The genre name
        /// </summary>
        [DataMember]
        public string Name { get; set; } = default!;
    }
}
