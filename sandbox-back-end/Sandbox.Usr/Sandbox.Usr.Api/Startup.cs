using Common.Application.Cqs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Sandbox.Shared.Api;
using Sandbox.Usr.ReadStack.Application.QueryHandlers;
using Sandbox.Usr.WriteStack.Application.CommandHandlers;

namespace Sandbox.Usr.Api
{
    public class Startup
    {
        private const int MayorVersion = 1, MinorVersion = 0;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCommonServices(
                Configuration,
                Shared.Api.Constants.Idp.Api.UsrApi,
                MayorVersion,
                MinorVersion,
                typeof(Startup),
                typeof(QueryHandlersReference),
                typeof(CommandHandlersReference)
                );
            services.AddCqsServices(typeof(QueryHandlersReference), typeof(CommandHandlersReference));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            app.ConfigureCommonMiddleWare(env, loggerFactory, $"/swagger/v{MayorVersion}/swagger.json",
                typeof(Startup).Assembly.GetName().Name);


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHealthChecks("/health");
                endpoints.MapControllers();
            });
        }
    }
}