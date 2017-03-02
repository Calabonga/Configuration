namespace Calabonga.Configuration {

    /// <summary>
    /// Config service interface
    /// </summary>
    public interface IAppConfig<out T> {

        /// <summary>
        /// Application settings stored in AppConfig.cfg file
        /// </summary>
        T Config { get; }

        void Reload();
    }
}