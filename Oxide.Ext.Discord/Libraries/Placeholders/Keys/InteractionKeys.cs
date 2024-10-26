using Oxide.Ext.Discord.Entities;

namespace Oxide.Ext.Discord.Libraries
{
    /// <summary>
    /// Placeholder Keys for <see cref="DiscordInteraction"/>
    /// </summary>
    public class InteractionKeys
    {
        /// <summary>
        /// <see cref="PlaceholderKey"/> for <see cref="DiscordInteraction.GetLangMessage(Oxide.Core.Plugins.Plugin,string)"/>
        /// </summary>
        public readonly PlaceholderKey Lang;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="prefix">Placeholder Key Prefix</param>
        public InteractionKeys(string prefix)
        {
            Lang = new PlaceholderKey(prefix, "lang");
        }
    }
}