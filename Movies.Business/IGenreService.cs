using Movies.Model;

namespace Movies.Business
{
    /// <summary>
    ///     Genre business service contract
    /// </summary>
    public interface IGenreService
    {
        /// <summary>
        ///     Get all the genres
        /// </summary>
        /// <param name="cancellationToken">
        ///     The operation cancellation token. An instance of <see cref="CancellationToken"/>
        /// </param>
        /// <returns>
        ///     A populated list of <see cref="GenreDto"/>
        /// </returns>
        Task<IList<GenreDto>> GetAsync(CancellationToken cancellationToken);
    }
}
