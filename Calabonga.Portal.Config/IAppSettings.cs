namespace Calabonga.Portal.Config {
    /// <summary>
    /// Default MVC application settings
    /// </summary>
    public interface IAppSettings {
        /// <summary>
        /// Pager page size by default
        /// </summary>
        int DefaultPagerSize { get; }
    }
}