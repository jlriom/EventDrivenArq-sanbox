using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Sandbox.Shared.Data.System.EntityFrameworkCore
{
    public partial class SystemDbContext
    {
        private static Dictionary<string, string> _settings = null;

        private static readonly object Lock = new object();

        public static Dictionary<string, string> GetConfigurationSettings(string connectionString, string module)
        {
            lock (Lock)
            {
                return _settings ?? (_settings = GetConfigurationSettingsFromDb(connectionString, module));
            }
        }

        private static Dictionary<string, string> GetConfigurationSettingsFromDb(string connectionString, string module)
        {
            var settings = new Dictionary<string, string>();

            using (var context = new SystemDbContext(GetConnectionOptions(connectionString)))
            {
                var retrievedSettings = context.SysConfig.Where(s => s.Module == module || s.Module == string.Empty || s.Module == null).ToList();

                foreach (var retrievedSetting in retrievedSettings)
                {
                    settings.Add(retrievedSetting.Key, retrievedSetting.Value);
                }
            }

            return settings;
        }

        private static DbContextOptions<SystemDbContext> GetConnectionOptions(string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SystemDbContext>();

            optionsBuilder.UseSqlServer(connectionString);

            return optionsBuilder.Options;
        }
    }
}