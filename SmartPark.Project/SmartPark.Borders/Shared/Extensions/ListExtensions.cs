namespace SmartPark.Borders.Shared.Extensions
{
    public static class ListExtensions
    {
        public static PagedResult<T> ToPagedResult<T>(this IEnumerable<T> source, int page, int pageSize)
        {
            var totalCount = source.Count();
            var items = source.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            return new PagedResult<T>
            {
                TotalRecords = totalCount,
                PageNumber = page,
                PageSize = pageSize,
                Data = items
            };
        }
    }
}
