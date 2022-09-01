using System.Runtime.Serialization;

namespace Movies.Model
{
    /// <summary>
    ///     Represents the movie search criteria 
    /// </summary>
    [DataContract]
    public class SearchCriteriaDto
    {
        /// <summary>
        ///     The movie name to filter the data
        /// </summary>
        [DataMember]
        public string? FilterByName { get; set; }

        /// <summary>
        ///     Numeric value to indicate what property will be used to sort the data.
        ///     Range of values: 1 - Id, 2 - Name, 3 - Release date
        /// </summary>
        [DataMember]
        public short? SortBy { get; set; }

        /// <summary>
        ///     Numeric value to indicate how data will be sorted.
        ///     Range of values: 1 - Ascending, 2 - Descending
        /// </summary>
        [DataMember]
        public short? SortDirection { get; set; }

        /// <summary>
        ///     The zero-based page number
        /// </summary>
        [DataMember]
        public int PageNum { get; set; } = 0;

        /// <summary>
        ///     The page size
        /// </summary>
        [DataMember]
        public int PageSize { get; set; } = 1;
    }
}
