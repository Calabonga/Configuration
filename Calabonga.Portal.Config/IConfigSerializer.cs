using System;

namespace Calabonga.Portal.Config {
    public interface IConfigSerializer {

        T DeserializeObject<T>(string value);

        string SerializeObject<T>(T config) where T : class;
    }
}