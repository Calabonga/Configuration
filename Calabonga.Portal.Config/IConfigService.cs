using System.Threading.Tasks;

namespace Calabonga.Portal.Config
{
    /// <summary>
    /// Configuration service wrappper
    /// </summary>
    /// <typeparam name="TConfig"></typeparam>
    public interface IConfigService<TConfig> where TConfig : class {

        /// <summary>
        /// Application config
        /// </summary>
        TConfig Config { get; }

        /// <summary>
        /// Save applications settings
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task SaveChanges(TConfig model);

        /// <summary>
        /// Reload from configuration file
        /// </summary>
        void Reload();
    }
}