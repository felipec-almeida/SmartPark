using SmartPark.Borders.Dtos.ParkingLot.Response;
using SmartPark.Borders.Interfaces.UseCases.Base;

namespace SmartPark.Borders.Interfaces.UseCases.ParkingLot
{
    public interface IGetParkingLotByIdUseCase : IBaseUseCase<Guid, ParkingLotDto?>
    {
    }
}
