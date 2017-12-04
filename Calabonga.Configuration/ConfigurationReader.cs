using System;
using System.IO;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;
using System.Web.Caching;
using System.Web.Hosting;

namespace Calabonga.Configurations {

    /// <summary>
    /// Configuration reader
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class ConfigurationReader<T> : IConfigService<T> where T : class {
        private const string CacheKey = "Calabonga.Configurations.ConfigKeyName";
        private T _appSettings;
        private readonly ICacheService _cacheService;
        private readonly IConfigSerializer _serializer;

        protected ConfigurationReader(IConfigSerializer serializer, ICacheService cacheService) {
            _serializer = serializer;
            _cacheService = cacheService;
        }

        /// <summary>
        /// Reload data from config file
        /// </summary>
        public void Reload() {
            _cacheService.Reset(GetCacheKeyName());
            DeserealizeSettings();
        }

        /// <summary>
        /// Read value from config element
        /// </summary>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        public TValue ReadValue<TValue>(Expression<Func<T, TValue>> e) {
            if (!(e.Body is MemberExpression member))
                throw new ArgumentException($"Expression '{e}' refers to a method, not a property.");

            var propInfo = member.Member as PropertyInfo;
            if (propInfo == null)
                throw new ArgumentException($"Expression '{e}' refers to a field, not a property.");

            try {

                return (TValue)propInfo.GetValue(Config, null);
            }
            catch (ArgumentException exception) {
                throw new ArgumentException("Property not found in configuration", exception);
            }
        }

        /// <summary>
        /// ReadValue from configuration
        /// </summary>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public TValue ReadValue<TValue>(string propertyName) {
            var type = typeof(T);
            try {
                return (TValue)type.GetProperty(propertyName)?.GetValue(Config);
            }
            catch (ArgumentNullException exception) {
                throw new ArgumentNullException(@"Property not found in configuration", exception);
            }
        }

        /// <summary>
        /// Save all data to the config file
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        public void SaveChanges(T config) {
            Serialize(config);
        }

        /// <summary>
        /// Config instance
        /// </summary>
        public T Config {
            get {
                if (_appSettings == null) {
                    _appSettings = _cacheService.Read<T>(GetCacheKeyName());
                    if (_appSettings == null) {
                        DeserealizeSettings();
                    }
                }
                return _appSettings;
            }
        }

        #region event OnLoaded

        /// <summary>
        /// Fire when configuration loaded
        /// </summary>
        public event ConfigurationLoadedEventHandler<T> ConfigurationLoaded;

        protected virtual void OnConfigurationReloaded(ConfigurationLoadedEventHandlerArgs<T> args) {
            ConfigurationLoaded?.Invoke(this, args);
        }

        #endregion

        /// <summary>
        /// Configuration folder
        /// </summary>
        public virtual string DirectoryName {
            get {
                return (HttpContext.Current != null ? HttpContext.Current.Server.MapPath("~/") : HostingEnvironment.MapPath("~/")) ?? Directory.GetCurrentDirectory();
            }
        }

        /// <summary>
        /// Configuration FileName
        /// </summary>
        public virtual string FileName {
            get {
                return "Config.json";
            }
        }

        #region private methods

        private T Import(string data) {
            try {
                var o = _serializer.DeserializeObject<T>(data);
                return string.IsNullOrEmpty(data) ? null : o;
            }
            catch (InvalidOperationException exception) {
                throw new InvalidOperationException("Can't deserialize current configuration.", exception);
            }
        }

        private string CreateDefaultAppSettings() {
            var settings = new object();
            var o = _serializer.SerializeObject(settings);
            using (var sw = File.CreateText(Path.Combine(DirectoryName, FileName))) {
                sw.Write(o);
            }
            return o;
        }

        private string LoadSettings() {
            try {
                string data;
                using (var fs = File.OpenText(Path.Combine(DirectoryName, FileName))) {
                    data = fs.ReadToEnd();
                }
                return data;
            }
            catch (FileNotFoundException) {
                return CreateDefaultAppSettings();
            }
            catch (DirectoryNotFoundException) {
                Directory.CreateDirectory(DirectoryName);
                return CreateDefaultAppSettings();
            }
        }

        private void DeserealizeSettings() {
            var data = LoadSettings();
            if (data == null) {
                return;
            }
            _appSettings = Import(data);
            _cacheService.Insert(GetCacheKeyName(), _appSettings, Cache.NoAbsoluteExpiration, TimeSpan.FromMinutes(3));
            OnConfigurationReloaded(new ConfigurationLoadedEventHandlerArgs<T> { Config = _appSettings });
        }

        private void Serialize(T config) {
            try {
                var data = _serializer.SerializeObject(config);
                if (data != null) {
                    using (var sw = File.CreateText(Path.Combine(DirectoryName, FileName))) {
                        sw.Write(data);
                    }
                }
            }
            catch {
                // ignored
            }
        }

        private string GetCacheKeyName()
        {
            return $"{CacheKey}_{FileName.Replace('.','_')}";
        }

        #endregion
    }
}