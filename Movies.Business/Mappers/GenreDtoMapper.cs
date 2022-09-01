using Movies.Data.Entities;
using Movies.Model;

namespace Movies.Business.Mappers
{
    /// <summary>
    ///     Genre DTO mapper (can be implemented with a library to map like auto-mapper)
    /// </summary>
    public class GenreDtoMapper
    {
        /// <summary>
        ///     Get an instance of <see cref="GenreDto"/> given an instance of <see cref="Genre"/>
        /// </summary>
        /// <param name="genre">
        ///     An instance of <see cref="Genre"/>
        /// </param>
        /// <returns>
        ///     If <paramref name="genre"/> is not null an instance of <see cref="GenreDto"/>, otherwise null
        /// </returns>
        public GenreDto Get(Genre genre)
        {
            if(genre is null)
            {
                return null;
            }

            return new GenreDto
            {
                Id = genre.Id,
                Name = genre.Name
            };
        }
    }
}
