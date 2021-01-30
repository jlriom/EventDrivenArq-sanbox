using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.Extensions.Configuration;
using Sandbox.Shared.Api.Configuration;
using Serilog;
using Serilog.Core;
using Serilog.Sinks.MSSqlServer.Sinks.MSSqlServer.Options;

namespace Sandbox.Shared.Api.Logging
{
    public class LoggingFactory
    {
        public Logger CreateDefault()
        {
            var config = ConfigurationHelper.GetConfiguration();

            var telemetryConfiguration = TelemetryConfiguration.CreateDefault();

            telemetryConfiguration.InstrumentationKey =
                config.GetValue<string>(ConfigurationKeys.ApplicationInsightsInstrumentationKey);

            var logDb = config.GetConnectionString(ConfigurationKeys.SystemSqlConnectionStringName);
            var sinkOpts = new SinkOptions
            {
                SchemaName = Constants.Log.LogSchemaName,
                TableName = Constants.Log.LogTableName
            };

            return new LoggerConfiguration()
                .ReadFrom.Configuration(config)
                .Enrich.WithMachineName()
                .Enrich.WithProcessId()
                .Enrich.FromLogContext()
                .WriteTo.ApplicationInsights(telemetryConfiguration, TelemetryConverter.Traces)
                .WriteTo.MSSqlServer(logDb, sinkOpts)
                .WriteTo.Console()
                .CreateLogger();
        }
    }
}