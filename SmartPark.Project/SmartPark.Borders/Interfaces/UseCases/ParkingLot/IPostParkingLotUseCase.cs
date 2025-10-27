using SmartPark.Borders.Interfaces.UseCases.Base;
using SmartPark.Borders.Shared.Response;
using SmartPark.Domain.Entities.ParkingLot;

namespace SmartPark.Borders.Interfaces.UseCases.ParkingLot
{
    public interface IPostParkingLotUseCase : IBaseUseCase<ParkingLotEntity, PostResponse>
    {
    }
}
