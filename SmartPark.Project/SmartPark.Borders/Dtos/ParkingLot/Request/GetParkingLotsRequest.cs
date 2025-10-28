namespace SmartPark.Borders.Dtos.ParkingLot.Request
{
    public record GetParkingLotsRequest
    {
        public int PageNumber { get; init; } = 0;
        public int PageSize { get; init; } = 10;
    }
}
