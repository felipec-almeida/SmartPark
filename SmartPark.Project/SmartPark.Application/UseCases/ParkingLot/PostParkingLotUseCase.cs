using SmartPark.Borders.Interfaces.Repositories;
using SmartPark.Borders.Interfaces.UseCases.ParkingLot;
using SmartPark.Borders.Shared.Response;
using SmartPark.Domain.Entities.ParkingLot;

namespace SmartPark.Application.UseCases.ParkingLot
{
    public class PostParkingLotUseCase : IPostParkingLotUseCase
    {
        private readonly IParkingLotRepository _parkingLotRepository;

        public PostParkingLotUseCase(IParkingLotRepository parkingLotRepository)
        {
            _parkingLotRepository = parkingLotRepository;
        }

        public async Task<PostResponse> Execute(ParkingLotEntity request)
        {
            return await _parkingLotRepository.PostAsync(request);
        }
    }
}
