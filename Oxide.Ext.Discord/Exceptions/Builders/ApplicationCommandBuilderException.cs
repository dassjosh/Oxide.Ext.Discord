using Oxide.Ext.Discord.Builders;
using Oxide.Ext.Discord.Entities;

namespace Oxide.Ext.Discord.Exceptions
{
    /// <summary>
    /// Represents an error when building Application Commands
    /// </summary>
    public class ApplicationCommandBuilderException : BaseDiscordException
    {
        private ApplicationCommandBuilderException(string message) : base(message) { }

        internal static void ThrowIfMixingSubCommandGroups(CommandOptionType? type)
        {
            if (type.HasValue && type.Value != CommandOptionType.SubCommandGroup 
                              && type.Value != CommandOptionType.SubCommand)
            {
                throw new ApplicationCommandBuilderException("Cannot mix sub command / sub command groups with command options");
            }
        }    
        
        internal static void ThrowIfMixingCommandOptions(CommandOptionType? type)
        {
            if (type.HasValue && (type.Value == CommandOptionType.SubCommandGroup 
                                  || type.Value == CommandOptionType.SubCommand))
            {
                throw new ApplicationCommandBuilderException("Cannot mix sub command / sub command groups with command options");
            }
        }        
        
        internal static void ThrowIfAddingSubCommandToMessageOrUser(ApplicationCommandBuilder builder)
        {
            if (builder.Command.Type == ApplicationCommandType.Message || builder.Command.Type == ApplicationCommandType.User)
            {
                throw new ApplicationCommandBuilderException("Message and User commands cannot have sub command groups");
            }
        }
        
        internal static void ThrowIfInvalidCommandOptionType(CommandOptionType type)
        {
            if (type == CommandOptionType.SubCommand || type == CommandOptionType.SubCommandGroup)
            {
                throw new ApplicationCommandBuilderException($"{type} cannot be SubCommand or SubCommandGroup for option type");
            }
        }
    }
}