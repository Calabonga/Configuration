using System;

namespace Calabonga.Configuration.Json
{
    /// <summary>
    /// Configuration items Loaded event arguments
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ConfigurationLoadedEventHandlerArgs<T> : EventArgs {
        public T Config { get; set; }
    }
}