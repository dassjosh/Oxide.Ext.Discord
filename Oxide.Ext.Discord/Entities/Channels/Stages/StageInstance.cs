using System;
using Newtonsoft.Json;
using Oxide.Ext.Discord.Clients;
using Oxide.Ext.Discord.Exceptions;
using Oxide.Ext.Discord.Interfaces;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents a channel <a href="https://discord.com/developers/docs/resources/stage-instance#stage-instance-object-stage-instance-structure">Stage Instance</a> within Discord.
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class StageInstance : ISnowflakeEntity
    {
        /// <summary>
        /// The ID of this Stage instance
        /// </summary>
        [JsonProperty("id")]
        public Snowflake Id { get; set; }
        
        /// <summary>
        /// The guild ID of the associated Stage channel
        /// </summary>
        [JsonProperty("guild_id")]
        public Snowflake GuildId { get; set; }
        
        /// <summary>
        /// The ID of the associated Stage channel
        /// </summary>
        [JsonProperty("channel_id")]
        public Snowflake ChannelId { get; set; }
        
        /// <summary>
        /// The topic of the Stage instance (1-120 characters)
        /// </summary>
        [JsonProperty("topic")]
        public string Topic { get; set; }
        
        /// <summary>
        /// The privacy level of the Stage instance
        /// </summary>
        [JsonProperty("privacy_level")]
        public PrivacyLevel PrivacyLevel { get; set; }
        
        /// <summary>
        /// Whether or not Stage discovery is disabled (deprecated)   
        /// </summary>
        [Obsolete("Deprecated by discord")]
        [JsonProperty("discoverable_disabled")]
        public bool DiscoverableDisabled { get; set; }
        
        /// <summary>
        /// The id of the scheduled event for this Stage instance
        /// </summary>
        [JsonProperty("guild_scheduled_event_id")]
        public Snowflake? GuildScheduledEventId { get; set; }

        /// <summary>
        /// Creates a new Stage instance associated to a Stage channel.
        /// Requires the user to be a moderator of the Stage channel.
        /// See <a href="https://discord.com/developers/docs/resources/stage-instance#create-stage-instance">Create Stage Instance</a>
        /// </summary>
        /// <param name="client">Client to use</param>
        /// <param name="create">Create Stage Instance Object</param>
        public static IPromise<StageInstance> Create(DiscordClient client, StageInstanceCreate create)
        {
            if (create == null) throw new ArgumentNullException(nameof(create));
            InvalidSnowflakeException.ThrowIfInvalid(create.ChannelId);
            return client.Bot.Rest.Post<StageInstance>(client,"stage-instances", create);
        }
        
        /// <summary>
        /// Gets the stage instance associated with the Stage channel, if it exists.
        /// See <a href="https://discord.com/developers/docs/resources/stage-instance#get-stage-instance">Get Stage Instance</a>
        /// </summary>
        /// <param name="client">Client to use</param>
        /// <param name="channelId">Channel ID to get the stage instance for</param>
        public static IPromise<StageInstance> Get(DiscordClient client, Snowflake channelId)
        {
            InvalidSnowflakeException.ThrowIfInvalid(channelId);
            return client.Bot.Rest.Get<StageInstance>(client,$"stage-instances/{channelId}");
        }

        /// <summary>
        /// Modifies fields of an existing Stage instance.
        /// Requires the user to be a moderator of the Stage channel.
        /// See <a href="https://discord.com/developers/docs/resources/stage-instance#modify-stage-instance">Update Stage Instance</a>
        /// </summary>
        /// <param name="client">Client to use</param>
        /// <param name="update">Update for the stage instance</param>
        public IPromise<StageInstance> Edit(DiscordClient client, StageInstanceUpdate update)
        {
            if (update == null) throw new ArgumentNullException(nameof(update));
            return client.Bot.Rest.Patch<StageInstance>(client,$"stage-instances/{ChannelId}", update);
        }
        
        /// <summary>
        /// Deletes the Stage instance.
        /// Requires the user to be a moderator of the Stage channel.
        /// See <a href="https://discord.com/developers/docs/resources/stage-instance#delete-stage-instance">Delete Stage Instance</a>
        /// </summary>
        /// <param name="client">Client to use</param>
        public IPromise Delete(DiscordClient client)
        {
            return client.Bot.Rest.Delete(client,$"stage-instances/{ChannelId}");
        }

        internal StageInstance Edit(StageInstance stage)
        {
            StageInstance previous = (StageInstance)MemberwiseClone();
            if (stage.Topic != null)
                Topic = stage.Topic;

            PrivacyLevel = stage.PrivacyLevel;
            
            return previous;
        }
    }
}