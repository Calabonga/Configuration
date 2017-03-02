namespace Calabonga.Configuration {

    /// <summary>
    /// Service for access to MVC application settings
    /// </summary>
    /// <typeparam name="TConfig"></typeparam>
    public abstract class Configuration<TConfig> : ConfigurationReader<TConfig> where TConfig : class {
        protected Configuration(IConfigSerializer serializer, ICacheService cacheService)
            : base(serializer, cacheService) {
        }
    }
}