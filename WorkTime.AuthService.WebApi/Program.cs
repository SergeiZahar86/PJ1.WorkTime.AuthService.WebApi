using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using WorkTime.AuthSerice.Data.DatabaseInitialization;
using WorkTime.AuthService.WebApi.AppStart.Configures;
using WorkTime.AuthService.WebApi.AppStart.ConfigureServices;


//------- Инициализация экземпляра приложения с предкофигурацией
WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

//------- Коллекция сервисов
IServiceCollection services = builder.Services;

//------- Из метода Startup.ConfigureServices()
ConfigureServicesBase.ConfigureServices(services, builder.Configuration);
ConfigureServicesAuthentication.ConfigureServices(services, builder.Configuration);
ConfigureServicesCors.ConfigureServices(services);
ConfigureServicesControllers.ConfigureServices(services);
//ConfigureServicesSwagger.ConfigureServices(services, Configuration);

// ------ Сборка приложения
WebApplication app = builder.Build();

//------- Обработка значений даты и времени для PostgreSQL (для MsSql закомментировать)
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

//------- Инициализация начальных данных
IServiceScope scope = ((IApplicationBuilder) app).ApplicationServices.CreateScope();
await DatabaseInitializer.InitAsync(scope.ServiceProvider);

//------- из метода Startup.Configure()   
ConfigureCommon.Configure(app, app.Environment);
ConfigureEndpoints.Configure(app);

//----- Запуск
app.Run();


