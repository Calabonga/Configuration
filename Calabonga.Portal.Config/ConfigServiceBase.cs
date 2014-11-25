using System.Threading.Tasks;

namespace Calabonga.Portal.Config {

    /// <summary>
    /// Service for access to MVC application settings 
    /// </summary>
    /// <typeparam name="TConfig"></typeparam>
    public class ConfigServiceBase<TConfig> : AppConfigrReader<TConfig> where TConfig : class {

        public ConfigServiceBase(IConfigSerializer serializer, ICacheService cacheService)
            : base(serializer, cacheService) {
        }

        public ConfigServiceBase(string configFileName, IConfigSerializer serializer, ICacheService cacheService)
            : base(configFileName, serializer, cacheService) {
        }

        /// <summary>
        /// Reload settings from a file
        /// </summary>
        public void ReloadConfig() {
            Reload();
        }
    }
}