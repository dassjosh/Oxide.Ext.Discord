using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Oxide.Core.Plugins;
using Oxide.Ext.Discord.Builders;
using Oxide.Ext.Discord.Clients;
using Oxide.Ext.Discord.Exceptions;
using Oxide.Ext.Discord.Interfaces;
using Oxide.Ext.Discord.Libraries;

namespace Oxide.Ext.Discord.Entities
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
        /// Client for the webhook
        /// </summary>
        public WebhookClient Client { get; internal set; }
        
        private BaseClient GetClient(DiscordClient client) => (BaseClient)Client ?? client.Bot;

        /// <summary>
        /// Create a new webhook.
        /// Requires the MANAGE_WEBHOOKS permission.
        /// See <a href="https://discord.com/developers/docs/resources/webhook#create-webhook">Create Webhook</a>
        /// </summary>
        /// <param name="client">Client to use</param>
        /// <param name="channelId">Channel ID for the webhook</param>
        /// <param name="create">Webhook create request</param>
        public static IPromise<DiscordWebhook> CreateWebhook(DiscordClient client, Snowflake channelId, WebhookCreate create)
        {
            InvalidSnowflakeException.ThrowIfInvalid(channelId);
            return client.Bot.Rest.Post<DiscordWebhook>(client,$"channels/{channelId}/webhooks", create);
        }

        /// <summary>
        /// Returns a list of channel webhook.
        /// See <a href="https://discord.com/developers/docs/resources/webhook#get-channel-webhooks">Get Channel Webhooks</a>
        /// </summary>
        /// <param name="client">Client to use</param>
        /// <param name="channelId">Channel ID to get webhooks for</param>
        public static IPromise<List<DiscordWebhook>> GetChannelWebhooks(DiscordClient client, Snowflake channelId)
        {
            InvalidSnowflakeException.ThrowIfInvalid(channelId);
            return client.Bot.Rest.Get<List<DiscordWebhook>>(client,$"channels/{channelId}/webhooks");
        }

        /// <summary>
        /// Returns a list of guild webhooks
        /// See <a href="https://discord.com/developers/docs/resources/webhook#get-guild-webhooks">Get Guild Webhooks</a>
        /// </summary>
        /// <param name="client">Client to use</param>
        /// <param name="guildId">Guild ID to get webhooks for</param>
        public static IPromise<List<DiscordWebhook>> GetGuildWebhooks(DiscordClient client, Snowflake guildId)
        {
            InvalidSnowflakeException.ThrowIfInvalid(guildId);
            return client.Bot.Rest.Get<List<DiscordWebhook>>(client,$"guilds/{guildId}/webhooks");
        }

        /// <summary>
        /// Returns the webhook with the given webhook ID
        /// See <a href="https://discord.com/developers/docs/resources/webhook#get-webhook">Get Webhook</a>
        /// </summary>
        /// <param name="client">Client to use</param>
        /// <param name="webhookId">Webhook ID to get</param>
        public static IPromise<DiscordWebhook> GetWebhook(DiscordClient client, Snowflake webhookId)
        {
            InvalidSnowflakeException.ThrowIfInvalid(webhookId);
            return client.Bot.Rest.Get<DiscordWebhook>(client,$"webhooks/{webhookId}");
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
        public static IPromise<DiscordWebhook> GetWebhookWithToken(DiscordClient client, Snowflake webhookId, string webhookToken)
        {
            InvalidSnowflakeException.ThrowIfInvalid(webhookId);
            return client.Bot.Rest.Get<DiscordWebhook>(client,$"webhooks/{webhookId}/{webhookToken}");
        }
        
        internal static IPromise<DiscordWebhook> GetWebhookWithToken(DiscordClient client, WebhookClient webhookClient, Snowflake webhookId, string webhookToken)
        {
            InvalidSnowflakeException.ThrowIfInvalid(webhookId);
            return webhookClient.Rest.Get<DiscordWebhook>(client,$"webhooks/{webhookId}/{webhookToken}");
        }

        /// <summary>
        /// Returns the webhook with the given ID &amp; Token
        /// This call does not required authentication
        /// No user is returned in webhook object
        /// See <a href="https://discord.com/developers/docs/resources/webhook#get-webhook-with-token">Get Webhook with Token</a>
        /// </summary>
        /// <param name="client">Client to use</param>
        /// <param name="webhookUrl">Returns the webhook for the specified URL</param>
        public static IPromise<DiscordWebhook> GetWebhookWithUrl(DiscordClient client, string webhookUrl)
        {
            string[] webhookInfo = webhookUrl.Split(new[] {'/'}, StringSplitOptions.RemoveEmptyEntries);
            string id = webhookInfo[webhookInfo.Length - 2];
            string token = webhookInfo[webhookInfo.Length - 1];
            
            return client.Bot.Rest.Get<DiscordWebhook>(client,$"webhooks/{id}/{token}");
        }

        /// <summary>
        /// Modify a webhook.
        /// Requires the MANAGE_WEBHOOKS permission.
        /// See <a href="https://discord.com/developers/docs/resources/webhook#modify-webhook">Modify Webhook</a>
        /// </summary>
        /// <param name="client">Client to use</param>
        /// <param name="edit">Edit request for the webhook</param>
        public IPromise<DiscordWebhook> EditWebhook(DiscordClient client, WebhookEdit edit)
        {
            return client.Bot.Rest.Patch<DiscordWebhook>(client,$"webhooks/{Id}", edit);
        }

        /// <summary>
        /// Modify a webhook.
        /// Requires the MANAGE_WEBHOOKS permission.
        /// See <a href="https://discord.com/developers/docs/resources/webhook#modify-webhook-with-token">Modify Webhook with Token</a>
        /// </summary>
        /// <param name="client">Client to use</param>
        /// <param name="edit">Edit request for the webhook</param>
        public IPromise<DiscordWebhook> ModifyWebhookWithToken(DiscordClient client, WebhookEdit edit)
        {
            return GetClient(client).Rest.Patch<DiscordWebhook>(client,$"webhooks/{Id}/{Token}", edit);
        }

        /// <summary>
        /// Delete a webhook permanently.
        /// Requires the MANAGE_WEBHOOKS permission.
        /// See <a href="https://discord.com/developers/docs/resources/webhook#delete-webhook">Delete Webhook</a>
        /// </summary>
        /// <param name="client">Client to use</param>
        public IPromise DeleteWebhook(DiscordClient client)
        {
            return client.Bot.Rest.Delete(client,$"webhooks/{Id}");
        }

        /// <summary>
        /// Delete a webhook permanently.
        /// Does not require authentication.
        /// See <a href="https://discord.com/developers/docs/resources/webhook#delete-webhook-with-token">Delete Webhook with Token</a>
        /// </summary>
        /// <param name="client">Client to use</param>
        public IPromise DeleteWebhookWithToken(DiscordClient client)
        {
            return GetClient(client).Rest.Delete(client,$"webhooks/{Id}/{Token}");
        }

        /// <summary>
        /// Executes a webhook
        /// See <a href="https://discord.com/developers/docs/resources/webhook#execute-webhook">Execute Webhook</a>
        /// </summary>
        /// <param name="client">Client to use</param>
        /// <param name="message">Message data</param>
        /// <param name="executeParams">Webhook execution parameters</param>
        public IPromise ExecuteWebhook(DiscordClient client, WebhookCreateMessage message, WebhookExecuteParams executeParams = null)
        {
            if (executeParams == null)
            {
                executeParams = WebhookExecuteParams.Default;
            }

            return GetClient(client).Rest.Post(client,$"webhooks/{Id}/{Token}{executeParams.GetWebhookFormat()}{executeParams.ToQueryString()}", message);
        }
        
        /// <summary>
        /// Executes a webhook
        /// See <a href="https://discord.com/developers/docs/resources/webhook#execute-webhook">Execute Webhook</a>
        /// </summary>
        /// <param name="client">Client to use</param>
        /// <param name="builder">Builder for the message</param>
        /// <param name="executeParams">Webhook execution parameters</param>
        public IPromise ExecuteWebhook(DiscordClient client, WebhookMessageBuilder builder, WebhookExecuteParams executeParams = null)
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
        public IPromise<DiscordMessage> ExecuteWebhookWithMessage(DiscordClient client, WebhookCreateMessage message, WebhookExecuteParams executeParams = null)
        {
            if (executeParams == null)
            {
                executeParams = WebhookExecuteParams.DefaultWait;
            }

            return GetClient(client).Rest.Post<DiscordMessage>(client,$"webhooks/{Id}/{Token}{executeParams.GetWebhookFormat()}{executeParams.ToQueryString()}", message);
        }
        
        /// <summary>
        /// Executes a webhook
        /// See <a href="https://discord.com/developers/docs/resources/webhook#execute-webhook">Execute Webhook</a>
        /// </summary>
        /// <param name="client">Client to use</param>
        /// <param name="builder">Builder for the message</param>
        /// <param name="executeParams">Webhook execution parameters</param>
        public IPromise<DiscordMessage> ExecuteWebhookWithMessage(DiscordClient client, WebhookMessageBuilder builder, WebhookExecuteParams executeParams = null)
        {
            return ExecuteWebhookWithMessage(client, builder.Build(), executeParams);
        }

        /// <summary>
        /// Send a message to a webhook using a global message template
        /// </summary>
        /// <param name="client">Client to use</param>
        /// <param name="templateName">Template Name</param>
        /// <param name="message">Message to use (optional)</param>
        /// <param name="placeholders">Placeholders to apply (optional)</param>
        /// <param name="executeParams">Webhook execution parameters</param>
        public IPromise<DiscordMessage> ExecuteWebhookGlobalTemplate(DiscordClient client, TemplateKey templateName, WebhookCreateMessage message = null, PlaceholderData placeholders = null, WebhookExecuteParams executeParams = null)
        {
            WebhookCreateMessage template = DiscordExtension.DiscordMessageTemplates.GetGlobalTemplate(client.Plugin, templateName).ToMessage(placeholders, message);
            return ExecuteWebhookWithMessage(client, template, executeParams);
        }

        /// <summary>
        /// Send a message to a webhook using a localized message template
        /// </summary>
        /// <param name="client">Client to use</param>
        /// <param name="templateName">Template Name</param>
        /// <param name="language">Oxide language to use</param>
        /// <param name="message">Message to use (optional)</param>
        /// <param name="placeholders">Placeholders to apply (optional)</param>
        /// <param name="executeParams">Webhook execution parameters</param>
        public IPromise<DiscordMessage> ExecuteWebhookTemplate(DiscordClient client, TemplateKey templateName, string language = DiscordLocales.DefaultServerLanguage, WebhookCreateMessage message = null, PlaceholderData placeholders = null, WebhookExecuteParams executeParams = null)
        {
            WebhookCreateMessage template = DiscordExtension.DiscordMessageTemplates.GetLocalizedTemplate(client.Plugin, templateName, language).ToMessage(placeholders, message);
            return ExecuteWebhookWithMessage(client, template, executeParams);
        }

        /// <summary>
        /// Gets a previously-sent webhook message from the same token.
        /// See <a href="https://discord.com/developers/docs/resources/webhook#get-webhook-message">Edit Webhook Message</a>
        /// </summary>
        /// <param name="client">Client to use</param>
        /// <param name="messageId">Message ID to get</param>
        /// <param name="messageParams">Message Params</param>
        public IPromise<DiscordMessage> GetWebhookMessage(DiscordClient client, Snowflake messageId, WebhookMessageParams messageParams = null)
        {
            InvalidSnowflakeException.ThrowIfInvalid(messageId);
            return GetClient(client).Rest.Get<DiscordMessage>(client,$"webhooks/{Id}/{Token}/messages/{messageId}{messageParams?.ToQueryString()}");
        }
        
        /// <summary>
        /// Edits a previously-sent webhook message from the same token.
        /// See <a href="https://discord.com/developers/docs/resources/webhook#edit-webhook-message">Edit Webhook Message</a>
        /// </summary>
        /// <param name="client">Client to use</param>
        /// <param name="messageId">Message ID to edit</param>
        /// <param name="messageParams">Message Params</param>
        /// <param name="message">The updated message</param>
        public IPromise<DiscordMessage> EditWebhookMessage(DiscordClient client, Snowflake messageId, WebhookEditMessage message, WebhookMessageParams messageParams = null)
        {
            return GetClient(client).Rest.Patch<DiscordMessage>(client,$"webhooks/{Id}/{Token}/messages/{messageId}{messageParams?.ToQueryString()}", message);
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
        public IPromise<DiscordMessage> EditWebhookMessageGlobalTemplate(DiscordClient client, Snowflake messageId, Plugin plugin, TemplateKey templateName, WebhookEditMessage message = null, PlaceholderData placeholders = null, WebhookMessageParams messageParams = null)
        {
            WebhookEditMessage template = DiscordExtension.DiscordMessageTemplates.GetGlobalTemplate(plugin, templateName).ToMessage(placeholders, message);
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
        public IPromise<DiscordMessage> EditWebhookMessageTemplate(DiscordClient client, Snowflake messageId, Plugin plugin, TemplateKey templateName, string language = DiscordLocales.DefaultServerLanguage, WebhookEditMessage message = null, PlaceholderData placeholders = null, WebhookMessageParams messageParams = null)
        {
            WebhookEditMessage template = DiscordExtension.DiscordMessageTemplates.GetLocalizedTemplate(plugin, templateName, language).ToMessage(placeholders, message);
            return EditWebhookMessage(client, messageId, template, messageParams);
        }
        
        /// <summary>
        /// Deletes a message that was created by the webhook.
        /// </summary>
        /// <param name="client">Client to use</param>
        /// <param name="messageId">Message ID to delete</param>
        public IPromise DeleteWebhookMessage(DiscordClient client, Snowflake messageId)
        {
            InvalidSnowflakeException.ThrowIfInvalid(messageId);
            return GetClient(client).Rest.Delete(client,$"webhooks/{Id}/{Token}/messages/{messageId}");
        }
    }
}