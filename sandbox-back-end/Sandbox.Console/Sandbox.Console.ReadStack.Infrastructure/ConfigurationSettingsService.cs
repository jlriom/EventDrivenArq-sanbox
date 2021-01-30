using Microsoft.Extensions.Configuration;
using Sandbox.Console.ReadStack.Core;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sandbox.Console.ReadStack.Infrastructure
{
    public class ConfigurationSettingsService : IConfigurationSettingsService
    {
        private readonly IConfiguration _configuration;

        public ConfigurationSettingsService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<List<IConfigurationSection>> GetConfigurationSettings()
        {

            var config = _configuration.GetChildren().ToList();

            foreach (var section in _configuration.GetChildren())
            {
                if (string.IsNullOrEmpty(section.Value))
                {
                    var subSection = section.GetChildren().ToList();
                    config.AddRange(subSection);
                }
            }

            return await Task.FromResult(config);
        }
    }
}