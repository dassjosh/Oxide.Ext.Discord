using System;
using Oxide.Ext.Discord.Entities;

namespace Oxide.Ext.Discord.Attributes
{
    /// <summary>
    /// Discord Message Component Command Attribute for <see cref="InteractionType.MessageComponent"/>
    /// Callback Hook Format:
    /// <code>
    /// [DiscordMessageComponentCommandAttribute("CustomId")]
    /// private void MessageComponentCommand(DiscordInteraction interaction)
    /// {
    ///     Puts("MessageComponentCommand Works!");
    /// }
    /// </code>
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public sealed class DiscordMessageComponentCommandAttribute : BaseApplicationCommandAttribute
    {
        internal readonly string CustomId;
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="customId">CustomID to match on. Matching uses string.StartsWith</param>
        public DiscordMessageComponentCommandAttribute(string customId)
        {
            CustomId = customId;
        }
    }
}