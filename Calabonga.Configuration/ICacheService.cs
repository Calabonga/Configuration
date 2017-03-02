using System;
using System.Web;

namespace Calabonga.Configuration {

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

    /// <summary>
    /// Cache service for MvcConfig
    /// </summary>
    public class CacheService : ICacheService {

        public CacheService() {

        }

        /// <summary>
        /// Сохранение в кэш
        /// </summary>
        /// <param name="key">название параметра</param>
        /// <param name="value"></param>
        /// <param name="absoluteExparation"></param>
        /// <param name="slidingExpiration"></param>
        public void Insert(string key, object value, DateTime absoluteExparation, TimeSpan slidingExpiration) {
            if (value == null) return;
            if (HttpContext.Current == null || HttpContext.Current.Cache == null) return;
            HttpContext.Current.Cache.Insert(key, value, null, absoluteExparation, slidingExpiration);
        }

        /// <summary>
        /// Чтение объекта из кэша
        /// </summary>
        /// <typeparam name="T">тип</typeparam>
        /// <param name="key">название параметра (ключ)</param>
        /// <param name="defaultValue">значение по умолчанию</param>
        /// <returns></returns>
        public T Read<T>(string key, T defaultValue) where T : class {
            if (defaultValue == null) throw new ArgumentNullException(nameof(defaultValue));
            if (HttpContext.Current == null || HttpContext.Current.Cache == null) return null;
            if (HttpContext.Current.Cache[key] == null) return defaultValue;
            var result = HttpContext.Current.Cache[key];
            if (result != null) {
                try {
                    return (T)result;
                }
                catch (InvalidCastException) {
                    throw new InvalidCastException("Invalid cast from cache object");
                }
            }
            return null;
        }

        /// <summary>
        /// Чтение объекта из кэша
        /// </summary>
        /// <typeparam name="T">тип</typeparam>
        /// <param name="key">название параметра (ключ)</param>
        /// <param name="value">значение по умолчанию</param>
        /// <param name="absoluteExpiration">Искает</param>
        /// <param name="slidingExpiration"></param>
        /// <returns></returns>
        public T Read<T>(string key, T value, DateTime absoluteExpiration, TimeSpan slidingExpiration) where T : class {
            if (absoluteExpiration == null) throw new ArgumentNullException("absoluteExpiration");
            if (slidingExpiration == null) throw new ArgumentNullException("slidingExpiration");
            if (HttpContext.Current == null || HttpContext.Current.Cache == null) return null;
            if (HttpContext.Current.Cache[key] == null) {
                Insert(key, value, absoluteExpiration, slidingExpiration);
                return value;
            }
            var result = HttpContext.Current.Cache[key];
            if (result != null) {
                try {
                    return (T)result;
                }
                catch (InvalidCastException) {
                    throw new InvalidCastException("Invalid cast from cache object");
                }
            }
            return null;
        }

        /// <summary>
        /// Проверка наличия ключа в кэше
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool HasKey(string key) {
            if (HttpContext.Current == null || HttpContext.Current.Cache == null) return false;
            return HttpContext.Current.Cache[key] != null;
        }

        /// <summary>
        /// Чтение объекта из кэша
        /// </summary>
        /// <typeparam name="T">тип</typeparam>
        /// <param name="key">название параметра (ключ)</param>
        /// <returns></returns>
        public T Read<T>(string key) where T : class {
            if (HttpContext.Current == null || HttpContext.Current.Cache == null) return null;
            if (HttpContext.Current.Cache[key] == null) return null;

            var result = HttpContext.Current.Cache[key];
            if (result != null) {
                try {
                    return (T)result;
                }
                catch (InvalidCastException) {
                    throw new InvalidCastException("Invalid cast from cache object");
                }
            }
            return null;
        }

        /// <summary>
        /// Сброс кэша
        /// </summary>
        public void Reset(string key) {
            if (HttpContext.Current == null || HttpContext.Current.Cache == null) return;
            if (HttpContext.Current.Cache[key] != null) {
                HttpContext.Current.Cache.Remove(key);
            }
        }
    }
}