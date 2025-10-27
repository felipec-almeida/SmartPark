using SmartPark.Borders.Interfaces.Repositories;
using SmartPark.Infrastructure.Repositories;

namespace SmartPark.Api.Configuration
{
    public static class RepositoryConfiguration
    {
        public static IServiceCollection ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<IParkingLotRepository, ParkingLotRepository>();

            return services;
        }
    }
}
