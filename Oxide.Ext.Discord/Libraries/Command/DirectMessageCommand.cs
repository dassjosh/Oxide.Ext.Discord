using Oxide.Core.Plugins;
using Oxide.Ext.Discord.Entities;
using Oxide.Ext.Discord.Extensions;
using Oxide.Ext.Discord.Logging;

namespace Oxide.Ext.Discord.Libraries
{
    internal class DirectMessageCommand : BaseCommand
    {
        internal DirectMessageCommand(Plugin plugin, string name, string hook) : base(plugin, name, hook) { }
        
        public override bool CanHandle(DiscordMessage message, DiscordChannel channel)
        {
            return !message.GuildId.HasValue;
        }

        public override void LogDebug(DebugLogger logger)
        {
            logger.AppendField("Name", Name);
            logger.AppendField("Plugin", Plugin.FullName());
            logger.AppendField("Type", "DM Command");
        }
    }
}