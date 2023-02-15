
using Microsoft.EntityFrameworkCore;
using Movies.Model;
using Movies.Data;
using Movies.Business.Mappers;
using Movies.Data.Mappers;
using Movies.Data.Entities;

namespace Movies.Business
{
    /// <summary>
    ///     Concrete implementation of <see cref="IMovieService"/>
    /// </summary>
    public class MovieService : IMovieService
    {        
        private readonly MoviesContext _context;

        /// <summary>
        ///     Creates an instance of <see cref="MovieService"/>
        /// </summary>
        /// <param name="context">
        ///     An instance of <see cref="MoviesContext"/>
        /// </param>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when the creation parameters are missing
        /// </exception>
        public MovieService(MoviesContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <inheritdoc />
        public async Task<MovieDto> CreateAsync(CreateMovieCriteriaDto criteria, CancellationToken cancellationToken)
        {
            if(criteria is null)
            {
                throw new ArgumentNullException(nameof(criteria));
            }

            var entityMapper = new MovieMapper();
            var movie = entityMapper.Get(criteria);

            _context.Movies.Add(movie);

            await _context.SaveChangesAsync(cancellationToken);

            var dto = await this.GetByIdAsync(movie.Id, cancellationToken);

            return dto;
        }

        /// <inheritdoc />
        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var movieEntity = await _context.Movies.FindAsync(new object[] { id }, cancellationToken);
            if(movieEntity is null)
            {
                return;
            }

            var movieGenresQuery = _context.MovieGenres.Where(mg => mg.MovieId == id);
            foreach (var movieGenre in movieGenresQuery)
            {
                _context.MovieGenres.Remove(movieGenre);
            }

            _context.Movies.Remove(movieEntity);

            await _context.SaveChangesAsync(cancellationToken);
        }

        /// <inheritdoc />
        public async Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken)
        {
            var exists = await _context.Movies.AnyAsync(movie => movie.Id == id, cancellationToken);
            return exists;
        }

        /// <inheritdoc />
        public async Task<MovieDto> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {            
            var entity = await _context.Movies
                .Include(m=> m.MovieGenres)
                .ThenInclude(mg=>mg.Genre)
                .AsNoTracking()
                .SingleOrDefaultAsync(movie => movie.Id == id, cancellationToken);

            if(entity is null)
            {
                return null;
            }

            var mapper = new MovieDtoMapper();
            return mapper.Get(entity);
        }

        /// <inheritdoc />
        public async Task<SearchResultDto<MovieDto>> SearchAsync(SearchCriteriaDto criteria, CancellationToken cancellationToken)
        {
            if (criteria is null)
            {
                throw new ArgumentNullException(nameof(criteria));
            }

            criteria.SetupDefaultSortBy();
            criteria.SetupDefaultSortDirection();

            var queryMovies = _context.Movies
                .Include(m => m.MovieGenres)
                .ThenInclude(mg => mg.Genre)
                .AsNoTracking()
                .FilterByName(criteria.FilterByName)
                .SortBy(criteria.SortBy.Value, criteria.SortDirection.Value);

            var movies = await queryMovies.ToListAsync(cancellationToken);

            var movieDtoMapper = new MovieDtoMapper();
            var result = new SearchResultDto<MovieDto>();

            result.TotalItems = movies.Count;
            result.Results = movies.Page<Movie>(criteria.PageNum, criteria.PageSize).Select(movieDtoMapper.Get).ToList();

            return result;
        }

        /// <inheritdoc />
        public async Task<MovieDto> UpdateAsync(Guid id, UpdateMovieCriteriaDto criteria, CancellationToken cancellationToken)
        {
            if (criteria is null)
            {
                throw new ArgumentNullException(nameof(criteria));
            }

            var movieEntity = await _context.Movies.FindAsync(new object[] { id }, cancellationToken);
            if(movieEntity is null)
            {
                throw new InvalidOperationException($"The movie with id {id} does not exits in the database.");
            }

            movieEntity.Name = criteria.Name;
            movieEntity.ReleaseYear = criteria.ReleaseYear;
            
            var currentMovieGenres = await _context.MovieGenres.Where(mg=> mg.MovieId == id)
                .ToListAsync(cancellationToken);

            var movieGenresToRemove = currentMovieGenres.ExceptBy(criteria.GenreIds, g => g.GenreId);
            var movieGenresToAdd = criteria.GenreIds.Except(currentMovieGenres.Select(g => g.GenreId));

            foreach (var movieGenre in movieGenresToRemove)
            {
                var movieGenreEntity = await _context.MovieGenres.FindAsync(new object[] {movieGenre.MovieId, movieGenre.GenreId}, cancellationToken);
                if(movieGenreEntity is null)
                {
                    continue;
                }
                _context.MovieGenres.Remove(movieGenreEntity);
            }

            foreach (var genreId in movieGenresToAdd)
            {
                var newMovieGenre = new MoviesGenres
                {
                    GenreId = genreId,
                    MovieId = id
                };
                movieEntity.MovieGenres.Add(newMovieGenre);
            }
            
            await _context.SaveChangesAsync(cancellationToken);

            var dto = await this.GetByIdAsync(id, cancellationToken);

            return dto;
        }
    }
}
