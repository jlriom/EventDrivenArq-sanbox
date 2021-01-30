using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Sandbox.Emailer.Application.Processes;
using Sandbox.Emailer.Core;
using Sandbox.Emailer.Infrastructure;
using Sandbox.Shared.Api;
using Sandbox.Shared.Messaging.RabbitMq;

namespace Sandbox.EMailer.Api
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
            services.AddTransient<IEmailSender, EmailSender>();

            services.AddCommonServices(
                Configuration,
                Shared.Api.Constants.Idp.Api.EmailerApi,
                MayorVersion,
                MinorVersion,
                typeof(Startup)
                );

            services.AddMessagingServices(Configuration, new MessagingConfiguration());

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