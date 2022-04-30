using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using PJ1.AuthService.WebApi.AppStart.ConfigureServices;

namespace PJ1.AuthService.WebApi.AppStart.Configures
{
    /// <summary>
    /// Класс с общими настройками
    /// </summary>
    public static class ConfigureCommon
    {
        /// <summary>
        /// Задает общие настройки
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public static void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //Зарегистрируйте промежуточное программное обеспечение Swagger с
            //дополнительным действием настроек для параметров Di-Injected
            //app.UseSwagger();

            //Зарегистрируйте промежуточное программное обеспечение SwaggerUi с
            //дополнительным действием настроек для параметров Di-Injected
            //app.UseSwaggerUI(ConfigureServicesSwagger.SwaggerSettings);

            //Добавляет промежуточное программное обеспечение для перенаправления
            //HTTP-запросов к HTTPS.
            //app.UseHttpsRedirection();
        }
    }
}