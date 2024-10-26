using Oxide.Ext.Discord.Interfaces;

namespace Oxide.Ext.Discord.Libraries
{
    /// <summary>
    /// Embed Field Templates Library
    /// </summary>
    public class DiscordEmbedFieldTemplates : BaseMessageTemplateLibrary<DiscordEmbedFieldTemplate>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger"></param>
        internal DiscordEmbedFieldTemplates(ILogger logger) : base(TemplateType.EmbedField, logger) { }
    }
}