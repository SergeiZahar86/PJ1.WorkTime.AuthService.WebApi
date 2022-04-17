using Microsoft.Extensions.DependencyInjection;

namespace WorkTime.AuthService.WebApi.AppStart.ConfigureServices
{
    /// <summary>
    /// Configure controllers
    /// </summary>
    public static class ConfigureServicesControllers
    {
        /// <summary>
        /// Configure services
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
        }
    }
}
