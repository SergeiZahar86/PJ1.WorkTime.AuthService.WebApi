using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PJ1.AuthService.WebApi.Infrastructure;
using PJ1.AuthService.Data.Models;

namespace PJ1.AuthService.WebApi.AppStart.ConfigureServices
{
    /// <summary>
    /// Регистрация и конфигурации сервисов аутентификации
    /// </summary>
    public static class ConfigureServicesAuthentication
    {
        /// <summary>
        /// Настроить аутентификацию и авторизацию.
        /// Ссылка на документацию:
        /// "https://identityserver4.readthedocs.io/en/latest/quickstarts/5_entityframework.html"
        /// </summary>
        /// <param name="services">Коллекция сервисов</param>
        /// <param name="configuration">Конфигурация</param>
        public static void ConfigureServices(IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddAuthorization();

            services.AddIdentityServer()
                //Настраивает идентификатор, чтобы использовать реализации идентификаторов ASP.NET
                .AddAspNetIdentity<AppUser>()
                //Добавляет клиентов
                .AddInMemoryClients(IdentityServerConfiguration.GetClients())
                //Добавляет ресурсы индивидуальности
                .AddInMemoryIdentityResources(IdentityServerConfiguration.GetIdentityResources())
                //Добавляет scopes.
                .AddInMemoryApiScopes(IdentityServerConfiguration.GetApiScopes())
                //Добавляет ресурсы 
                .AddInMemoryApiResources(IdentityServerConfiguration.GetApiResources())
                //Добавляет службу профиля.
                .AddProfileService<ProfileService>()
                //Устанавливает временные учетные данные.
                .AddDeveloperSigningCredential();

            //Устанавливает учетные данные.
            //.AddSigningCredential(certificate);
        }
    }
}