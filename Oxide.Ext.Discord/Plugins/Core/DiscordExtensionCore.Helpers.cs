using Oxide.Core.Plugins;

namespace Oxide.Ext.Discord.Plugins
{
    internal partial class DiscordExtensionCore
    {
        private static bool IsPluginLoaded(Plugin plugin) => plugin != null && plugin.IsLoaded;
    }
}