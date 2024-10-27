using System.Collections.Generic;
using Newtonsoft.Json;
using Oxide.Ext.Discord.Clients;
using Oxide.Ext.Discord.Interfaces;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents <a href="https://discord.com/developers/docs/resources/soundboard#soundboard-sound-object">Soundboard</a> in Discord
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class DiscordSoundboardSound : ISnowflakeEntity
    {
        /// <summary>
        /// ID of the sound
        /// </summary>
        public Snowflake Id => SoundId;
        
        /// <summary>
        /// Name of this sound
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
        
        /// <summary>
        /// ID of this sound
        /// </summary>
        [JsonProperty("sound_id")]
        public Snowflake SoundId { get; set; }
        
        /// <summary>
        /// Volume of this sound, from 0 to 1
        /// </summary>
        [JsonProperty("volume")]
        public double Volume { get; set; }
        
        /// <summary>
        /// ID of this sound's custom emoji
        /// </summary>
        [JsonProperty("emoji_id")]
        public Snowflake? EmojiId { get; set; }
        
        /// <summary>
        /// Unicode character of this sound's standard emoji
        /// </summary>
        [JsonProperty("emoji_name")]
        public string EmojiName { get; set; }
        
        /// <summary>
        /// ID of the guild this sound is in
        /// </summary>
        [JsonProperty("guild_id")]
        public Snowflake GuildId { get; set; }
        
        /// <summary>
        /// Whether this sound can be used, may be false due to loss of Server Boosts
        /// </summary>
        [JsonProperty("available")]
        public bool Available { get; set; }
        
        /// <summary>
        /// User who created this sound
        /// </summary>
        [JsonProperty("user")]
        public DiscordUser User { get; set; }
        
        /// <summary>
        /// Returns a list of soundboard sound objects that can be used by all users.
        /// See <a href="https://discord.com/developers/docs/resources/soundboard#list-default-soundboard-sounds">List Default Soundboard Sounds</a>
        /// </summary>
        /// <param name="client">Client to use</param>
        public static IPromise<List<DiscordSoundboardSound>> GetDefaultSounds(DiscordClient client)
        {
            return client.Bot.Rest.Get<List<DiscordSoundboardSound>>(client,$"soundboard-default-sounds");
        }

        /// <summary>
        /// Returns a list of soundboard sound objects that can be used by all users.
        /// See <a href="https://discord.com/developers/docs/resources/soundboard#list-default-soundboard-sounds">List Default Soundboard Sounds</a>
        /// </summary>
        /// <param name="client">Client to use</param>
        /// <param name="update">Update to apply</param>
        public IPromise<DiscordSoundboardSound> Edit(DiscordClient client, SoundboardSoundUpdate update)
        {
            return client.Bot.Rest.Patch<DiscordSoundboardSound>(client,$"guilds/{GuildId}/soundboard-sounds/{Id}", update);
        }
        
        /// <summary>
        /// Returns a list of soundboard sound objects that can be used by all users.
        /// See <a href="https://discord.com/developers/docs/resources/soundboard#list-default-soundboard-sounds">List Default Soundboard Sounds</a>
        /// </summary>
        /// <param name="client">Client to use</param>
        public IPromise Delete(DiscordClient client)
        {
            return client.Bot.Rest.Delete(client,$"guilds/{GuildId}/soundboard-sounds/{Id}");
        }

        internal void Update(DiscordSoundboardSound update)
        {
            if (!string.IsNullOrEmpty(update.Name) && Name != update.Name) Name = update.Name;
            if (Volume != update.Volume) Volume = update.Volume;
            if (EmojiId != update.EmojiId) EmojiId = update.EmojiId;
            if (!string.IsNullOrEmpty(update.EmojiName) && EmojiName != update.EmojiName) EmojiName = update.EmojiName;
            if (Available != update.Available) Available = update.Available;
        } 
    }
}