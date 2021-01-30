using Common.Application.Clock;
using Common.Application.Cqs;
using Common.Application.Services.BlobStorage;
using Common.Application.Services.BlobStorage.Adapters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;
using Sandbox.Doc.Api.HttpHandlers;
using Sandbox.Doc.ReadStack.Application.QueryHandlers;
using Sandbox.Doc.ReadStack.Core;
using Sandbox.Doc.ReadStack.Infrastructure;
using Sandbox.Doc.WriteStack.Application.CommandHandlers;
using Sandbox.Doc.WriteStack.Application.Processes;
using Sandbox.Doc.WriteStack.Domain.Documents;
using Sandbox.Doc.WriteStack.Domain.Emails;
using Sandbox.Doc.WriteStack.Domain.Notifications;
using Sandbox.Doc.WriteStack.Domain.Services;
using Sandbox.Doc.WriteStack.Infrastructure;
using Sandbox.Doc.WriteStack.Infrastructure.Documents;
using Sandbox.Doc.WriteStack.Infrastructure.Emails;
using Sandbox.Doc.WriteStack.Infrastructure.Notifications;
using Sandbox.Doc.WriteStack.Infrastructure.Services;
using Sandbox.Shared.Api;
using Sandbox.Shared.Data.Documents.EntityFrameworkCore;
using Sandbox.Shared.Messaging.RabbitMq;
using System;
using System.Net.Http;
using SharedConfigurationKeys = Sandbox.Shared.Api.Configuration.ConfigurationKeys;

namespace Sandbox.Doc.Api
{
    public class Startup
    {
        private const int MayorVersion = 1, MinorVersion = 0;

        public Startup(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            Configuration = configuration;
            WebHostEnvironment = webHostEnvironment;
        }

        private IConfiguration Configuration { get; }

        public IWebHostEnvironment WebHostEnvironment { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IClock, SystemClock>();

            services.AddDbContext<DocumentsDbContext>(options =>
                options.UseSqlServer(Configuration.GetValue<string>(SharedConfigurationKeys.DocSqlConnectionStringName)));

            services.AddScoped<IDocumentReadonlyRepository, DocumentReadonlyRepository>();

            services.AddScoped<IDocumentRepository, DocumentRepository>();
            services.AddScoped<IDocumentUnitOfWork, DocumentUnitOfWork>();

            services.AddScoped<IDocumentClientUrlProvider>(provider
                => new DocumentClientUrlProvider(
                    Configuration.GetValue<string>(SharedConfigurationKeys.DocPortalUrl)));

            services.AddScoped<IEmailProviderFactory, EmailProviderFactory>();
            services.AddScoped<INotificationProviderFactory, NotificationProviderFactory>();

            services.AddHttpContextAccessor();

            services.AddTransient<BearerTokenHandler>();

            services.AddHttpClient(Constants.BlobApiHttpClientName, client =>
            {
                client.BaseAddress = new Uri(Configuration.GetValue<string>(SharedConfigurationKeys.BlobApiUrl));
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
            })
            .AddHttpMessageHandler<BearerTokenHandler>();

            services.AddHttpClient(Constants.IpdHttpClientName, client =>
            {
                client.BaseAddress = new Uri(Configuration.GetValue<string>(SharedConfigurationKeys.AuthorityUrl));
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
            });

            services.AddScoped<IBlobStorageClient, RestClientAdapter>(provider =>
            {
                var httpClientFactory = provider.GetRequiredService<IHttpClientFactory>();
                return new RestClientAdapter(httpClientFactory, Constants.BlobApiHttpClientName, Constants.BlobApiBasePath);
            });


            services.AddCommonServices(
                Configuration,
                Shared.Api.Constants.Idp.Api.DocApi,
                MayorVersion,
                MinorVersion,
                typeof(Startup),
                typeof(QueryHandlersReference),
                typeof(CommandHandlersReference),
                typeof(DocDomainInfrastructureReference)
                );

            services.AddCqsServices(typeof(QueryHandlersReference), typeof(CommandHandlersReference));

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