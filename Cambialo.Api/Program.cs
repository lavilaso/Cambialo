using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cambialo.Api.Data;
using Cambialo.Api.Data.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Cambialo.Api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var hostingEnvironment = services.GetService<IWebHostEnvironment>();

                //TODO: Probablemente la mejor opcion sea agregar las migraciones antes de el seeding, es necesario migrar en dev y produccion

                if (hostingEnvironment.IsDevelopment())
                {
                    var userManager = services.GetRequiredService<UserManager<User>>();
                    var roleManager = services.GetRequiredService<RoleManager<IdentityRole<Guid>>>();
                    var dbContext = services.GetRequiredService<ApplicationDbContext>();

                    await Seed.InitializeAsync(userManager, roleManager, dbContext);
                }
                else if (hostingEnvironment.IsProduction())
                {
                    //TODO: Agregar logica para realizar migraciones al pasar a produccion
                }
            }
            await host.RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
