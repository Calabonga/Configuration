using System.IO;
using System.Threading.Tasks;
using System.Web;

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

        private async Task Serialize(T config) {
            try {
                var data = _serializer.SerializeObject(config);
                //                var data = JsonConvert.SerializeObject(config);
                if (data != null) {
                    using (var sw = File.CreateText(Path.Combine(_directoryConfig, _fileNameSettings))) {
                        await sw.WriteAsync(data);
                    }
                }
            }
            catch { }
        }

        private void DeserealizeSettings() {
            var data = LoadSettings();
            _appSettings = Import(data);
        }

        private string LoadSettings() {
            try {
                string data;
                using (var fs = File.OpenText(Path.Combine(_directoryConfig, _fileNameSettings))) {
                    data = fs.ReadToEnd();
                }
                return data;
            }
            catch (FileNotFoundException exception)
            {
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

        private string CreateDefaultAppSettings()
        {
            var settings = DefaultSettings();
            var o = _serializer.SerializeObject(settings);
            using (var sw = File.CreateText(Path.Combine(_directoryConfig, _fileNameSettings)))
            {
                sw.Write(o);
            }
            return o;
        }

        private T Import(string data) {
            var o = _serializer.DeserializeObject<T>(data);
            //            var o = JsonConvert.DeserializeObject<T>(data);
            return string.IsNullOrEmpty(data) ? null : o;
        }

        /// <summary>
        /// Reload data from config-file
        /// </summary>
        public void Reload()
        {
            DeserealizeSettings();
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
        public async Task SaveChanges(T config) {
            await Serialize(config);
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
    }
}