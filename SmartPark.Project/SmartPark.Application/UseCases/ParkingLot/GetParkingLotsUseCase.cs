using SmartPark.Borders.Dtos.ParkingLot.Request;
using SmartPark.Borders.Dtos.ParkingLot.Response;
using SmartPark.Borders.Interfaces.Repositories;
using SmartPark.Borders.Interfaces.UseCases.ParkingLot;
using SmartPark.Borders.Shared;
using SmartPark.Borders.Shared.Extensions;
using SmartPark.Infrastructure.Adapters;

namespace SmartPark.Application.UseCases.ParkingLot
{
    public class GetParkingLotsUseCase : IGetParkingLotsUseCase
    {
        private readonly IParkingLotRepository _parkingLotRepository;

        public GetParkingLotsUseCase(IParkingLotRepository parkingLotRepository)
        {
            _parkingLotRepository = parkingLotRepository;
        }

        public async Task<PagedResult<ParkingLotDto>> Execute(GetParkingLotsRequest request)
        {
            var parkingLotsList = await _parkingLotRepository.GetAllAsync(request.PageNumber, request.PageSize);
            var response = ParkingLotAdapter.ToParkingLotDtoList(parkingLotsList).ToPagedResult(request.PageNumber, request.PageSize);

            return response;
        }
    }
}
