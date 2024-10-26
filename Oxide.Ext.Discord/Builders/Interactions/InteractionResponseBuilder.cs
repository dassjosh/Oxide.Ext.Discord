using Oxide.Ext.Discord.Entities;

namespace Oxide.Ext.Discord.Builders
{
    /// <summary>
    /// Represents a builder for <see cref="InteractionCallbackData"/>
    /// </summary>
    public class InteractionResponseBuilder : BaseInteractionMessageBuilder<InteractionCallbackData, InteractionResponseBuilder>
    {
        /// <summary>
        /// Constructor for creating a new InteractionCallbackData
        /// </summary>
        /// <param name="interaction">Interaction this followup is for</param>
        public InteractionResponseBuilder(DiscordInteraction interaction) : this(interaction, new InteractionCallbackData()) { }
        
        /// <summary>
        /// Constructor for using an existing InteractionCallbackData
        /// </summary>
        /// <param name="interaction">Interaction this followup is for</param>
        /// <param name="message">Message to use</param>
        public InteractionResponseBuilder(DiscordInteraction interaction, InteractionCallbackData message) : base(interaction, message) { }
    }
}