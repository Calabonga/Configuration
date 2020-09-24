using System;

namespace Calabonga.Configuration.Core
{
    /// <summary>
    /// Configuration items Loaded event arguments
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ConfigurationLoadedEventHandlerArgs<T> : EventArgs {
        public T Config { get; set; }
    }
}