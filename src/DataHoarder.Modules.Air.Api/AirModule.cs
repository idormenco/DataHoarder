using DataHoarder.Modules.Air.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("DataHoarder.Bootstrapper")]
namespace DataHoarder.Modules.Air.Api
{
    internal static class AirModule
    {
        public static IServiceCollection AddAirModule(this IServiceCollection services)
        {
            services.AddCore();

            return services;
        }

        public static IApplicationBuilder UseAirModule(this IApplicationBuilder app)
        {
            app.UseBackgroundJobs();
            return app;
        }
    }
}
