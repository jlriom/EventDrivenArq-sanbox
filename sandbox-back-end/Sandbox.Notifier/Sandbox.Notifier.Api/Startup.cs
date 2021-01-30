using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Sandbox.Notifier.Application.Processes;
using Sandbox.Notifier.Application.Processes.Hubs;
using Sandbox.Shared.Api;
using Sandbox.Shared.Messaging.RabbitMq;

namespace Sandbox.Notifier.Api
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
                Shared.Api.Constants.Idp.Api.NotifierApi,
                MayorVersion,
                MinorVersion,
                typeof(Startup)
                );

            services.AddMessagingServices(Configuration, new MessagingConfiguration());
            services.AddSignalR();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            app.ConfigureCommonMiddleWare(env, loggerFactory, $"/swagger/v{MayorVersion}/swagger.json",
                typeof(Startup).Assembly.GetName().Name);


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHealthChecks("/health");
                endpoints.MapControllers();
                endpoints.MapHub<NotificationHub>("/notificationhub");
            });
        }
    }
}