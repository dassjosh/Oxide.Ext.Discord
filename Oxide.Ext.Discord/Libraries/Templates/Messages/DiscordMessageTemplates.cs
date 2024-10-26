using Oxide.Ext.Discord.Interfaces;

namespace Oxide.Ext.Discord.Libraries
{
    /// <summary>
    /// Modal Templates Library
    /// </summary>
    public class DiscordMessageTemplates : BaseMessageTemplateLibrary<DiscordMessageTemplate>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger"></param>
        internal DiscordMessageTemplates(ILogger logger) : base(TemplateType.Message, logger) { }
    }
}