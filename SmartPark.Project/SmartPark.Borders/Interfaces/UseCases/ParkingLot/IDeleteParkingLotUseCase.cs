using SmartPark.Borders.Interfaces.UseCases.Base;
using SmartPark.Borders.Shared.Response;

namespace SmartPark.Borders.Interfaces.UseCases.ParkingLot
{
    public interface IDeleteParkingLotUseCase : IBaseUseCase<Guid, BaseDeleteResponse?>
    {
    }
}
