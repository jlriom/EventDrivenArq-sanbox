using Sandbox.Shared.Data.System.EntityFrameworkCore;
using System.Collections.Generic;

namespace Sandbox.Shared.Api.Configuration
{
    public class SharedConfiguration
    {
        private readonly SandboxConfigurationSource _source;

        public SharedConfiguration(SandboxConfigurationSource source)
        {
            _source = source;
        }

        public Dictionary<string, string> GetSettings()
        {
            var settings = SystemDbContext.GetConfigurationSettings(_source.ConnectionString, _source.Module);
            return settings;
        }
    }
}
