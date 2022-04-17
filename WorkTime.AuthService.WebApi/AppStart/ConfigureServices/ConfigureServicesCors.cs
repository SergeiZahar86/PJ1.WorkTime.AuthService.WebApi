using Microsoft.Extensions.DependencyInjection;

namespace WorkTime.AuthService.WebApi.AppStart.ConfigureServices
{
    /// <summary>
    /// Cors configurations
    /// </summary>
    public class ConfigureServicesCors
    {
        /// <summary>
        /// ConfigureServices
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                {
                    builder.AllowAnyOrigin();
                    builder.AllowAnyHeader();
                    builder.AllowAnyMethod();
                    //builder.AllowCredentials();
                    //builder.WithOrigins("http://localhost:4200");

                });
            });
        }
    }
}