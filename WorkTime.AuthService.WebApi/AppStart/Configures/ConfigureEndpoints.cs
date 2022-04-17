using Microsoft.AspNetCore.Builder;

namespace WorkTime.AuthService.WebApi.AppStart.Configures
{
    /// <summary>
    /// Configure pipeline
    /// </summary>
    public static class ConfigureEndpoints
    {
        /// <summary>
        /// Configure Routing
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
