using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using MusifyAPI.Services;

namespace MusifyAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        //This method is called at runtime. Add service to container
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_2_2);
            services.AddDbContext<MusifyLibrary.Models.MusifyContext>();
            services.AddScoped<IMusifyRepository, MusifyRepository>();
            services.AddAutoMapper(typeof(Startup));
        }

        //This method is called at runtime. Configure http request pipeline
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

    }
}

