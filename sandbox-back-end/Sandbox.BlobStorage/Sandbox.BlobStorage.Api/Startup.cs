using Common.Application.Cqs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Sandbox.BlobStorage.ReadStack.Application.QueryHandlers;
using Sandbox.BlobStorage.ReadStack.Core;
using Sandbox.BlobStorage.ReadStack.Infrastructure;
using Sandbox.BlobStorage.WriteStack.Application.CommandHandlers;
using Sandbox.BlobStorage.WriteStack.Domain;
using Sandbox.BlobStorage.WriteStack.Infrastructure;
using Sandbox.Shared.Api;
using Sandbox.Shared.Api.Configuration;
using Sandbox.Shared.Data.Blob.EntityFrameworkCore;

namespace Sandbox.BlobStorage.Api
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
            services.AddDbContext<BlobDocumentDbContext>(options =>
                options.UseSqlServer(Configuration.GetValue<string>(ConfigurationKeys.BlobSqlConnectionStringName)));

            services.AddScoped<IBlobReadonlyRepository, BlobReadonlyRepository>();

            services.AddScoped<IBlobRepository, BlobRepository>();
            services.AddScoped<IBlobUnitOfWork, BlobUnitOfWork>();

            services.AddCommonServices(
                Configuration,
                Shared.Api.Constants.Idp.Api.BlobStorageApi,
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