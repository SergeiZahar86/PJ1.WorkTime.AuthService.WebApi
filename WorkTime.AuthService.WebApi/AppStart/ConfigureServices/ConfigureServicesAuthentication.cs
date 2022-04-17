using IdentityServer4.AspNetIdentity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WorkTime.AuthSerice.Data.Models;
using WorkTime.AuthService.WebApi.AppStart;
using WorkTime.AuthService.WebApi.Infrastructure;

namespace WorkTime.AuthService.WebApi.AppStart.ConfigureServices
{
    /// <summary>
    /// ASP.NET Core services registration and configurations
    /// Authentication path
    /// </summary>
    public static class ConfigureServicesAuthentication
    {
        /// <summary>
        /// Настроить аутентификацию и авторизацию
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthorization();

            services.AddIdentityServer()
                //.AddAspNetIdentity<IdentityUser>()
                .AddAspNetIdentity<AppUser>()
                .AddInMemoryClients(IdentityServerConfiguration.GetClients())
                .AddInMemoryApiResources(IdentityServerConfiguration.GetApiResources())
                .AddInMemoryIdentityResources(IdentityServerConfiguration.GetIdentityResources())
                .AddInMemoryApiScopes(IdentityServerConfiguration.GetApiScopes()) 
                .AddProfileService<ProfileService>()
                // .AddSigningCredential(certificate);
                .AddDeveloperSigningCredential();
        }
    }
}
