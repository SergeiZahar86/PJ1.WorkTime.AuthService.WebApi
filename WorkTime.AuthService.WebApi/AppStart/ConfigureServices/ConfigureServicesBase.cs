using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WorkTime.AuthSerice.Data;
using WorkTime.AuthSerice.Data.Models;

namespace WorkTime.AuthService.WebApi.AppStart.ConfigureServices
{
    public static class ConfigureServicesBase
    {
        /// <summary>
        /// ConfigureServices Services
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(config =>
                {
                    //config.UseSqlServer(configuration.GetConnectionString(nameof(ApplicationDbContext)));
                    config.UseNpgsql(configuration.GetConnectionString(nameof(ApplicationDbContext)));
                })

                //.AddIdentity<IdentityUser, IdentityRole>(config =>
                .AddIdentity<AppUser, AppRole>(config =>
                {
                    config.Password.RequireDigit = false;
                    config.Password.RequireLowercase = false;
                    config.Password.RequireNonAlphanumeric = false;
                    config.Password.RequireUppercase = false;
                    config.Password.RequiredLength = 4;
                })
                .AddEntityFrameworkStores<ApplicationDbContext>();


            services.ConfigureApplicationCookie(config => { config.Cookie.Name = "IdentityServer.Cookies"; });
            services.AddControllers();
        }
        
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(config =>
                {
                    //config.UseSqlServer(configuration.GetConnectionString(nameof(ApplicationDbContext)));
                    config.UseNpgsql("Host=localhost;Port=5432;Database=MY_Project_11_04_22;Username=postgres;Password=2712");
                })

                //.AddIdentity<IdentityUser, IdentityRole>(config =>
                .AddIdentity<AppUser, AppRole>(config =>
                {
                    config.Password.RequireDigit = false;
                    config.Password.RequireLowercase = false;
                    config.Password.RequireNonAlphanumeric = false;
                    config.Password.RequireUppercase = false;
                    config.Password.RequiredLength = 4;
                })
                .AddEntityFrameworkStores<ApplicationDbContext>();


            services.ConfigureApplicationCookie(config => { config.Cookie.Name = "IdentityServer.Cookies"; });
            services.AddControllers();
        }
    }
}