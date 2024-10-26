using Oxide.Ext.Discord.Exceptions;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents a Base Message for an interaction
    /// </summary>
    public abstract class BaseInteractionMessage : BaseMessageCreate
    {
        ///<inheritdoc/>
        protected override void ValidateRequiredFields() { }

        ///<inheritdoc/>
        protected override void ValidateFlags()
        {
            InvalidMessageException.ThrowIfInvalidFlags(Flags, MessageFlags.SuppressEmbeds | MessageFlags.Ephemeral | MessageFlags.SuppressNotifications, "Invalid Message Flags Used for Channel Message. Only supported flags are MessageFlags.SuppressEmbeds, MessageFlags.Ephemeral, and MessageFlags.SuppressNotifications");
        }
    }
}