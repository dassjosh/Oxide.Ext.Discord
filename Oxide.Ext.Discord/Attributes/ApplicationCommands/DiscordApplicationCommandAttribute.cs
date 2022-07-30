using System;
using Oxide.Ext.Discord.Entities.Interactions;

namespace Oxide.Ext.Discord.Attributes.ApplicationCommands
{
    /// <summary>
    /// Discord Application Command Attribute for <see cref="InteractionType.ApplicationCommand"/>
    /// Callback Hook Format:
    /// <code>
    /// private void Callback(DiscordInteraction interaction, InteractionDataParsed parsed)
    /// {
    ///     Puts("Callback Works!");
    /// }
    /// </code>
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class DiscordApplicationCommandAttribute : Attribute
    {
        internal readonly string Command;
        internal readonly string Group;
        internal readonly string SubCommand;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="command">Command for the Application Command</param>
        /// <param name="group">Sub Command Group for the Application Command</param>
        /// <param name="subCommand">Sub Command for the Application Command</param>
        public DiscordApplicationCommandAttribute(string command, string group = null, string subCommand = null)
        {
            Command = command;
            Group = group;
            SubCommand = subCommand;
        }
    }
}