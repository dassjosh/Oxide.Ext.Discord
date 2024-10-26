using System;
using Oxide.Ext.Discord.Entities;

namespace Oxide.Ext.Discord.Attributes
{
    /// <summary>
    /// Discord Application Command Attribute for <see cref="InteractionType.ApplicationCommand"/>
    /// Callback Hook Format:
    /// <code>
    /// [DiscordApplicationCommandAttribute("Command", "Sub Command", "Group")]
    /// private void ApplicationCommandMethod(DiscordInteraction interaction, InteractionDataParsed parsed)
    /// {
    ///     Puts("ApplicationCommandMethod Works!");
    /// }
    /// </code>
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class DiscordApplicationCommandAttribute : BaseApplicationCommandAttribute
    {
        internal readonly string Command;
        internal readonly string Group;
        internal readonly string SubCommand;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="command">Command for the Application Command</param>
        /// <param name="subCommand">Sub Command for the Application Command</param>
        /// <param name="group">Sub Command Group for the Application Command</param>
        public DiscordApplicationCommandAttribute(string command, string subCommand = null, string group = null)
        {
            Command = command;
            Group = group;
            SubCommand = subCommand;
        }
    }
}