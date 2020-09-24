namespace Calabonga.Configuration.Core
{
    /// <summary>
    /// EventHandler on Load event
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    public delegate void ConfigurationLoadedEventHandler<T>(object sender, ConfigurationLoadedEventHandlerArgs<T> args);
}