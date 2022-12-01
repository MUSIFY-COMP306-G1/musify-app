using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using MusifyApp.Model;

namespace MusifyApp
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
            services.AddDbContext<MusicContext>(opt => opt.UseInMemoryDatabase("MusicList"));
            services.AddControllers();
        }

        //This method is called at runtime. Configure http request pipeline
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if(env.IsDevelopment())
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
