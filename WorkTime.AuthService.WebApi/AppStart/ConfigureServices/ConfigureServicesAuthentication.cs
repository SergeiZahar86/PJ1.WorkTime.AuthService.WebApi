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
    /// Регистрация и конфигурации сервисов аутентификации
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
                //Настраивает идентификатор, чтобы использовать реализации идентификаторов ASP.NET
                .AddAspNetIdentity<AppUser>()
                //Добавляет клиентов
                .AddInMemoryClients(IdentityServerConfiguration.GetClients())
                //Добавляет ресурсы 
                .AddInMemoryApiResources(IdentityServerConfiguration.GetApiResources())
                //Добавляет ресурсы индивидуальности
                .AddInMemoryIdentityResources(IdentityServerConfiguration.GetIdentityResources())
                //Добавляет scopes.
                .AddInMemoryApiScopes(IdentityServerConfiguration.GetApiScopes()) 
                //Добавляет службу профиля.
                .AddProfileService<ProfileService>()
                //Устанавливает временные учетные данные.
                .AddDeveloperSigningCredential();
            
                //Устанавливает учетные данные.
                //.AddSigningCredential(certificate);

        }
    }
}
