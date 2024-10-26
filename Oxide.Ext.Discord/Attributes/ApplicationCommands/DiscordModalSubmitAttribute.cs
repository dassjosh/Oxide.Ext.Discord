using System;
using Oxide.Ext.Discord.Entities;

namespace Oxide.Ext.Discord.Attributes
{
    /// <summary>
    /// Discord Message Component Command Attribute for <see cref="InteractionType.ModalSubmit"/>
    /// Callback Hook Format:
    /// <code>
    /// [DiscordModalSubmitAttribute("CustomId")]
    /// private void ModalSubmitCommand(DiscordInteraction interaction)
    /// {
    ///     Puts("ModalSubmitCommand Works!");
    /// }
    /// </code>
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public sealed class DiscordModalSubmitAttribute : BaseApplicationCommandAttribute
    {
        internal readonly string CustomId;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="customId">CustomID to match on. Matching uses string.StartsWith</param>
        public DiscordModalSubmitAttribute(string customId)
        {
            CustomId = customId;
        }
    }
}