using SmartPark.Borders.Interfaces.UseCases.Base;
using SmartPark.Domain.Entities.ParkingLot;

namespace SmartPark.Borders.Interfaces.UseCases.ParkingLot
{
    public interface IGetParkingLotByIdUseCase : IBaseUseCase<Guid, ParkingLotEntity?>
    {
    }
}
