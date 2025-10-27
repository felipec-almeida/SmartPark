namespace SmartPark.Borders.Shared.Response
{
    public record PostResponse
    {
        public bool IsCreated { get; init; } = false;
        public Guid Id { get; init; }
    }
}
