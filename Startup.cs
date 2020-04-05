using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DutchTreat
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // app.UseDefaultFiles();  not needed when using MVC
            app.UseStaticFiles();  // only delivers files from wwwroot   
            // add from nuget using: dotnet add package OdeToCode.UseNodeModules --version 3.0.0, allows use of node_modules in html
            // this didn't work for me used the library in the wwwroot/lib directory instead
            // app.UseNodeModules();  
            app.UseRouting();
            app.UseEndpoints(cfg => {
                cfg.MapControllerRoute("Fallback",
                "{controller}/{action}/{id?}",
                new {controller = "App", Action = "Index"});
            });

        }
    }
}
