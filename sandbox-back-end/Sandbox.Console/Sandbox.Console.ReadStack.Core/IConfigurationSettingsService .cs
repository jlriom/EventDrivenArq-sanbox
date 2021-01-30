using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sandbox.Console.ReadStack.Core
{
    public interface IConfigurationSettingsService
    {
        Task<List<IConfigurationSection>> GetConfigurationSettings();
    }
}