using System;
using Oxide.Ext.Discord.Attributes;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents <a href="https://discord.com/developers/docs/resources/guild#guild-member-object-guild-member-flags">Guild Member Flags</a>
    /// </summary>
    [Flags]
    public enum GuildMemberFlags : ushort
    {
        /// <summary>
        /// No Flags
        /// </summary>
        None = 0,

        /// <summary>
        /// Member has left and rejoined the guild
        /// Editable: False
        /// </summary>
        [DiscordEnum("DID_REJOIN")]
        DidRejoin = 1 << 0,

        /// <summary>
        /// Member has completed onboarding
        /// Editable: False
        /// </summary>
        [DiscordEnum("COMPLETED_ONBOARDING")]
        CompletedOnboarding = 1 << 1,

        /// <summary>
        /// Member is exempt from guild verification requirements
        /// Editable: True
        /// </summary>
        [DiscordEnum("BYPASSES_VERIFICATION")]
        BypassesVerification = 1 << 2,

        /// <summary>
        /// Member has started onboarding
        /// Editable: False
        /// </summary>
        [DiscordEnum("STARTED_ONBOARDING")]
        StartedOnboarding = 1 << 3,

        /// <summary>
        /// Member is a guest and can only access the voice channel they were invited to
        /// Editable: False
        /// </summary>
        [DiscordEnum("IS_GUEST")]
        IsGuest = 1 << 4,

        /// <summary>
        /// Member has started Server Guide new member actions
        /// Editable: False
        /// </summary>
        [DiscordEnum("STARTED_HOME_ACTIONS")]
        StartedHomeActions = 1 << 5,

        /// <summary>
        /// Member has completed Server Guide new member actions
        /// Editable: False
        /// </summary>
        [DiscordEnum("COMPLETED_HOME_ACTIONS")]
        CompletedHomeActions = 1 << 6,

        /// <summary>
        /// Member's username, display name, or nickname is blocked by AutoMod
        /// Editable: False
        /// </summary>
        [DiscordEnum("AUTOMOD_QUARANTINED_USERNAME")]
        AutoModQuarantinedUsername = 1 << 7,

        /// <summary>
        /// Member has dismissed the DM settings upsell
        /// Editable: False
        /// </summary>
        [DiscordEnum("DM_SETTINGS_UPSELL_ACKNOWLEDGED")]
        DmSettingsUpsellAcknowledged = 1 << 9,
    }
}