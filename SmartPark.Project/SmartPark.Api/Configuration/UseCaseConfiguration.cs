using SmartPark.Application.UseCases.ParkingLot;
using SmartPark.Borders.Interfaces.UseCases.ParkingLot;

namespace SmartPark.Api.Configuration
{
    public static class UseCaseConfiguration
    {
        public static IServiceCollection ConfigureUseCases(this IServiceCollection services)
        {
            services.AddScoped<IGetParkingLotsUseCase, GetParkingLotsUseCase>();
            services.AddScoped<IGetParkingLotByIdUseCase, GetParkingLotByIdUseCase>();
            
            return services;
        }
    }
}
