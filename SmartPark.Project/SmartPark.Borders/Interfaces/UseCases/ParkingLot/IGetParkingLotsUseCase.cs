using SmartPark.Borders.Dtos.ParkingLot.Request;
using SmartPark.Borders.Dtos.ParkingLot.Response;
using SmartPark.Borders.Interfaces.UseCases.Base;
using SmartPark.Borders.Shared;

namespace SmartPark.Borders.Interfaces.UseCases.ParkingLot
{
    public interface IGetParkingLotsUseCase : IBaseUseCase<GetParkingLotsRequest, PagedResult<ParkingLotDto>>
    {
    }
}
