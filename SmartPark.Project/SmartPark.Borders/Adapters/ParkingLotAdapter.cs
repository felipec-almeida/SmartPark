using SmartPark.Borders.Dtos.ParkingLot;
using SmartPark.Borders.Dtos.ParkingLot.Request;
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
                Address = new ParkingLotAddressDto
                {
                    Street = entity.Address.Street,
                    City = entity.Address.City,
                    Number = entity.Address.Number,
                    State = entity.Address.State,
                    ZipCode = entity.Address.ZipCode
                },
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

        public static ParkingLotEntity ToParkingLotEntity(PostParkingLotRequest entity)
        {
            return new ParkingLotEntity
            {
                Id = Guid.NewGuid(),
                Name = entity.Name,
                CarSpots = entity.CarSpots,
                MotorcycleSpots = entity.MotorcycleSpots,
                Address = new ParkingLotAddressEntity
                {
                    Street = entity.Address.Street,
                    City = entity.Address.City,
                    Number = entity.Address.Number,
                    State = entity.Address.State,
                    ZipCode = entity.Address.ZipCode
                }
            };
        }
    }
}
