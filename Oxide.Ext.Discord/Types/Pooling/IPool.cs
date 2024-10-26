using Oxide.Ext.Discord.Interfaces;

namespace Oxide.Ext.Discord.Types
{
    /// <summary>
    /// Represents a pool
    /// </summary>
    public interface IPool : IDebugLoggable
    {
        /// <summary>
        /// Called on a pool when a plugin is unloaded
        /// </summary>
        /// <param name="pluginPool"></param>
        void OnPluginUnloaded(DiscordPluginPool pluginPool);

        /// <summary>
        /// Clears the pool of all items
        /// </summary>
        void ClearPoolEntities();

        /// <summary>
        /// Wipes all pools of the given type
        /// </summary>
        void RemoveAllPools();
    }
}