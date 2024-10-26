using System;
using System.Collections.Generic;
using Oxide.Ext.Discord.Entities;

namespace Oxide.Ext.Discord.Plugins
{
    internal class CommandCache
    {
        public readonly List<DiscordApplicationCommand> Commands;
        private readonly DateTime _cachedDateTime = DateTime.UtcNow;

        public CommandCache(List<DiscordApplicationCommand> commands)
        {
            Commands = commands;
        }
        
        public bool IsExpired => _cachedDateTime + TimeSpan.FromSeconds(15) < DateTime.UtcNow;

        public void RemoveCommand(Snowflake id)
        {
            for (int index = 0; index < Commands.Count; index++)
            {
                DiscordApplicationCommand command = Commands[index];
                if (command.Id == id)
                {
                    Commands.RemoveAt(index);
                    break;
                }
            }
        }
    }
}