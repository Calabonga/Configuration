namespace Calabonga.Configuration.Core.Demo2_2
{
    public class AppConfiguration : Configuration<AppSettings>
    {
        /// <inheritdoc />
        public AppConfiguration(IConfigurationSerializer serializer) : base(serializer)
        {
        }
    }
}