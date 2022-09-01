namespace Movies.Model
{
    /// <summary>
    ///     Represents the search results
    /// </summary>
    public class SearchResultDto<TResult> where TResult : class
    {
        /// <summary>
        ///     A list of <see cref="TResult"/> that represents the search results
        /// </summary>
        public IList<TResult> Results { get; set; } = new List<TResult>();

        /// <summary>
        ///     The search total results
        /// </summary>
        public int TotalItems { get; set; }
    }
}
