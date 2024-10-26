using System;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents a <a href="https://discord.com/developers/docs/resources/channelattachment-flags">Attachment flags for an attachment</a>
    /// </summary>
    [Flags]
    public enum AttachmentFlags
    {
        /// <summary>
        /// No Attachment Flags
        /// </summary>
        None = 0,
        
        /// <summary>
        /// This attachment has been edited using the remix feature on mobile
        /// </summary>
        IsRemix = 1 << 2,
    }
}