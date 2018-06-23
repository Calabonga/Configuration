namespace Calabonga.Configurations
{

    /// <summary>
    /// Service for access to MVC application settings
    /// </summary>
    /// <typeparam name="TConfig"></typeparam>
    public abstract class Configuration<TConfig> : ConfigurationReader<TConfig> where TConfig : class
    {

        protected Configuration(IConfigSerializer serializer, ICacheService cacheService)
            : base(serializer, cacheService)
        {
        }

        /// <summary>
        /// Static configuration loader
        /// </summary>
        /// <param name="serializer"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        protected static TConfig Current(IConfigSerializer serializer, string fileName)
        {
            var serialized = LoadFromFile(fileName);
            if (string.IsNullOrEmpty(serialized))
            {
                return default(TConfig);
            }
            return serializer.DeserializeObject<TConfig>(serialized);
        }
    }
}