using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WorkTime.AuthSerice.Data;
using WorkTime.AuthSerice.Data.Models;

namespace WorkTime.AuthService.WebApi.AppStart.ConfigureServices
{
    /// <summary>
    /// Класс устанавливающий регистрацию и конфигурацию базовых сервисов
    /// </summary>
    public static class ConfigureServicesBase
    {
        /// <summary>
        /// Регистрация и конфигурации базовых сервисов
        /// </summary>
        /// <param name="services">Коллекция сервисов</param>
        /// <param name="configuration">Конфигурация</param>
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
                    //Получает или задает флаг, указывающий, что пароли должны
                    //содержать цифру. По умолчанию true.
                    config.Password.RequireDigit = false;
                    //Получает или задает флаг, указывающий, что пароли должны содержать
                    //символ нижнего региона ASCII. По умолчанию true.
                    config.Password.RequireLowercase = false;
                    //Получает или задает флаг, указывающий, что пароли должны содержать
                    //не буквенно-цифровой символ. По умолчанию true.
                    config.Password.RequireNonAlphanumeric = false;
                    //Получает или задает флаг, указывающий, что пароли должны содержать
                    //верхний символ ASCII. По умолчанию true.
                    config.Password.RequireUppercase = false;
                    //Получает или устанавливает минимальную длину, который должен
                    //быть пароль. По умолчанию до 6.
                    config.Password.RequiredLength = 4;
                })
                .AddEntityFrameworkStores<ApplicationDbContext>();

            // Настраивает приложение cookie
            services.ConfigureApplicationCookie(config =>
            {
                config.Cookie.Name = "IdentityServer.Cookies";
            });
            // Добавляет сервисы для контроллеров.
            // Этот метод не будет регистрировать службы, используемые для views или страниц.
            //services.AddControllers();
        }
    }
}