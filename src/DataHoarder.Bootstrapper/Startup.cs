using DataHoarder.Modules.Air.Api;
using DataHoarder.Shared.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataHoarder.Bootstrapper
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddInfrastructure();
            services.AddSwagger();

            services.AddAirModule();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseHttpsRedirection();

            app.UseInfrastructure();
            app.UseRouting();
            app.UseAirModule();
            app.UseApiSwagger();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGet("/", context => context.Response.WriteAsync("Data Hoarder API"));
            });
        }
    }
}
