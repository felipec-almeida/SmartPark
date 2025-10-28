namespace SmartPark.Borders.Shared.Response
{
    public record BaseErrorResponse
    {
        public IEnumerable<string> Errors { get; set; }
    }
}
