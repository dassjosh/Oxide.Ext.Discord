using System;
using System.Collections.Generic;
using Oxide.Ext.Discord.Entities;
using Oxide.Ext.Discord.Exceptions;
using Oxide.Ext.Discord.Libraries;

namespace Oxide.Ext.Discord.Builders
{
    /// <summary>
    /// Represents a builder for <see cref="MessageCreate"/>
    /// </summary>
    /// <typeparam name="TMessage">Type of the message</typeparam>
    /// <typeparam name="TBuilder">Type of the builder</typeparam>
    public abstract class BaseChannelMessageBuilder<TMessage, TBuilder> : BaseMessageBuilder<TMessage, TBuilder>
        where TMessage : MessageCreate
        where TBuilder : BaseChannelMessageBuilder<TMessage, TBuilder>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">Message being created</param>
        protected BaseChannelMessageBuilder(TMessage message) : base(message) { }
        
        /// <summary>
        /// Adds a sticker to the message
        /// </summary>
        /// <param name="stickerId">Sticker ID to be added</param>
        /// <returns>This</returns>
        public TBuilder AddSticker(Snowflake stickerId)
        {
            InvalidSnowflakeException.ThrowIfInvalid(stickerId);
            Message.StickerIds ??= new List<Snowflake>();
            InvalidMessageException.ThrowIfMaxStickers(Message.StickerIds.Count + 1);
            Message.StickerIds.Add(stickerId);
            return Builder;
        }
        
        /// <summary>
        /// Adds a sticker to the message
        /// </summary>
        /// <param name="sticker">Sticker to be added</param>
        /// <returns>This</returns>
        public TBuilder AddSticker(DiscordSticker sticker)
        {
            if (sticker == null) throw new ArgumentNullException(nameof(sticker));
            return AddSticker(sticker.Id);
        }
    
        /// <summary>
        /// Adds stickers to the message
        /// </summary>
        /// <param name="stickerIds">Sticker ID's to be added</param>
        /// <returns>This</returns>
        public TBuilder AddStickers(ICollection<Snowflake> stickerIds)
        {
            if (stickerIds == null) throw new ArgumentNullException(nameof(stickerIds));
            InvalidSnowflakeException.ThrowIfInvalid(stickerIds);
            Message.StickerIds ??= new List<Snowflake>();
            InvalidMessageException.ThrowIfMaxStickers(Message.StickerIds.Count + stickerIds.Count);
            Message.StickerIds.AddRange(stickerIds);
            return Builder;
        }
        
        /// <summary>
        /// Adds stickers to the message
        /// </summary>
        /// <param name="stickerIds">Sticker ID's to be added</param>
        /// <returns>This</returns>
        public TBuilder AddStickers(ICollection<DiscordSticker> stickerIds)
        {
            if (stickerIds == null) throw new ArgumentNullException(nameof(stickerIds));
            List<Snowflake> ids = DiscordPool.Internal.GetList<Snowflake>();
            foreach (DiscordSticker sticker in stickerIds)
            {
                ids.Add(sticker.Id);
            }
            AddStickers(ids);
            DiscordPool.Internal.FreeList(ids);
                
            return Builder;
        }
        
        /// <summary>
        /// Adds a <see cref="MessageReference"/> to the message
        /// </summary>
        /// <param name="reference">Message Reference to be added</param>
        /// <returns>This</returns>
        public TBuilder AddMessageReference(MessageReference reference)
        {
            Message.MessageReference = reference ?? throw new ArgumentNullException(nameof(reference));
            return Builder;
        }

        /// <summary>
        /// Adds a <see cref="AddMessageReference"/> to the message
        /// </summary>
        /// <param name="message">Message to reply to</param>
        /// <param name="failIfNotExists">Should the API call error if the message does not exist (Default true)</param>
        /// <returns>This</returns>
        public TBuilder AddReply(DiscordMessage message, bool failIfNotExists = true)
        {
            if (message == null) throw new ArgumentNullException(nameof(message));
            return AddReply(message.Id, message.GuildId, failIfNotExists);
        }

        /// <summary>
        /// Adds a <see cref="AddMessageReference"/> to the message
        /// </summary>
        /// <param name="messageId">ID of the message to reply to</param>
        /// <param name="guildId">Guild ID of the message if one exists</param>
        /// <param name="failIfNotExists">Should the API call error if the message does not exist (Default true)</param>
        /// <returns>This</returns>
        public TBuilder AddReply(Snowflake messageId, Snowflake? guildId = null, bool failIfNotExists = true)
        {
            MessageReference reference = Message.MessageReference ?? new MessageReference();
            reference.MessageId = messageId;
            reference.GuildId = guildId;
            reference.FailIfNotExists = failIfNotExists;
            Message.MessageReference = reference;
            return Builder;
        }
        
        /// <summary>
        /// Adds a sticker to the message
        /// </summary>
        /// <param name="sticker">Sticker to be added</param>
        /// <returns>This</returns>
        public TBuilder SuppressNotifications(DiscordSticker sticker)
        {
            Message.Flags |= MessageFlags.SuppressNotifications;
            return Builder;
        }
    }
}