using Newtonsoft.Json;

namespace Calabonga.Configuration.Json {

    /// <summary>
    /// Configuration serializer for JSON-format
    /// </summary>
    public class JsonConfigurationSerializer : IConfigurationSerializer {
        /// <summary>
        /// Read and Deserialize string data
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public T DeserializeObject<T>(string value) {
            return JsonConvert.DeserializeObject<T>(value);
        }

        /// <summary>
        /// Serialize and return
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="config"></param>
        /// <returns></returns>
        public string SerializeObject<T>(T config) where T : class {
            return JsonConvert.SerializeObject(config);
        }
    }
}
