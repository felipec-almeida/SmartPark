using SmartPark.Borders.Interfaces.Repositories;
using SmartPark.Borders.Interfaces.UseCases.ParkingLot;
using SmartPark.Domain.Entities.ParkingLot;

namespace SmartPark.Application.UseCases.ParkingLot
{
    public class GetParkingLotByIdUseCase : IGetParkingLotByIdUseCase
    {
        private readonly IParkingLotRepository _parkingLotRepository;

        public GetParkingLotByIdUseCase(IParkingLotRepository parkingLotRepository)
        {
            _parkingLotRepository = parkingLotRepository;
        }

        public async Task<ParkingLotEntity?> Execute(Guid request)
        {
            return await _parkingLotRepository.GetByIdAsync(request);
        }
    }
}
