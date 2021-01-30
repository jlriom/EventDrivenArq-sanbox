using IdentityServer4;
using IdentityServer4.Models;
using Microsoft.Extensions.Configuration;
using Sandbox.Shared.Api.Configuration;
using System.Collections.Generic;
using System.Linq;

namespace Sandbox.Idp
{
    public static class Config
    {
        private static readonly string[] ApiScopeRequestedClaims = { "role", "email" };
        private static readonly string RolesScope = "roles";

        public static IEnumerable<IdentityResource> IdentityResources =>
            new[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Address(),
                new IdentityResources.Email(),
                new IdentityResource(RolesScope, RolesScope, ApiScopeRequestedClaims)
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new[]
            {
                new ApiScope(Shared.Api.Constants.Idp.Api.BlobStorageApi, ApiScopeRequestedClaims),
                new ApiScope(Shared.Api.Constants.Idp.Api.ConsoleApi, ApiScopeRequestedClaims),
                new ApiScope(Shared.Api.Constants.Idp.Api.DocApi, ApiScopeRequestedClaims),
                new ApiScope(Shared.Api.Constants.Idp.Api.EmailerApi, ApiScopeRequestedClaims),
                new ApiScope(Shared.Api.Constants.Idp.Api.NotifierApi, ApiScopeRequestedClaims),
                new ApiScope(Shared.Api.Constants.Idp.Api.UsrApi, ApiScopeRequestedClaims)
            };

        public static IEnumerable<Client> GetClients(IConfiguration configuration)
        {
            return new[]
{
                ClientFactory.Create(
                    "Sandbox Admin portal",
                    Shared.Api.Constants.Idp.ClientId.SandboxAdminPortal,
                    configuration.GetValue<string>(ConfigurationKeys.AdminPortalUrl),
                    new []
                    {
                        Shared.Api.Constants.Idp.Api.UsrApi,
                        Shared.Api.Constants.Idp.Api.ConsoleApi,
                        Shared.Api.Constants.Idp.Api.EmailerApi,
                        Shared.Api.Constants.Idp.Api.NotifierApi
                    }),

                ClientFactory.Create(
                    "Sandbox Doc portal",
                    Shared.Api.Constants.Idp.ClientId.SandboxDocPortal,
                    configuration.GetValue<string>(ConfigurationKeys.DocPortalUrl),
                    new []{ Shared.Api.Constants.Idp.Api.DocApi}),


                ClientFactory.Create(
                    Shared.Api.Constants.Idp.ClientId.SandboxDocApi,
                    Shared.Api.Constants.Idp.Api.BlobStorageApi),

                new Client
                {
                    ClientId =  Shared.Api.Constants.Idp.ClientId.SandboxSwagger,
                    ClientName = "Swagger UI access",
                    ClientSecrets =
                    {
                        new Secret(Shared.Api.Constants.Idp.Api.ApiSecret.Sha256())
                    },

                    AllowedGrantTypes = GrantTypes.Code,
                    RequirePkce = true,
                    RequireClientSecret = false,

                    RedirectUris =
                    {
                        $"{configuration.GetValue<string>(ConfigurationKeys.BlobApiUrl)}/oauth2-redirect.html",
                        $"{configuration.GetValue<string>(ConfigurationKeys.ConsoleApiUrl)}/oauth2-redirect.html",
                        $"{configuration.GetValue<string>(ConfigurationKeys.DocApiUrl)}/oauth2-redirect.html",
                        $"{configuration.GetValue<string>(ConfigurationKeys.EMailerApiUrl)}/oauth2-redirect.html",
                        $"{configuration.GetValue<string>(ConfigurationKeys.NotifierApiUrl)}/oauth2-redirect.html",
                        $"{configuration.GetValue<string>(ConfigurationKeys.UsrApiUrl)}/oauth2-redirect.html",
                    },
                    AllowedCorsOrigins =
                    {
                        configuration.GetValue<string>(ConfigurationKeys.BlobApiUrl),
                        configuration.GetValue<string>(ConfigurationKeys.ConsoleApiUrl),
                        configuration.GetValue<string>(ConfigurationKeys.DocApiUrl),
                        configuration.GetValue<string>(ConfigurationKeys.EMailerApiUrl),
                        configuration.GetValue<string>(ConfigurationKeys.NotifierApiUrl),
                        configuration.GetValue<string>(ConfigurationKeys.UsrApiUrl)
                    },
                    AllowedScopes =
                    {
                        Shared.Api.Constants.Idp.Api.DocApi,
                        Shared.Api.Constants.Idp.Api.UsrApi,
                        Shared.Api.Constants.Idp.Api.ConsoleApi,
                        Shared.Api.Constants.Idp.Api.EmailerApi,
                        Shared.Api.Constants.Idp.Api.NotifierApi,
                        Shared.Api.Constants.Idp.Api.BlobStorageApi,
                        IdentityServerConstants.StandardScopes.Email
                    }
                }
            };
        }

        private static class ClientFactory
        {
            public static Client Create(string clientId, string allowedScope)
            {
                return new Client
                {
                    ClientId = clientId,
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets =
                    {
                        new Secret(Shared.Api.Constants.Idp.Api.ApiSecret.Sha256())
                    },
                    AllowedScopes = { allowedScope, IdentityServerConstants.StandardScopes.Email }
                };
            }

            public static Client Create(string clientName, string clientId, string url, IEnumerable<string> allowedScopes)
            {
                var standardAllowedScopes = new string[]
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    IdentityServerConstants.StandardScopes.Address,
                    IdentityServerConstants.StandardScopes.Email,
                    RolesScope
                };

                return new Client
                {
                    ClientName = clientName,
                    ClientId = clientId,
                    AllowedGrantTypes = GrantTypes.Code,
                    RequirePkce = true,
                    RedirectUris = new List<string>
                    {
                        $"{url}/{Shared.Api.Constants.Idp.ClientId.RedirectUri}"
                    },
                    PostLogoutRedirectUris =
                    {
                        $"{url}/{Shared.Api.Constants.Idp.ClientId.PostLogoutRedirectUri}"
                    },
                    AllowedScopes = standardAllowedScopes.Union(allowedScopes).ToList(),
                    RequireClientSecret = false,
                    RequireConsent = false,
                    AllowOfflineAccess = true,
                    AllowAccessTokensViaBrowser = true,
                    RefreshTokenExpiration = TokenExpiration.Sliding,
                    AllowedCorsOrigins = { $"{url}" }
                };
            }
        }
    }
}