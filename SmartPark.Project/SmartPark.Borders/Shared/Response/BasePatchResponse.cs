namespace SmartPark.Borders.Shared.Response
{
    public record BasePatchResponse : BaseResponse<object>
    {
        public bool IsUpdated { get; init; }
    }
}
