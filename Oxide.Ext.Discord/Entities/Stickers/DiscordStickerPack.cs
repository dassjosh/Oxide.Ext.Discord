using System.Collections.Generic;
using Newtonsoft.Json;
using Oxide.Ext.Discord.Clients;
using Oxide.Ext.Discord.Exceptions;
using Oxide.Ext.Discord.Interfaces;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents a <a href="https://discord.com/developers/docs/resources/sticker#sticker-pack-object">Sticker Pack Object</a>
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class DiscordStickerPack
    {
        /// <summary>
        /// ID of the sticker pack
        /// </summary>
        [JsonProperty("id")]
        public Snowflake Id { get; set; }

        /// <summary>
        /// The stickers in the pack
        /// </summary>
        [JsonProperty("stickers")]
        public List<DiscordSticker> Stickers { get; set; }

        /// <summary>
        /// Name of the sticker pack
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// ID of the pack's SKU
        /// </summary>
        [JsonProperty("sku_id")]
        public Snowflake SkuId { get; set; }

        /// <summary>
        /// ID of a sticker in the pack which is shown as the pack's icon
        /// </summary>
        [JsonProperty("cover_sticker_id")]
        public Snowflake? CoverStickerId { get; set; }

        /// <summary>
        /// Description of the sticker pack
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// ID of the sticker pack's banner image
        /// </summary>
        [JsonProperty("banner_asset_id")]
        public Snowflake? BannerAssetId { get; set; }

        /// <summary>
        /// Returns a sticker pack object for the given sticker pack ID.
        /// See <a href="https://discord.com/developers/docs/resources/sticker#get-sticker-pack">List Nitro Sticker Packs</a>
        /// </summary>
        /// <param name="client">Client to use</param>
        /// <param name="packId">ID of the pack</param>
        public static IPromise<DiscordStickerPack> GetStickerPack(DiscordClient client, Snowflake packId)
        {
            InvalidSnowflakeException.ThrowIfInvalid(packId);
            return client.Bot.Rest.Get<DiscordStickerPack>(client, $"sticker-packs/{packId}");
        }

        /// <summary>
        /// Returns the list of sticker packs available to Nitro subscribers.
        /// See <a href="https://discord.com/developers/docs/resources/sticker#list-nitro-sticker-packs">List Nitro Sticker Packs</a>
        /// </summary>
        /// <param name="client">Client to use</param>
        public static IPromise<List<DiscordStickerPack>> GetStickerPacks(DiscordClient client)
        {
            return client.Bot.Rest.Get<List<DiscordStickerPack>>(client, "sticker-packs");
        }
    }
}