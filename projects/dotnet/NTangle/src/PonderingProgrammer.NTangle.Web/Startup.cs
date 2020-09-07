using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PonderingProgrammer.NTangle.Core;

namespace PonderingProgrammer.NTangle.Web
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<NTangleContext>();
            services.AddRazorPages().AddRazorRuntimeCompilation();
            services.AddSession();
            
            services.AddScoped<ITipRepository, TipRepository>();
            services.AddScoped<ITipSetRepository, TipSetRepository>();
            services.AddScoped<IActivityRepository, ActivityRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapDefaultControllerRoute();
                endpoints.MapRazorPages();
            });
        }
    }
}
