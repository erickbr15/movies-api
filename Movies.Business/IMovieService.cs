using Movies.Model;

namespace Movies.Business
{
    /// <summary>
    ///     Movies domain service contract
    /// </summary>
    public interface IMovieService
    {
        /// <summary>
        ///     Verify if a movie exists with the given id
        /// </summary>
        /// <param name="id">
        ///     The unique movie identifer
        /// </param>
        /// <param name="cancellationToken">
        ///     The operation cancellation token. An instance of <see cref="CancellationToken"/>
        /// </param>
        /// <returns>
        ///     true if the movie id exists, otherwise false
        /// </returns>
        Task<bool> ExistsAsync(string id, CancellationToken cancellationToken);

        /// <summary>
        ///     Get a movie given the identifier
        /// </summary>
        /// <param name="id">
        ///     The unique movie identifier
        /// </param>
        /// <param name="cancellationToken">
        ///     The operation cancellation token. An instance of <see cref="CancellationToken"/>
        /// </param>
        /// <returns>
        ///     An instance of <see cref="Movie"/>
        /// </returns>
        Task<MovieDto> GetByIdAsync(string id, CancellationToken cancellationToken);

        /// <summary>
        ///     Creates a new movie
        /// </summary>
        /// <param name="criteria">
        ///     The movie creation criteria. An instance of <see cref="CreateMovieCriteriaDto"/>
        /// </param>
        /// <param name="cancellationToken">
        ///     The operation cancellation token. An instance of <see cref="CancellationToken"/>
        /// </param>
        /// <returns>
        ///     An instance of <see cref="MovieDto"/> which represents the created movie.
        /// </returns>
        Task<MovieDto> CreateAsync(CreateMovieCriteriaDto criteria, CancellationToken cancellationToken);

        /// <summary>
        ///     Updates the properties of an existing movie
        /// </summary>
        /// <param name="criteria">
        ///     The movie edit criteria. An instance of <see cref="UpdateMovieCriteriaDto"/>
        /// </param>
        /// <param name="cancellationToken">
        ///     The operation cancellation token. An instance of <see cref="CancellationToken"/>
        /// </param>
        /// <returns>
        ///     An instance of <see cref="MovieDto"/> which represents the edited movie.
        /// </returns>
        Task<MovieDto> UpdateAsync(string id, UpdateMovieCriteriaDto criteria, CancellationToken cancellationToken);

        /// <summary>
        ///     Search, sort and page the movies based on the given criteria
        /// </summary>
        /// <param name="criteria">
        ///     The criteria to search, sort and page the movie query results. An instance of <see cref="SearchCriteriaDto"/>
        /// </param>
        /// <param name="cancellationToken">
        ///     The operation cancellation token. An instance of <see cref="CancellationToken"/>
        /// </param>
        /// <returns>
        ///     An instance of <see cref="SearchResultDto{MovieDto}"/>
        /// </returns>
        Task<SearchResultDto<MovieDto>> SearchAsync(SearchCriteriaDto criteria, CancellationToken cancellationToken);

        /// <summary>
        ///     Deletes a movie
        /// </summary>
        /// <param name="id">
        ///     The movie unique identifier
        /// </param>
        /// <param name="cancellationToken">
        ///     The operation cancellation token. An instance of <see cref="CancellationToken"/>
        /// </param>
        Task DeleteAsync(string id, CancellationToken cancellationToken);
    }
}
