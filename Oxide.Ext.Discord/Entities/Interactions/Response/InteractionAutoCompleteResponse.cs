namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents an Auto Complete response in Discord
    /// </summary>
    public class InteractionAutoCompleteResponse : BaseInteractionResponse<InteractionAutoCompleteMessage>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public InteractionAutoCompleteResponse() { }

        /// <summary>
        /// Constructor with initial message
        /// </summary>
        /// <param name="message">Message to use for the response</param>
        public InteractionAutoCompleteResponse(InteractionAutoCompleteMessage message) : base(InteractionResponseType.ApplicationCommandAutocompleteResult, message) { }
    }
}