namespace Movies.Model
{
    public static class SearchCriteriaDtoExtensions
    {
        public static void SetupDefaultSortBy(this SearchCriteriaDto criteria)
        {                        
            var validSortByProperties = new int[] { 
                SortMovieByProperties.Id, 
                SortMovieByProperties.Name, 
                SortMovieByProperties.ReleaseDate };

            if(!validSortByProperties.Contains(criteria.SortBy ?? -1))
            {
                criteria.SortBy = SortMovieByProperties.Name;
            }
        }

        public static void SetupDefaultSortDirection(this SearchCriteriaDto criteria)
        {
            var validSortDirections = new int[] {
                SortMovieByDirection.Ascending,
                SortMovieByDirection.Descending
            };

            if (!validSortDirections.Contains(criteria.SortDirection ?? -1))
            {
                criteria.SortDirection = SortMovieByDirection.Ascending;
            }
        }
    }
}
