using Oxide.Ext.Discord.Interfaces;

namespace Oxide.Ext.Discord.Libraries
{
    /// <summary>
    /// InputText Templates Library
    /// </summary>
    public class DiscordSelectMenuTemplates : BaseMessageTemplateLibrary<SelectMenuTemplate>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger"></param>
        internal DiscordSelectMenuTemplates(ILogger logger) : base(TemplateType.SelectMenuComponent, logger) { }
    }
}