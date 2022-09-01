using Microsoft.AspNetCore.Mvc;
using Movies.Business;
using Movies.Model;

namespace Movies.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _moviesDomainService;

        /// <summary>
        ///     Creates an instance of <see cref="MoviesController"/>
        /// </summary>
        /// <param name="moviesDomainService">
        ///     An instance of <see cref="IMovieService"/>
        /// </param>
        /// <exception cref="ArgumentNullException">
        ///     It is thrown when <paramref name="moviesDomainService"/> is null
        /// </exception>
        public MoviesController(IMovieService moviesDomainService)
        {
            _moviesDomainService = moviesDomainService ?? throw new ArgumentNullException(nameof(moviesDomainService));
        }

        /// <summary>
        ///     Gets a movie by id
        /// </summary>
        /// <param name="id">
        ///     The unique movie identifier
        /// </param>
        /// <param name="cancellationToken">
        ///     The operation cancellation token. An instance of <see cref="CancellationToken"/>
        /// </param>
        /// <returns>
        ///     An instance of <see cref="MovieDto"/> which represents the movie
        /// </returns>
        [HttpGet("{id}", Name = "GetMovieById")]
        public async Task<ActionResult<MovieDto>> GetAsync(string id, CancellationToken cancellationToken)
        {
            var movie = await _moviesDomainService.GetByIdAsync(id, cancellationToken);

            if(movie is null)
            {
                return new NotFoundResult();
            }

            return new OkObjectResult(movie);
        }

        /// <summary>
        ///     Creates a new movie    
        /// </summary>
        /// <param name="criteria">
        ///     The criteria to create a new movie. An instance of <see cref="CreateMovieCriteriaDto"/>
        /// </param>
        /// <param name="cancellationToken">
        ///     The operation cancellation token. An instance of <see cref="CancellationToken"/>
        /// </param>
        /// <returns>
        ///     An instance of the created movie. <see cref="MovieDto"/>
        /// </returns>
        [HttpPost(Name = "CreateMovie")]
        public async Task<ActionResult<MovieDto>> PostAsync([FromBody] CreateMovieCriteriaDto criteria, CancellationToken cancellationToken)
        {
            if(criteria is null)
            {
                return new BadRequestObjectResult("The movie create criteria is required.");
            }

            var newMovie = await _moviesDomainService.CreateAsync(criteria, cancellationToken);

            return new CreatedAtRouteResult("GetMovieById", new { id = newMovie.Id }, newMovie);
        }

        /// <summary>
        ///     Updates an existing movie
        /// </summary>
        /// <param name="id">
        ///     The unique movie identifier
        /// </param>
        /// <param name="criteria">
        ///     The criteria to update an existing movie. An instance of <see cref="UpdateMovieCriteriaDto"/>
        /// </param>
        /// <param name="cancellationToken">
        ///     The operation cancellation token. An instance of <see cref="CancellationToken"/>
        /// </param>
        /// <returns>
        ///     An instance of the updated movie. <see cref="MovieDto"/>
        /// </returns>
        [HttpPut("{id}", Name = "UpdateMovie")]
        public async Task<ActionResult<MovieDto>> PutAsync(string id, [FromBody] UpdateMovieCriteriaDto criteria, CancellationToken cancellationToken)
        {
            if(criteria is null)
            {
                return new BadRequestObjectResult("The movie update criteria is required.");
            }

            var existsMovie = await _moviesDomainService.ExistsAsync(id, cancellationToken);
            if (!existsMovie)
            {
                return new NotFoundResult();
            }

            var movie = await _moviesDomainService.UpdateAsync(id, criteria, cancellationToken);

            return new OkObjectResult(movie);
        }

        /// <summary>
        ///     Deletes a movie
        /// </summary>
        /// <param name="id">
        ///     The unique movie identifier
        /// </param>
        /// <param name="cancellationToken">
        ///     The operation cancellation token. An instance of <see cref="CancellationToken"/>
        /// </param>
        [HttpDelete("{id}", Name = "DeleteMovie")]
        public async Task<ActionResult> DeleteAsync(string id, CancellationToken cancellationToken)
        {            
            await _moviesDomainService.DeleteAsync(id, cancellationToken);

            return new OkResult();
        }

        /// <summary>
        ///     Searches for movies
        /// </summary>
        /// <param name="searchCriteria">
        ///     The search criteria. <see cref="SearchCriteriaDto"/>
        /// </param>
        /// <param name="cancellationToken">
        ///     The operation cancellation token. An instance of <see cref="CancellationToken"/>
        /// </param>
        /// <returns>
        ///     An instance of <see cref="SearchResultDto{MovieDto}"/>
        /// </returns>
        [HttpPost("search", Name = "SearchMovies")]
        public async Task<ActionResult<SearchResultDto<MovieDto>>> SearchAsync([FromBody]SearchCriteriaDto searchCriteria, CancellationToken cancellationToken)
        {
            if (searchCriteria is null)
            {
                return new BadRequestObjectResult("The search criteria is required.");
            }

            var result = await _moviesDomainService.SearchAsync(searchCriteria, cancellationToken);

            return new OkObjectResult(result);
        }
    }
}
