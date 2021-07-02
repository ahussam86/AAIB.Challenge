using AAIB.Challenge.Web.AppServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AAIB.Challenge.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddMemoryCache();
            services.AddSingleton<IReportDataLoader>((container) => {
                var env=container.GetRequiredService<IWebHostEnvironment>();
                return new JsonReportDataLoader(Path.Combine(env.WebRootPath, "Data\\reports.json"));
            });

            services.AddSingleton<IReportService>((container) =>
            {
                var cache=container.GetRequiredService<IMemoryCache>();
                var dataLoader= container.GetRequiredService<IReportDataLoader>();
                return new ReportService(cache, dataLoader);
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,
        IMemoryCache cache, IReportService reportService)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                    //pattern: "{controller=Reports}/{action=Index}");
            });
        }
    }
}
