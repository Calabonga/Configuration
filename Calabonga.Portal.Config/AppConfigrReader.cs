using System;
using System.IO;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;
using System.Web.ModelBinding;

namespace Calabonga.Portal.Config {

    /// <summary>
    /// Congiguration reader
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class AppConfigrReader<T> : IConfigService<T> where T : class {

        private T _appSettings;
        private readonly string _fileNameSettings = "AppConfig.cfg";
        private readonly IConfigSerializer _serializer;
        private readonly string _directoryConfig = HttpContext.Current.Server.MapPath("~/App_Config");

        protected AppConfigrReader(IConfigSerializer serializer) {
            _serializer = serializer;
        }

        protected AppConfigrReader(string configFileName, IConfigSerializer serializer)
            : this(serializer) {
            _fileNameSettings = configFileName;
        }


        /// <summary>
        /// Reload data from config file
        /// </summary>
        public void Reload() {
            DeserealizeSettings();
        }

        /// <summary>
        /// Read value from config element
        /// </summary>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        public TValue ReadValue<TValue>(Expression<Func<T, TValue>> e) {
            var member = e.Body as MemberExpression;
            if (member == null)
                throw new ArgumentException(string.Format(
                    "Expression '{0}' refers to a method, not a property.", e));

            var propInfo = member.Member as PropertyInfo;
            if (propInfo == null)
                throw new ArgumentException(string.Format(
                    "Expression '{0}' refers to a field, not a property.",
                    e.ToString()));

            try {

                return (TValue)propInfo.GetValue(Config, null);
            }
            catch (Exception) {
                throw;
            }
        }

        public TValue ReadValue<TValue>(string propertyName) {
            var type = typeof(T);
            try {

                return (TValue)type.GetProperty(propertyName).GetValue(Config);
            }
            catch (Exception) {
                throw;
            }
        }

        /// <summary>
        /// Save all data to the config file
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        public async Task SaveChanges(T config) {
            await Serialize(config);
        }



        /// <summary>
        /// Config instance
        /// </summary>
        public T Config {
            get {
                if (_appSettings == null) {
                    DeserealizeSettings();
                }
                return _appSettings;
            }
        }
        private AppSettings DefaultSettings() {
            return new AppSettings {
                AdminEmail = "admin@domain.com",
                DefaultPagerSize = 10,
                DomainUrl = "http://www.domain.com",
                IsHtmlForEmailMessagesEnabled = true,
                IsLogging = true,
                RobotEmail = "robot@domain.com",
                SmtpClient = "localhost"
            };
        }

        private T Import(string data) {
            var o = _serializer.DeserializeObject<T>(data);
            return string.IsNullOrEmpty(data) ? null : o;
        }

        private string CreateDefaultAppSettings() {
            var settings = DefaultSettings();
            var o = _serializer.SerializeObject(settings);
            using (var sw = File.CreateText(Path.Combine(_directoryConfig, _fileNameSettings))) {
                sw.Write(o);
            }
            return o;
        }

        private string LoadSettings() {
            try {
                string data;
                using (var fs = File.OpenText(Path.Combine(_directoryConfig, _fileNameSettings))) {
                    data = fs.ReadToEnd();
                }
                return data;
            }
            catch (FileNotFoundException exception) {
                return CreateDefaultAppSettings();
            }
            catch (DirectoryNotFoundException) {
                Directory.CreateDirectory(_directoryConfig);
                return CreateDefaultAppSettings();
            }
            catch {
                return null;
            }
        }

        private void DeserealizeSettings() {
            var data = LoadSettings();
            _appSettings = Import(data);
        }

        private async Task Serialize(T config) {
            try {
                var data = _serializer.SerializeObject(config);
                if (data != null) {
                    using (var sw = File.CreateText(Path.Combine(_directoryConfig, _fileNameSettings))) {
                        await sw.WriteAsync(data);
                    }
                }
            }
            catch { }
        }
    }
}