using SmartPark.Borders.Dtos.ParkingLot.Request;
using SmartPark.Borders.Interfaces.UseCases.Base;
using SmartPark.Borders.Shared.Response;

namespace SmartPark.Borders.Interfaces.UseCases.ParkingLot
{
    public interface IPatchParkingLotUseCase : IBaseUseCase<(Guid, PatchParkingLotRequest), BasePatchResponse?>
    {
    }
}
