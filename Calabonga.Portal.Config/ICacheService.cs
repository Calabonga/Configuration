using System;

namespace Calabonga.Portal.Config {

    /// <summary>
    /// Cache service
    /// </summary>
    public interface ICacheService {

        /// <summary>
        /// Save to Cache
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="value"></param>
        /// <param name="absoluteExparation"></param>
        /// <param name="slidingExpiration"></param>
        void Insert(string key, object value, DateTime absoluteExparation, TimeSpan slidingExpiration);

        /// <summary>
        /// Read cache by key
        /// </summary>
        /// <typeparam name="T">type to convert</typeparam>
        /// <param name="key">key</param>
        /// <returns></returns>
        T Read<T>(string key) where T : class;

        /// <summary>
        /// Read cache by key
        /// </summary>
        /// <typeparam name="T">type to convert</typeparam>
        /// <param name="key">key</param>
        /// <param name="defaultValue">default value</param>
        /// <returns></returns>
        T Read<T>(string key, T defaultValue) where T : class;

        /// <summary>
        ///  Read cache by key
        /// </summary>
        /// <typeparam name="T">type to convert</typeparam>
        /// <param name="key">key</param>
        /// <param name="value">default value</param>
        /// <param name="absoluteExpiration">expiration</param>
        /// <param name="slidingExpiration"></param>
        /// <returns></returns>
        T Read<T>(string key, T value, DateTime absoluteExpiration, TimeSpan slidingExpiration) where T : class;

        /// <summary>
        /// Check key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        bool HasKey(string key);

        /// <summary>
        /// Reset cache by key
        /// </summary>
        void Reset(string key);

    }
}