using System;
using Oxide.Ext.Discord.Entities;

namespace Oxide.Ext.Discord.Attributes
{
    /// <summary>
    /// Discord Auto Complete Command Attribute for <see cref="InteractionType.ApplicationCommandAutoComplete"/>
    /// Callback Hook Format:
    /// <code>
    /// [DiscordAutoCompleteCommandAttribute("ArgumentName")]
    /// private void AutoCompleteCommand(DiscordInteraction interaction, InteractionDataOption focused)
    /// {
    ///     Puts("AutoCompleteCommand Works!");
    /// }
    /// </code>
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public sealed class DiscordAutoCompleteCommandAttribute : DiscordApplicationCommandAttribute
    {
        internal readonly string ArgumentName;
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="command">Command for the Auto Complete</param>
        /// <param name="argumentName">Argument Name for the Auto Complete</param>
        /// <param name="subCommand">Sub Command for the Auto Complete</param>
        /// <param name="group">Sub Command Group for the Auto Complete</param>
        public DiscordAutoCompleteCommandAttribute(string command, string argumentName, string subCommand = null, string group = null) : base(command, subCommand, group) 
        {
            ArgumentName = argumentName;
        }
    }
}