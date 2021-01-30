using Microsoft.Extensions.Configuration;
using System.IO;

namespace Sandbox.Shared.Api.Logging
{
    public static class ConfigurationHelper
    {
        public static IConfigurationRoot GetConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory());

            builder.AddJsonFile(Constants.Environment.ConfigFileName, false, true);

            builder.AddEnvironmentVariables();
            return builder.Build();
        }
    }
}