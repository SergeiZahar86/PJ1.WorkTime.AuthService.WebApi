using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using WorkTime.AuthService.WebApi.AppStart.ConfigureServices;

namespace WorkTime.AuthService.WebApi.AppStart.Configures
{
    /// <summary>
    /// Pipeline configuration
    /// </summary>
    public static class ConfigureCommon
    {
        /// <summary>
        /// Configure pipeline
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public static void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //app.UseSwagger();
            //app.UseSwaggerUI(ConfigureServicesSwagger.SwaggerSettings);
            //app.UseHttpsRedirection();
        }
    }
}
