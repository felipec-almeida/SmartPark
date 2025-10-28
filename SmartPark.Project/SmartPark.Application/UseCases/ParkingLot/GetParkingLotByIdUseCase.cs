using SmartPark.Borders.Dtos.ParkingLot.Response;
using SmartPark.Borders.Interfaces.Repositories;
using SmartPark.Borders.Interfaces.UseCases.ParkingLot;
using SmartPark.Infrastructure.Adapters;

namespace SmartPark.Application.UseCases.ParkingLot
{
    public class GetParkingLotByIdUseCase : IGetParkingLotByIdUseCase
    {
        private readonly IParkingLotRepository _parkingLotRepository;

        public GetParkingLotByIdUseCase(IParkingLotRepository parkingLotRepository)
        {
            _parkingLotRepository = parkingLotRepository;
        }

        public async Task<ParkingLotDto?> Execute(Guid request)
        {
            var response = await _parkingLotRepository.GetByIdAsync(request);

            if (response == null)
                return null;

            var result = ParkingLotAdapter.ToParkingLotDto(response);

            return result;
        }
    }
}
