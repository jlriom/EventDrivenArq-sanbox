using AutoMapper;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Sandbox.Shared.Api.Configuration;
using Sandbox.Shared.Api.Security;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sandbox.Shared.Api
{
    public static class ConfigureCommonServicesExtensions
    {
        public static void AddCommonServices(this IServiceCollection services,
            IConfiguration configuration,
            string apiScope,
            int mayorVersion, int minorVersion, params Type[] autoMapReferenceTypes)
        {
            services.AddSingleton(Log.Logger);
            services.AddMemoryCache();
            services.AddCorsPolicy();
            services.AddHealthChecks();

            services.AddApplicationInsightsTelemetry(
                configuration.GetValue<string>(ConfigurationKeys.ApplicationInsightsInstrumentationKey));


            var dbConnectionStrings = new[]
            {
                configuration.GetConnectionString(ConfigurationKeys.SystemSqlConnectionStringName),
                configuration.GetValue<string>(ConfigurationKeys.BlobSqlConnectionStringName),
                configuration.GetValue<string>(ConfigurationKeys.UserSqlConnectionStringName),
                configuration.GetValue<string>(ConfigurationKeys.DocSqlConnectionStringName)
            }.Distinct().ToList();

            foreach (var dbConnectionString in dbConnectionStrings)
            {
                services.AddHealthChecks().AddSqlServer(dbConnectionString);
            }

            string authorityUrl = configuration.GetValue<string>(ConfigurationKeys.AuthorityUrl);
            string apiName = $"{authorityUrl}/resources";

            services
                .AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
                .AddIdentityServerAuthentication(identityServerAuthenticationOptions =>
                {
                    identityServerAuthenticationOptions.Authority = authorityUrl;
                    identityServerAuthenticationOptions.ApiName = apiName;
                });

            services.AddAutoMapper(autoMapReferenceTypes);
            services.AddControllers();
            services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(mayorVersion, minorVersion);
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ReportApiVersions = true;
            });
            services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.OAuth2,
                    Flows = new OpenApiOAuthFlows
                    {
                        AuthorizationCode = new OpenApiOAuthFlow
                        {
                            AuthorizationUrl = new Uri($"{authorityUrl}/connect/authorize"),
                            TokenUrl = new Uri($"{authorityUrl}/connect/token"),
                            Scopes = new Dictionary<string, string>
                            {
                                {apiScope, "Api Access"}
                            }
                        }
                    }
                });

                options.OperationFilter<AuthorizeCheckOperationFilter>(apiScope);
            });
        }
    }
}