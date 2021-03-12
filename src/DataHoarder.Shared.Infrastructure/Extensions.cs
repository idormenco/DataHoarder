using DataHoarder.Shared.Infrastructure.Api;
using Hangfire;
using Hangfire.MemoryStorage;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("DataHoarder.Bootstrapper")]
namespace DataHoarder.Shared.Infrastructure
{
    internal static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddControllers()
                .ConfigureApplicationPartManager(manager =>
                {
                    manager.FeatureProviders.Add(new InternalControllerFeatureProvider());
                });

            // Add Hangfire services.
            services.AddHangfire(configuration => configuration
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UseMemoryStorage());

            // Add the processing server as IHostedService
            services.AddHangfireServer();

            return services;
        }

        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DataHoarder", Version = "v1" });
            });

            return services;
        }

        public static IApplicationBuilder UseApiSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger(c =>
            {
                c.RouteTemplate = "/swagger/{documentName}/swagger.json";
            });

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "DataHoarder");
            });

            return app;
        }

        public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app)
        {
            app.UseHangfireDashboard();
            return app;
        }

    }
}
