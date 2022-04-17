using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkTime.AuthSerice.Data.DatabaseInitialization;

namespace WorkTime.AuthService.WebApi
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            // Обработка значений даты и времени для PostgreSQL (для MsSql закомментировать)
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            
            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                await DatabaseInitializer.InitAsync(scope.ServiceProvider);
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
