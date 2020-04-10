using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;
using DutchTreat.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DutchTreat.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace DutchTreat
{
    public class Startup
    {
        private readonly IConfiguration _config;
        public Startup(IConfiguration config)
        {
            _config = config;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IMailService, NullMailService>();
            services.AddControllersWithViews();
            services.AddRazorPages(); // needed this for razor pages redirection to work, not part of the course, possible as using newer version of dotnetcore (3.1)
            services.AddDbContext<DutchContext>(cfg =>
            {
                cfg.UseNpgsql(_config.GetConnectionString("DutchConnectionString"));
            });

            services.AddTransient<DutchSeeder>();
            services.AddScoped<IDutchRepository, DutchRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            // app.UseDefaultFiles();  not needed when using MVC
            app.UseStaticFiles(); // only delivers files from wwwroot   
            // add from nuget using: dotnet add package OdeToCode.UseNodeModules --version 3.0.0, allows use of node_modules in html
            // this didn't work for me used the library in the wwwroot/lib directory instead
            // app.UseNodeModules(); 
            app.UseRouting();
            app.UseEndpoints(cfg =>
            {
                cfg.MapControllerRoute("Default",
                    "{controller}/{action}/{id?}",
                    new {controller = "App", Action = "Index"});
                cfg.MapRazorPages(); // needed to redirect to razor error page, not part of the course which runs on older version (3.0 vs 3.1)
            });
        }
    }
}