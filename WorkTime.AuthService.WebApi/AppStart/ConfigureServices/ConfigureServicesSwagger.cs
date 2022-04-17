using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace WorkTime.AuthService.WebApi.AppStart.ConfigureServices
{
    /// <summary>
    /// Swagger configuration
    /// </summary>
    public static class ConfigureServicesSwagger
    {
        private const string AppTitle = "Search Dialogue API ";
        private static string AppVersion = "1.0.0";
        private const string SwaggerConfig = "/swagger/v1/swagger.json";
        private const string SwaggerUrl = "api/manual";

        /// <summary>
        /// ConfigureServices Swagger services
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = AppTitle,
                    Version = AppVersion,
                    Description = "Search Dialogue API module API documentation." +
                    " This API based on ASP.NET Core 5.",

                    Contact = new OpenApiContact
                    {
                        Name = "Sergei Zakharov",
                        Email = "sergeizahargood@gmail.com",
                        Url = new Uri("https://www.instagram.com/sergeizahargood_gmail_com/")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "MY License",
                        Url = new Uri("https://www.instagram.com/")
                    }
                });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);
                //options.ResolveConflictingActions(x => x.First());

                //var url = configuration.GetSection("IdentityServer").GetValue<string>("Url");

                options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    //In = ParameterLocation.Header,
                    //Scheme = "bearer",
                    //Name = "Authorization",
                    //Description = "Authorization token",
                    Type = SecuritySchemeType.OAuth2,
                    Flows = new OpenApiOAuthFlows
                    {
                        Password = new OpenApiOAuthFlow
                        {
                            TokenUrl = new Uri("https://localhost:6001/connect/token"),
                            Scopes = new Dictionary<string, string>
                            {
                                //{ "api1", "Default scope" }
                            }
                        }
                    }
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "oauth2"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,

                        },
                        new List<string>()
                    }
                });

            });
        }

        /// <summary>
        /// properties for swagger UI
        /// </summary>
        /// <param name="settings"></param>
        public static void SwaggerSettings(SwaggerUIOptions settings)
        {
            settings.SwaggerEndpoint(SwaggerConfig, $"{AppTitle} v.{AppVersion}");
            settings.DocumentTitle = "Search Dialogue API";
            settings.RoutePrefix = "docs";
            //settings.DefaultModelExpandDepth(0);
            //settings.DefaultModelRendering(ModelRendering.Model);
            //settings.DefaultModelsExpandDepth(0);
            settings.DocExpansion(DocExpansion.List);
            settings.OAuthClientId("client_id_swagger");
            settings.OAuthScopeSeparator(" ");
            settings.OAuthClientSecret("client_secret_swagger");
            //settings.DisplayRequestDuration();
            //settings.OAuthAppName("Microservice API module API documentation");
        }
    }
}
