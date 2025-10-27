using SmartPark.Borders.Dtos.ParkingLot.Response;
using SmartPark.Domain.Entities.ParkingLot;

namespace SmartPark.Infrastructure.Adapters
{
    public static class ParkingLotAdapter
    {
        public static ParkingLotDto ToParkingLotDto(ParkingLotEntity entity)
        {
            return new ParkingLotDto
            {
                Id = entity.Id,
                Name = entity.Name,
                CarSpots = entity.CarSpots,
                MotorcycleSpots = entity.MotorcycleSpots,
                TotalSpots = entity.TotalSpots,
            };
        }

        public static IEnumerable<ParkingLotDto> ToParkingLotDtoList(IEnumerable<ParkingLotEntity> entities)
        {
            return entities.Select(entity => new ParkingLotDto
            {
                Id = entity.Id,
                Name = entity.Name,
                CarSpots = entity.CarSpots,
                MotorcycleSpots = entity.MotorcycleSpots,
                TotalSpots = entity.TotalSpots,
            });
        }
    }
}
