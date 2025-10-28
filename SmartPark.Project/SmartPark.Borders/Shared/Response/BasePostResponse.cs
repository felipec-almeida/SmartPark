
namespace SmartPark.Borders.Shared.Response
{
    public record BasePostResponse : BaseResponse<object>
    {
        public bool IsCreated { get; init; }
    }
}
