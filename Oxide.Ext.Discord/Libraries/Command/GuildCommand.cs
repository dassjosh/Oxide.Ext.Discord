using System.Collections.Generic;
using Oxide.Core.Plugins;
using Oxide.Ext.Discord.Entities;
using Oxide.Ext.Discord.Extensions;
using Oxide.Ext.Discord.Logging;

namespace Oxide.Ext.Discord.Libraries
{
    internal class GuildCommand : BaseCommand
    {
        private readonly List<Snowflake> _allowedChannels;

        public GuildCommand(Plugin plugin, string name, string hook, List<Snowflake> allowedChannels) : base(plugin, name, hook)
        {
            _allowedChannels = allowedChannels;
        }

        public override bool CanHandle(DiscordMessage message, DiscordChannel channel)
        {
            if (!message.GuildId.HasValue)
            {
                return false;
            }
            
            if (channel == null)
            {
                return true;
            }

            if (_allowedChannels == null || _allowedChannels.Count == 0 || _allowedChannels.Contains(channel.Id))
            {
                return true;
            }

            if (channel.ParentId.HasValue && _allowedChannels.Contains(channel.ParentId.Value))
            {
                return true;
            }
            
            return false;
        }

        public override void LogDebug(DebugLogger logger)
        {
            logger.AppendField("Name", Name);
            logger.AppendField("Plugin", Plugin.FullName());
            logger.AppendField("Type", "Guild Command");
        }
    }
}