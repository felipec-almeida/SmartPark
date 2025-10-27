namespace SmartPark.Domain.Entities.ParkingLot
{
    public record ParkingLotEntity
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public ParkingLotAddressEntity Address { get; init; }
        public int CarSpots { get; init; }
        public int MotorcycleSpots { get; init; }

        public int TotalSpots => CarSpots + MotorcycleSpots;
    }
}
