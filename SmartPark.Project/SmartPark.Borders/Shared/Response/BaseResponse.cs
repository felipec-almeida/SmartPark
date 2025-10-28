using System.Text.Json.Serialization;

namespace SmartPark.Borders.Shared.Response
{
    public record BaseResponse<T>
    {
        public T Result { get; init; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Message { get; init; }
    }
}
