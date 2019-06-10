using Microsoft.Extensions.DependencyInjection;
using PlanetDatabase.Core.Services.Planets;

namespace PlanetDatabase.Extensions
{
    public static class ServiceExtensions
    {

        public static void ConfigureCors(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicyAllowAll",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });
        }

        public static void AddScoped(IServiceCollection services)
        {
            services.AddScoped<IPlanetService, PlanetService>();
        }
    }
}
