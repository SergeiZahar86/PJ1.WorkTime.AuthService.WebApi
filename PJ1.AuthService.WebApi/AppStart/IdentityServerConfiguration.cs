using System.Collections.Generic;
using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using static IdentityServer4.IdentityServerConstants;

namespace PJ1.AuthService.WebApi.AppStart
{
    /// <summary>
    /// Класс устанавливает конфигурацию IdentityServer
    /// </summary>
    public static class IdentityServerConfiguration
    {
        /// <summary>
        /// URL клиента
        /// </summary>
        private static string spaClientUrl = "https://localhost:10003";

        /// <summary>
        /// Добавляет список клиентов (настройка подключенных клиентов)
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Client> GetClients() =>
            new List<Client>
            {
                // Фронтэнд клиент
                new Client
                {
                    ClientId = "client_angular",
                    ClientName = "SPA by Angular Code Client",
                    AccessTokenType = AccessTokenType.Jwt,
                    //RequireConsent = false,
                    AccessTokenLifetime = 20, // 330 seconds, default 60 minutes
                    IdentityTokenLifetime = 20,
                    RequireClientSecret = false,
                    AllowedGrantTypes = GrantTypes.Code,
                    RequirePkce = true,
                    AllowAccessTokensViaBrowser = true,
                    AllowedCorsOrigins =
                    {
                        $"{spaClientUrl}",
                        "https://localhost:4200"
                    },
                    RedirectUris =
                    {
                        $"{spaClientUrl}/counter",
                        $"{spaClientUrl}/fetch-data",
                        $"{spaClientUrl}/silent-renew.html",
                        $"{spaClientUrl}/silent-refresh.html",
                        "https://localhost:4200",
                        "https://localhost:4200/silent-renew.html",
                        "https://localhost:4200/silent-refresh.html",
                    },
                    PostLogoutRedirectUris =
                    {
                        $"{spaClientUrl}/counter",
                        $"{spaClientUrl}/fetch-data",
                        $"{spaClientUrl}/unauthorized",
                        $"{spaClientUrl}",
                        "https://localhost:4200/unauthorized",
                        "https://localhost:4200"
                    },
                    AllowedScopes =
                    {
                        //"OrdersAPI",
                        "SwaggerAPI",
                        StandardScopes.OpenId,
                        StandardScopes.Profile
                    }
                },

                // Клиент с бизнес логикой
                new Client
                {
                    ClientId = "client_business",
                    ClientSecrets = {new Secret("client_secret_swagger".ToSha256())},
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    AllowedCorsOrigins = {"https://localhost:7001"},
                    AllowedScopes =
                    {
                        "SwaggerAPI",
                        StandardScopes.OpenId,
                        StandardScopes.Profile,
                        //"roles"
                    },
                    AlwaysIncludeUserClaimsInIdToken = true,
                    UpdateAccessTokenClaimsOnRefresh = true
                }
            };

        /// <summary>
        /// Получение (указание) API ресурсов которые могут взаимодействовать c 
        /// сервером авторизации. Название ресурсов указываются в GetClients() =>
        /// new Client => AllowedScopes
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<ApiResource> GetApiResources()
        {
            var list = new List<ApiResource>();
            //list.Add(new ApiResource("SwaggerAPI", "API Application"));
            list.Add(new ApiResource("SwaggerAPI", "API Application")
            {
                Scopes = {"SwaggerAPI"}
            });
            //new ApiResource("OrdersAPI"),
            //new ApiResource("roles", "My Roles", new[] { "role", "name" }),
            //new ApiResource(LocalApi.ScopeName, "Local Api", new [] { JwtClaimTypes.Role }),
            return list;
        }

        /// <summary>
        /// Запрос утверждений (Scopes) о пользователе.
        /// Ссылка на документацию:
        /// "https://identityserver4.readthedocs.io/en/latest/quickstarts/2_interactive_aspnetcore.html#:~:text=not%20registered%20yet.-,Adding%20support%20for%20OpenID%20Connect%20Identity%20Scopes,-Similar%20to%20OAuth"
        /// </summary>
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                // сообщает провайдеру о необходимости возврата утверждения sub (идентификатора
                // субъекта) в токене идентификации.
                new IdentityResources.OpenId(),
                // представляет отображаемое имя, адрес электронной почты и утверждение веб-сайта и тд.
                new IdentityResources.Profile(),
            };
        }

        /// <summary>
        /// IdentityServer4 version 4.x.x changes
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<ApiScope> GetApiScopes()
        {
            return new List<ApiScope>
            {
                new ApiScope("SwaggerAPI", "Swagger API")
            };
        }
    }
}