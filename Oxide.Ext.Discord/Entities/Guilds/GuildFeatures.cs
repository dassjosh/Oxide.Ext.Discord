using Newtonsoft.Json;
using Oxide.Ext.Discord.Attributes;
using Oxide.Ext.Discord.Json;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents <a href="https://discord.com/developers/docs/resources/guild#guild-object-guild-features">Guild Features</a>
    /// </summary>
    [JsonConverter(typeof(DiscordEnumConverter))]
    public enum GuildFeatures : byte
    {
        /// <summary>
        /// Discord Extension doesn't currently support a guild features
        /// </summary>
        Unknown,
        
        /// <summary>
        /// Guild has access to set an animated guild banner image    
        /// </summary>
        [DiscordEnum("ANIMATED_BANNER")] 
        AnimatedBanner,
        
        /// <summary>
        /// Guild has access to set an animated guild icon
        /// </summary>
        [DiscordEnum("ANIMATED_ICON")] 
        AnimatedIcon,
        
        /// <summary>
        /// Guild is using the old permissions configuration behavior
        /// </summary>
        [DiscordEnum("APPLICATION_COMMAND_PERMISSIONS_V2")] 
        ApplicationCommandPermissionsV2,
        
        /// <summary>
        /// Guild has set up auto moderation rules
        /// </summary>
        [DiscordEnum("AUTO_MODERATION")] 
        AutoModeration,
        
        /// <summary>
        /// Guild has access to set a guild banner image
        /// </summary>
        [DiscordEnum("BANNER")] 
        Banner,

        /// <summary>
        /// Guild can enable welcome screen and discovery, and receives community updates
        /// </summary>
        [DiscordEnum("COMMUNITY")] 
        Community,
        
        /// <summary>
        /// Guild has enabled monetization
        /// </summary>
        [DiscordEnum("CREATOR_MONETIZABLE_PROVISIONAL")] 
        CreatorMonetizableProvisional,
        
        /// <summary>
        /// Guild has enabled the role subscription promo page
        /// </summary>
        [DiscordEnum("CREATOR_STORE_PAGE")] 
        CreatorStorePage,
        
        /// <summary>
        /// Guild has been set as a support server on the App Directory
        /// </summary>
        [DiscordEnum("DEVELOPER_SUPPORT_SERVER")] 
        DeveloperSupportServer,
        
        /// <summary>
        /// Guild is lurkable and able to be discovered in the directory
        /// </summary>
        [DiscordEnum("DISCOVERABLE")] 
        Discoverable,
        
        /// <summary>
        /// Guild is able to be featured in the directory
        /// </summary>
        [DiscordEnum("FEATURABLE")] 
        Featurable,
        
        /// <summary>
        /// Guild has paused invites, preventing new users from joining
        /// </summary>
        [DiscordEnum("INVITES_DISABLED")] 
        InvitesDisabled,
        
        /// <summary>
        /// Guild has access to set an invite splash background
        /// </summary>
        [DiscordEnum("INVITE_SPLASH")] 
        InviteSplash,
        
        /// <summary>
        /// Guild has enabled Membership Screening
        /// </summary>
        [DiscordEnum("MEMBER_VERIFICATION_GATE_ENABLED")] 
        MemberVerificationGateEnabled,
        
        /// <summary>
        /// Guild has increased custom sticker slots
        /// </summary>
        [DiscordEnum("MORE_STICKERS")] 
        MoreStickers,

        /// <summary>
        /// Guild has access to create news channels
        /// </summary>
        [DiscordEnum("NEWS")] 
        News,
        
        /// <summary>
        /// Guild is partnered
        /// </summary>
        [DiscordEnum("PARTNERED")] 
        Partnered,
        
        /// <summary>
        /// Guild can be previewed before joining via Membership Screening or the directory
        /// </summary>
        [DiscordEnum("PREVIEW_ENABLED")] 
        PreviewEnabled,
        
        /// <summary>
        /// Guild has disabled alerts for join raids in the configured safety alerts channel
        /// </summary>
        [DiscordEnum("RAID_ALERTS_DISABLED")] 
        RaidAlertsDisabled,
        
        /// <summary>
        /// Guild can be previewed before joining via Membership Screening or the directory
        /// </summary>
        [DiscordEnum("ROLE_ICONS")] 
        RoleIcons,

        /// <summary>
        /// Guild has role subscriptions that can be purchased
        /// </summary>
        [DiscordEnum("ROLE_SUBSCRIPTIONS_AVAILABLE_FOR_PURCHASE")] 
        RoleSubscriptionsAvailableForPurchase,
        
        /// <summary>
        /// Guild has enabled role subscriptions
        /// </summary>
        [DiscordEnum("ROLE_SUBSCRIPTIONS_ENABLED")] 
        RoleSubscriptionsEnabled,
        
        /// <summary>
        /// Guild has enabled ticketed events
        /// </summary>
        [DiscordEnum("TICKETED_EVENTS_ENABLED")] 
        TicketedEventsEnabled,
        
        /// <summary>
        /// Guild has access to set a vanity URL
        /// </summary>
        [DiscordEnum("VANITY_URL")] 
        VanityUrl,
        
        /// <summary>
        /// Guild is verified
        /// </summary>
        [DiscordEnum("VERIFIED")] 
        Verified,
        
        /// <summary>
        /// Guild has access to set 384kbps bitrate in voice (previously VIP voice servers)
        /// </summary>
        [DiscordEnum("VIP_REGIONS")] 
        VipRegions,
        
        /// <summary>
        /// Guild has enabled the welcome screen
        /// </summary>
        [DiscordEnum("WELCOME_SCREEN_ENABLED")] 
        WelcomeScreenEnabled,
    }
}