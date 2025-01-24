using Oxide.Ext.Discord.Attributes;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents <a href="https://discord.com/developers/docs/resources/channel#message-object-message-types">Message Types</a>
    /// </summary>
    public enum MessageType : byte
    {
        /// <summary>
        /// The default message type
        /// </summary>
        [DiscordEnum("DEFAULT")]
        Default = 0,

        /// <summary>
        /// The message when a recipient is added
        /// </summary>
        [DiscordEnum("RECIPIENT_ADD")]
        RecipientAdd = 1,

        /// <summary>
        /// The message when a recipient is removed
        /// </summary>
        [DiscordEnum("RECIPIENT_REMOVE")]
        RecipientRemove = 2,

        /// <summary>
        /// The message when a user is called
        /// </summary>
        [DiscordEnum("CALL")]
        Call = 3,

        /// <summary>
        /// The message when a channel name is changed
        /// </summary>
        [DiscordEnum("CHANNEL_NAME_CHANGE")]
        ChannelNameChange = 4,

        /// <summary>
        /// The message when a channel icon is changed
        /// </summary>
        [DiscordEnum("CHANNEL_ICON_CHANGE")]
        ChannelIconChange = 5,

        /// <summary>
        /// The message when another message is pinned
        /// </summary>
        [DiscordEnum("CHANNEL_PINNED_MESSAGE")]
        ChannelPinnedMessage = 6,

        /// <summary>
        /// The message when a new member joined
        /// </summary>
        [DiscordEnum("USER_JOIN")]
        UserJoin = 7,

        /// <summary>
        ///  The message for when a user boosts a guild
        /// </summary>
        [DiscordEnum("GUILD_BOOST")]
        GuildBoost = 8,

        /// <summary>
        /// The message for when a guild reaches Tier 1 of Nitro boosts
        /// </summary>
        [DiscordEnum("GUILD_BOOST_TIER_1")]
        GuildBoostTier1 = 9,

        /// <summary>
        /// The message for when a guild reaches Tier 2 of Nitro boosts
        /// </summary>
        [DiscordEnum("GUILD_BOOST_TIER_2")]
        GuildBoostTier2 = 10,

        /// <summary>
        /// The message for when a guild reaches Tier 3 of Nitro boosts
        /// </summary>
        [DiscordEnum("GUILD_BOOST_TIER_3")]
        GuildBoostTier3 = 11,

        /// <summary>
        /// The message for when a news channel subscription is added to a text channel
        /// </summary>
        [DiscordEnum("CHANNEL_FOLLOW_ADD")]
        ChannelFollowAdd = 12,

        /// <summary>
        /// The message for when a guild discovery is disqualified
        /// </summary>
        [DiscordEnum("GUILD_DISCOVERY_DISQUALIFIED")]
        GuildDiscoveryDisqualified = 14,

        /// <summary>
        /// The message for when a guild discovery is requalified
        /// </summary>
        [DiscordEnum("GUILD_DISCOVERY_REQUALIFIED")]
        GuildDiscoveryRequalified = 15,

        /// <summary>
        /// The message for grace period initial warning
        /// </summary>
        [DiscordEnum("GUILD_DISCOVERY_GRACE_PERIOD_INITIAL_WARNING")]
        GuildDiscoveryGracePeriodInitialWarning = 16,

        /// <summary>
        /// The message for grace period final warning
        /// </summary>
        [DiscordEnum("GUILD_DISCOVERY_GRACE_PERIOD_FINAL_WARNING")]
        GuildDiscoveryGracePeriodFinalWarning = 17,

        /// <summary>
        /// The message created a thread
        /// </summary>
        [DiscordEnum("THREAD_CREATED")]
        ThreadCreated = 18,

        /// <summary>
        /// The message for when the message is a reply
        /// </summary>
        [DiscordEnum("REPLY")]
        Reply = 19,

        /// <summary>
        /// The message for when the message is an application command
        /// </summary>
        [DiscordEnum("CHAT_INPUT_COMMAND")]
        ChatInputCommand = 20,

        /// <summary>
        /// Starter message for a thread
        /// </summary>
        [DiscordEnum("THREAD_STARTER_MESSAGE")]
        ThreadStarterMessage = 21,

        /// <summary>
        /// Reminder for a guild invite
        /// </summary>
        [DiscordEnum("GUILD_INVITE_REMINDER")]
        GuildInviteReminder = 22,

        /// <summary>
        /// Reminder for a guild invite
        /// </summary>
        [DiscordEnum("CONTEXT_MENU_COMMAND")]
        ContextMenuCommand = 23,

        /// <summary>
        /// Message is an auto mod action
        /// </summary>
        [DiscordEnum("AUTO_MODERATION_ACTION")]
        AutoModerationAction = 24,

        /// <summary>
        /// Message is a role subscription purchase
        /// </summary>
        [DiscordEnum("ROLE_SUBSCRIPTION_PURCHASE")]
        RoleSubscriptionPurchase = 25,

        /// <summary>
        /// Message is a interaction premium upsell
        /// </summary>
        [DiscordEnum("INTERACTION_PREMIUM_UPSELL")]
        InteractionPremiumUpsell = 26,

        /// <summary>
        /// Message is a stage start
        /// </summary>
        [DiscordEnum("STAGE_START")]
        StageStart = 27,

        /// <summary>
        /// Message is a stage end
        /// </summary>
        [DiscordEnum("STAGE_END")]
        StageEnd = 28,

        /// <summary>
        /// Message is a stage speaker
        /// </summary>
        [DiscordEnum("STAGE_SPEAKER")]
        StageSpeaker = 29,

        /// <summary>
        /// Message is a stage raise hand
        /// </summary>
        [DiscordEnum("STAGE_RAISE_HAND")]
        StageRaiseHand = 30,

        /// <summary>
        /// Message is a stage topic
        /// </summary>
        [DiscordEnum("STAGE_TOPIC")]
        StageTopic = 31,

        /// <summary>
        /// Message is a Guild Application Premium Subscription
        /// </summary>
        [DiscordEnum("GUILD_APPLICATION_PREMIUM_SUBSCRIPTION")]
        GuildApplicationPremiumSubscription = 32,

        /// <summary>
        /// Message is a Guild Incident Alert Mode Enabled
        /// </summary>
        [DiscordEnum("GUILD_INCIDENT_ALERT_MODE_ENABLED")]
        GuildIncidentAlertModeEnabled = 36,

        /// <summary>
        /// Message is a Guild Incident Alert Mode Disabled
        /// </summary>
        [DiscordEnum("GUILD_INCIDENT_ALERT_MODE_DISABLED")]
        GuildIncidentAlertModeDisabled = 37,

        /// <summary>
        /// Message is a Guild Incident Report Raid
        /// </summary>
        [DiscordEnum("GUILD_INCIDENT_REPORT_RAID")]
        GuildIncidentReportRaid = 38,

        /// <summary>
        /// Message is a Guild Incident Report False Alarm
        /// </summary>
        [DiscordEnum("GUILD_INCIDENT_REPORT_FALSE_ALARM")]
        GuildIncidentReportFalseAlarm = 39,

        /// <summary>
        /// Message is a Purchase Notification
        /// </summary>
        [DiscordEnum("PURCHASE_NOTIFICATION")]
        PurchaseNotification = 44,

        /// <summary>
        /// Message is a poll result
        /// </summary>
        [DiscordEnum("POLL_RESULT")]
        PollResult = 44,
    }
}