using Oxide.Ext.Discord.Types;

namespace Oxide.Ext.Discord.Interfaces
{
    /// <summary>
    /// Interface for plugins to use that need access to a pool
    /// </summary>
    public interface IDiscordPool
    {
        /// <summary>
        /// Pool for plugins to use
        /// </summary>
        DiscordPluginPool Pool { get; set; }
    }
}