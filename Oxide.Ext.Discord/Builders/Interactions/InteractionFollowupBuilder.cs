using Oxide.Ext.Discord.Entities;

namespace Oxide.Ext.Discord.Builders
{
    /// <summary>
    /// Represents a builder for <see cref="CommandFollowupCreate"/>
    /// </summary>
    public class InteractionFollowupBuilder : BaseInteractionMessageBuilder<CommandFollowupCreate, InteractionFollowupBuilder>
    {
        /// <summary>
        /// Constructor for creating a new CommandFollowupCreate
        /// </summary>
        /// <param name="interaction">Interaction this followup is for</param>
        public InteractionFollowupBuilder(DiscordInteraction interaction) : this(interaction, new CommandFollowupCreate()) { }
        
        /// <summary>
        /// Constructor for using an existing CommandFollowupCreate
        /// </summary>
        /// <param name="interaction">Interaction this followup is for</param>
        /// <param name="message">Message to use</param>
        public InteractionFollowupBuilder(DiscordInteraction interaction, CommandFollowupCreate message) : base(interaction, message) { }
    }
}