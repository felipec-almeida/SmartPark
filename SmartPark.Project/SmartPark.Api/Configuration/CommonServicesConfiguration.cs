using SmartPark.Api.Extensions;

namespace SmartPark.Api.Configuration
{
    public static class CommonServicesConfiguration
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            services.ConfigureInMemoryDb();
            services.ConfigureValidators();
            services.ConfigureRepositories();
            services.ConfigureUseCases();
            services.AddSingleton<ActionResultConverter>();

            return services;
        }
    }
}
