using System;
using Oxide.Ext.Discord.Cache;
using Oxide.Ext.Discord.Entities;
using Oxide.Ext.Discord.Types;

namespace Oxide.Ext.Discord.Libraries
{
    internal readonly struct AppCommandId : IEquatable<AppCommandId>
    {
        public readonly InteractionType Type;
        public readonly string Command;
        public readonly string Group;
        public readonly string SubCommand;
        public readonly string Argument;

        public AppCommandId(InteractionType type, string command, string group = null, string subCommand = null, string argument = null)
        {
            if(string.IsNullOrEmpty(command)) throw new ArgumentNullException(nameof(command));

            Type = type;
            Command = command;
            Group = group;
            SubCommand = subCommand;
            Argument = argument;
        }
        
        public override string ToString()
        {
            ValueStringBuilder sb = new();
            sb.Append(EnumCache<InteractionType>.Instance.ToString(Type));
            sb.Append(':');
            sb.Append(Command);
            if (!string.IsNullOrEmpty(Group))
            {
                sb.Append('/');
                sb.Append(Group);
            }
            if (!string.IsNullOrEmpty(SubCommand))
            {
                sb.Append('/');
                sb.Append(SubCommand);
            }
            if (!string.IsNullOrEmpty(Argument))
            {
                sb.Append('#');
                sb.Append(Argument);
            }

            return sb.ToString();
        }
        
        public bool Equals(AppCommandId other) => Type == other.Type && Command == other.Command && Group == other.Group && SubCommand == other.SubCommand && Argument == other.Argument;
        public override bool Equals(object obj) => obj is AppCommandId other && Equals(other);
        public override int GetHashCode() => HashCode.Combine((int)Type, Command, Group, SubCommand, Argument);
    }
}