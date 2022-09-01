using Movies.Data.Entities;
using Movies.Model;

namespace Movies.Business.Mappers
{
    /// <summary>
    ///     Movie DTO mapper (can be implemented with a library to map like auto-mapper)
    /// </summary>
    public class MovieDtoMapper
    {
        /// <summary>
        ///     Get an instance of <see cref="MovieDto"/> given an instance of <see cref="Movie"/>
        /// </summary>
        /// <param name="movie">
        ///     An instance of <see cref="Movie"/>
        /// </param>
        /// <returns>
        ///     If <paramref name="movie"/> is not null an instance of <see cref="MovieDto"/>, otherwise null
        /// </returns>
        public MovieDto Get(Movie movie)
        {
            if(movie is null)
            {
                return null;
            }

            var dto = new MovieDto
            {
                Id = movie.Id,
                Name = movie.Name,
                ReleaseDate = movie.ReleaseDate
            };

            foreach (var movieGenre in movie.MovieGenres)
            {
                dto.Genres.Add(new GenreDto
                {
                    Id = movieGenre.Genre.Id,
                    Name = movieGenre.Genre.Name
                });
            }

            return dto;
        }
    }
}
