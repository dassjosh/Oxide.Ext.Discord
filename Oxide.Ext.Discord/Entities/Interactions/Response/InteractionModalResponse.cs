namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents an Interaction Modal Response
    /// </summary>
    public class InteractionModalResponse : BaseInteractionResponse<InteractionModalMessage>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public InteractionModalResponse() { }

        /// <summary>
        /// Constructor with message
        /// </summary>
        /// <param name="message">Message to use for the response</param>
        public InteractionModalResponse(InteractionModalMessage message) : base(InteractionResponseType.Modal, message) { }
    }
}