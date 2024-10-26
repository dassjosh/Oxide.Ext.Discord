using System;
using Oxide.Ext.Discord.Attributes;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents <a href="https://discord.com/developers/docs/topics/gateway#activity-object-activity-flags">Activity Flags</a>
    /// </summary>
    [Flags]
    public enum ActivityFlags
    {
        /// <summary>
        /// No Actions can be done to this activity
        /// </summary>
        [DiscordEnum("NONE")]
        None = 0,
        
        /// <summary>
        /// No Actions can be done to this activity
        /// </summary>
        [DiscordEnum("INSTANCE")]
        Instance = 1 << 0,
        
        /// <summary>
        /// Activity can be joined
        /// </summary>
        [DiscordEnum("JOIN")]
        Join = 1 << 1,
        
        /// <summary>
        /// Activity can be spectated
        /// </summary>
        [DiscordEnum("SPECTATE")]
        Spectate = 1 << 2,
        
        /// <summary>
        /// User may request to join activity
        /// </summary>
        [DiscordEnum("JOIN_REQUEST")]
        JoinRequest = 1 << 3,
        
        /// <summary>
        /// User can listen along in spotify
        /// </summary>
        [DiscordEnum("SYNC")]
        Sync = 1 << 4,
        
        /// <summary>
        /// User can play this song
        /// </summary>
        [DiscordEnum("PLAY")]
        Play = 1 << 5,

        /// <summary>
        /// User is playing an activity in a voice channel with friends
        /// </summary>
        [DiscordEnum("PARTY_PRIVACY_FRIENDS")]
        PartyPrivacyFriends = 1 << 6,
        
        /// <summary>
        /// User is playing an activity in a voice channel
        /// </summary>
        [DiscordEnum("PARTY_PRIVACY_VOICE_CHANNEL")]
        PartyPrivacyVoiceChannel = 1 << 7,
        
        /// <summary>
        /// User is playing embedded activity
        /// </summary>
        [DiscordEnum("EMBEDDED")]
        Embedded = 1 << 8,
    }
}