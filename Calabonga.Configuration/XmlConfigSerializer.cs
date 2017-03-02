using System.IO;
using System.Xml.Serialization;

namespace Calabonga.Configurations {
    /// <summary>
    /// Configuration serializer for XML-format
    /// </summary>
    public class XmlConfigSerializer : IConfigSerializer {

        /// <summary>
        /// Read and Deserialize string data
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
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
                    // ignored
                }
            }
            return default(T);
        }


        /// <summary>
        /// Serialize and return
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="config"></param>
        /// <returns></returns>
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
                    // ignored
                }
            }
            return null;
        }
    }
}