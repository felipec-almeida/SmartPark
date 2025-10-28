using SmartPark.Borders.Interfaces.Repositories;
using SmartPark.Borders.Interfaces.UseCases.ParkingLot;
using SmartPark.Borders.Shared.Response;
using SmartPark.Infrastructure.Adapters;

namespace SmartPark.Application.UseCases.ParkingLot
{
    public class DeleteParkingLotUseCase : IDeleteParkingLotUseCase
    {
        private readonly IParkingLotRepository _parkingLotRepository;

        public DeleteParkingLotUseCase(IParkingLotRepository parkingLotRepository)
        {
            _parkingLotRepository = parkingLotRepository;
        }

        public async Task<BaseDeleteResponse?> Execute(Guid id)
        {
            var response = await _parkingLotRepository.DeleteAsync(id);

            if (response == null)
                return null;

            return response;
        }
    }
}
