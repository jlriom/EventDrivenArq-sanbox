using Common.Application.Cqs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Sandbox.Console.ReadStack.Application.QueryHandlers;
using Sandbox.Console.ReadStack.Core;
using Sandbox.Console.ReadStack.Infrastructure;
using Sandbox.Shared.Api;
using Sandbox.Shared.Api.Configuration;
using Sandbox.Shared.Data.System.EntityFrameworkCore;

namespace Sandbox.Console.Api
{
    public class Startup
    {
        private const int MayorVersion = 1, MinorVersion = 0;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {


            services.AddDbContext<SystemDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString(ConfigurationKeys.SystemSqlConnectionStringName)));

            services.AddScoped<IConfigurationSettingsService, ConfigurationSettingsService>();
            services.AddScoped<ILogReadonlyRepository, LogReadonlyRepository>();

            services.AddCommonServices(
                Configuration,
                Shared.Api.Constants.Idp.Api.ConsoleApi,
                MayorVersion,
                MinorVersion,
                typeof(QueryHandlersReference));

            services.AddCqsServices(typeof(QueryHandlersReference));

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