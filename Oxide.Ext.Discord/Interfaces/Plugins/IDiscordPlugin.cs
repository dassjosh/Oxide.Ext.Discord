using Oxide.Ext.Discord.Clients;

namespace Oxide.Ext.Discord.Interfaces
{
    /// <summary>
    /// Represents a plugin that uses the Discord Extension
    /// </summary>
    public interface IDiscordPlugin : IPluginBase
    {
        /// <summary>
        /// Gets / Sets the DiscordClient on a plugin
        /// </summary>
        DiscordClient Client { get; set; }
    }
}