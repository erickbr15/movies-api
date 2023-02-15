using Movies.Data.Entities;
using Movies.Model;

namespace Movies.Data.Mappers
{
    /// <summary>
    ///     Movie entity mapper (can be implemented using Automapper, or other similar library)
    /// </summary>
    public class MovieMapper
    {
        /// <summary>
        ///     Creates an instance of <see cref="Movie"/> given an instance of <see cref="CreateMovieCriteriaDto"/>
        /// </summary>
        /// <param name="createMovieCriteria">
        ///     An instance of <see cref="CreateMovieCriteriaDto"/>
        /// </param>
        /// <returns>
        ///     An instance of <see cref="Movie"/>
        /// </returns>
        public Movie? Get(CreateMovieCriteriaDto createMovieCriteria)
        {
            if(createMovieCriteria is null)
            {
                return null;
            }

            var movie = new Movie
            {
                Name = createMovieCriteria.Name ?? string.Empty,
                ReleaseYear = createMovieCriteria.ReleaseYear
            };

            foreach (var genreId in createMovieCriteria.Genres)
            {
                movie.MovieGenres.Add(new MoviesGenres {
                    GenreId = genreId
                });
            }

            return movie;
        }
    }
}
