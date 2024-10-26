using System;
using System.Collections.Generic;
using Oxide.Ext.Discord.Entities;
using Oxide.Ext.Discord.Exceptions;

namespace Oxide.Ext.Discord.Builders
{
    /// <summary>
    /// Represents a builder for <see cref="BaseMessageCreate"/>
    /// </summary>
    /// <typeparam name="TMessage"></typeparam>
    /// <typeparam name="TBuilder"></typeparam>
    public abstract class BaseMessageBuilder<TMessage, TBuilder> 
        where TMessage : BaseMessageCreate
        where TBuilder : BaseMessageBuilder<TMessage, TBuilder> 
    {
        /// <summary>
        /// Message the builder is for
        /// </summary>
        protected readonly TMessage Message;
        
        /// <summary>
        /// This builder
        /// </summary>
        protected readonly TBuilder Builder;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">Message being created</param>
        protected BaseMessageBuilder(TMessage message)
        {
            Builder = (TBuilder)this;
            Message = message;
        }

        /// <summary>
        /// Adds message text
        /// </summary>
        /// <param name="content">Text to be added</param>
        /// <returns>This</returns>
        public virtual TBuilder AddContent(string content)
        {
            InvalidMessageException.ThrowIfInvalidContent(content);
            Message.Content = content;
            return Builder;
        }
        
        /// <summary>
        /// Marks the message As Text-To-Speech
        /// </summary>
        /// <param name="enabled">Should TTS be enabled (Default true)</param>
        /// <returns>this</returns>
        public virtual TBuilder AsTts(bool enabled = true)
        {
            Message.Tts = enabled;
            return Builder;
        }
        
        /// <summary>
        /// Adds a <see cref="DiscordEmbed"/>
        /// </summary>
        /// <param name="embed">Embed to be added</param>
        /// <returns>This</returns>
        public virtual TBuilder AddEmbed(DiscordEmbed embed)
        {
            if (embed == null) throw new ArgumentNullException(nameof(embed));
            Message.Embeds ??= new List<DiscordEmbed>();

            InvalidEmbedException.ThrowIfEmbedLimit(Message.Embeds.Count + 1);
            Message.Embeds.Add(embed);
            return Builder;
        }

        /// <summary>
        /// Adds <see cref="DiscordEmbed"/> created from a <see cref="DiscordEmbedBuilder"/>
        /// </summary>
        /// <param name="builder">Build to add embeds from</param>
        /// <returns>This</returns>
        public virtual TBuilder AddEmbed(DiscordEmbedBuilder builder)
        {
            if (builder == null) throw new ArgumentNullException(nameof(builder));
            return AddEmbed(builder.Build());
        }

        /// <summary>
        /// Adds a collection of <see cref="DiscordEmbed"/> to the response
        /// </summary>
        /// <param name="embeds">Embeds to be added</param>
        /// <returns>This</returns>
        public virtual TBuilder AddEmbeds(ICollection<DiscordEmbed> embeds)
        {
            if (embeds == null) throw new ArgumentNullException(nameof(embeds));
            Message.Embeds ??= new List<DiscordEmbed>();

            InvalidEmbedException.ThrowIfEmbedLimit(Message.Embeds.Count + embeds.Count);
            Message.Embeds.AddRange(embeds);
            return Builder;
        }

        /// <summary>
        /// Adds <see cref="AllowedMentions"/> to the response
        /// </summary>
        /// <param name="mentions">Mentions to be added</param>
        /// <returns>This</returns>
        public virtual TBuilder AddAllowedMentions(AllowedMentions mentions)
        {
            if (mentions == null) throw new ArgumentNullException(nameof(mentions));
            Message.AllowedMentions = mentions;
            return Builder;
        }

        /// <summary>
        /// Suppresses embeds on this response
        /// </summary>
        /// <returns>This</returns>
        public virtual TBuilder SuppressEmbeds()
        {
            Message.Flags |= MessageFlags.SuppressEmbeds;
            return Builder;
        }

        /// <summary>
        /// Adds a single <see cref="ActionRowComponent"/> 
        /// </summary>
        /// <param name="component">Component to be added</param>
        /// <returns>This</returns>
        public virtual TBuilder AddActionRow(ActionRowComponent component)
        {
            if (component == null) throw new ArgumentNullException(nameof(component));
            Message.Components ??= new List<ActionRowComponent>();

            InvalidMessageComponentException.ThrowIfInvalidMaxActionRows(Message.Components.Count + 1);
            Message.Components.Add(component);
            return Builder;
        }

        /// <summary>
        /// Adds a collection MessageComponents/>
        /// </summary>
        /// <param name="components">Components to be added</param>
        /// <returns>This</returns>
        public virtual TBuilder AddComponents(ICollection<ActionRowComponent> components)
        {
            if (components == null) throw new ArgumentNullException(nameof(components));
            Message.Components ??= new List<ActionRowComponent>();

            InvalidMessageComponentException.ThrowIfInvalidMaxActionRows(Message.Components.Count + components.Count);
            Message.Components.AddRange(components);
            return Builder;
        }

        /// <summary>
        /// Adds MessageComponents from <see cref="MessageComponentBuilder"/>
        /// </summary>
        /// <param name="builder">Build to add components from</param>
        /// <returns>This</returns>
        public virtual TBuilder AddComponents(MessageComponentBuilder builder)
        {
            if (builder == null) throw new ArgumentNullException(nameof(builder));
            return AddComponents(builder.Build());
        }

        /// <summary>
        /// Adds an attachment to the message
        /// </summary>
        /// <param name="filename">Name of the file</param>
        /// <param name="data">byte[] of the attachment</param>
        /// <param name="contentType">Attachment content type</param>
        /// <param name="description">Description for the attachment</param>
        /// <param name="title">Title of the attachment</param>
        public virtual TBuilder AddAttachment(string filename, byte[] data, string contentType, string description = null, string title = null)
        {
            Message.AddAttachment(filename, data, contentType, description, title);
            return Builder;
        }

        /// <summary>
        /// Returns the built message
        /// </summary>
        /// <returns></returns>
        public TMessage Build()
        {
            return Message;
        }
    }
}