using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Sandbox.Shared.Api.ErrorHandling;
using Sandbox.Shared.Api.Logging;
using Sandbox.Shared.Api.Security;
using Serilog;

namespace Sandbox.Shared.Api
{
    public static class ConfigureCommonExtensions
    {
        public static void ConfigureCommonMiddleWare(this IApplicationBuilder app, IWebHostEnvironment env,
            ILoggerFactory loggerFactory,
            string swaggerEndPointUrl, string swaggerEndpointName)
        {
            if (env.IsAnyDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            if (!env.IsProduction())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint(swaggerEndPointUrl, swaggerEndpointName);
                    c.RoutePrefix = string.Empty;
                    c.OAuthClientId(Constants.Idp.ClientId.SandboxSwagger);
                    c.OAuthUsePkce();
                });
            }

            app.UseSerilogRequestLogging();

            app.ConfigureExceptionHandler(loggerFactory);

            app.UseMiddleware<RateLimiterMiddleware>();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCorsPolicy();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseMiddleware<ThreadPrincipalMiddleware>();

            app.UseMiddleware<EnrichLogFromContextMiddleware>();

        }
    }
}