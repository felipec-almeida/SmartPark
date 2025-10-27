namespace SmartPark.Borders.Shared
{
    public record PagedResult<T>
    {
        public IEnumerable<T> Data { get; init; } = [];
        public int PageNumber { get; init; }
        public int PageSize { get; init; }
        public int TotalRecords { get; init; }
        public int TotalPages => (int)Math.Ceiling((double)TotalRecords / PageSize);
    }
}
