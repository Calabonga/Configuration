using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Calabonga.Portal.Config {
    /// <summary>
    /// Default serializer for config settings 
    /// use Xml format
    /// </summary>
    public class DefaultConfigSerializer : IConfigSerializer {

        public T DeserializeObject<T>(string value) {
            if (value == null) {
                return default(T);
            }
            var formatter = new XmlSerializer(typeof(T));
            using (var st = new StringReader(value)) {

                try {
                    return (T)formatter.Deserialize(st);
                }

                catch {
                }
            }
            return default(T);
        }

        public string SerializeObject<T>(T config) where T : class {

            using (var ms = new MemoryStream()) {

                var formatter = new XmlSerializer(typeof(T));
                try {
                    formatter.Serialize(ms, config);
                    ms.Position = 0;
                    string result;
                    using (var sr = new StreamReader(ms)) {
                        result = sr.ReadToEnd();
                    }
                    return result;
                }
                catch {
                }
            }
            return null;
        }
    }
}