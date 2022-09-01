using Microsoft.EntityFrameworkCore;
using Movies.Business.Mappers;
using Movies.Data;
using Movies.Model;

namespace Movies.Business
{
    /// <summary>
    ///     Concrete implementation of <see cref="IGenreService"/>
    /// </summary>
    public class GenreService : IGenreService
    {
        private readonly MoviesContext _context;

        /// <summary>
        ///     Creates an instance of <see cref="GenreService"/>
        /// </summary>
        /// <param name="context">
        ///     An instance of <see cref="MoviesContext"/>
        /// </param>
        /// <exception cref="ArgumentNullException">
        ///     It is thrown when <paramref name="context"/> is null
        /// </exception>
        public GenreService(MoviesContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <inheritdoc />
        public async Task<IList<GenreDto>> GetAsync(CancellationToken cancellationToken)
        {
            var mapper = new GenreDtoMapper();

            var dtos = (await _context.Genres.ToListAsync(cancellationToken))
                .Select(mapper.Get)
                .ToList();

            return dtos;               
        }
    }
}
