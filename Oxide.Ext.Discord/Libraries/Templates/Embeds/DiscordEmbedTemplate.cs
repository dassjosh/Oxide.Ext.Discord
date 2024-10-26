using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Oxide.Ext.Discord.Callbacks;
using Oxide.Ext.Discord.Entities;
using Oxide.Ext.Discord.Exceptions;
using Oxide.Ext.Discord.Interfaces;
using Oxide.Ext.Discord.Types;

namespace Oxide.Ext.Discord.Libraries
{
    /// <summary>
    /// Discord Template for embed
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class DiscordEmbedTemplate : IBulkTemplate<DiscordEmbed>
    {
        /// <summary>
        /// If this embed is enabled
        /// </summary>
        [JsonProperty("Show Embed")]
        public bool Enabled { get; set; } = true;

        /// <summary>
        /// The Tile for the embed
        /// </summary>
        [JsonProperty("Embed Title")]
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// This Title Url for the embed
        /// </summary>
        [JsonProperty("Embed Title URL")]
        public string Url { get; set; } = string.Empty;

        /// <summary>
        /// The description of the embed
        /// </summary>
        [JsonProperty("Embed Description")]
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// The Hex Color for the embed
        /// </summary>
        [JsonProperty("Embed Hex Color")]
        public string Color { get; set; } = DiscordColor.Default.ToHex();

        /// <summary>
        /// Image URL to show in the embed
        /// </summary>
        [JsonProperty("Embed Image URL")]
        public string ImageUrl { get; set; } = string.Empty;

        /// <summary>
        /// Thumbnail url to show in the embed
        /// </summary>
        [JsonProperty("Embed Thumbnail URL")]
        public string ThumbnailUrl { get; set; } = string.Empty;

        /// <summary>
        /// Video url to show in the embed
        /// </summary>
        [JsonProperty("Embed Video Url")]
        public string VideoUrl { get; set; } = string.Empty;

        /// <summary>
        /// Show timestamp in the embed
        /// </summary>
        [JsonProperty("Show Embed TimeStamp")]
        public bool TimeStamp { get; set; } = false;

        /// <summary>
        /// Fields for the embed
        /// </summary>
        [JsonProperty("Embed Fields")]
        public List<DiscordEmbedFieldTemplate> Fields { get; set; } = new();

        /// <summary>
        /// Footer for the embed
        /// </summary>
        [JsonProperty("Embed Footer")]
        public EmbedFooterTemplate Footer { get; set; } = new();
        
        /// <summary>
        /// Constructor
        /// </summary>
        [JsonConstructor]
        public DiscordEmbedTemplate() { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="title"></param>
        /// <param name="description"></param>
        /// <param name="titleUrl"></param>
        public DiscordEmbedTemplate(string title, string description, string titleUrl = "")
        {
            Title = title;
            Description = description;
            Url = titleUrl;
        }

        /// <summary>
        /// Converts the template to a <see cref="DiscordEmbed"/>
        /// </summary>
        /// <param name="data">Data to use</param>
        /// <param name="embed">Initial embed to use</param>
        /// <returns></returns>
        public DiscordEmbed ToEntity(PlaceholderData data = null, DiscordEmbed embed = null)
        {
            embed ??= new DiscordEmbed();
            
            data?.IncrementDepth();

            DiscordPlaceholders placeholders = DiscordPlaceholders.Instance;
            embed.Title = placeholders.ProcessPlaceholders(Title, data);
            embed.Url = placeholders.ProcessPlaceholders(Url, data);
            embed.Description = placeholders.ProcessPlaceholders(Description, data);
            embed.Color = !string.IsNullOrEmpty(Color) ? new DiscordColor(placeholders.ProcessPlaceholders(Color, data)) : null;
            embed.Timestamp = TimeStamp ? DateTime.UtcNow : null;

            if (!string.IsNullOrEmpty(ImageUrl))
            {
                embed.Image = new EmbedImage
                {
                    Url = placeholders.ProcessPlaceholders(ImageUrl, data)
                };
            }

            if (!string.IsNullOrEmpty(ThumbnailUrl))
            {
                embed.Thumbnail = new EmbedThumbnail
                {
                    Url = placeholders.ProcessPlaceholders(ThumbnailUrl, data)
                };
            }

            if (!string.IsNullOrEmpty(VideoUrl))
            {
                embed.Video = new EmbedVideo
                {
                    Url = placeholders.ProcessPlaceholders(ThumbnailUrl, data)
                };
            }

            if (Fields != null && Fields.Count != 0)
            {
                InvalidEmbedException.ThrowIfInvalidFieldCount(Fields.Count);
                embed.Fields = new List<EmbedField>();
                for (int index = 0; index < Fields.Count; index++)
                {
                    EmbedField field = Fields[index].ToEntity(data);
                    if (field != null)
                    {
                        embed.Fields.Add(field);
                    }
                }
            }

            if (Footer != null && Footer.Enabled)
            {
                embed.Footer = Footer.ToFooter(data);
            }

            data?.DecrementDepth();
            data?.AutoDispose();
            
            return embed;
        }

        ///<inheritdoc/>
        public IPromise<List<DiscordEmbed>> ToEntityBulk(List<PlaceholderData> data = null)
        {
            IPendingPromise<List<DiscordEmbed>> promise = Promise<List<DiscordEmbed>>.Create();
            BulkToEntityCallback<DiscordEmbedTemplate, DiscordEmbed>.Start(this, data, promise);
            return promise;
        }
    }
}