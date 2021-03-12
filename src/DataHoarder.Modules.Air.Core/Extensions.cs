using DataHoarder.Modules.Air.Core.BackgroundJobs;
using DataHoarder.Modules.Air.Core.Options;
using DataHoarder.Modules.Air.Core.Providers;
using DataHoarder.Modules.Air.Core.Services;
using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("DataHoarder.Modules.Air.Api")]
namespace DataHoarder.Modules.Air.Core
{
    internal static class Extensions
    {
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            services.ConfigureAirModuleOptions();

            var options = services.GetAirModuleOptions();
            services.AddSingleton<IAirQualityProvider, AirQualityProvider>();
            services.AddTransient<IAirQualityCacheUpdaterBackgrounJob, AirQualityCacheUpdaterBackgrounJob>();

            if (options.CachingEnabled)
            {
                services.AddMemoryCache();
                services.AddScoped<AirQualityService>();
                services.AddScoped<IAirQualityService, CachedAirQualityService>();
            }
            else
            {
                services.AddScoped<IAirQualityService, AirQualityService>();
            }

            return services;
        }

        public static IApplicationBuilder UseBackgroundJobs(this IApplicationBuilder app)
        {
            var airModuleOptions = app.GetAirModuleOptions();

            var recurringJobManager = app.ApplicationServices.GetService<IRecurringJobManager>();
            var backgroundJob = app.ApplicationServices.GetService<IAirQualityCacheUpdaterBackgrounJob>();

            recurringJobManager.AddOrUpdate("Air quality crawler",
                () => backgroundJob.UpdateAirQualityCacheAsync(),
                airModuleOptions.BackgroundJobCronExpression);

            return app;
        }
    }
}
