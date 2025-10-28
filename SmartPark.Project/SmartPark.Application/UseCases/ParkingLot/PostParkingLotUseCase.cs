using FluentValidation;
using SmartPark.Borders.Dtos.ParkingLot.Request;
using SmartPark.Borders.Interfaces.Repositories;
using SmartPark.Borders.Interfaces.UseCases.ParkingLot;
using SmartPark.Borders.Shared.Response;
using SmartPark.Infrastructure.Adapters;

namespace SmartPark.Application.UseCases.ParkingLot
{
    public class PostParkingLotUseCase : IPostParkingLotUseCase
    {
        private readonly IParkingLotRepository _parkingLotRepository;
        private readonly IValidator<PostParkingLotRequest> _validator;

        public PostParkingLotUseCase(
            IParkingLotRepository parkingLotRepository,
            IValidator<PostParkingLotRequest> validator
            )
        {
            _parkingLotRepository = parkingLotRepository;
            _validator = validator;
        }

        public async Task<BasePostResponse> Execute(PostParkingLotRequest request)
        {
            await _validator.ValidateAndThrowAsync(request, default);

            var parkingLotEntity = ParkingLotAdapter.ToParkingLotEntity(request);

            return await _parkingLotRepository.PostAsync(parkingLotEntity);
        }
    }
}
