using System;
using System.Linq.Expressions;

namespace Calabonga.Configuration {
    /// <summary>
    /// Configuration service wrappper
    /// </summary>
    /// <typeparam name="TConfig"></typeparam>
    public interface IConfigService<TConfig> where TConfig : class {

        /// <summary>
        /// Config file location folder
        /// </summary>
        string DirectoryName { get; }

        /// <summary>
        /// Config file name
        /// </summary>
        string FileName { get; }

        /// <summary>
        /// Event OnConfigurationLoaded
        /// </summary>
        event ConfigurationLoadedEventHandler<TConfig> ConfigurationLoaded;

        /// <summary>
        /// Application config
        /// </summary>
        TConfig Config { get; }

        /// <summary>
        /// Save applications settings
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        void SaveChanges(TConfig model);

        /// <summary>
        /// Reload from configuration file
        /// </summary>
        void Reload();

        /// <summary>
        /// Read a value from config element
        /// </summary>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        TValue ReadValue<TValue>(Expression<Func<TConfig, TValue>> propertiyExpression);

        /// <summary>
        /// Read a value from configuration file
        /// </summary>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        TValue ReadValue<TValue>(string propertyName);

    }
}