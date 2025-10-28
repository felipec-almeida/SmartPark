namespace SmartPark.Domain.Entities.ParkingRecord
{
    public record ParkingRecordEntity
    {
        public Guid Id { get; init; }
        public Guid ParkingLotId { get; init; }
        public CustomerEntity Customer { get; init; }
        public VehicleEntity Vehicle { get; init; }
        public DateTime EntryTime { get; init; }
        public int RequestedHours { get; init; }
        public DateTime? ExitTime { get; set; }
        public decimal? PricePaid { get; set; }
    }
}


