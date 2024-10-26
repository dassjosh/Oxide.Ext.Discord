using Oxide.Ext.Discord.Interfaces;

namespace Oxide.Ext.Discord.Libraries
{
    /// <summary>
    /// Embed Templates Library
    /// </summary>
    public class DiscordEmbedTemplates : BaseMessageTemplateLibrary<DiscordEmbedTemplate>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger"></param>
        internal DiscordEmbedTemplates(ILogger logger) : base(TemplateType.Embed, logger) { }
    }
}