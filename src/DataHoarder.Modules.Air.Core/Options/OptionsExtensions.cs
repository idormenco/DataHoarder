using DataHoarder.Shared.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataHoarder.Modules.Air.Core.Options
{
    public static class OptionsExtensions
    {
        public static IServiceCollection ConfigureAirModuleOptions(this IServiceCollection services)
        {
            return services.ConfigureOptions<AirModuleOptions>("AirQualityModule");
        }

        public static AirModuleOptions GetAirModuleOptions(this IServiceCollection services)
        {
            var options = services.GetOptions<AirModuleOptions>("AirQualityModule");

            return options;
        }

        public static AirModuleOptions GetAirModuleOptions(this IApplicationBuilder app)
        {
            var options = app
                .ApplicationServices
                .GetService<IConfiguration>()
                .GetOptions<AirModuleOptions>("AirQualityModule");

            return options;
        }
    }
}
