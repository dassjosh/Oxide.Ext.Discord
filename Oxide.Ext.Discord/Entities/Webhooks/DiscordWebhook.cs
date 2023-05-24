﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Oxide.Core.Libraries;
using Oxide.Core.Plugins;
using Oxide.Ext.Discord.Builders.Messages;
using Oxide.Ext.Discord.Entities.Api;
using Oxide.Ext.Discord.Entities.Guilds;
using Oxide.Ext.Discord.Entities.Messages;
using Oxide.Ext.Discord.Entities.Users;
using Oxide.Ext.Discord.Exceptions.Entities;
using Oxide.Ext.Discord.Libraries.Langs;
using Oxide.Ext.Discord.Libraries.Placeholders;
using Oxide.Ext.Discord.Promise;

namespace Oxide.Ext.Discord.Entities.Webhooks
{
    /// <summary>
    /// Represents <a href="https://discord.com/developers/docs/resources/webhook#webhook-object">Webhook Structure</a>
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class DiscordWebhook
    {
        /// <summary>
        /// The id of the webhook
        /// </summary>
        [JsonProperty("id")]
        public Snowflake Id { get; set; }
        
        /// <summary>
        /// The type of the webhook
        /// See <see cref="WebhookType"/>
        /// </summary>
        [JsonProperty("type")]
        public WebhookType Type { get; set; }
        
        /// <summary>
        /// The guild id this webhook is for, if any
        /// </summary>
        [JsonProperty("guild_id")]
        public Snowflake? GuildId { get; set; }
        
        /// <summary>
        /// The channel id this webhook is for, if any
        /// </summary>
        [JsonProperty("channel_id")]
        public Snowflake? ChannelId { get; set; }
        
        /// <summary>
        /// The user this webhook was created by
        /// not returned when getting a webhook with its token
        /// </summary>
        [JsonProperty("user")]
        public DiscordUser User { get; set; }
        
        /// <summary>
        /// The default name of the webhook
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
        
        /// <summary>
        /// the default user avatar hash of the webhook
        /// </summary>
        [JsonProperty("avatar")]
        public string Avatar { get; set; }
        
        /// <summary>
        /// The secure token of the webhook
        /// returned for Incoming Webhooks
        /// </summary>
        [JsonProperty("token")]
        public string Token { get; set; }
        
        /// <summary>
        /// The bot/OAuth2 application that created this webhook
        /// </summary>
        [JsonProperty("application_id")]
        public Snowflake ApplicationId { get; set; }
        
        /// <summary>
        /// The guild of the channel that this webhook is following (returned for Channel Follower Webhooks)
        /// </summary>
        [JsonProperty("source_guild")]
        public DiscordGuild SourceGuild { get; set; }
        
        /// <summary>
        /// The channel that this webhook is following (returned for Channel Follower Webhooks)
        /// </summary>
        [JsonProperty("source_channel")]
        public Snowflake SourceChannel { get; set; }

        /// <summary>
        /// Create a new webhook.
        /// Requires the MANAGE_WEBHOOKS permission.
        /// See <a href="https://discord.com/developers/docs/resources/webhook#create-webhook">Create Webhook</a>
        /// </summary>
        /// <param name="client">Client to use</param>
        /// <param name="channelId">Channel ID for the webhook</param>
        /// <param name="create">Webhook create request</param>
        /// <param name="callback">Callback with the completed webhook</param>
        /// <param name="error">Callback when an error occurs with error information</param>
        public static IDiscordPromise<DiscordWebhook> CreateWebhook(DiscordClient client, Snowflake channelId, WebhookCreate create)
        {
            InvalidSnowflakeException.ThrowIfInvalid(channelId, nameof(channelId));
            return client.Bot.Rest.CreateRequest<DiscordWebhook>(client,$"channels/{channelId}/webhooks", RequestMethod.POST, create);
        }

        /// <summary>
        /// Returns a list of channel webhook.
        /// See <a href="https://discord.com/developers/docs/resources/webhook#get-channel-webhooks">Get Channel Webhooks</a>
        /// </summary>
        /// <param name="client">Client to use</param>
        /// <param name="channelId">Channel ID to get webhooks for</param>
        /// <param name="callback">Callback with a list of channel webhooks</param>
        /// <param name="error">Callback when an error occurs with error information</param>
        public static IDiscordPromise<List<DiscordWebhook>> GetChannelWebhooks(DiscordClient client, Snowflake channelId)
        {
            InvalidSnowflakeException.ThrowIfInvalid(channelId, nameof(channelId));
            return client.Bot.Rest.CreateRequest<List<DiscordWebhook>>(client,$"channels/{channelId}/webhooks", RequestMethod.GET);
        }

        /// <summary>
        /// Returns a list of guild webhooks
        /// See <a href="https://discord.com/developers/docs/resources/webhook#get-guild-webhooks">Get Guild Webhooks</a>
        /// </summary>
        /// <param name="client">Client to use</param>
        /// <param name="guildId">Guild ID to get webhooks for</param>
        /// <param name="callback">Callback with the list of guild webhooks</param>
        /// <param name="error">Callback when an error occurs with error information</param>
        public static IDiscordPromise<List<DiscordWebhook>> GetGuildWebhooks(DiscordClient client, Snowflake guildId)
        {
            InvalidSnowflakeException.ThrowIfInvalid(guildId, nameof(guildId));
            return client.Bot.Rest.CreateRequest<List<DiscordWebhook>>(client,$"guilds/{guildId}/webhooks", RequestMethod.GET);
        }

        /// <summary>
        /// Returns the webhook with the given webhook ID
        /// See <a href="https://discord.com/developers/docs/resources/webhook#get-webhook">Get Webhook</a>
        /// </summary>
        /// <param name="client">Client to use</param>
        /// <param name="webhookId">Webhook ID to get</param>
        /// <param name="callback">Callback with the webhook</param>
        /// <param name="error">Callback when an error occurs with error information</param>
        public static IDiscordPromise<DiscordWebhook> GetWebhook(DiscordClient client, Snowflake webhookId)
        {
            InvalidSnowflakeException.ThrowIfInvalid(webhookId, nameof(webhookId));
            return client.Bot.Rest.CreateRequest<DiscordWebhook>(client,$"webhooks/{webhookId}", RequestMethod.GET);
        }

        /// <summary>
        /// Returns the webhook with the given ID &amp; Token
        /// This call does not required authentication
        /// No user is returned in webhook object
        /// See <a href="https://discord.com/developers/docs/resources/webhook#get-webhook-with-token">Get Webhook with Token</a>
        /// </summary>
        /// <param name="client">Client to use</param>
        /// <param name="webhookId">Webhook ID to get</param>
        /// <param name="webhookToken">Webhook Token</param>
        /// <param name="callback">Callback with the webhook</param>
        /// <param name="error">Callback when an error occurs with error information</param>
        public static IDiscordPromise<DiscordWebhook> GetWebhookWithToken(DiscordClient client, Snowflake webhookId, string webhookToken)
        {
            InvalidSnowflakeException.ThrowIfInvalid(webhookId, nameof(webhookId));
            return client.Bot.Rest.CreateRequest<DiscordWebhook>(client,$"webhooks/{webhookId}/{webhookToken}", RequestMethod.GET);
        }

        /// <summary>
        /// Returns the webhook with the given ID &amp; Token
        /// This call does not required authentication
        /// No user is returned in webhook object
        /// See <a href="https://discord.com/developers/docs/resources/webhook#get-webhook-with-token">Get Webhook with Token</a>
        /// </summary>
        /// <param name="client">Client to use</param>
        /// <param name="webhookUrl">Returns the webhook for the specified URL</param>
        /// <param name="callback">Callback with the webhook</param>
        /// <param name="error">Callback when an error occurs with error information</param>
        public static IDiscordPromise<DiscordWebhook> GetWebhookWithUrl(DiscordClient client, string webhookUrl)
        {
            string[] webhookInfo = webhookUrl.Split(new[] {'/'}, StringSplitOptions.RemoveEmptyEntries);
            string id = webhookInfo[webhookInfo.Length - 2];
            string token = webhookInfo[webhookInfo.Length - 1];
            
            return client.Bot.Rest.CreateRequest<DiscordWebhook>(client,$"webhooks/{id}/{token}", RequestMethod.GET);
        }

        /// <summary>
        /// Modify a webhook.
        /// Requires the MANAGE_WEBHOOKS permission.
        /// See <a href="https://discord.com/developers/docs/resources/webhook#modify-webhook">Modify Webhook</a>
        /// </summary>
        /// <param name="client">Client to use</param>
        /// <param name="name">New webhook name</param>
        /// <param name="avatar">New avatar image</param>
        /// <param name="channelId">Channel to move the webhook to</param>
        /// <param name="callback">Callback with the updated webhook</param>
        /// <param name="error">Callback when an error occurs with error information</param>
        public IDiscordPromise<DiscordWebhook> EditWebhook(DiscordClient client, WebhookEdit edit)
        {
            return client.Bot.Rest.CreateRequest<DiscordWebhook>(client,$"webhooks/{Id}", RequestMethod.PATCH, edit);
        }

        /// <summary>
        /// Modify a webhook.
        /// Requires the MANAGE_WEBHOOKS permission.
        /// See <a href="https://discord.com/developers/docs/resources/webhook#modify-webhook-with-token">Modify Webhook with Token</a>
        /// </summary>
        /// <param name="client">Client to use</param>
        /// <param name="name">New webhook name</param>
        /// <param name="avatar">New avatar image</param>
        /// <param name="callback">Callback with the updated webhook</param>
        /// <param name="error">Callback when an error occurs with error information</param>
        public IDiscordPromise<DiscordWebhook> ModifyWebhookWithToken(DiscordClient client, WebhookEdit edit)
        {
            return client.Bot.Rest.CreateRequest<DiscordWebhook>(client,$"webhooks/{Id}/{Token}", RequestMethod.PATCH, edit);
        }

        /// <summary>
        /// Delete a webhook permanently.
        /// Requires the MANAGE_WEBHOOKS permission.
        /// See <a href="https://discord.com/developers/docs/resources/webhook#delete-webhook">Delete Webhook</a>
        /// </summary>
        /// <param name="client">Client to use</param>
        public IDiscordPromise DeleteWebhook(DiscordClient client)
        {
            return client.Bot.Rest.CreateRequest(client,$"webhooks/{Id}", RequestMethod.DELETE);
        }

        /// <summary>
        /// Delete a webhook permanently.
        /// Does not require authentication.
        /// See <a href="https://discord.com/developers/docs/resources/webhook#delete-webhook-with-token">Delete Webhook with Token</a>
        /// </summary>
        /// <param name="client">Client to use</param>
        /// <param name="callback">Callback once the action is completed</param>
        /// <param name="error">Callback when an error occurs with error information</param>
        public IDiscordPromise DeleteWebhookWithToken(DiscordClient client)
        {
            return client.Bot.Rest.CreateRequest(client,$"webhooks/{Id}/{Token}", RequestMethod.DELETE);
        }

        /// <summary>
        /// Executes a webhook
        /// See <a href="https://discord.com/developers/docs/resources/webhook#execute-webhook">Execute Webhook</a>
        /// </summary>
        /// <param name="client">Client to use</param>
        /// <param name="message">Message data</param>
        /// <param name="executeParams">Webhook execution parameters</param>
        /// <param name="callback">Callback once the action is completed</param>
        /// <param name="error">Callback when an error occurs with error information</param>
        public IDiscordPromise ExecuteWebhook(DiscordClient client, WebhookCreateMessage message, WebhookExecuteParams executeParams = null)
        {
            if (executeParams == null)
            {
                executeParams = WebhookExecuteParams.Default;
            }

            return client.Bot.Rest.CreateRequest(client,$"webhooks/{Id}/{Token}{executeParams.GetWebhookFormat()}{executeParams.ToQueryString()}", RequestMethod.POST, message);
        }
        
        /// <summary>
        /// Executes a webhook
        /// See <a href="https://discord.com/developers/docs/resources/webhook#execute-webhook">Execute Webhook</a>
        /// </summary>
        /// <param name="client">Client to use</param>
        /// <param name="builder">Builder for the message</param>
        /// <param name="executeParams">Webhook execution parameters</param>
        /// <param name="callback">Callback once the action is completed</param>
        /// <param name="error">Callback when an error occurs with error information</param>
        public IDiscordPromise ExecuteWebhook(DiscordClient client, WebhookMessageBuilder builder, WebhookExecuteParams executeParams = null)
        {
            return ExecuteWebhook(client, builder.Build(), executeParams);
        }

        /// <summary>
        /// Executes a webhook
        /// See <a href="https://discord.com/developers/docs/resources/webhook#execute-webhook">Execute Webhook</a>
        /// </summary>
        /// <param name="client">Client to use</param>
        /// <param name="message">Message data</param>
        /// <param name="executeParams">Webhook execution parameters</param>
        /// <param name="callback">Callback with the created message</param>
        /// <param name="error">Callback when an error occurs with error information</param>
        public IDiscordPromise<DiscordMessage> ExecuteWebhookWithMessage(DiscordClient client, WebhookCreateMessage message, WebhookExecuteParams executeParams = null)
        {
            if (executeParams == null)
            {
                executeParams = WebhookExecuteParams.DefaultWait;
            }

            return client.Bot.Rest.CreateRequest<DiscordMessage>(client,$"webhooks/{Id}/{Token}{executeParams.GetWebhookFormat()}{executeParams.ToQueryString()}", RequestMethod.POST, message);
        }
        
        /// <summary>
        /// Executes a webhook
        /// See <a href="https://discord.com/developers/docs/resources/webhook#execute-webhook">Execute Webhook</a>
        /// </summary>
        /// <param name="client">Client to use</param>
        /// <param name="builder">Builder for the message</param>
        /// <param name="executeParams">Webhook execution parameters</param>
        /// <param name="callback">Callback with the created message</param>
        /// <param name="error">Callback when an error occurs with error information</param>
        public IDiscordPromise<DiscordMessage> ExecuteWebhookWithMessage(DiscordClient client, WebhookMessageBuilder builder, WebhookExecuteParams executeParams = null)
        {
            return ExecuteWebhookWithMessage(client, builder.Build(), executeParams);
        }

        /// <summary>
        /// Send a message to a webhook using a global message template
        /// </summary>
        /// <param name="client">Client to use</param>
        /// <param name="plugin">Plugin for the template</param>
        /// <param name="templateName">Template Name</param>
        /// <param name="message">Message to use (optional)</param>
        /// <param name="placeholders">Placeholders to apply (optional)</param>
        /// <param name="executeParams">Webhook execution parameters</param>
        /// <param name="callback">Callback when the message is created</param>
        /// <param name="error">Callback when an error occurs with error information</param>
        public IDiscordPromise<DiscordMessage> ExecuteWebhookGlobalTemplate(DiscordClient client, Plugin plugin, string templateName, WebhookCreateMessage message = null, PlaceholderData placeholders = null, WebhookExecuteParams executeParams = null)
        {
            WebhookCreateMessage template = DiscordExtension.DiscordMessageTemplates.GetGlobalTemplate(plugin, templateName).ToMessage(placeholders, message);
            return ExecuteWebhookWithMessage(client, template, executeParams);
        }

        /// <summary>
        /// Send a message to a webhook using a localized message template
        /// </summary>
        /// <param name="client">Client to use</param>
        /// <param name="plugin">Plugin for the template</param>
        /// <param name="templateName">Template Name</param>
        /// <param name="language">Oxide language to use</param>
        /// <param name="message">Message to use (optional)</param>
        /// <param name="placeholders">Placeholders to apply (optional)</param>
        /// <param name="executeParams">Webhook execution parameters</param>
        /// <param name="callback">Callback when the message is created</param>
        /// <param name="error">Callback when an error occurs with error information</param>
        public IDiscordPromise<DiscordMessage> ExecuteWebhookTemplate(DiscordClient client, Plugin plugin, string templateName, string language = DiscordLang.DefaultOxideLanguage, WebhookCreateMessage message = null, PlaceholderData placeholders = null, WebhookExecuteParams executeParams = null)
        {
            WebhookCreateMessage template = DiscordExtension.DiscordMessageTemplates.GetLocalizedTemplate(plugin, templateName, language).ToMessage(placeholders, message);
            return ExecuteWebhookWithMessage(client, template, executeParams);
        }

        /// <summary>
        /// Gets a previously-sent webhook message from the same token.
        /// See <a href="https://discord.com/developers/docs/resources/webhook#get-webhook-message">Edit Webhook Message</a>
        /// </summary>
        /// <param name="client">Client to use</param>
        /// <param name="messageId">Message ID to get</param>
        /// <param name="messageParams">Message Params</param>
        /// <param name="callback">Callback with the message</param>
        /// <param name="error">Callback when an error occurs with error information</param>
        public IDiscordPromise<DiscordMessage> GetWebhookMessage(DiscordClient client, Snowflake messageId, WebhookMessageParams messageParams = null)
        {
            InvalidSnowflakeException.ThrowIfInvalid(messageId, nameof(messageId));
            return client.Bot.Rest.CreateRequest<DiscordMessage>(client,$"webhooks/{Id}/{Token}/messages/{messageId}{messageParams?.ToQueryString()}", RequestMethod.GET);
        }
        
        /// <summary>
        /// Edits a previously-sent webhook message from the same token.
        /// See <a href="https://discord.com/developers/docs/resources/webhook#edit-webhook-message">Edit Webhook Message</a>
        /// </summary>
        /// <param name="client">Client to use</param>
        /// <param name="messageId">Message ID to edit</param>
        /// <param name="messageParams">Message Params</param>
        /// <param name="message">The updated message</param>
        /// <param name="callback">Callback with the edited message</param>
        /// <param name="error">Callback when an error occurs with error information</param>
        public IDiscordPromise<DiscordMessage> EditWebhookMessage(DiscordClient client, Snowflake messageId, DiscordMessage message, WebhookMessageParams messageParams = null)
        {
            return client.Bot.Rest.CreateRequest<DiscordMessage>(client,$"webhooks/{Id}/{Token}/messages/{messageId}{messageParams?.ToQueryString()}", RequestMethod.PATCH, message);
        }

        /// <summary>
        /// Edit a message from a webhook using a global message template
        /// </summary>
        /// <param name="client">Client to use</param>
        /// <param name="messageId">Message ID of the message to edit</param>
        /// <param name="plugin">Plugin for the template</param>
        /// <param name="templateName">Template Name</param>
        /// <param name="message">Message to use (optional)</param>
        /// <param name="placeholders">Placeholders to apply (optional)</param>
        /// <param name="messageParams">Message Params</param>
        /// <param name="callback">Callback when the message is created</param>
        /// <param name="error">Callback when an error occurs with error information</param>
        public IDiscordPromise<DiscordMessage> EditWebhookMessageGlobalTemplate(DiscordClient client, Snowflake messageId, Plugin plugin, string templateName, DiscordMessage message = null, PlaceholderData placeholders = null, WebhookMessageParams messageParams = null)
        {
            DiscordMessage template = DiscordExtension.DiscordMessageTemplates.GetGlobalTemplate(plugin, templateName).ToMessage(placeholders, message);
            return EditWebhookMessage(client, messageId, template, messageParams);
        }

        /// <summary>
        /// Edit a message from a webhook using a localized message template
        /// </summary>
        /// <param name="client">Client to use</param>
        /// <param name="messageId">Message ID of the message to edit</param>
        /// <param name="plugin">Plugin for the template</param>
        /// <param name="templateName">Template Name</param>
        /// <param name="language">Oxide language to use</param>
        /// <param name="message">Message to use (optional)</param>
        /// <param name="placeholders">Placeholders to apply (optional)</param>
        /// <param name="messageParams">Message Params</param>
        /// <param name="callback">Callback when the message is created</param>
        /// <param name="error">Callback when an error occurs with error information</param>
        public IDiscordPromise<DiscordMessage> EditWebhookMessageTemplate(DiscordClient client, Snowflake messageId, Plugin plugin, string templateName, string language = DiscordLang.DefaultOxideLanguage, DiscordMessage message = null, PlaceholderData placeholders = null, WebhookMessageParams messageParams = null)
        {
            DiscordMessage template = DiscordExtension.DiscordMessageTemplates.GetLocalizedTemplate(plugin, templateName, language).ToMessage(placeholders, message);
            return EditWebhookMessage(client, messageId, template, messageParams);
        }
        
        /// <summary>
        /// Deletes a message that was created by the webhook.
        /// </summary>
        /// <param name="client">Client to use</param>
        /// <param name="messageId">Message ID to delete</param>
        /// <param name="callback">Callback once the action is completed</param>
        /// <param name="error">Callback when an error occurs with error information</param>
        public IDiscordPromise DeleteWebhookMessage(DiscordClient client, Snowflake messageId)
        {
            InvalidSnowflakeException.ThrowIfInvalid(messageId, nameof(messageId));
            return client.Bot.Rest.CreateRequest(client,$"webhooks/{Id}/{Token}/messages/{messageId}", RequestMethod.DELETE);
        }
    }
}
