using Oxide.Core.Plugins;
using Oxide.Ext.Discord.Entities;
using Oxide.Ext.Discord.Plugins;

namespace Oxide.Ext.Discord.Libraries
{
    /// <summary>
    /// <see cref="DiscordInteraction"/> placeholders
    /// </summary>
    public static class InteractionPlaceholders
    {
        /// <summary>
        /// <see cref="DiscordInteraction.GetLangMessage(Oxide.Core.Plugins.Plugin,string)"/> placeholder
        /// </summary>
        public static string Lang(PlaceholderState state, DiscordInteraction interaction) => interaction.GetLangMessage(state.Data.Get<Plugin>(), state.Format);

        internal static void RegisterPlaceholders()
        {
            RegisterPlaceholders(DiscordExtensionCore.Instance, DefaultKeys.Interaction, new PlaceholderDataKey(nameof(DiscordInteraction)));
        }
        
        /// <summary>
        /// Registers placeholders for the given plugin. 
        /// </summary>
        /// <param name="plugin">Plugin to register placeholders for</param>
        /// <param name="keys">Prefix to use for the placeholders</param>
        /// <param name="dataKey">Data key in <see cref="PlaceholderData"/></param>
        public static void RegisterPlaceholders(Plugin plugin, InteractionKeys keys, PlaceholderDataKey dataKey)
        {
            DiscordPlaceholders placeholders = DiscordPlaceholders.Instance;
            placeholders.RegisterPlaceholder<DiscordInteraction, string>(plugin, keys.Lang, dataKey, Lang);
        }
    }
}