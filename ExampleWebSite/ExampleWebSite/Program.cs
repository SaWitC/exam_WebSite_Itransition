using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExampleWebSite.Data;
using Microsoft.AspNetCore.Identity;
using ExampleWebSite.Models;

namespace ExampleWebSite
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();


            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<ExamWebSiteDBContext>();

                    //var userManager = services.GetRequiredService<UserManager<User>>();//initialse admin
                    //var rolesManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                    //await RoleInitialiser.Initialiser(userManager, rolesManager);
                    var userManager = services.GetRequiredService<UserManager<User>>();//initialse admin
                    var rolesManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                    await AdminAccountInitialise.Initialiser(userManager,rolesManager);

                    SampleDate.InitialiseThemes(context);//initialse category
                }
                catch (Exception ex)
                {
                    var loger = services.GetRequiredService<ILogger<Program>>();
                    loger.LogError(ex, "Error in system");
                }
            }
            host.Run();

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
