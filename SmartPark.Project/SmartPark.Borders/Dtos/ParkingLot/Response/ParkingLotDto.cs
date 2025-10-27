namespace SmartPark.Borders.Dtos.ParkingLot.Response
{
    public record ParkingLotDto
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public int CarSpots { get; init; }
        public int MotorcycleSpots { get; init; }
        public int TotalSpots { get; init; }
    }
}
