namespace Calabonga.Configuration {

    /// <summary>
    /// Service for access to MVC application settings
    /// </summary>
    /// <typeparam name="TConfig"></typeparam>
    public class ConfigServiceBase<TConfig> : AppConfigrReader<TConfig> where TConfig : class {

        public ConfigServiceBase(string configFileName, IConfigSerializer serializer, ICacheService cacheService)
            : base(configFileName, serializer, cacheService) {
        }
    }
}