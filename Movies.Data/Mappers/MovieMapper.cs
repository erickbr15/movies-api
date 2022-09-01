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
        public Movie Get(CreateMovieCriteriaDto createMovieCriteria)
        {
            if(createMovieCriteria is null)
            {
                return null;
            }

            var movie = new Movie
            {
                Id = createMovieCriteria.Id,
                Name = createMovieCriteria.Name,
                ReleaseDate = createMovieCriteria.ReleaseDate
            };

            foreach (var genreId in createMovieCriteria.Genres)
            {
                movie.MovieGenres.Add(new MovieGenre { 
                    MovieId = createMovieCriteria.Id,
                    GenreId = genreId
                });
            }

            return movie;
        }
    }
}
