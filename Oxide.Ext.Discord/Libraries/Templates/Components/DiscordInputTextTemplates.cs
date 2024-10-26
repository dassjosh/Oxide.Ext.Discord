using Oxide.Ext.Discord.Interfaces;

namespace Oxide.Ext.Discord.Libraries
{
    /// <summary>
    /// InputText Templates Library
    /// </summary>
    public class DiscordInputTextTemplates : BaseMessageTemplateLibrary<InputTextTemplate>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger"></param>
        internal DiscordInputTextTemplates(ILogger logger) : base(TemplateType.InputTextComponent, logger) { }
    }
}