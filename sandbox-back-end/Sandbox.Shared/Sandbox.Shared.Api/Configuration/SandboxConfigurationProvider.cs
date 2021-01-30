using Microsoft.Extensions.Configuration;
using System;

namespace Sandbox.Shared.Api.Configuration
{
    public class SandboxConfigurationProvider : ConfigurationProvider
    {
        public SandboxConfigurationProvider(SandboxConfigurationSource source)
        {
            Source = source;
        }

        private SandboxConfigurationSource Source { get; }

        public override void Load()
        {
            var settings = new SharedConfiguration(Source).GetSettings();

            foreach (var setting in settings)
            {
                Set(setting.Key, setting.Value);
            }
        }
    }

    public class SandboxConfigurationOptions
    {
        public string Module { get; set; }
        public string ConnectionString { get; set; }
    }

    public class SandboxConfigurationSource : IConfigurationSource
    {
        public SandboxConfigurationSource(SandboxConfigurationOptions options)
        {
            Module = options.Module;
            ConnectionString = options.ConnectionString;
        }

        public string Module { get; }
        public string ConnectionString { get; }

        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            return new SandboxConfigurationProvider(this);
        }
    }

    public static class SandboxConfigurationExtensions
    {
        public static IConfigurationBuilder AddSandboxConfiguration(this IConfigurationBuilder configuration,
            Action<SandboxConfigurationOptions> options)
        {
            _ = options ?? throw new ArgumentNullException(nameof(options));
            var sandboxConfigurationOptions = new SandboxConfigurationOptions();
            options(sandboxConfigurationOptions);
            configuration.Add(new SandboxConfigurationSource(sandboxConfigurationOptions));
            return configuration;
        }
    }
}