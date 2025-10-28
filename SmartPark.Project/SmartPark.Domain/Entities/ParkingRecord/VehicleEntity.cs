using SmartPark.Domain.Enum;

namespace SmartPark.Domain.Entities.ParkingRecord
{
    public record VehicleEntity
    {
        public string Name { get; init; }
        public string Plate { get; init; }
        public VehicleType Type { get; init; }
    }
}
