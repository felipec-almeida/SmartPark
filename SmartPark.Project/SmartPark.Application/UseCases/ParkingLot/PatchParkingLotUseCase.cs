using SmartPark.Borders.Dtos.ParkingLot.Request;
using SmartPark.Borders.Interfaces.Repositories;
using SmartPark.Borders.Interfaces.UseCases.ParkingLot;
using SmartPark.Borders.Shared.Response;

namespace SmartPark.Application.UseCases.ParkingLot
{
    public class PatchParkingLotUseCase : IPatchParkingLotUseCase
    {
        private readonly IParkingLotRepository _parkingLotRepository;

        public PatchParkingLotUseCase(IParkingLotRepository parkingLotRepository)
        {
            _parkingLotRepository = parkingLotRepository;
        }

        public async Task<BasePatchResponse?> Execute((Guid, PatchParkingLotRequest) request)
        {
            var response = await _parkingLotRepository.PatchAsync(request);

            if (response == null)
                return null;

            return response;
        }
    }
}
