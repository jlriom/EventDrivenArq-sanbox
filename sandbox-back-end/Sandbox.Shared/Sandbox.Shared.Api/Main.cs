using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Sandbox.Shared.Api.Configuration;
using Sandbox.Shared.Api.Logging;
using Serilog;
using Serilog.Core;
using System;

namespace Sandbox.Shared.Api
{
    public class Main
    {
        public Main()
        {
            Log.Logger = new LoggingFactory().CreateDefault();
        }

        public Main(Logger logger)
        {
            Log.Logger = logger;
        }

        public void Start(Action<IWebHostBuilder> useStartUp, string[] args, string module)
        {

            try
            {
                Log.Information("Starting up");
                CreateHostBuilder(useStartUp, args, module).Build().Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Application start-up failed");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }


        private static IHostBuilder CreateHostBuilder(Action<IWebHostBuilder> useStartUp, string[] args, string module)
        {
            return Host.CreateDefaultBuilder(args)
                .UseSerilog()
                .ConfigureWebHostDefaults(useStartUp)
                .ConfigureAppConfiguration((builderContext, config) =>
                {
                    var configuration = config.Build();
                    config.AddSandboxConfiguration(options =>
                    {
                        options.Module = module;
                        options.ConnectionString = configuration.GetConnectionString(ConfigurationKeys.SystemSqlConnectionStringName);
                    });
                });
        }
    }
}
