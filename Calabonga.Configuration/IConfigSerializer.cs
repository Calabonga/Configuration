namespace Calabonga.Configuration {

    /// <summary>
    /// Serializator for config file
    /// </summary>
    public interface IConfigSerializer {

        /// <summary>
        /// Read and Deserialize string data
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        T DeserializeObject<T>(string value);

        /// <summary>
        /// Serialize and return
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="config"></param>
        /// <returns></returns>
        string SerializeObject<T>(T config) where T : class;
    }
}