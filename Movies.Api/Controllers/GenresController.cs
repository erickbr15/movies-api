using Microsoft.AspNetCore.Mvc;
using Movies.Business;
using Movies.Model;

namespace Movies.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IGenreService _genreDomainService;

        /// <summary>
        ///     Creates an instance of <see cref="GenresController"/>
        /// </summary>
        /// <param name="genreDomainService">
        ///     An instance of <see cref="IGenreService"/>
        /// </param>
        /// <exception cref="ArgumentNullException">
        ///     It is thrown if <paramref name="genreDomainService"/> is null
        /// </exception>
        public GenresController(IGenreService genreDomainService)
        {
            _genreDomainService = genreDomainService ?? throw new ArgumentNullException(nameof(genreDomainService));
        }

        /// <summary>
        ///     Gets a list of genres
        /// </summary>
        /// <param name="cancellationToken">
        ///     The operation cancellation token. An instance of <see cref="CancellationToken"/>
        /// </param>
        /// <returns>
        ///     A populated list of <see cref="GenreDto"/>
        /// </returns>
        [HttpGet(Name = "GetGenres")]
        public async Task<ActionResult<IList<GenreDto>>> GetAsync(CancellationToken cancellationToken)
        {
            var movies = await _genreDomainService.GetAsync(cancellationToken);           
            return new OkObjectResult(movies);
        }
    }
}
