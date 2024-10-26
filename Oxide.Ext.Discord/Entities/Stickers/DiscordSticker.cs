using Newtonsoft.Json;
using Oxide.Ext.Discord.Clients;
using Oxide.Ext.Discord.Exceptions;
using Oxide.Ext.Discord.Helpers;
using Oxide.Ext.Discord.Interfaces;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents a <a href="https://discord.com/developers/docs/resources/sticker#sticker-object">Discord Sticker Structure</a>
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class DiscordSticker : ISnowflakeEntity
    {
        /// <summary>
        /// ID of the sticker
        /// </summary>
        [JsonProperty("id")]
        public Snowflake Id { get; set; }
        
        /// <summary>
        /// ID of the pack the sticker is from
        /// </summary>
        [JsonProperty("pack_id")]
        public Snowflake? PackId { get; set; }
        
        /// <summary>
        /// Name of the sticker
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
        
        /// <summary>
        /// Description of the sticker
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }
        
        /// <summary>
        /// For guild stickers, a unicode emoji representing the sticker's expression.
        /// For nitro stickers, a comma-separated list of related expressions.
        /// autocomplete/suggestion tags for the sticker (max 200 characters)
        /// </summary>
        [JsonProperty("tags")]
        public string Tags { get; set; }

        /// <summary>
        /// Type of sticker.
        /// </summary>
        [JsonProperty("type")]
        public StickerType Type { get; set; }
        
        /// <summary>
        /// Type of sticker format
        /// <see cref="StickerFormatType"/>
        /// </summary>
        [JsonProperty("format_type")]
        public StickerFormatType FormatType { get; set; }
        
        /// <summary>
        /// Whether or not the sticker is available
        /// </summary>
        [JsonProperty("available")]
        public bool? Available { get; set; }
        
        /// <summary>
        /// Id of the guild that owns this sticker
        /// </summary>
        [JsonProperty("guild_id")]
        public Snowflake? GuildId { get; set; }
        
        /// <summary>
        /// The user that uploaded the sticker
        /// </summary>
        [JsonProperty("user")]
        public DiscordUser User { get; set; }
        
        /// <summary>
        /// A sticker's sort order within a pack
        /// </summary>
        [JsonProperty("sort_value")]
        public int? SortValue { get; set; }

        /// <summary>
        /// Returns the Url for the sticker
        /// </summary>
        public string StickerUrl => DiscordCdn.GetSticker(this);
        
        /// <summary>
        /// Returns a sticker object for the given sticker ID.
        /// See <a href="https://discord.com/developers/docs/resources/sticker#get-sticker">Get Sticker</a>
        /// </summary>
        /// <param name="client">Client to use</param>
        /// <param name="stickerId">ID of the sticker</param>
        public static IPromise<DiscordSticker> Get(DiscordClient client, Snowflake stickerId)
        {
            InvalidSnowflakeException.ThrowIfInvalid(stickerId);
            return client.Bot.Rest.Get<DiscordSticker>(client,$"stickers/{stickerId}");
        }
        
        /// <summary>
        /// Modify the given sticker.
        /// Requires the MANAGE_EMOJIS_AND_STICKERS permission.
        /// Returns the updated sticker object on success.
        /// See <a href="https://discord.com/developers/docs/resources/sticker#modify-guild-sticker">Modify Guild Sticker</a>
        /// </summary>
        /// <param name="client">Client to use</param>
        public IPromise<DiscordSticker> ModifyGuildSticker(DiscordClient client)
        {
            InvalidGuildStickerException.ThrowIfNotGuildType(Type, "This endpoint can only be used for guild stickers");
            return client.Bot.Rest.Patch<DiscordSticker>(client,$"guilds/{GuildId}/stickers/{Id}", this);
        }
        
        /// <summary>
        /// Delete the given sticker.
        /// Requires the MANAGE_EMOJIS_AND_STICKERS permission.
        /// See <a href="https://discord.com/developers/docs/resources/sticker#delete-guild-sticker">Delete Guild Sticker</a>
        /// </summary>
        /// <param name="client">Client to use</param>
        public IPromise DeleteGuildSticker(DiscordClient client)
        {
            InvalidGuildStickerException.ThrowIfNotGuildType(Type, "This endpoint can only be used for guild stickers");
            return client.Bot.Rest.Delete(client,$"guilds/{GuildId}/stickers/{Id}");
        }
        
        internal void Update(DiscordSticker sticker)
        {
            if (sticker.Name != null) Name = sticker.Name;
            if (sticker.Description != null) Description = sticker.Description;
            if (sticker.Tags != null) Tags = sticker.Tags;
        }
    }
}