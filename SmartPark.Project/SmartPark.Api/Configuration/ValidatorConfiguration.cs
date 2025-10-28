using FluentValidation;
using SmartPark.Borders.Dtos.ParkingLot.Request;
using SmartPark.Borders.Validators.ParkingLot;

namespace SmartPark.Api.Configuration
{
    public static class ValidatorConfiguration
    {
        public static IServiceCollection ConfigureValidators(this IServiceCollection services)
        {
            services.AddScoped<IValidator<PostParkingLotRequest>, PostParkingLotRequestValidator>();
            services.AddScoped<IValidator<PatchParkingLotRequest>, PatchParkingLotRequestValidator>();

            return services;
        }
    }
}
