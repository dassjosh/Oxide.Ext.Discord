using Oxide.Ext.Discord.Interfaces;

namespace Oxide.Ext.Discord.Libraries
{
    /// <summary>
    /// Button Templates Library
    /// </summary>
    public class DiscordButtonTemplates : BaseMessageTemplateLibrary<ButtonTemplate>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger"></param>
        internal DiscordButtonTemplates(ILogger logger) : base(TemplateType.ButtonComponent, logger) { }
    }
}