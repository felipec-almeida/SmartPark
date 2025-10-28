namespace SmartPark.Borders.Dtos.ParkingLot.Request
{
    public record PostParkingLotRequest
    {
        public string Name { get; init; }
        public ParkingLotAddressDto Address { get; init; }
        public int CarSpots { get; init; }
        public int MotorcycleSpots { get; init; }
    }
}
