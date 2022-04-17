using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkTime.AuthService.WebApi.AppStart.Configures;
using WorkTime.AuthService.WebApi.AppStart.ConfigureServices;

namespace WorkTime.AuthService.WebApi
{
    public class Startup
    {


        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureServicesBase.ConfigureServices(services, Configuration);
            ConfigureServicesAuthentication.ConfigureServices(services, Configuration);
            //ConfigureServicesSwagger.ConfigureServices(services, Configuration);
            ConfigureServicesCors.ConfigureServices(services);
            ConfigureServicesControllers.ConfigureServices(services);


        }

        // Этот метод вызывается временем выполнения. Используйте
        // этот метод для настройки трубопровода HTTP-запроса
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            ConfigureCommon.Configure(app, env);
            ConfigureEndpoints.Configure(app);
        }
    }
}
