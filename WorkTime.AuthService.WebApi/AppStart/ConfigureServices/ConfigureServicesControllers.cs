using Microsoft.Extensions.DependencyInjection;

namespace WorkTime.AuthService.WebApi.AppStart.ConfigureServices
{
    /// <summary>
    /// Класс устанавливающий конфигурацию контроллеров
    /// </summary>
    public static class ConfigureServicesControllers
    {
        /// <summary>
        /// Конфигурация контроллеров
        /// </summary>
        /// <param name="services">Коллекция сервисов</param>
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
        }
    }
}
