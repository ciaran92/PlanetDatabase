using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PlanetDatabase.Data.Context;
using PlanetDatabase.Data.Entities;
using PlanetDatabase.Data.Models.Planet;
using PlanetDatabase.Extensions;
using System.IO;

namespace PlanetDatabase
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        
        public void ConfigureServices(IServiceCollection services)
        {
            ServiceExtensions.ConfigureCors(services);
            ServiceExtensions.AddScoped(services);

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddDbContext<PlanetDatabaseContext>(options 
                => options.UseSqlServer(Configuration["ConnectionStrings:PlanetDatabaseConnection"]));
        }
        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            { 
                app.UseHsts();
            }

            app.Use(async (context, next) =>
            {
                await next();

                if (context.Response.StatusCode == 404 && !Path.HasExtension(context.Request.Path.Value))
                {
                    context.Request.Path = "/index.html";
                    await next();
                }
            });

            app.UseDefaultFiles();
            app.UseStaticFiles();

            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Planet, PlanetListDto>();
            });

            app.UseCors("CorsPolicyAllowAll");
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
