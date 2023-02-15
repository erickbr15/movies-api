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
        public MovieDto? Get(Movie movie)
        {
            if(movie is null)
            {
                return null;
            }

            var dto = new MovieDto
            {
                Id = movie.Id,
                Name = movie.Name,
                ReleaseYear = movie.ReleaseYear
            };

            dto.Genres = movie.MovieGenres.Select(mg => new GenreDto
            {
                Id = mg.Genre?.Id ?? 0,
                Name = mg.Genre?.Name ?? string.Empty
            }).ToList();
            
            return dto;
        }
    }
}
