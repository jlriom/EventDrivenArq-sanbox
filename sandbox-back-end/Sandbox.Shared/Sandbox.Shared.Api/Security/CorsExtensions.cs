using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Sandbox.Shared.Api.Security
{
    public static class CorsExtensions
    {
        private static readonly string CorsPolicyName = "CorsPolicyName";

        public static void AddCorsPolicy(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddCors(SetupCorsAction());
        }

        public static void UseCorsPolicy(this IApplicationBuilder app)
        {
            app.UseCors(CorsPolicyName);
        }

        private static Action<CorsOptions> SetupCorsAction()
        {
            return options =>
            {
                options.AddPolicy(CorsPolicyName,
                    builder =>
                    {
                        builder
                            .AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            };
        }
    }
}