using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Oxide.Ext.Discord.Exceptions;
using Oxide.Ext.Discord.Interfaces;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents <a href="https://discord.com/developers/docs/resources/guild#modify-guild">Update Guild Structure</a>
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class GuildUpdate : IDiscordValidation
    {
        /// <summary>
        /// Name of the guild (2-100 characters)
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
        
        /// <summary>
        /// Voice region id
        /// </summary>
        [Obsolete("Deprecated in Discord API")]
        [JsonProperty("region")]
        public string Region { get; set; }

        /// <summary>
        /// Verification level
        /// </summary>
        [JsonProperty("verification_level")]
        public GuildVerificationLevel? VerificationLevel { get; set; }
                
        /// <summary>
        /// Default message notification level
        /// </summary>
        [JsonProperty("default_message_notifications")]
        public DefaultNotificationLevel? DefaultMessageNotifications { get; set; }
             
        /// <summary>
        /// Explicit content filter level
        /// </summary>
        [JsonProperty("explicit_content_filter")]
        public ExplicitContentFilterLevel? ExplicitContentFilter { get; set; }

        /// <summary>
        /// ID of afk channel
        /// </summary>
        [JsonProperty("afk_channel_id")]
        public Snowflake? AfkChannelId { get; set; }
                
        /// <summary>
        /// Afk timeout in seconds
        /// Can be set to: null, 60, 300, 900, 1800, 3600
        /// </summary>
        [JsonProperty("afk_timeout")]
        public int? AfkTimeout { get; set; }
        
        /// <summary>
        /// Base64 128x128 image for the guild icon
        /// </summary>
        [JsonProperty("icon")]        
        public DiscordImageData? Icon { get; set; }
             
        /// <summary>
        /// User id to transfer guild ownership to (must be owner)
        /// </summary>
        [JsonProperty("owner_id")]
        public Snowflake? OwnerId { get; set; }
        
        /// <summary>
        /// Image for the guild splash (when the server has the INVITE_SPLASH feature)
        /// </summary>
        [JsonProperty("splash")]        
        public DiscordImageData? Splash { get; set; }
        
        /// <summary>
        /// Image for the guild discovery splash (when the server has the DISCOVERABLE feature)
        /// </summary>
        [JsonProperty("discovery_splash")]        
        public DiscordImageData? DiscoverySplash { get; set; }
        
        /// <summary>
        /// Image for the guild banner (when the server has the BANNER feature; can be animated gif when the server has the ANIMATED_BANNER feature)
        /// </summary>
        [JsonProperty("banner")]        
        public DiscordImageData? Banner { get; set; }
        
        /// <summary>
        /// The id of the channel where guild notices such as welcome messages and boost events are posted
        /// </summary>
        [JsonProperty("system_channel_id")]
        public Snowflake? SystemChannelId { get; set; }
        
        /// <summary>
        /// System channel flags
        /// </summary>
        [JsonProperty("system_channel_flags")]
        public SystemChannelFlags? SystemChannelFlags { get; set; }
        
        /// <summary>
        /// The id of the channel where Community guilds display rules and/or guidelines
        /// </summary>
        [JsonProperty("rules_channel_id")]
        public SystemChannelFlags? RulesChannelId { get; set; }

        /// <summary>
        /// The id of the channel where admins and moderators of Community guilds receive notices from Discord
        /// </summary>
        [JsonProperty("public_updates_channel_id")]
        public SystemChannelFlags? PublicUpdatesChannelId { get; set; }
        
        /// <summary>
        /// The preferred locale of a Community guild used in server discovery and notices from Discord; defaults to "en-US"
        /// </summary>
        [JsonProperty("preferred_locale")]
        public string PreferredLocale { get; set; }
        
        /// <summary>
        /// Enabled guild features
        /// </summary>
        [JsonProperty("features")]
        public List<GuildFeatures> Features { get; set; }
        
        /// <summary>
        /// The description for the guild
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }
        
        /// <summary>
        /// Whether the guild's boost progress bar should be enabled
        /// </summary>
        [JsonProperty("premium_progress_bar_enabled")]
        public bool? PremiumProgressBarEnabled { get; set; }
        
        /// <summary>
        /// The id of the channel where admins and moderators of Community guilds receive safety alerts from Discord
        /// </summary>
        [JsonProperty("safety_alerts_channel_id")]
        public SystemChannelFlags? SafetyAlertsChannelId { get; set; }
        
        ///<inheritdoc/>
        public void Validate()
        {
            InvalidGuildException.ThrowIfInvalidName(Name, true);
            InvalidImageDataException.ThrowIfInvalidImageData(Icon);
            InvalidImageDataException.ThrowIfInvalidImageData(Splash);
            InvalidImageDataException.ThrowIfInvalidImageData(DiscoverySplash);
            InvalidImageDataException.ThrowIfInvalidImageData(Banner);
            InvalidSnowflakeException.ThrowIfInvalid(AfkChannelId, false);
            InvalidSnowflakeException.ThrowIfInvalid(SystemChannelId, false);
        }
    }
}