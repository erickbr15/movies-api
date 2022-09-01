using Movies.Data.Entities;
using Movies.Model;

namespace Movies.Data
{
    /// <summary>
    /// 
    /// </summary>
    public static class IQueryableExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="movies"></param>
        /// <param name="sortBy"></param>
        /// <param name="sortDirection"></param>
        /// <returns></returns>
        public static IQueryable<Movie> SortBy(this IQueryable<Movie> movies, short sortBy, short sortDirection)
        {             
            if(sortBy == SortMovieByProperties.Name && sortDirection == SortMovieByDirection.Ascending)
            {
                movies = movies.OrderBy(m => m.Name);
            }
            else if(sortBy == SortMovieByProperties.Name && sortDirection == SortMovieByDirection.Descending)
            {
                movies = movies.OrderByDescending(m => m.Name);
            }
            else if (sortBy == SortMovieByProperties.Id && sortDirection == SortMovieByDirection.Ascending)
            {
                movies = movies.OrderBy(m => m.Id);
            }
            else if (sortBy == SortMovieByProperties.Id && sortDirection == SortMovieByDirection.Descending)
            {
                movies = movies.OrderByDescending(m => m.Id);
            }
            else if (sortBy == SortMovieByProperties.ReleaseDate && sortDirection == SortMovieByDirection.Ascending)
            {
                movies = movies.OrderBy(m => m.ReleaseDate);
            }
            else if (sortBy == SortMovieByProperties.ReleaseDate && sortDirection == SortMovieByDirection.Descending)
            {
                movies = movies.OrderByDescending(m => m.ReleaseDate);
            }

            return movies;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="movies"></param>
        /// <param name="movieName"></param>
        /// <returns></returns>
        public static IQueryable<Movie> FilterByName(this IQueryable<Movie> movies, string movieName)
        {
            if (string.IsNullOrWhiteSpace(movieName))
            {
                return movies;
            }
            return movies.Where(x=> x.Name != null && x.Name.ToUpper().Contains(movieName.ToUpper()));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="pageNumZeroStart"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static IList<T> Page<T>(this IList<T> query, int pageNumZeroStart, int pageSize)
        {
            if (pageSize == 0)
            {
                throw new ArgumentOutOfRangeException(nameof(pageSize), "pageSize cannot be zero.");
            }

            if (pageNumZeroStart != 0)
            {
                query = query.Skip(pageNumZeroStart * pageSize).ToList();
            }

            return query.Take(pageSize).ToList();
        }
    }
}
