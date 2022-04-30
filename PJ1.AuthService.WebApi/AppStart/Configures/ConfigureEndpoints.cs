using Microsoft.AspNetCore.Builder;

namespace PJ1.AuthService.WebApi.AppStart.Configures
{
    /// <summary>
    /// Класс для настройки источника информации
    /// </summary>
    public static class ConfigureEndpoints
    {
        /// <summary>
        /// Настроить маршрутизацию, Cors, и т.д.
        /// </summary>
        /// <param name="app"></param>
        public static void Configure(IApplicationBuilder app)
        {
            app.UseStaticFiles();

            app.UseRouting();
            app.UseCors("CorsPolicy");
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseIdentityServer();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}