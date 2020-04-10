using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using DutchTreat.Data;
using Microsoft.AspNetCore;
using Microsoft.Extensions.DependencyInjection;


namespace DutchTreat
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);
            SeedDb(host);
            host.Run();
        }

        private static void SeedDb(IWebHost host)
        {
            var scopeFactory = host.Services.GetService<IServiceScopeFactory>();
            using (var scope = scopeFactory.CreateScope())
            {
                var seeder = scope.ServiceProvider.GetService<DutchSeeder>();
                seeder.Seed();
            }
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                // .ConfigureAppConfiguration(SetupConfiguration)
                .ConfigureAppConfiguration(SetupConfiguration)
                .UseStartup<Startup>()
                .Build();
               
  

        private static void SetupConfiguration(WebHostBuilderContext ctx, IConfigurationBuilder builder)
        {
            // Remove the default configuration options
            builder.Sources.Clear();
            
            // configuration can be read from these sources, the list is hierarchical with last taking precedent
            builder.AddJsonFile("config.json", false, true)
                // not going to use xml so commenting out for now.
                // .AddXmlFile("config.xml", true)
                
                .AddEnvironmentVariables();
        }
    }
}
