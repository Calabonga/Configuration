namespace Calabonga.Configuration.Core
{

    /// <summary>
    /// Service for access to MVC application settings
    /// </summary>
    /// <typeparam name="TConfig"></typeparam>
    public abstract class Configuration<TConfig> : ConfigurationReader<TConfig> where TConfig : class
    {

        protected Configuration(IConfigurationSerializer serializer)
            : base(serializer)
        {
        }

        /// <summary>
        /// Static configuration loader
        /// </summary>
        /// <param name="serializer"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        protected static TConfig Current(IConfigurationSerializer serializer, string fileName)
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