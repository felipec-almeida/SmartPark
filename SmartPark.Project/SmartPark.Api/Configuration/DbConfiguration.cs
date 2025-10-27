using Microsoft.EntityFrameworkCore;
using SmartPark.Infrastructure.Context.ParkingLot;

namespace SmartPark.Api.Configuration
{
    public static class DbConfiguration
    {
        public static IServiceCollection ConfigureInMemoryDb(this IServiceCollection services)
        {
            services.AddDbContext<ParkingLotDbContext>(options =>
            {
                options.UseInMemoryDatabase("SmartPark.ParkingLotDb");
            });

            return services;
        }
    }
}
