# Oxide.Ext.Discord assembly

## Oxide.Ext.Discord namespace

| public type | description |
| --- | --- |
| class [DiscordExtension](./Oxide.Ext.Discord/DiscordExtension.md) | Discord Extension that is loaded by Oxide |

## Oxide.Ext.Discord.Attributes namespace

| public type | description |
| --- | --- |
| abstract class [BaseApplicationCommandAttribute](./Oxide.Ext.Discord/Attributes/BaseApplicationCommandAttribute.md) | Base attribute for Application Commands |
| abstract class [BaseCommandAttribute](./Oxide.Ext.Discord/Attributes/BaseCommandAttribute.md) | Represents a base attribute for commands |
| abstract class [BaseDiscordAttribute](./Oxide.Ext.Discord/Attributes/BaseDiscordAttribute.md) | Base Attribute for all Discord Extension Attributes |
| class [DirectMessageCommandAttribute](./Oxide.Ext.Discord/Attributes/DirectMessageCommandAttribute.md) | Used to identify direct message bot commands |
| class [DiscordApplicationCommandAttribute](./Oxide.Ext.Discord/Attributes/DiscordApplicationCommandAttribute.md) | Discord Application Command Attribute for ApplicationCommand Callback Hook Format: |
| class [DiscordAutoCompleteCommandAttribute](./Oxide.Ext.Discord/Attributes/DiscordAutoCompleteCommandAttribute.md) | Discord Auto Complete Command Attribute for ApplicationCommandAutoComplete Callback Hook Format: |
| class [DiscordMessageComponentCommandAttribute](./Oxide.Ext.Discord/Attributes/DiscordMessageComponentCommandAttribute.md) | Discord Message Component Command Attribute for MessageComponent Callback Hook Format: |
| class [DiscordModalSubmitAttribute](./Oxide.Ext.Discord/Attributes/DiscordModalSubmitAttribute.md) | Discord Message Component Command Attribute for ModalSubmit Callback Hook Format: |
| class [GuildCommandAttribute](./Oxide.Ext.Discord/Attributes/GuildCommandAttribute.md) | Used to identify guild bot commands |

## Oxide.Ext.Discord.Builders namespace

| public type | description |
| --- | --- |
| class [ApplicationCommandBuilder](./Oxide.Ext.Discord/Builders/ApplicationCommandBuilder.md) | Builder to use when building application commands |
| class [ApplicationCommandGroupBuilder](./Oxide.Ext.Discord/Builders/ApplicationCommandGroupBuilder.md) | Builder for Sub Command Groups |
| class [ApplicationCommandOptionBuilder](./Oxide.Ext.Discord/Builders/ApplicationCommandOptionBuilder.md) | Represents a Subcommand Option Builder for SubCommands |
| class [ApplicationSubCommandBuilder](./Oxide.Ext.Discord/Builders/ApplicationSubCommandBuilder.md) | Application Sub Command Builder |
| enum [AutoCompleteSearchMode](./Oxide.Ext.Discord/Builders/AutoCompleteSearchMode.md) | AutoComplete Search Mode for [`InteractionAutoCompleteBuilder`](./Oxide.Ext.Discord/Builders/InteractionAutoCompleteBuilder.md) |
| abstract class [BaseChannelMessageBuilder&lt;TMessage,TBuilder&gt;](./Oxide.Ext.Discord/Builders/BaseChannelMessageBuilder%7BTMessage,TBuilder%7D.md) | Represents a builder for [`MessageCreate`](./Oxide.Ext.Discord/Entities/MessageCreate.md) |
| abstract class [BaseInteractionMessageBuilder&lt;TMessage,TBuilder&gt;](./Oxide.Ext.Discord/Builders/BaseInteractionMessageBuilder%7BTMessage,TBuilder%7D.md) | Represents a builder for [`BaseInteractionMessage`](./Oxide.Ext.Discord/Entities/BaseInteractionMessage.md) |
| abstract class [BaseMessageBuilder&lt;TMessage,TBuilder&gt;](./Oxide.Ext.Discord/Builders/BaseMessageBuilder%7BTMessage,TBuilder%7D.md) | Represents a builder for [`BaseMessageCreate`](./Oxide.Ext.Discord/Entities/BaseMessageCreate.md) |
| abstract class [BaseWebhookMessageBuilder&lt;TMessage,TBuilder&gt;](./Oxide.Ext.Discord/Builders/BaseWebhookMessageBuilder%7BTMessage,TBuilder%7D.md) | Represents a builder for [`WebhookCreateMessage`](./Oxide.Ext.Discord/Entities/WebhookCreateMessage.md) |
| class [DiscordEmbedBuilder](./Oxide.Ext.Discord/Builders/DiscordEmbedBuilder.md) | Builds a new DiscordEmbed |
| class [DiscordMessageBuilder](./Oxide.Ext.Discord/Builders/DiscordMessageBuilder.md) | Represents a builder for [`MessageCreate`](./Oxide.Ext.Discord/Entities/MessageCreate.md) |
| class [InteractionAutoCompleteBuilder](./Oxide.Ext.Discord/Builders/InteractionAutoCompleteBuilder.md) | Builder for Auto Complete Interaction |
| class [InteractionFollowupBuilder](./Oxide.Ext.Discord/Builders/InteractionFollowupBuilder.md) | Represents a builder for [`CommandFollowupCreate`](./Oxide.Ext.Discord/Entities/CommandFollowupCreate.md) |
| class [InteractionModalBuilder](./Oxide.Ext.Discord/Builders/InteractionModalBuilder.md) | Builds a Modal Interaction Response Message |
| class [InteractionResponseBuilder](./Oxide.Ext.Discord/Builders/InteractionResponseBuilder.md) | Represents a builder for [`InteractionCallbackData`](./Oxide.Ext.Discord/Entities/InteractionCallbackData.md) |
| class [MessageComponentBuilder](./Oxide.Ext.Discord/Builders/MessageComponentBuilder.md) | Builder for Message Components |
| [Flags] enum [PlayerDisplayNameMode](./Oxide.Ext.Discord/Builders/PlayerDisplayNameMode.md) | Player Name Formatting options for [`PlayerNameFormatter`](./Oxide.Ext.Discord/Builders/PlayerNameFormatter.md) |
| class [PlayerNameFormatter](./Oxide.Ext.Discord/Builders/PlayerNameFormatter.md) | Formatter for player names |
| struct [QueryStringBuilder](./Oxide.Ext.Discord/Builders/QueryStringBuilder.md) | Builder used to build query strings for urls |
| class [SelectMenuComponentBuilder](./Oxide.Ext.Discord/Builders/SelectMenuComponentBuilder.md) | Builder for Select Menus |
| class [WebhookMessageBuilder](./Oxide.Ext.Discord/Builders/WebhookMessageBuilder.md) | Represents a builder for [`WebhookMessageBuilder`](./Oxide.Ext.Discord/Builders/WebhookMessageBuilder.md) |

## Oxide.Ext.Discord.Builders.Ansi namespace

| public type | description |
| --- | --- |
| class [AnsiBuilder](./Oxide.Ext.Discord/Builders/Ansi/AnsiBuilder.md) | Builder for ANSI colored text |
| enum [BackgroundColor](./Oxide.Ext.Discord/Builders/Ansi/BackgroundColor.md) | Ansi Background colors |
| [Flags] enum [FontStyle](./Oxide.Ext.Discord/Builders/Ansi/FontStyle.md) | Font Styles for ANSI text |
| enum [TextColor](./Oxide.Ext.Discord/Builders/Ansi/TextColor.md) | Text Colors for Ansi Text |

## Oxide.Ext.Discord.Cache namespace

| public type | description |
| --- | --- |
| class [DiscordPluginCache](./Oxide.Ext.Discord/Cache/DiscordPluginCache.md) | Represents a cache for Loaded and Loadable plugins |
| class [EmojiCache](./Oxide.Ext.Discord/Cache/EmojiCache.md) | Cached Emoji Data |
| class [EntityCache&lt;T&gt;](./Oxide.Ext.Discord/Cache/EntityCache%7BT%7D.md) | Cache for {T} |
| class [EnumCache&lt;T&gt;](./Oxide.Ext.Discord/Cache/EnumCache%7BT%7D.md) | Represents a cache of enum strings |
| class [ServerPlayerCache](./Oxide.Ext.Discord/Cache/ServerPlayerCache.md) | Cache for server IPlayer |
| class [StringCache&lt;T&gt;](./Oxide.Ext.Discord/Cache/StringCache%7BT%7D.md) | Caches strings from {T} ToString method |

## Oxide.Ext.Discord.Callbacks namespace

| public type | description |
| --- | --- |
| abstract class [BaseAsyncCallback](./Oxide.Ext.Discord/Callbacks/BaseAsyncCallback.md) | Represents a base callback to be used when needing a lambda callback so no delegate or class is generated This class is pooled to prevent allocations |
| abstract class [BaseCallback](./Oxide.Ext.Discord/Callbacks/BaseCallback.md) | Represents a base callback to be used when needing a lambda callback so no delegate or class is generated This class is pooled to prevent allocations |
| abstract class [BaseCallback&lt;T&gt;](./Oxide.Ext.Discord/Callbacks/BaseCallback%7BT%7D.md) | Represents a base callback to be used when needing a lambda callback so no delegate or class is generated This class is pooled to prevent allocations |
| abstract class [BaseNextTickCallback](./Oxide.Ext.Discord/Callbacks/BaseNextTickCallback.md) | Represents a callback that calls next tick |

## Oxide.Ext.Discord.Clients namespace

| public type | description |
| --- | --- |
| abstract class [BaseClient](./Oxide.Ext.Discord/Clients/BaseClient.md) | BaseClient that can connect to discord |
| class [BotClient](./Oxide.Ext.Discord/Clients/BotClient.md) | Represents a bot connected to discord |
| class [DiscordClient](./Oxide.Ext.Discord/Clients/DiscordClient.md) | Represents the object a plugin uses to connect to discord |
| class [WebhookClient](./Oxide.Ext.Discord/Clients/WebhookClient.md) | A client that can connect to a webhook |

## Oxide.Ext.Discord.Connections namespace

| public type | description |
| --- | --- |
| class [BotConnection](./Oxide.Ext.Discord/Connections/BotConnection.md) | Bot Connection Settings |
| class [BotTokenData](./Oxide.Ext.Discord/Connections/BotTokenData.md) | Represents the parsed Bot Token data |
| class [WebhookConnection](./Oxide.Ext.Discord/Connections/WebhookConnection.md) | Connection for a webhook |

## Oxide.Ext.Discord.Constants namespace

| public type | description |
| --- | --- |
| class [DiscordEncoding](./Oxide.Ext.Discord/Constants/DiscordEncoding.md) | Encoding format the Discord Uses |
| static class [DiscordEndpoints](./Oxide.Ext.Discord/Constants/DiscordEndpoints.md) | Discord API endpoint settings |
| static class [DiscordExtHooks](./Oxide.Ext.Discord/Constants/DiscordExtHooks.md) | Represents all hooks available in the discord extension |
| static class [RateLimitHeaders](./Oxide.Ext.Discord/Constants/RateLimitHeaders.md) | Represents [Header Format](https://discord.com/developers/docs/topics/rate-limits#header-format) |

## Oxide.Ext.Discord.Entities namespace

| public type | description |
| --- | --- |
| class [ActionRowComponent](./Oxide.Ext.Discord/Entities/ActionRowComponent.md) | Represents [Action Row Component](https://discord.com/developers/docs/interactions/message-components#actionrow) within discord |
| class [ActivityAssets](./Oxide.Ext.Discord/Entities/ActivityAssets.md) | Represents [Activity Assets](https://discord.com/developers/docs/topics/gateway#activity-object-activity-assets) |
| class [ActivityButton](./Oxide.Ext.Discord/Entities/ActivityButton.md) | Represents [Activity Buttons](https://discord.com/developers/docs/topics/gateway#activity-object-activity-buttons) |
| [Flags] enum [ActivityFlags](./Oxide.Ext.Discord/Entities/ActivityFlags.md) | Represents [Activity Flags](https://discord.com/developers/docs/topics/gateway#activity-object-activity-flags) |
| class [ActivityInstance](./Oxide.Ext.Discord/Entities/ActivityInstance.md) | Represents [Activity Instance](https://discord.com/developers/docs/resources/application#get-application-activity-instance-activity-instance-object) |
| class [ActivityLocation](./Oxide.Ext.Discord/Entities/ActivityLocation.md) | Represents [Activity Location](https://discord.com/developers/docs/resources/application#get-application-activity-instance-activity-location-object) |
| enum [ActivityLocationKind](./Oxide.Ext.Discord/Entities/ActivityLocationKind.md) | Represents [Activity Location Kind Enum](https://discord.com/developers/docs/resources/application#get-application-activity-instance-activity-location-kind-enum) |
| class [ActivityParty](./Oxide.Ext.Discord/Entities/ActivityParty.md) | Represents [Activity Party](https://discord.com/developers/docs/topics/gateway#activity-object-activity-party) |
| class [ActivitySecrets](./Oxide.Ext.Discord/Entities/ActivitySecrets.md) | Represents [Activity Secrets](https://discord.com/developers/docs/topics/gateway#activity-object-activity-secrets) |
| class [ActivityTimestamps](./Oxide.Ext.Discord/Entities/ActivityTimestamps.md) | Represents [Activity Timestamps](https://discord.com/developers/docs/topics/gateway#activity-object-activity-timestamps) |
| enum [ActivityType](./Oxide.Ext.Discord/Entities/ActivityType.md) | Represents [Activity Types](https://discord.com/developers/docs/topics/gateway#activity-object-activity-types) |
| class [AllowedMentions](./Oxide.Ext.Discord/Entities/AllowedMentions.md) | Represents a [Allowed Mention Types](https://discord.com/developers/docs/resources/channel#allowed-mentions-object) |
| enum [AllowedMentionTypes](./Oxide.Ext.Discord/Entities/AllowedMentionTypes.md) | Represents a [Allowed Mention Types](https://discord.com/developers/docs/resources/channel#allowed-mentions-object-allowed-mention-types) for a message |
| enum [AnimationType](./Oxide.Ext.Discord/Entities/AnimationType.md) | Represents the [Animation Type]() |
| enum [ApplicationCommandHandlerType](./Oxide.Ext.Discord/Entities/ApplicationCommandHandlerType.md) | Represents [Entry Point Command Handler Types](https://discord.com/developers/docs/interactions/application-commands#application-command-object-entry-point-command-handler-types) |
| enum [ApplicationCommandType](./Oxide.Ext.Discord/Entities/ApplicationCommandType.md) | Represents [Application Command Type](https://discord.com/developers/docs/interactions/application-commands#application-command-object-application-command-types) |
| class [ApplicationEmojiCreate](./Oxide.Ext.Discord/Entities/ApplicationEmojiCreate.md) | Represents [Application Emoji Create Structure](https://discord.com/developers/docs/resources/emoji#create-application-emoji-json-params) |
| class [ApplicationEmojis](./Oxide.Ext.Discord/Entities/ApplicationEmojis.md) | Represents [Application Emojis](https://discord.com/developers/docs/resources/emoji#list-application-emojis) |
| class [ApplicationEmojiUpdate](./Oxide.Ext.Discord/Entities/ApplicationEmojiUpdate.md) | Represents [Emoji Update Structure](https://discord.com/developers/docs/resources/emoji#modify-guild-emoji-json-params) |
| [Flags] enum [ApplicationFlags](./Oxide.Ext.Discord/Entities/ApplicationFlags.md) | Represents [Application Flags](https://discord.com/developers/docs/resources/application#application-object-application-flags) |
| enum [ApplicationIntegrationType](./Oxide.Ext.Discord/Entities/ApplicationIntegrationType.md) | Represents a [Application Integration Types](https://discord.com/developers/docs/resources/application#application-object-application-integration-types) |
| class [ApplicationIntegrationTypeConfiguration](./Oxide.Ext.Discord/Entities/ApplicationIntegrationTypeConfiguration.md) | Represents a [Application Integration Type Configuration](https://discord.com/developers/docs/resources/application#application-object-application-integration-type-configuration-object) |
| class [ApplicationRoleConnectionMetadata](./Oxide.Ext.Discord/Entities/ApplicationRoleConnectionMetadata.md) | Represents [Application Role Connection Metadata Structure](https://discord.com/developers/docs/resources/application-role-connection-metadata#application-role-connection-metadata-object-application-role-connection-metadata-structure) |
| enum [ApplicationRoleConnectionMetadataType](./Oxide.Ext.Discord/Entities/ApplicationRoleConnectionMetadataType.md) | Represents [Application Role Connection Metadata Type](Application Role Connection Metadata Structure) |
| class [ApplicationUpdate](./Oxide.Ext.Discord/Entities/ApplicationUpdate.md) | Represents [Edit Application Structure](https://discord.com/developers/docs/resources/application#edit-current-application-json-params) |
| [Flags] enum [AttachmentFlags](./Oxide.Ext.Discord/Entities/AttachmentFlags.md) | Represents a [Attachment flags for an attachment](https://discord.com/developers/docs/resources/channelattachment-flags) |
| class [AutoModAction](./Oxide.Ext.Discord/Entities/AutoModAction.md) | Represents [Auto Mod Action](https://discord.com/developers/docs/resources/auto-moderation#auto-moderation-action-object) |
| class [AutoModActionExecutionEvent](./Oxide.Ext.Discord/Entities/AutoModActionExecutionEvent.md) | Represents [Auto Moderation Action Execution Event](https://discord.com/developers/docs/topics/gateway#auto-moderation-action-execution-auto-moderation-action-execution-event-fields) |
| class [AutoModActionMetadata](./Oxide.Ext.Discord/Entities/AutoModActionMetadata.md) | Represents [Auto Mod Action Metadata](https://discord.com/developers/docs/resources/auto-moderation#auto-moderation-action-object-action-metadata) |
| enum [AutoModActionType](./Oxide.Ext.Discord/Entities/AutoModActionType.md) | Represents [Auto Mod Action Types](https://discord.com/developers/docs/resources/auto-moderation#auto-moderation-action-object-action-types) |
| enum [AutoModEventType](./Oxide.Ext.Discord/Entities/AutoModEventType.md) | Represents [Auto Mod Event Type](https://discord.com/developers/docs/resources/auto-moderation#auto-moderation-rule-object-event-types) |
| enum [AutoModKeywordPresetType](./Oxide.Ext.Discord/Entities/AutoModKeywordPresetType.md) | Represents [Auto Mod Keyword Preset Types](https://discord.com/developers/docs/resources/auto-moderation#auto-moderation-rule-object-keyword-preset-types) |
| class [AutoModRule](./Oxide.Ext.Discord/Entities/AutoModRule.md) | Represents [Auto Mod Rule](https://discord.com/developers/docs/resources/auto-moderation#auto-moderation-rule-object) |
| class [AutoModRuleCreate](./Oxide.Ext.Discord/Entities/AutoModRuleCreate.md) | Represents [Auto Mod Rule Create](https://discord.com/developers/docs/resources/auto-moderation#create-auto-moderation-rule-json-params) |
| class [AutoModRuleModify](./Oxide.Ext.Discord/Entities/AutoModRuleModify.md) | Represents [Auto Mod Rule Modify](https://discord.com/developers/docs/resources/auto-moderation#modify-auto-moderation-rule-json-params) |
| class [AutoModTriggerMetadata](./Oxide.Ext.Discord/Entities/AutoModTriggerMetadata.md) | Represents [Auto Mod Trigger Metadata](https://discord.com/developers/docs/resources/auto-moderation#auto-moderation-rule-object-trigger-metadata) |
| enum [AutoModTriggerType](./Oxide.Ext.Discord/Entities/AutoModTriggerType.md) | Represents [Auto Mod Trigger Types](https://discord.com/developers/docs/resources/auto-moderation#auto-moderation-rule-object-trigger-types) |
| class [AvatarDecorationData](./Oxide.Ext.Discord/Entities/AvatarDecorationData.md) | Represents [Avatar Decoration Structure](https://discord.com/developers/docs/resources/user#avatar-decoration-data-object-avatar-decoration-data-structure) |
| abstract class [BaseComponent](./Oxide.Ext.Discord/Entities/BaseComponent.md) | Represents [Message Component](https://discord.com/developers/docs/interactions/message-components#component-object) within discord |
| abstract class [BaseInteractableComponent](./Oxide.Ext.Discord/Entities/BaseInteractableComponent.md) | Represent a MessageComponent that can be interacted with |
| abstract class [BaseInteractionMessage](./Oxide.Ext.Discord/Entities/BaseInteractionMessage.md) | Represents a Base Message for an interaction |
| abstract class [BaseInteractionResponse](./Oxide.Ext.Discord/Entities/BaseInteractionResponse.md) | Represents a Base Interaction response |
| abstract class [BaseInteractionResponse&lt;T&gt;](./Oxide.Ext.Discord/Entities/BaseInteractionResponse%7BT%7D.md) | Represents a Base Interaction Response with generic data {T} |
| abstract class [BaseMessageCreate](./Oxide.Ext.Discord/Entities/BaseMessageCreate.md) | Represents a base message in discord |
| abstract class [BaseSelectMenuComponent](./Oxide.Ext.Discord/Entities/BaseSelectMenuComponent.md) | Represents a [Select Menus Component](https://discord.com/developers/docs/interactions/message-components#select-menus) within discord. |
| class [ButtonComponent](./Oxide.Ext.Discord/Entities/ButtonComponent.md) | Represents a [Button Component](https://discord.com/developers/docs/interactions/message-components#buttons) within discord. |
| enum [ButtonStyle](./Oxide.Ext.Discord/Entities/ButtonStyle.md) | Represents [Button Styles](https://discord.com/developers/docs/interactions/message-components#buttons-button-styles) within Discord.. |
| class [ChannelCreate](./Oxide.Ext.Discord/Entities/ChannelCreate.md) | Represents a [Guild Channel Create Structure](https://discord.com/developers/docs/resources/guild#create-guild-channel-json-params) |
| [Flags] enum [ChannelFlags](./Oxide.Ext.Discord/Entities/ChannelFlags.md) | Represents [Channel Flags](https://discord.com/developers/docs/resources/channel#channel-object-channel-flags) |
| class [ChannelInvite](./Oxide.Ext.Discord/Entities/ChannelInvite.md) | Represents a [Channel Invite Structure](https://discord.com/developers/docs/resources/channel#create-channel-invite-json-params) |
| class [ChannelMention](./Oxide.Ext.Discord/Entities/ChannelMention.md) | Represents a [Channel Mention Structure](https://discord.com/developers/docs/resources/channel#channel-mention-object-channel-mention-structure) in a message |
| class [ChannelMessagesRequest](./Oxide.Ext.Discord/Entities/ChannelMessagesRequest.md) | Represents [Get Channel Messages Request](https://discord.com/developers/docs/resources/channel#get-channel-messages) |
| class [ChannelPinsUpdatedEvent](./Oxide.Ext.Discord/Entities/ChannelPinsUpdatedEvent.md) | Represents [Channel Pins Update](https://discord.com/developers/docs/topics/gateway#channel-pins-update) |
| class [ChannelSelectComponent](./Oxide.Ext.Discord/Entities/ChannelSelectComponent.md) | Represents a [Select Menus Component](https://discord.com/developers/docs/interactions/message-components#select-menus) within discord. |
| enum [ChannelType](./Oxide.Ext.Discord/Entities/ChannelType.md) | Represents a [Types of Channels](https://discord.com/developers/docs/resources/channel#channel-object-channel-types) |
| class [ClientStatus](./Oxide.Ext.Discord/Entities/ClientStatus.md) | Represents [Client Status Structure](https://discord.com/developers/docs/topics/gateway#client-status-object) |
| class [CommandBulkOverwrite](./Oxide.Ext.Discord/Entities/CommandBulkOverwrite.md) | Represents [Bulk Overwrite Guild Application Commands](https://discord.com/developers/docs/interactions/application-commands#bulk-overwrite-guild-application-commands-bulk-application-command-json-params) |
| class [CommandCreate](./Oxide.Ext.Discord/Entities/CommandCreate.md) | Represents [Application Command Create](https://discord.com/developers/docs/interactions/application-commands#create-global-application-command-json-params) Represents [Application Command Create](https://discord.com/developers/docs/interactions/application-commands#create-guild-application-command-json-params) |
| class [CommandFollowupCreate](./Oxide.Ext.Discord/Entities/CommandFollowupCreate.md) | Represents a [Command Followup](https://discord.com/developers/docs/interactions/receiving-and-responding#create-followup-message) within discord. |
| class [CommandFollowupUpdate](./Oxide.Ext.Discord/Entities/CommandFollowupUpdate.md) | Represents a [Command Followup]() within discord. |
| class [CommandOption](./Oxide.Ext.Discord/Entities/CommandOption.md) | Represents [ApplicationCommandOption](https://discord.com/developers/docs/interactions/application-commands#application-command-object-application-command-option-structure) |
| class [CommandOptionChoice](./Oxide.Ext.Discord/Entities/CommandOptionChoice.md) | Represents [ApplicationCommandOptionChoice](https://discord.com/developers/docs/interactions/application-commands#application-command-object-application-command-option-choice-structure) If you specify choices for an option, they are the only valid values for a user to pick |
| enum [CommandOptionType](./Oxide.Ext.Discord/Entities/CommandOptionType.md) | Represents [ApplicationCommandOptionType](https://discord.com/developers/docs/interactions/application-commands#application-command-object-application-command-option-type) |
| class [CommandPayload](./Oxide.Ext.Discord/Entities/CommandPayload.md) | Represents a command payload |
| class [CommandPermissions](./Oxide.Ext.Discord/Entities/CommandPermissions.md) | Represents [ApplicationCommandPermissions](https://discord.com/developers/docs/interactions/application-commands#application-command-permissions-object-application-command-permissions-structure) |
| enum [CommandPermissionType](./Oxide.Ext.Discord/Entities/CommandPermissionType.md) | Represents [ApplicationCommandPermissionType](https://discord.com/developers/docs/interactions/application-commands#application-command-permissions-object-application-command-permission-type) |
| class [CommandUpdate](./Oxide.Ext.Discord/Entities/CommandUpdate.md) | Represents [Application Command Update](https://discord.com/developers/docs/interactions/application-commands#edit-global-application-command-json-params) |
| class [CommandUpdatePermissions](./Oxide.Ext.Discord/Entities/CommandUpdatePermissions.md) | Represents [Edit Application Command Permissions](https://discord.com/developers/docs/interactions/application-commands#edit-application-command-permissions-json-params) |
| class [Connection](./Oxide.Ext.Discord/Entities/Connection.md) | Represents a Discord Users [Connection](https://discord.com/developers/docs/resources/user#connection-object) |
| class [ConnectionProperties](./Oxide.Ext.Discord/Entities/ConnectionProperties.md) | Represents [Identify Connection Properties](https://discord.com/developers/docs/topics/gateway#identify-identify-connection-properties) |
| enum [ConnectionType](./Oxide.Ext.Discord/Entities/ConnectionType.md) | Represents a [Connection Type](https://discord.com/developers/docs/resources/user#connection-object-connection-structure) for a connection |
| enum [ConnectionVisibilityType](./Oxide.Ext.Discord/Entities/ConnectionVisibilityType.md) | Represents connection [Visibility Types](https://discord.com/developers/docs/resources/user#connection-object-visibility-types) |
| class [CreateTestEntitlement](./Oxide.Ext.Discord/Entities/CreateTestEntitlement.md) | Represents a [Create Test Entitlement Structure](https://discord.com/developers/docs/monetization/entitlements#create-test-entitlement-json-params) |
| enum [DefaultNotificationLevel](./Oxide.Ext.Discord/Entities/DefaultNotificationLevel.md) | Represents [Default Message Notification Level](https://discord.com/developers/docs/resources/guild#guild-object-default-message-notification-level) |
| class [DefaultReaction](./Oxide.Ext.Discord/Entities/DefaultReaction.md) | Represents [Default Reaction Structure](https://discord.com/developers/docs/resources/channel#followed-channel-object) |
| class [DiscordActivity](./Oxide.Ext.Discord/Entities/DiscordActivity.md) | Represents [Activity Structure](https://discord.com/developers/docs/topics/gateway-events#activity-object) |
| class [DiscordApplication](./Oxide.Ext.Discord/Entities/DiscordApplication.md) | Represents [Application Structure](https://discord.com/developers/docs/resources/application#application-object) |
| class [DiscordApplicationCommand](./Oxide.Ext.Discord/Entities/DiscordApplicationCommand.md) | Represents [ApplicationCommand](https://discord.com/developers/docs/interactions/application-commands#application-command-object-application-command-structure) |
| class [DiscordChannel](./Oxide.Ext.Discord/Entities/DiscordChannel.md) | Represents a guild or DM [Channel Structure](https://discord.com/developers/docs/resources/channel#channel-object) within Discord. |
| struct [DiscordColor](./Oxide.Ext.Discord/Entities/DiscordColor.md) | Represents a Discord Color |
| class [DiscordEmbed](./Oxide.Ext.Discord/Entities/DiscordEmbed.md) | Represents [Embed Structure](https://discord.com/developers/docs/resources/channel#embed-object) |
| class [DiscordEmoji](./Oxide.Ext.Discord/Entities/DiscordEmoji.md) | Represents [Emoji Structure](https://discord.com/developers/docs/resources/emoji#emoji-object) |
| class [DiscordEntitlement](./Oxide.Ext.Discord/Entities/DiscordEntitlement.md) | Represents a [Entitlement Structure](https://discord.com/developers/docs/monetization/entitlements#entitlement-object-entitlement-structure) |
| enum [DiscordFileSize](./Oxide.Ext.Discord/Entities/DiscordFileSize.md) | Represents an image size |
| class [DiscordGuild](./Oxide.Ext.Discord/Entities/DiscordGuild.md) | Represents [Guild Structure](https://discord.com/developers/docs/resources/guild#guild-object) |
| enum [DiscordHttpStatusCode](./Oxide.Ext.Discord/Entities/DiscordHttpStatusCode.md) | Represents possible HTTP Codes sent from discord |
| struct [DiscordImageData](./Oxide.Ext.Discord/Entities/DiscordImageData.md) | Represents [Discord Image Data](https://discord.com/developers/docs/reference#image-data) |
| enum [DiscordImageFormat](./Oxide.Ext.Discord/Entities/DiscordImageFormat.md) | Represents [Image Formats](https://discord.com/developers/docs/reference#image-formatting-image-formats) |
| class [DiscordInteraction](./Oxide.Ext.Discord/Entities/DiscordInteraction.md) | Represents [Interaction Structure](https://discord.com/developers/docs/interactions/receiving-and-responding#interaction-object-interaction-structure) |
| class [DiscordInvite](./Oxide.Ext.Discord/Entities/DiscordInvite.md) | Represents an [Invite Structure](https://discord.com/developers/docs/resources/invite#invite-object) that when used, adds a user to a guild or group DM channel. |
| class [DiscordMessage](./Oxide.Ext.Discord/Entities/DiscordMessage.md) | Represents a [Message Structure](https://discord.com/developers/docs/resources/channel#message-object) sent in a channel within Discord.. |
| class [DiscordPoll](./Oxide.Ext.Discord/Entities/DiscordPoll.md) | Represents a [Discord Poll](https://discord.com/developers/docs/resources/poll#poll-object-poll-object-structure) |
| class [DiscordRole](./Oxide.Ext.Discord/Entities/DiscordRole.md) | Represents [Role Structure](https://discord.com/developers/docs/topics/permissions#role-object) |
| class [DiscordSku](./Oxide.Ext.Discord/Entities/DiscordSku.md) | Represents a [SKU Structure](https://discord.com/developers/docs/monetization/skus#sku-object-sku-structure) |
| enum [DiscordSkuType](./Oxide.Ext.Discord/Entities/DiscordSkuType.md) | Represents a [Discord SKU Types](https://discord.com/developers/docs/monetization/skus#sku-object-sku-types) |
| class [DiscordSoundboardSound](./Oxide.Ext.Discord/Entities/DiscordSoundboardSound.md) | Represents [Soundboard](https://discord.com/developers/docs/resources/soundboard#soundboard-sound-object) in Discord |
| struct [DiscordSoundData](./Oxide.Ext.Discord/Entities/DiscordSoundData.md) | Represents [Discord Sound Data](https://discord.com/developers/docs/reference#image-data) |
| enum [DiscordSoundFormat](./Oxide.Ext.Discord/Entities/DiscordSoundFormat.md) | Represents [Image Formats](https://discord.com/developers/docs/reference#image-formatting-image-formats) |
| class [DiscordSticker](./Oxide.Ext.Discord/Entities/DiscordSticker.md) | Represents a [Discord Sticker Structure](https://discord.com/developers/docs/resources/sticker#sticker-object) |
| class [DiscordStickerPack](./Oxide.Ext.Discord/Entities/DiscordStickerPack.md) | Represents a [Sticker Pack Object](https://discord.com/developers/docs/resources/sticker#sticker-pack-object) |
| class [DiscordSubscription](./Oxide.Ext.Discord/Entities/DiscordSubscription.md) | Represents a [Subscription](https://discord.com/developers/docs/resources/subscription#subscription-resource) |
| class [DiscordTeam](./Oxide.Ext.Discord/Entities/DiscordTeam.md) | Represents a [Team Object](https://discord.com/developers/docs/topics/teams#data-models-team-object) |
| class [DiscordUser](./Oxide.Ext.Discord/Entities/DiscordUser.md) | Represents [User Structure](https://discord.com/developers/docs/resources/user#user-object) |
| class [DiscordWebhook](./Oxide.Ext.Discord/Entities/DiscordWebhook.md) | Represents [Webhook Structure](https://discord.com/developers/docs/resources/webhook#webhook-object) |
| class [EmbedAuthor](./Oxide.Ext.Discord/Entities/EmbedAuthor.md) | Represents [Embed Author Structure](https://discord.com/developers/docs/resources/channel#embed-object-embed-author-structure) |
| class [EmbedField](./Oxide.Ext.Discord/Entities/EmbedField.md) | Represents [Embed Field Structure](https://discord.com/developers/docs/resources/channel#embed-object-embed-field-structure) |
| class [EmbedFooter](./Oxide.Ext.Discord/Entities/EmbedFooter.md) | Represents [Embed Footer Structure](https://discord.com/developers/docs/resources/channel#embed-object-embed-footer-structure) |
| class [EmbedImage](./Oxide.Ext.Discord/Entities/EmbedImage.md) | Represents [Embed Image Structure](https://discord.com/developers/docs/resources/channel#embed-object-embed-image-structure) |
| class [EmbedProvider](./Oxide.Ext.Discord/Entities/EmbedProvider.md) | Represents [Embed Provider Structure](https://discord.com/developers/docs/resources/channel#embed-object-embed-provider-structure) |
| class [EmbedThumbnail](./Oxide.Ext.Discord/Entities/EmbedThumbnail.md) | Represents [Embed Thumbnail Structure](https://discord.com/developers/docs/resources/channel#embed-object-embed-thumbnail-structure) |
| enum [EmbedType](./Oxide.Ext.Discord/Entities/EmbedType.md) |  |
| class [EmbedVideo](./Oxide.Ext.Discord/Entities/EmbedVideo.md) | Represents [Embed Video Structure](https://discord.com/developers/docs/resources/channel#embed-object-embed-video-structure) |
| class [EmojiCreate](./Oxide.Ext.Discord/Entities/EmojiCreate.md) | Represents [Emoji Create Structure](https://discord.com/developers/docs/resources/emoji#create-guild-emoji-json-params) |
| class [EmojiUpdate](./Oxide.Ext.Discord/Entities/EmojiUpdate.md) | Represents [Emoji Update Structure](https://discord.com/developers/docs/resources/emoji#modify-guild-emoji-json-params) |
| enum [EntitlementOwnerType](./Oxide.Ext.Discord/Entities/EntitlementOwnerType.md) | Represents a [Entitlement Owner Types](https://discord.com/developers/docs/monetization/entitlements#create-test-entitlement-json-params) |
| enum [EntitlementType](./Oxide.Ext.Discord/Entities/EntitlementType.md) | Represents a [Entitlement Types](https://discord.com/developers/docs/monetization/entitlements#entitlement-object-entitlement-types) |
| class [EventPayload](./Oxide.Ext.Discord/Entities/EventPayload.md) | Represents [Gateway Payload Structure](https://discord.com/developers/docs/topics/gateway#payloads) |
| enum [ExplicitContentFilterLevel](./Oxide.Ext.Discord/Entities/ExplicitContentFilterLevel.md) | Represents [Explicit Content Filter Level](https://discord.com/developers/docs/resources/guild#guild-object-explicit-content-filter-level) |
| class [FollowedChannel](./Oxide.Ext.Discord/Entities/FollowedChannel.md) | Represents a [Followed Channel Structure](https://discord.com/developers/docs/resources/channel#followed-channel-object-followed-channel-structure) from an API response |
| enum [ForumLayoutTypes](./Oxide.Ext.Discord/Entities/ForumLayoutTypes.md) | Represents a [Forum Layout Types](https://discord.com/developers/docs/resources/channel#channel-object-forum-layout-types) |
| class [ForumTag](./Oxide.Ext.Discord/Entities/ForumTag.md) | Represents a [Forum Tag Structure](https://discord.com/developers/docs/resources/channel#forum-tag-object) An object that represents a tag that is able to be applied to a thread in a `GUILD_FORUM` or `GUILD_MEDIA` channel. |
| enum [GatewayCommandCode](./Oxide.Ext.Discord/Entities/GatewayCommandCode.md) | Represents [Gateway Opcodes](https://discord.com/developers/docs/topics/opcodes-and-status-codes#gateway-gateway-opcodes) |
| enum [GatewayEventCode](./Oxide.Ext.Discord/Entities/GatewayEventCode.md) | Represents [Gateway Opcodes](https://discord.com/developers/docs/topics/opcodes-and-status-codes#gateway-gateway-opcodes) |
| class [GatewayHelloEvent](./Oxide.Ext.Discord/Entities/GatewayHelloEvent.md) | Represents [Hello](https://discord.com/developers/docs/topics/gateway#hello) Sent on connection to the websocket. Defines the heartbeat interval that the client should heartbeat to. |
| [Flags] enum [GatewayIntents](./Oxide.Ext.Discord/Entities/GatewayIntents.md) | Represents [Gateway Intents](https://discord.com/developers/docs/topics/gateway#gateway-intents) These are used to indicate which events your bot / application wants to listen to / have access to |
| class [GatewayReadyEvent](./Oxide.Ext.Discord/Entities/GatewayReadyEvent.md) | Represents [Ready](https://discord.com/developers/docs/topics/gateway#ready) The ready event is dispatched when a client has completed the initial handshake with the gateway (for new sessions) |
| class [GatewayResumedEvent](./Oxide.Ext.Discord/Entities/GatewayResumedEvent.md) | Represents [Resumed](https://discord.com/developers/docs/topics/gateway#resumed) The resumed event is dispatched when a client has sent a resume payload to the gateway (for resuming existing sessions). |
| class [GetEntitlements](./Oxide.Ext.Discord/Entities/GetEntitlements.md) | Get Entitlements Query String Builder |
| class [GetGuildSoundboardSoundsEvent](./Oxide.Ext.Discord/Entities/GetGuildSoundboardSoundsEvent.md) | Represents [Soundboard Sounds Event Fields](https://discord.com/developers/docs/events/gateway-events#soundboard-sounds-soundboard-sounds-event-fields) |
| class [GetGuildSoundsResponse](./Oxide.Ext.Discord/Entities/GetGuildSoundsResponse.md) | Represents [Get Guild Sounds Response](https://discord.com/developers/docs/resources/soundboard#list-guild-soundboard-sounds-response-structure) in Discord |
| class [GetPollAnswerResponse](./Oxide.Ext.Discord/Entities/GetPollAnswerResponse.md) | Represents a [Get Poll Answers Response](https://discord.com/developers/docs/resources/poll#get-answer-voters-response-body) |
| class [GetPollAnswerVoters](./Oxide.Ext.Discord/Entities/GetPollAnswerVoters.md) | Represents a [Get Answer Voters Query String Params](https://discord.com/developers/docs/resources/poll#get-answer-voters-query-string-params) |
| class [GetSkuSubscriptionsQueryString](./Oxide.Ext.Discord/Entities/GetSkuSubscriptionsQueryString.md) |  |
| class [GetSoundboardSoundsCommand](./Oxide.Ext.Discord/Entities/GetSoundboardSoundsCommand.md) | Represents [Update Voice State](https://discord.com/developers/docs/topics/gateway#update-voice-state) |
| class [GetThreadMember](./Oxide.Ext.Discord/Entities/GetThreadMember.md) | Represents [Get Thread Member Query String Params](https://discord.com/developers/docs/resources/channel#get-thread-member-query-string-params) |
| class [GroupDmChannelUpdate](./Oxide.Ext.Discord/Entities/GroupDmChannelUpdate.md) | Represents a [Group DM Channel Update Structure](https://discord.com/developers/docs/resources/channel#modify-channel-json-params-group-dm) |
| class [GuildBan](./Oxide.Ext.Discord/Entities/GuildBan.md) | Represents [Guild Ban Structure](https://discord.com/developers/docs/resources/guild#ban-object-ban-structure) |
| class [GuildBanCreate](./Oxide.Ext.Discord/Entities/GuildBanCreate.md) | Represents [Guild Ban Create Structure](https://discord.com/developers/docs/resources/guild#create-guild-ban) |
| class [GuildBansRequest](./Oxide.Ext.Discord/Entities/GuildBansRequest.md) | Represents a [Get Guild Bans Query String Params](https://discord.com/developers/docs/resources/guild#get-guild-bans-query-string-params) |
| class [GuildChannelPosition](./Oxide.Ext.Discord/Entities/GuildChannelPosition.md) | Represents [Modify Guild Channel Position](https://discord.com/developers/docs/resources/guild#modify-guild-channel-positions) |
| class [GuildChannelUpdate](./Oxide.Ext.Discord/Entities/GuildChannelUpdate.md) | Represents a [Guild Channel Update Structure](https://discord.com/developers/docs/resources/channel#modify-channel-json-params-guild-channel) |
| class [GuildCommandPermissions](./Oxide.Ext.Discord/Entities/GuildCommandPermissions.md) | Represents [ApplicationCommandPermissions](https://discord.com/developers/docs/interactions/application-commands#application-command-permissions-object-guild-application-command-permissions-structure) |
| class [GuildCreate](./Oxide.Ext.Discord/Entities/GuildCreate.md) | Represents [Create Guild Structure](https://discord.com/developers/docs/resources/guild#create-guild) |
| class [GuildCurrentUserVoiceStateUpdate](./Oxide.Ext.Discord/Entities/GuildCurrentUserVoiceStateUpdate.md) | Represents a [Modify Current User Voice State](https://discord.com/developers/docs/resources/guild#modify-current-user-voice-state-json-params) |
| class [GuildEmojisUpdatedEvent](./Oxide.Ext.Discord/Entities/GuildEmojisUpdatedEvent.md) | Represents [Guild Emojis Update](https://discord.com/developers/docs/topics/gateway#guild-emojis-update) |
| enum [GuildFeatures](./Oxide.Ext.Discord/Entities/GuildFeatures.md) | Represents [Guild Features](https://discord.com/developers/docs/resources/guild#guild-object-guild-features) |
| class [GuildIntegrationsUpdatedEvent](./Oxide.Ext.Discord/Entities/GuildIntegrationsUpdatedEvent.md) | Represents [Guild Integrations Update](https://discord.com/developers/docs/topics/gateway#guild-integrations-update) |
| class [GuildListMembers](./Oxide.Ext.Discord/Entities/GuildListMembers.md) | Represents a [List Guild Members](https://discord.com/developers/docs/resources/guild#list-guild-members-query-string-params) Stucture |
| class [GuildMember](./Oxide.Ext.Discord/Entities/GuildMember.md) | Represents [Guild Member Structure](https://discord.com/developers/docs/resources/guild#guild-member-object-guild-member-structure) |
| class [GuildMemberAdd](./Oxide.Ext.Discord/Entities/GuildMemberAdd.md) | Represents [Guild Member Add](https://discord.com/developers/docs/resources/guild#add-guild-member-json-params) |
| class [GuildMemberAddedEvent](./Oxide.Ext.Discord/Entities/GuildMemberAddedEvent.md) | Represents [Guild Member Add](https://discord.com/developers/docs/topics/gateway#guild-member-add) |
| class [GuildMemberBannedEvent](./Oxide.Ext.Discord/Entities/GuildMemberBannedEvent.md) | Represents [Guild Ban Add](https://discord.com/developers/docs/topics/gateway#guild-ban-add) Event Represents [Guild Ban Remove](https://discord.com/developers/docs/topics/gateway#guild-ban-remove) Event |
| [Flags] enum [GuildMemberFlags](./Oxide.Ext.Discord/Entities/GuildMemberFlags.md) | Represents [Guild Member Flags](https://discord.com/developers/docs/resources/guild#guild-member-object-guild-member-flags) |
| class [GuildMemberRemovedEvent](./Oxide.Ext.Discord/Entities/GuildMemberRemovedEvent.md) | Represents [Guild Member Remove](https://discord.com/developers/docs/topics/gateway#guild-member-remove) |
| class [GuildMembersChunkEvent](./Oxide.Ext.Discord/Entities/GuildMembersChunkEvent.md) | Represents [Guild Members Chunk](https://discord.com/developers/docs/topics/gateway#guild-members-chunk) |
| class [GuildMembersRequestCommand](./Oxide.Ext.Discord/Entities/GuildMembersRequestCommand.md) | Represents [Request Guild Members](https://discord.com/developers/docs/topics/gateway-events#request-guild-members) |
| class [GuildMemberUpdate](./Oxide.Ext.Discord/Entities/GuildMemberUpdate.md) | Represents [Guild Member Update Structure](https://discord.com/developers/docs/resources/guild#modify-guild-member-json-params) |
| class [GuildMemberUpdatedEvent](./Oxide.Ext.Discord/Entities/GuildMemberUpdatedEvent.md) | Represents [Guild Member Update](https://discord.com/developers/docs/topics/gateway#guild-member-update) |
| enum [GuildMfaLevel](./Oxide.Ext.Discord/Entities/GuildMfaLevel.md) | Represents [MFA Level](https://discord.com/developers/docs/resources/guild#guild-object-mfa-level) |
| enum [GuildNavigationType](./Oxide.Ext.Discord/Entities/GuildNavigationType.md) | Represents [Guild Navigation Types](https://discord.com/developers/docs/reference#message-formatting-guild-navigation-types) |
| enum [GuildNsfwLevel](./Oxide.Ext.Discord/Entities/GuildNsfwLevel.md) | Represents [Guild NSFW Level](https://discord.com/developers/docs/resources/guild#guild-nsfw-level) |
| class [GuildOnboarding](./Oxide.Ext.Discord/Entities/GuildOnboarding.md) | Represents [Guild Onboarding Structure](https://discord.com/developers/docs/resources/guild#guild-onboarding-object-guild-onboarding-structure) |
| enum [GuildOnboardingMode](./Oxide.Ext.Discord/Entities/GuildOnboardingMode.md) | Represents [Guild Onboarding Mode Structure](https://discord.com/developers/docs/resources/guild#onboarding-mode) |
| class [GuildOnboardingUpdate](./Oxide.Ext.Discord/Entities/GuildOnboardingUpdate.md) | Represents [Guild Onboarding Update Structure]() |
| enum [GuildPremiumTier](./Oxide.Ext.Discord/Entities/GuildPremiumTier.md) | Represents [Verification Level](https://discord.com/developers/docs/resources/guild#guild-object-verification-level) |
| class [GuildPreview](./Oxide.Ext.Discord/Entities/GuildPreview.md) | Represents [Guild Preview Structure](https://discord.com/developers/docs/resources/guild#guild-preview-object) |
| class [GuildPruneBegin](./Oxide.Ext.Discord/Entities/GuildPruneBegin.md) | Represents [Guild Prune Begin](https://discord.com/developers/docs/resources/guild#begin-guild-prune) |
| class [GuildPruneGet](./Oxide.Ext.Discord/Entities/GuildPruneGet.md) | Represents [Guild Prune Get](https://discord.com/developers/docs/resources/guild#get-guild-prune-count) |
| class [GuildPruneResult](./Oxide.Ext.Discord/Entities/GuildPruneResult.md) | Represents [Guild Prune Count Response](https://discord.com/developers/docs/resources/guild#get-guild-prune-count) Represents [Guild Prune Begin Response](https://discord.com/developers/docs/resources/guild#begin-guild-prune) |
| class [GuildRoleCreatedEvent](./Oxide.Ext.Discord/Entities/GuildRoleCreatedEvent.md) | Represents [Guild Role Create](https://discord.com/developers/docs/topics/gateway#guild-role-create) |
| class [GuildRoleDeletedEvent](./Oxide.Ext.Discord/Entities/GuildRoleDeletedEvent.md) | Represents [Guild Role Delete](https://discord.com/developers/docs/topics/gateway#guild-role-delete) |
| class [GuildRolePosition](./Oxide.Ext.Discord/Entities/GuildRolePosition.md) | Represents [Guild Role Position](https://discord.com/developers/docs/resources/guild#modify-guild-role-positions) |
| class [GuildRoleUpdatedEvent](./Oxide.Ext.Discord/Entities/GuildRoleUpdatedEvent.md) | Represents [Guild Role Update](https://discord.com/developers/docs/topics/gateway#guild-role-update) |
| class [GuildScheduledEvent](./Oxide.Ext.Discord/Entities/GuildScheduledEvent.md) | Represents [Guild Scheduled Event Structure](https://discord.com/developers/docs/resources/guild-scheduled-event) |
| class [GuildScheduleEventUserAddedEvent](./Oxide.Ext.Discord/Entities/GuildScheduleEventUserAddedEvent.md) | Represents a [Guild Scheduled Event User Add Event Fields](https://discord.com/developers/docs/topics/gateway#guild-scheduled-event-user-add-guild-scheduled-event-user-add-event-fields) |
| class [GuildScheduleEventUserRemovedEvent](./Oxide.Ext.Discord/Entities/GuildScheduleEventUserRemovedEvent.md) | Represents a [Guild Scheduled Event User Remove Event Fields](https://discord.com/developers/docs/topics/gateway#guild-scheduled-event-user-remove) |
| class [GuildSearchMembers](./Oxide.Ext.Discord/Entities/GuildSearchMembers.md) | Represents [Search Guild Members](https://discord.com/developers/docs/resources/guild#search-guild-members-query-string-params) Structure |
| class [GuildStickerCreate](./Oxide.Ext.Discord/Entities/GuildStickerCreate.md) | Represents a [Sticker Pack Object](https://discord.com/developers/docs/resources/sticker#sticker-pack-object) |
| class [GuildStickersUpdatedEvent](./Oxide.Ext.Discord/Entities/GuildStickersUpdatedEvent.md) | Represents [Guild Stickers Update](https://discord.com/developers/docs/topics/gateway#guild-stickers-update) |
| class [GuildUpdate](./Oxide.Ext.Discord/Entities/GuildUpdate.md) | Represents [Update Guild Structure](https://discord.com/developers/docs/resources/guild#modify-guild) |
| class [GuildUpdateMfaLevel](./Oxide.Ext.Discord/Entities/GuildUpdateMfaLevel.md) | Represents [Guild MFA Level Update](https://discord.com/developers/docs/resources/guild#modify-guild-mfa-level-json-params) |
| class [GuildUserVoiceStateUpdate](./Oxide.Ext.Discord/Entities/GuildUserVoiceStateUpdate.md) | Represents a [Modify User Voice State](https://discord.com/developers/docs/resources/guild#modify-user-voice-state-json-params) |
| enum [GuildVerificationLevel](./Oxide.Ext.Discord/Entities/GuildVerificationLevel.md) | Represents [Verification Level](https://discord.com/developers/docs/resources/guild#guild-object-verification-level) |
| class [GuildWelcomeScreen](./Oxide.Ext.Discord/Entities/GuildWelcomeScreen.md) | Represents [Welcome Screen Structure](https://discord.com/developers/docs/resources/guild#welcome-screen-object) |
| class [GuildWelcomeScreenChannel](./Oxide.Ext.Discord/Entities/GuildWelcomeScreenChannel.md) | Represents [Welcome Screen Channel Structure](https://discord.com/developers/docs/resources/guild#welcome-screen-object-welcome-screen-channel-structure) |
| class [GuildWidget](./Oxide.Ext.Discord/Entities/GuildWidget.md) | Represents |
| class [GuildWidgetSettings](./Oxide.Ext.Discord/Entities/GuildWidgetSettings.md) | Represents [Guild Widget Settings Structure](https://discord.com/developers/docs/resources/guild#guild-widget-object-guild-widget-structure) |
| class [IdentifyCommand](./Oxide.Ext.Discord/Entities/IdentifyCommand.md) | Represents [Identify](https://discord.com/developers/docs/topics/gateway#identify) Command |
| class [InputTextComponent](./Oxide.Ext.Discord/Entities/InputTextComponent.md) | Represents a [Input Text Component](https://discord.com/developers/docs/interactions/message-components#input-text) within discord. |
| enum [InputTextStyles](./Oxide.Ext.Discord/Entities/InputTextStyles.md) | Represents a [Input Text Styles](https://discord.com/developers/docs/interactions/message-components#input-text-styles) within discord. |
| class [InstallParams](./Oxide.Ext.Discord/Entities/InstallParams.md) | Represents a [Install Params Structure](https://discord.com/developers/docs/resources/application#install-params-object) |
| class [Integration](./Oxide.Ext.Discord/Entities/Integration.md) | Represents [Integration Structure](https://discord.com/developers/docs/resources/guild#integration-object) |
| class [IntegrationAccount](./Oxide.Ext.Discord/Entities/IntegrationAccount.md) | Represents [Integration Account Structure](https://discord.com/developers/docs/resources/guild#integration-account-object) |
| class [IntegrationApplication](./Oxide.Ext.Discord/Entities/IntegrationApplication.md) | Represents [Integration Application Structure](https://discord.com/developers/docs/resources/guild#integration-application-object) |
| class [IntegrationCreatedEvent](./Oxide.Ext.Discord/Entities/IntegrationCreatedEvent.md) | Represents a [Integration Create Structure](https://discord.com/developers/docs/topics/gateway#integration-create-integration-create-event-additional-fields) |
| class [IntegrationDeletedEvent](./Oxide.Ext.Discord/Entities/IntegrationDeletedEvent.md) | Represents a [Integration Delete Structure](https://discord.com/developers/docs/topics/gateway#integration-delete-integration-delete-event-fields) |
| enum [IntegrationExpireBehaviors](./Oxide.Ext.Discord/Entities/IntegrationExpireBehaviors.md) | Represents [Integration Expire Behaviors](https://discord.com/developers/docs/resources/guild#integration-object-integration-expire-behaviors) |
| enum [IntegrationType](./Oxide.Ext.Discord/Entities/IntegrationType.md) | Represents Integrations types |
| class [IntegrationUpdate](./Oxide.Ext.Discord/Entities/IntegrationUpdate.md) | Represents [Integration Update Structure](https://discord.com/developers/docs/resources/guild#modify-guild-integration-json-params) |
| class [IntegrationUpdatedEvent](./Oxide.Ext.Discord/Entities/IntegrationUpdatedEvent.md) | Represents a [Integration Update Structure](https://discord.com/developers/docs/topics/gateway#integration-update-integration-update-event-additional-fields) |
| class [InteractionAutoCompleteMessage](./Oxide.Ext.Discord/Entities/InteractionAutoCompleteMessage.md) | Interaction Auto Complete Response Message |
| class [InteractionAutoCompleteResponse](./Oxide.Ext.Discord/Entities/InteractionAutoCompleteResponse.md) | Represents an Auto Complete response in Discord |
| class [InteractionCallback](./Oxide.Ext.Discord/Entities/InteractionCallback.md) | Represents [Interaction Callback Object](https://discord.com/developers/docs/interactions/receiving-and-responding#interaction-callback-interaction-callback-object) |
| class [InteractionCallbackActivityInstanceResource](./Oxide.Ext.Discord/Entities/InteractionCallbackActivityInstanceResource.md) | Represents [Interaction Callback Activity Instance Resource](https://discord.com/developers/docs/interactions/receiving-and-responding#interaction-callback-interaction-callback-activity-instance-resource) |
| class [InteractionCallbackData](./Oxide.Ext.Discord/Entities/InteractionCallbackData.md) | Represents [Interaction Application Command Callback Data Structure](https://discord.com/developers/docs/interactions/receiving-and-responding#interaction-response-object-interaction-callback-data-structure) |
| class [InteractionCallbackResponse](./Oxide.Ext.Discord/Entities/InteractionCallbackResponse.md) | Represents [Interaction Callback Response](https://discord.com/developers/docs/interactions/receiving-and-responding#interaction-callback-interaction-callback-response-object) |
| enum [InteractionContextTypes](./Oxide.Ext.Discord/Entities/InteractionContextTypes.md) | Represents a [Interaction Context Types](https://discord.com/developers/docs/interactions/receiving-and-responding#interaction-object-interaction-context-types) |
| class [InteractionData](./Oxide.Ext.Discord/Entities/InteractionData.md) | Represents [ApplicationCommandInteractionData](https://discord.com/developers/docs/interactions/receiving-and-responding#interaction-object-interaction-data) |
| class [InteractionDataArgs](./Oxide.Ext.Discord/Entities/InteractionDataArgs.md) | Args supplied for the interaction |
| class [InteractionDataOption](./Oxide.Ext.Discord/Entities/InteractionDataOption.md) | Represents [Application Command Interaction Data Option](https://discord.com/developers/docs/interactions/application-commands#application-command-object-application-command-interaction-data-option-structure) |
| class [InteractionDataParsed](./Oxide.Ext.Discord/Entities/InteractionDataParsed.md) | Parses Interaction Data to make it easier to process for application commands |
| class [InteractionDataResolved](./Oxide.Ext.Discord/Entities/InteractionDataResolved.md) | Represents [Application Command Interaction Data Option](https://discord.com/developers/docs/interactions/receiving-and-responding#interaction-object-resolved-data-structure) |
| class [InteractionModalMessage](./Oxide.Ext.Discord/Entities/InteractionModalMessage.md) | Represents an Interaction Modal Message |
| class [InteractionModalResponse](./Oxide.Ext.Discord/Entities/InteractionModalResponse.md) | Represents an Interaction Modal Response |
| class [InteractionResource](./Oxide.Ext.Discord/Entities/InteractionResource.md) | Represents [Interaction Callback Resource](https://discord.com/developers/docs/interactions/receiving-and-responding#interaction-callback-interaction-callback-resource-object) |
| class [InteractionResponse](./Oxide.Ext.Discord/Entities/InteractionResponse.md) | Represents [Interaction Response](https://discord.com/developers/docs/interactions/receiving-and-responding#interaction-response-object) |
| enum [InteractionResponseType](./Oxide.Ext.Discord/Entities/InteractionResponseType.md) | Represents [InteractionResponseType](https://discord.com/developers/docs/interactions/receiving-and-responding#interaction-response-object-interaction-callback-type) |
| enum [InteractionType](./Oxide.Ext.Discord/Entities/InteractionType.md) | Represents [InteractionType](https://discord.com/developers/docs/interactions/receiving-and-responding#interaction-object-interaction-type) |
| class [InviteCreatedEvent](./Oxide.Ext.Discord/Entities/InviteCreatedEvent.md) | Represents [Invite Create](https://discord.com/developers/docs/topics/gateway#invite-create) |
| class [InviteDeletedEvent](./Oxide.Ext.Discord/Entities/InviteDeletedEvent.md) | Represents [Invite Delete](https://discord.com/developers/docs/topics/gateway#invite-delete) |
| class [InviteLookup](./Oxide.Ext.Discord/Entities/InviteLookup.md) | Represents a [Scheduled Event Lookup Structure](https://discord.com/developers/docs/resources/guild-scheduled-event#list-scheduled-events-for-guild-query-string-params) within Discord. |
| class [InviteMetadata](./Oxide.Ext.Discord/Entities/InviteMetadata.md) | Represents [Invite Metadata Structure](https://discord.com/developers/docs/resources/invite#invite-metadata-object-invite-metadata-structure) |
| class [InviteStageInstance](./Oxide.Ext.Discord/Entities/InviteStageInstance.md) | Represents an [Invite Stage Instance](https://discord.com/developers/docs/resources/invite#invite-stage-instance-object) |
| enum [InviteType](./Oxide.Ext.Discord/Entities/InviteType.md) | Represents [Invite Types](https://discord.com/developers/docs/resources/invite#invite-types) |
| class [ListThreadMembers](./Oxide.Ext.Discord/Entities/ListThreadMembers.md) | Represents [List Thread Member Query String Params](https://discord.com/developers/docs/resources/channel#list-thread-members-query-string-params) |
| class [MentionableSelectComponent](./Oxide.Ext.Discord/Entities/MentionableSelectComponent.md) | Represents a [Select Menus Component](https://discord.com/developers/docs/interactions/message-components#select-menus) within discord. |
| class [MessageActivity](./Oxide.Ext.Discord/Entities/MessageActivity.md) | Represents a [Message Activity Structure](https://discord.com/developers/docs/resources/channel#message-object-message-activity-structure) |
| enum [MessageActivityType](./Oxide.Ext.Discord/Entities/MessageActivityType.md) | Represents a [Message Activity Types](https://discord.com/developers/docs/resources/channel#message-object-message-activity-types) |
| class [MessageAttachment](./Oxide.Ext.Discord/Entities/MessageAttachment.md) | Represents a message [Attachment Structure](https://discord.com/developers/docs/resources/channel#attachment-object) |
| class [MessageBulkDeletedEvent](./Oxide.Ext.Discord/Entities/MessageBulkDeletedEvent.md) | Represents [Message Delete Bulk](https://discord.com/developers/docs/topics/gateway#message-delete-bulk) |
| class [MessageCall](./Oxide.Ext.Discord/Entities/MessageCall.md) | Represents a [Message Call Structure](https://discord.com/developers/docs/resources/channel#message-call-object) |
| enum [MessageComponentType](./Oxide.Ext.Discord/Entities/MessageComponentType.md) | Represents a [Message Component Type](https://discord.com/developers/docs/interactions/message-components#component-types) within Discord.. |
| class [MessageCreate](./Oxide.Ext.Discord/Entities/MessageCreate.md) | Represents a [Message Create Structure](https://discord.com/developers/docs/resources/channel#create-message-jsonform-params) to be created in discord |
| class [MessageDeletedEvent](./Oxide.Ext.Discord/Entities/MessageDeletedEvent.md) | Represents [Message Delete](https://discord.com/developers/docs/topics/gateway#message-delete) |
| class [MessageFileAttachment](./Oxide.Ext.Discord/Entities/MessageFileAttachment.md) | Represents a file attachment for a discord message |
| [Flags] enum [MessageFlags](./Oxide.Ext.Discord/Entities/MessageFlags.md) | Represents [Message Flags](https://discord.com/developers/docs/resources/channel#message-object-message-flags) for a message |
| class [MessageInteraction](./Oxide.Ext.Discord/Entities/MessageInteraction.md) | Represents a [Message Interaction Structure](https://discord.com/developers/docs/interactions/receiving-and-responding#message-interaction-object) within Discord. |
| class [MessageInteractionMetadata](./Oxide.Ext.Discord/Entities/MessageInteractionMetadata.md) | Represents a [Message Interaction Metadata Structure](https://discord.com/developers/docs/resources/channel#message-interaction-metadata-object-message-interaction-metadata-structure) within Discord. |
| class [MessagePollVoteAddedEvent](./Oxide.Ext.Discord/Entities/MessagePollVoteAddedEvent.md) | Represents [Message Poll Vote Added Event](https://discord.com/developers/docs/topics/gateway-events#message-poll-vote-add) |
| class [MessagePollVoteRemovedEvent](./Oxide.Ext.Discord/Entities/MessagePollVoteRemovedEvent.md) | Represents [Message Poll Vote Removed Event](https://discord.com/developers/docs/topics/gateway-events#message-poll-vote-remove) |
| class [MessageReaction](./Oxide.Ext.Discord/Entities/MessageReaction.md) | Represents a [Reaction Structure](https://discord.com/developers/docs/resources/channel#reaction-object) |
| class [MessageReactionAddedEvent](./Oxide.Ext.Discord/Entities/MessageReactionAddedEvent.md) | Represents [Message Reaction Add](https://discord.com/developers/docs/topics/gateway#message-reaction-add) |
| class [MessageReactionRemovedAllEmojiEvent](./Oxide.Ext.Discord/Entities/MessageReactionRemovedAllEmojiEvent.md) | Represents [Message Reaction Remove All](https://discord.com/developers/docs/topics/gateway#message-reaction-remove-emoji-message-reaction-remove-emoji) |
| class [MessageReactionRemovedAllEvent](./Oxide.Ext.Discord/Entities/MessageReactionRemovedAllEvent.md) | Represents [Message Reaction Remove All](https://discord.com/developers/docs/topics/gateway#message-reaction-remove-all) |
| class [MessageReactionRemovedEvent](./Oxide.Ext.Discord/Entities/MessageReactionRemovedEvent.md) | Represents [Message Reaction Remove](https://discord.com/developers/docs/topics/gateway#message-reaction-remove) |
| class [MessageReference](./Oxide.Ext.Discord/Entities/MessageReference.md) | Represents a [Message Reference Structure](https://discord.com/developers/docs/resources/channel#message-reference-object-message-reference-structure) for a message |
| enum [MessageReferenceType](./Oxide.Ext.Discord/Entities/MessageReferenceType.md) | Represents [Message Reference Type](https://discord.com/developers/docs/resources/channel#message-reference-types) |
| class [MessageSnapshot](./Oxide.Ext.Discord/Entities/MessageSnapshot.md) | Represents a [Message Snapshot](https://discord.com/developers/docs/resources/channel#message-snapshot-object) |
| enum [MessageType](./Oxide.Ext.Discord/Entities/MessageType.md) | Represents [Message Types](https://discord.com/developers/docs/resources/channel#message-object-message-types) |
| class [MessageUpdate](./Oxide.Ext.Discord/Entities/MessageUpdate.md) | Represents a [Message Update Structure](https://discord.com/developers/docs/resources/channel#edit-message-jsonform-params) sent in a channel within Discord.. |
| class [OnboardingPrompt](./Oxide.Ext.Discord/Entities/OnboardingPrompt.md) | Represents [Onboarding Prompt Structure](https://discord.com/developers/docs/resources/guild#guild-onboarding-object-onboarding-prompt-structure) |
| class [OnboardingPromptOption](./Oxide.Ext.Discord/Entities/OnboardingPromptOption.md) | Represents [Prompt Option Structure](https://discord.com/developers/docs/resources/guild#guild-onboarding-object-prompt-option-structure) |
| enum [OnboardingPromptType](./Oxide.Ext.Discord/Entities/OnboardingPromptType.md) | Represents [Prompt Types](https://discord.com/developers/docs/resources/guild#guild-onboarding-object-prompt-types) |
| class [Overwrite](./Oxide.Ext.Discord/Entities/Overwrite.md) | Represents a [Overwrite Structure](https://discord.com/developers/docs/resources/channel#overwrite-object-overwrite-structure) |
| [Flags] enum [PermissionFlags](./Oxide.Ext.Discord/Entities/PermissionFlags.md) | Represents [Permission Flags](https://discord.com/developers/docs/topics/permissions#permissions-bitwise-permission-flags) for user or role |
| enum [PermissionType](./Oxide.Ext.Discord/Entities/PermissionType.md) | Represents the type of permission |
| class [PollAnswerCount](./Oxide.Ext.Discord/Entities/PollAnswerCount.md) | Represents a [Discord Poll Answer Count](https://discord.com/developers/docs/resources/poll#poll-results-object-poll-answer-count-object-structure) |
| class [PollAnswers](./Oxide.Ext.Discord/Entities/PollAnswers.md) | Represents a [Discord Poll Answers](https://discord.com/developers/docs/resources/poll#poll-answer-object) |
| class [PollCreate](./Oxide.Ext.Discord/Entities/PollCreate.md) | Represents a [Discord Poll Create](https://discord.com/developers/docs/resources/poll#poll-create-request-object-poll-create-request-object-structure) |
| enum [PollLayoutType](./Oxide.Ext.Discord/Entities/PollLayoutType.md) | Represents a [Discord Poll Layout Type](https://discord.com/developers/docs/resources/poll#layout-type) |
| class [PollMedia](./Oxide.Ext.Discord/Entities/PollMedia.md) | Represents a [Discord Poll Media](https://discord.com/developers/docs/resources/poll#poll-media-object) |
| class [PollResults](./Oxide.Ext.Discord/Entities/PollResults.md) | Represents a [Discord Poll Results](https://discord.com/developers/docs/resources/poll#poll-results-object) |
| class [PresenceUpdatedEvent](./Oxide.Ext.Discord/Entities/PresenceUpdatedEvent.md) | Represents [Presence Update](https://discord.com/developers/docs/topics/gateway#presence-update) |
| enum [PrivacyLevel](./Oxide.Ext.Discord/Entities/PrivacyLevel.md) | Represents a [Stage Privacy Level](https://discord.com/developers/docs/resources/stage-instance#stage-instance-object-privacy-level) within Discord. |
| class [RateLimitResponse](./Oxide.Ext.Discord/Entities/RateLimitResponse.md) | Represents a rate limit response from an API request |
| class [ReactionCountDetails](./Oxide.Ext.Discord/Entities/ReactionCountDetails.md) | Represents a [Reaction Count Details Structure](https://discord.com/developers/docs/resources/channel#reaction-count-details-object) |
| enum [ReactionType](./Oxide.Ext.Discord/Entities/ReactionType.md) | Represents a [Discord Reaction Type](https://discord.com/developers/docs/resources/channel#get-reactions-reaction-types) |
| class [RecurrenceRule](./Oxide.Ext.Discord/Entities/RecurrenceRule.md) | Represents [Guild Scheduled Event Recurrence Rule Object](https://discord.com/developers/docs/resources/guild-scheduled-event#guild-scheduled-event-recurrence-rule-object) |
| enum [RecurrenceRuleFrequency](./Oxide.Ext.Discord/Entities/RecurrenceRuleFrequency.md) | Represents [Guild Scheduled Event Recurrence Rule Frequency](https://discord.com/developers/docs/resources/guild-scheduled-event#guild-scheduled-event-recurrence-rule-object-guild-scheduled-event-recurrence-rule-frequency) |
| enum [RecurrenceRuleMonth](./Oxide.Ext.Discord/Entities/RecurrenceRuleMonth.md) | Represents [Guild Scheduled Event Recurrence Rule Month](https://discord.com/developers/docs/resources/guild-scheduled-event#guild-scheduled-event-recurrence-rule-object-guild-scheduled-event-recurrence-rule-month) |
| class [RecurrenceRuleNWeekday](./Oxide.Ext.Discord/Entities/RecurrenceRuleNWeekday.md) | Represents [Guild Scheduled Event Recurrence Rule N Weekday Object](https://discord.com/developers/docs/resources/guild-scheduled-event#guild-scheduled-event-recurrence-rule-object-guild-scheduled-event-recurrence-rule-nweekday-structure) |
| enum [RecurrenceRuleWeekday](./Oxide.Ext.Discord/Entities/RecurrenceRuleWeekday.md) | Represents [Guild Scheduled Event Recurrence Rule Weekday](https://discord.com/developers/docs/resources/guild-scheduled-event#guild-scheduled-event-recurrence-rule-object-guild-scheduled-event-recurrence-rule-weekday) |
| enum [RequestErrorType](./Oxide.Ext.Discord/Entities/RequestErrorType.md) | Represents a Discord Request Error Type |
| class [RequestResponse](./Oxide.Ext.Discord/Entities/RequestResponse.md) | Represents a REST response from discord |
| class [ResponseError](./Oxide.Ext.Discord/Entities/ResponseError.md) | Error object that is returned to the caller when a request fails |
| class [ResponseErrorMessage](./Oxide.Ext.Discord/Entities/ResponseErrorMessage.md) | Represents an [error from the discord API](https://discord.com/developers/docs/reference#error-messages) |
| class [ResumeSessionCommand](./Oxide.Ext.Discord/Entities/ResumeSessionCommand.md) | Represents [Resume](https://discord.com/developers/docs/topics/gateway#resume) |
| [Flags] enum [RoleFlags](./Oxide.Ext.Discord/Entities/RoleFlags.md) | Represents [Role Flags](https://discord.com/developers/docs/topics/permissions#role-flags) |
| class [RoleSelectComponent](./Oxide.Ext.Discord/Entities/RoleSelectComponent.md) | Represents a [Select Menus Component](https://discord.com/developers/docs/interactions/message-components#select-menus) within discord. |
| class [RoleSubscription](./Oxide.Ext.Discord/Entities/RoleSubscription.md) | Represents [Role Subscription Structure](https://discord.com/developers/docs/resources/channel#role-subscription-data-object-role-subscription-data-object-structure) |
| class [RoleTags](./Oxide.Ext.Discord/Entities/RoleTags.md) | Represents [Role Tags Structure](https://discord.com/developers/docs/topics/permissions#role-object-role-tags-structure) |
| class [ScheduledEventCreate](./Oxide.Ext.Discord/Entities/ScheduledEventCreate.md) | Represents [Guild Scheduled Event Create](https://discord.com/developers/docs/resources/guild-scheduled-event#create-guild-scheduled-event) within discord |
| class [ScheduledEventEntityMetadata](./Oxide.Ext.Discord/Entities/ScheduledEventEntityMetadata.md) | Represents [Guild Scheduled Event Entity Metadata](https://discord.com/developers/docs/resources/guild-scheduled-event#guild-scheduled-event-object-guild-scheduled-event-entity-metadata) |
| enum [ScheduledEventEntityType](./Oxide.Ext.Discord/Entities/ScheduledEventEntityType.md) | Represents [Scheduled Entity Type](https://discord.com/developers/docs/resources/guild-scheduled-event#guild-scheduled-event-object-guild-scheduled-event-entity-types) |
| class [ScheduledEventLookup](./Oxide.Ext.Discord/Entities/ScheduledEventLookup.md) | Represents a [Scheduled Event Lookup Structure](https://discord.com/developers/docs/resources/guild-scheduled-event#list-scheduled-events-for-guild-query-string-params) within Discord. |
| enum [ScheduledEventPrivacyLevel](./Oxide.Ext.Discord/Entities/ScheduledEventPrivacyLevel.md) | Represents [Guild Scheduled Event Privacy Level](https://discord.com/developers/docs/resources/guild-scheduled-event#guild-scheduled-event-object-guild-scheduled-event-privacy-level) |
| enum [ScheduledEventStatus](./Oxide.Ext.Discord/Entities/ScheduledEventStatus.md) | Represents [Guild Scheduled Event Status](https://discord.com/developers/docs/resources/guild-scheduled-event#guild-scheduled-event-object-guild-scheduled-event-status) |
| class [ScheduledEventUpdate](./Oxide.Ext.Discord/Entities/ScheduledEventUpdate.md) | Represents [Guild Scheduled Event Update](https://discord.com/developers/docs/resources/guild-scheduled-event#modify-guild-scheduled-event) within discord |
| class [ScheduledEventUser](./Oxide.Ext.Discord/Entities/ScheduledEventUser.md) | Represents [Guild Scheduled Event User Object](https://discord.com/developers/docs/resources/guild-scheduled-event#guild-scheduled-event-user-object-guild-scheduled-event-user-structure) within discord |
| class [ScheduledEventUsersLookup](./Oxide.Ext.Discord/Entities/ScheduledEventUsersLookup.md) | Represents a [Scheduled Event Lookup Structure](https://discord.com/developers/docs/resources/guild-scheduled-event#list-scheduled-events-for-guild-query-string-params) within Discord. Provide a user id to before and after for pagination. Users will always be returned in ascending order by user_id. If both before and after are provided, only before is respected. Fetching users in-between before and after is not supported. |
| class [SelectMenuDefaultValue](./Oxide.Ext.Discord/Entities/SelectMenuDefaultValue.md) | Represents a [Select Default Value Structure](https://discord.com/developers/docs/interactions/message-components#select-menu-object-select-default-value-structure) within discord. |
| enum [SelectMenuDefaultValueType](./Oxide.Ext.Discord/Entities/SelectMenuDefaultValueType.md) | Represents a [Select Menus Default Value Type](https://discord.com/developers/docs/interactions/message-components#select-menu-object-select-default-value-structure) within discord. |
| class [SelectMenuOption](./Oxide.Ext.Discord/Entities/SelectMenuOption.md) | Represents a [Select Menu Option Structure](https://discord.com/developers/docs/interactions/message-components#select-option-structure) within discord. |
| class [SendSoundboardSound](./Oxide.Ext.Discord/Entities/SendSoundboardSound.md) | Represents [Send Soundboard Sound Request](https://discord.com/developers/docs/resources/soundboard#send-soundboard-sound-json-params) in Discord |
| [Flags] enum [SkuFlags](./Oxide.Ext.Discord/Entities/SkuFlags.md) | Represents a [Discord SKU Flags](https://discord.com/developers/docs/monetization/skus#sku-object-sku-flags) |
| struct [Snowflake](./Oxide.Ext.Discord/Entities/Snowflake.md) | Represents an ID in discord. |
| enum [SortOrderType](./Oxide.Ext.Discord/Entities/SortOrderType.md) | Represents [Sort Order Types](https://discord.com/developers/docs/resources/channel#channel-object-sort-order-types) in Discord |
| class [SoundboardDeletedEvent](./Oxide.Ext.Discord/Entities/SoundboardDeletedEvent.md) | Represents [Guild Soundboard Sound Delete](https://discord.com/developers/docs/events/gateway-events#guild-soundboard-sound-delete-guild-soundboard-sound-delete-event-fields) |
| class [SoundboardSoundCreate](./Oxide.Ext.Discord/Entities/SoundboardSoundCreate.md) | Represents [Soundboard Create Request](https://discord.com/developers/docs/resources/soundboard#create-guild-soundboard-sound-json-params) in Discord |
| class [SoundboardSoundsUpdatedEvent](./Oxide.Ext.Discord/Entities/SoundboardSoundsUpdatedEvent.md) | Represents [Guild Soundboard Sounds Update](https://discord.com/developers/docs/events/gateway-events#guild-soundboard-sounds-update-guild-soundboard-sounds-update-event-fields) |
| class [SoundboardSoundUpdate](./Oxide.Ext.Discord/Entities/SoundboardSoundUpdate.md) | Represents [Soundboard Update Request](https://discord.com/developers/docs/resources/soundboard#modify-guild-soundboard-sound-json-params) in Discord |
| class [StageInstance](./Oxide.Ext.Discord/Entities/StageInstance.md) | Represents a channel [Stage Instance](https://discord.com/developers/docs/resources/stage-instance#stage-instance-object-stage-instance-structure) within Discord. |
| class [StageInstanceCreate](./Oxide.Ext.Discord/Entities/StageInstanceCreate.md) | Represents a  href="https://discord.com/developers/docs/resources/stage-instance#create-stage-instance-json-params"&gt;Stage Instance Create Structure |
| class [StageInstanceUpdate](./Oxide.Ext.Discord/Entities/StageInstanceUpdate.md) | Represents a [Modify Stage Instance](https://discord.com/developers/docs/resources/stage-instance#modify-stage-instance-json-params) Structure |
| enum [StickerFormatType](./Oxide.Ext.Discord/Entities/StickerFormatType.md) | Represents [Sticker Format Types](https://discord.com/developers/docs/resources/sticker#sticker-format-types) |
| enum [StickerType](./Oxide.Ext.Discord/Entities/StickerType.md) | Represents a [Sticker Types](https://discord.com/developers/docs/resources/sticker#sticker-types) |
| class [StringSelectComponent](./Oxide.Ext.Discord/Entities/StringSelectComponent.md) | Represents a [Select Menus Component](https://discord.com/developers/docs/interactions/message-components#select-menus) within discord. |
| enum [SubscriptionStatus](./Oxide.Ext.Discord/Entities/SubscriptionStatus.md) | Represents a [Subscription Statuses](https://discord.com/developers/docs/resources/subscription#subscription-statuses) |
| [Flags] enum [SystemChannelFlags](./Oxide.Ext.Discord/Entities/SystemChannelFlags.md) | Represents [System Channel Flags](https://discord.com/developers/docs/resources/guild#guild-object-system-channel-flags) |
| enum [TargetUserType](./Oxide.Ext.Discord/Entities/TargetUserType.md) | Represents [Target User Types](https://discord.com/developers/docs/resources/invite#invite-object-target-user-types) |
| class [TeamMember](./Oxide.Ext.Discord/Entities/TeamMember.md) | Represents [Team Members Object](https://discord.com/developers/docs/topics/teams#data-models-team-members-object) |
| enum [TeamMembershipState](./Oxide.Ext.Discord/Entities/TeamMembershipState.md) | Represents [Membership State Enum](https://discord.com/developers/docs/topics/teams#data-models-membership-state-enum) |
| enum [TeamRole](./Oxide.Ext.Discord/Entities/TeamRole.md) | Represents [Team Role Types](https://discord.com/developers/docs/topics/teams#team-member-roles-team-member-role-types) |
| class [ThreadArchivedLookup](./Oxide.Ext.Discord/Entities/ThreadArchivedLookup.md) | Represents a [Thread Archive Lookup Structure](https://discord.com/developers/docs/resources/channel#list-public-archived-threads-query-string-params) within Discord. Represents a [Thread Archive Lookup Structure](https://discord.com/developers/docs/resources/channel#list-private-archived-threads-query-string-params) within Discord. Represents a [Thread Archive Lookup Structure](https://discord.com/developers/docs/resources/channel#list-joined-private-archived-threads-query-string-params) within Discord. |
| class [ThreadChannelUpdate](./Oxide.Ext.Discord/Entities/ThreadChannelUpdate.md) | Represents a [Thread Channel Update Structure](https://discord.com/developers/docs/resources/channel#modify-channel-json-params-thread) |
| class [ThreadCreate](./Oxide.Ext.Discord/Entities/ThreadCreate.md) | Represents a [Thread Create Structure](https://discord.com/developers/docs/resources/channel#start-thread-without-message-json-params) within Discord. |
| class [ThreadCreateFromMessage](./Oxide.Ext.Discord/Entities/ThreadCreateFromMessage.md) | Represents a [Thread Create From Message](https://discord.com/developers/docs/resources/channel#start-thread-from-message-json-params) Structure |
| class [ThreadForumCreate](./Oxide.Ext.Discord/Entities/ThreadForumCreate.md) | Represents a [Start Thread in Forum Channel](https://discord.com/developers/docs/resources/channel#start-thread-in-forum-channel-jsonform-params) Structure |
| class [ThreadList](./Oxide.Ext.Discord/Entities/ThreadList.md) | Represents a [Thread List Structure](https://discord.com/developers/docs/resources/channel#list-active-threads) within Discord. Represents a [Thread List Public Archived Structure](https://discord.com/developers/docs/resources/channel#list-public-archived-threads-response-body) within Discord. Represents a [Thread List Private Archived Structure](https://discord.com/developers/docs/resources/channel#list-private-archived-threads-response-body) within Discord. Represents a [Thread List Private Archived Structure](https://discord.com/developers/docs/resources/guild#list-active-threads) within Discord. |
| class [ThreadListSyncEvent](./Oxide.Ext.Discord/Entities/ThreadListSyncEvent.md) | Represents [Thread List Sync](https://discord.com/developers/docs/topics/gateway#thread-list-sync-thread-list-sync-event-fields) |
| class [ThreadMember](./Oxide.Ext.Discord/Entities/ThreadMember.md) | Represents a guild or DM [Thread Member Structure](https://discord.com/developers/docs/resources/channel#thread-member-object) within Discord. |
| class [ThreadMembersUpdatedEvent](./Oxide.Ext.Discord/Entities/ThreadMembersUpdatedEvent.md) | Represents [Thread Members Update Structure](https://discord.com/developers/docs/topics/gateway#thread-members-update-thread-members-update-event-fields) |
| class [ThreadMemberUpdateEvent](./Oxide.Ext.Discord/Entities/ThreadMemberUpdateEvent.md) | Represents [Thread Member Update Structure](https://discord.com/developers/docs/topics/gateway#thread-member-update) |
| class [ThreadMetadata](./Oxide.Ext.Discord/Entities/ThreadMetadata.md) | Represents a guild or DM [Thread Metadata Structure](https://discord.com/developers/docs/resources/channel#thread-metadata-object-thread-metadata-structure) within Discord. |
| class [TypingStartedEvent](./Oxide.Ext.Discord/Entities/TypingStartedEvent.md) | Represents [Typing Start](https://discord.com/developers/docs/topics/gateway#typing-start) |
| class [UpdatePresenceCommand](./Oxide.Ext.Discord/Entities/UpdatePresenceCommand.md) | Represents [Update Status](https://discord.com/developers/docs/topics/gateway#update-presence) |
| class [UpdateVoiceStatusCommand](./Oxide.Ext.Discord/Entities/UpdateVoiceStatusCommand.md) | Represents [Update Voice State](https://discord.com/developers/docs/topics/gateway#update-voice-state) |
| [Flags] enum [UserFlags](./Oxide.Ext.Discord/Entities/UserFlags.md) | Represents [User Flags](https://discord.com/developers/docs/resources/user#user-object-user-flags) |
| class [UserGuildsRequest](./Oxide.Ext.Discord/Entities/UserGuildsRequest.md) | Represents a [Users Guild Request](https://discord.com/developers/docs/resources/user#get-current-user-guilds-query-string-params) |
| class [UserModifyCurrent](./Oxide.Ext.Discord/Entities/UserModifyCurrent.md) | Represents a [Modify Current User Structure](https://discord.com/developers/docs/resources/user#modify-current-user-json-params) |
| enum [UserPremiumType](./Oxide.Ext.Discord/Entities/UserPremiumType.md) | Represents Discord User [Premium Types](https://discord.com/developers/docs/resources/user#user-object-premium-types) |
| class [UserSelectComponent](./Oxide.Ext.Discord/Entities/UserSelectComponent.md) | Represents a [Select Menus Component](https://discord.com/developers/docs/interactions/message-components#select-menus) within discord. |
| enum [UserStatusType](./Oxide.Ext.Discord/Entities/UserStatusType.md) | Represents Discord User [Status Types](https://discord.com/developers/docs/topics/gateway#update-status-status-types) |
| enum [VideoQualityMode](./Oxide.Ext.Discord/Entities/VideoQualityMode.md) | Represents a [Video Quality Mode](https://discord.com/developers/docs/resources/channel#channel-object-video-quality-modes) |
| class [VoiceChannelEffectEvent](./Oxide.Ext.Discord/Entities/VoiceChannelEffectEvent.md) | Represents [Voice Server Update](https://discord.com/developers/docs/topics/gateway#voice-server-update) |
| class [VoiceRegion](./Oxide.Ext.Discord/Entities/VoiceRegion.md) | Represents [Voice Region Structure](https://discord.com/developers/docs/resources/voice#voice-region-object) |
| class [VoiceServerUpdatedEvent](./Oxide.Ext.Discord/Entities/VoiceServerUpdatedEvent.md) | Represents [Voice Server Update](https://discord.com/developers/docs/topics/gateway#voice-server-update) |
| class [VoiceState](./Oxide.Ext.Discord/Entities/VoiceState.md) | Represents [Voice State Structure](https://discord.com/developers/docs/resources/voice#voice-state-object) |
| class [WebhookCreate](./Oxide.Ext.Discord/Entities/WebhookCreate.md) | Represents a [Webhook Create Structure](https://discord.com/developers/docs/resources/webhook#create-webhook-json-params) |
| class [WebhookCreateMessage](./Oxide.Ext.Discord/Entities/WebhookCreateMessage.md) | Represents [Webhook Create Message](https://discord.com/developers/docs/resources/webhook#execute-webhook-jsonform-params) |
| class [WebhookEdit](./Oxide.Ext.Discord/Entities/WebhookEdit.md) | Represents a [Webhook Create Structure](https://discord.com/developers/docs/resources/webhook#create-webhook-json-params) |
| class [WebhookEditMessage](./Oxide.Ext.Discord/Entities/WebhookEditMessage.md) | Represents [Webhook Edit Message Structure](https://discord.com/developers/docs/resources/webhook#edit-webhook-message-jsonform-params) |
| class [WebhookExecuteParams](./Oxide.Ext.Discord/Entities/WebhookExecuteParams.md) | Represents parameters to execute a webhook |
| class [WebhookMessageParams](./Oxide.Ext.Discord/Entities/WebhookMessageParams.md) | Represents webhook message query string parameters |
| enum [WebhookSendType](./Oxide.Ext.Discord/Entities/WebhookSendType.md) | Use to control which webhook execute url to call |
| class [WebhooksUpdatedEvent](./Oxide.Ext.Discord/Entities/WebhooksUpdatedEvent.md) | Represents [Webhooks Update](https://discord.com/developers/docs/topics/gateway#webhooks-update) |
| enum [WebhookType](./Oxide.Ext.Discord/Entities/WebhookType.md) | Represents [Webhook Types](https://discord.com/developers/docs/resources/webhook#webhook-object-webhook-types) |
| class [WebSocketCommand](./Oxide.Ext.Discord/Entities/WebSocketCommand.md) | Represents a command to be sent over the web socket |
| class [WelcomeScreenUpdate](./Oxide.Ext.Discord/Entities/WelcomeScreenUpdate.md) | Represents [https://discord.com/developers/docs/resources/guild#modify-guild-welcome-screen](https://discord.com/developers/docs/resources/guild#modify-guild-welcome-screen) |

## Oxide.Ext.Discord.Exceptions namespace

| public type | description |
| --- | --- |
| class [ApplicationCommandBuilderException](./Oxide.Ext.Discord/Exceptions/ApplicationCommandBuilderException.md) | Represents an error when building Application Commands |
| class [ApplicationRoleConnectionMetadataException](./Oxide.Ext.Discord/Exceptions/ApplicationRoleConnectionMetadataException.md) | Exceptions for [`ApplicationRoleConnectionMetadata`](./Oxide.Ext.Discord/Entities/ApplicationRoleConnectionMetadata.md) |
| class [AutoModTriggerMetadataException](./Oxide.Ext.Discord/Exceptions/AutoModTriggerMetadataException.md) | Exceptions for [`AutoModTriggerMetadata`](./Oxide.Ext.Discord/Entities/AutoModTriggerMetadata.md) |
| abstract class [BaseDiscordException](./Oxide.Ext.Discord/Exceptions/BaseDiscordException.md) | Represents a base discord extension |
| class [BlockedUserException](./Oxide.Ext.Discord/Exceptions/BlockedUserException.md) | Exception when a user has blocked receving messages from a bot |
| class [DiscordApplicationException](./Oxide.Ext.Discord/Exceptions/DiscordApplicationException.md) | Exceptions for [`DiscordApplication`](./Oxide.Ext.Discord/Entities/DiscordApplication.md) |
| class [DiscordClientException](./Oxide.Ext.Discord/Exceptions/DiscordClientException.md) | Exceptions for the [`DiscordClient`](./Oxide.Ext.Discord/Clients/DiscordClient.md) |
| class [DiscordLocaleNotFoundException](./Oxide.Ext.Discord/Exceptions/DiscordLocaleNotFoundException.md) | Exception thrown when Discord Locale is not found |
| class [DiscordLoggerException](./Oxide.Ext.Discord/Exceptions/DiscordLoggerException.md) | Exceptions for the [`DiscordClient`](./Oxide.Ext.Discord/Clients/DiscordClient.md) |
| class [DiscordTemplateException](./Oxide.Ext.Discord/Exceptions/DiscordTemplateException.md) | Exception for Discord Templates |
| class [DiscordWebSocketException](./Oxide.Ext.Discord/Exceptions/DiscordWebSocketException.md) | Represents an exception that occured with the websocket |
| class [DuplicateTemplateException](./Oxide.Ext.Discord/Exceptions/DuplicateTemplateException.md) | Thrown when duplicate templates have been registered for the same type, plugin, and name |
| class [InteractionArgException](./Oxide.Ext.Discord/Exceptions/InteractionArgException.md) | Represents an error when an interaction arg does not match the requested type |
| class [InteractionResponseBuilderException](./Oxide.Ext.Discord/Exceptions/InteractionResponseBuilderException.md) | Represents an Interaction Response Builder Exception |
| class [InvalidApplicationCommandException](./Oxide.Ext.Discord/Exceptions/InvalidApplicationCommandException.md) | Represents an invalid application command |
| class [InvalidAutoCompleteChoiceException](./Oxide.Ext.Discord/Exceptions/InvalidAutoCompleteChoiceException.md) | Exception for invalid Auto Complete choices |
| class [InvalidChannelException](./Oxide.Ext.Discord/Exceptions/InvalidChannelException.md) | Represents using an invalid channel |
| class [InvalidChannelInviteException](./Oxide.Ext.Discord/Exceptions/InvalidChannelInviteException.md) | Represents an error in channel invite |
| class [InvalidCommandOptionChoiceException](./Oxide.Ext.Discord/Exceptions/InvalidCommandOptionChoiceException.md) | Represents an error in application command option choice |
| class [InvalidCommandOptionException](./Oxide.Ext.Discord/Exceptions/InvalidCommandOptionException.md) | Represents an error in application command option |
| class [InvalidDiscordColorException](./Oxide.Ext.Discord/Exceptions/InvalidDiscordColorException.md) | Represents an invalid discord color |
| class [InvalidEmbedException](./Oxide.Ext.Discord/Exceptions/InvalidEmbedException.md) | Represents an invalid embed |
| class [InvalidEmojiException](./Oxide.Ext.Discord/Exceptions/InvalidEmojiException.md) | Error thrown when an emoji string fails validation |
| class [InvalidFileNameException](./Oxide.Ext.Discord/Exceptions/InvalidFileNameException.md) | Exception throw when an attachment filename contains invalid characters |
| class [InvalidForumTagException](./Oxide.Ext.Discord/Exceptions/InvalidForumTagException.md) | Represents an exception for channel threads |
| class [InvalidGetEntitlementException](./Oxide.Ext.Discord/Exceptions/InvalidGetEntitlementException.md) | Exceptions for invalid entitlements |
| class [InvalidGetSkuSubscriptionsException](./Oxide.Ext.Discord/Exceptions/InvalidGetSkuSubscriptionsException.md) | Exceptions for invalid entitlements |
| class [InvalidGuildBanException](./Oxide.Ext.Discord/Exceptions/InvalidGuildBanException.md) | Represents an error in channel ban |
| class [InvalidGuildException](./Oxide.Ext.Discord/Exceptions/InvalidGuildException.md) | Represents an exception in guild |
| class [InvalidGuildListMembersException](./Oxide.Ext.Discord/Exceptions/InvalidGuildListMembersException.md) | Represents an exception in guid list request |
| class [InvalidGuildMemberException](./Oxide.Ext.Discord/Exceptions/InvalidGuildMemberException.md) | Represents an exception in guild member |
| class [InvalidGuildPruneException](./Oxide.Ext.Discord/Exceptions/InvalidGuildPruneException.md) | Represents an exception in guild prune requests |
| class [InvalidGuildRoleException](./Oxide.Ext.Discord/Exceptions/InvalidGuildRoleException.md) | Represents an exception for invalid guild roles |
| class [InvalidGuildScheduledEventException](./Oxide.Ext.Discord/Exceptions/InvalidGuildScheduledEventException.md) | Represents an exception in guild scheduled events |
| class [InvalidGuildScheduledEventLookupException](./Oxide.Ext.Discord/Exceptions/InvalidGuildScheduledEventLookupException.md) | Represents an exception in guild schedule event lookup requests |
| class [InvalidGuildSearchMembersException](./Oxide.Ext.Discord/Exceptions/InvalidGuildSearchMembersException.md) | Represents an exception in guild member search requests |
| class [InvalidGuildStickerException](./Oxide.Ext.Discord/Exceptions/InvalidGuildStickerException.md) | Represents an exception in guild stickers |
| class [InvalidImageDataException](./Oxide.Ext.Discord/Exceptions/InvalidImageDataException.md) | Represents an exception in discord image data |
| class [InvalidInteractionResponseException](./Oxide.Ext.Discord/Exceptions/InvalidInteractionResponseException.md) | Error thrown when an interaction response is invalid |
| class [InvalidMessageComponentException](./Oxide.Ext.Discord/Exceptions/InvalidMessageComponentException.md) | Represents an invalid message component |
| class [InvalidMessageException](./Oxide.Ext.Discord/Exceptions/InvalidMessageException.md) | Represents an invalid message |
| class [InvalidPlaceholderDataException](./Oxide.Ext.Discord/Exceptions/InvalidPlaceholderDataException.md) | Exception thrown if [`PlaceholderDataKey`](./Oxide.Ext.Discord/Libraries/PlaceholderDataKey.md) is not valid |
| class [InvalidPlaceholderException](./Oxide.Ext.Discord/Exceptions/InvalidPlaceholderException.md) | Exception thrown if [`PlaceholderKey`](./Oxide.Ext.Discord/Libraries/PlaceholderKey.md) is not valid |
| class [InvalidPoolException](./Oxide.Ext.Discord/Exceptions/InvalidPoolException.md) | An exception when something is invalid with a pool |
| class [InvalidSelectMenuComponentException](./Oxide.Ext.Discord/Exceptions/InvalidSelectMenuComponentException.md) | Represents an exception for select menu components |
| class [InvalidSnowflakeException](./Oxide.Ext.Discord/Exceptions/InvalidSnowflakeException.md) | Exception thrown when an invalid Snowflake ID is used in an API call |
| class [InvalidSoundboardException](./Oxide.Ext.Discord/Exceptions/InvalidSoundboardException.md) | Represents an exception in discord sound data |
| class [InvalidSoundDataException](./Oxide.Ext.Discord/Exceptions/InvalidSoundDataException.md) | Represents an exception in discord sound data |
| class [InvalidTemplateVersionException](./Oxide.Ext.Discord/Exceptions/InvalidTemplateVersionException.md) | Thrown when the minimum template version is higher than the current template version |
| class [InvalidThreadException](./Oxide.Ext.Discord/Exceptions/InvalidThreadException.md) | Represents an exception for channel threads |
| class [InvalidUserException](./Oxide.Ext.Discord/Exceptions/InvalidUserException.md) | Represents an exception when modifying a user with invalid data |
| class [InvalidWebhookException](./Oxide.Ext.Discord/Exceptions/InvalidWebhookException.md) | Represents a Webhook Create Exception |
| class [MessageComponentBuilderException](./Oxide.Ext.Discord/Exceptions/MessageComponentBuilderException.md) | Represents an exception in Message Component Builder |
| class [PromiseCancelledException](./Oxide.Ext.Discord/Exceptions/PromiseCancelledException.md) | Exception when a promised is cancelled |
| class [PromiseException](./Oxide.Ext.Discord/Exceptions/PromiseException.md) | Exceptions for promises |
| class [RequestCancelledException](./Oxide.Ext.Discord/Exceptions/RequestCancelledException.md) | Exception returns from promise when a request is cancelled |
| class [ServerLocaleNotFoundException](./Oxide.Ext.Discord/Exceptions/ServerLocaleNotFoundException.md) | Exception thrown when Server Locale is not found |
| class [TokenMismatchException](./Oxide.Ext.Discord/Exceptions/TokenMismatchException.md) | Represents a bot token mismatch |

## Oxide.Ext.Discord.Exceptions.Data namespace

| public type | description |
| --- | --- |
| class [DataInfoNotFoundException](./Oxide.Ext.Discord/Exceptions/Data/DataInfoNotFoundException.md) | Exception for Data Info not being fouind |

## Oxide.Ext.Discord.Extensions namespace

| public type | description |
| --- | --- |
| static class [ByteExt](./Oxide.Ext.Discord/Extensions/ByteExt.md) |  |
| static class [DateTimeOffsetExt](./Oxide.Ext.Discord/Extensions/DateTimeOffsetExt.md) | DateTimeOffset Extensions |
| static class [DiscordUserExt](./Oxide.Ext.Discord/Extensions/DiscordUserExt.md) | Adds extension methods to Discord User to allow sending server chat commands to the player |
| static class [HashExt](./Oxide.Ext.Discord/Extensions/HashExt.md) | Hash extensions |
| static class [IEnumerableExt](./Oxide.Ext.Discord/Extensions/IEnumerableExt.md) | Represents Extension to IEnumerable |
| static class [MathExt](./Oxide.Ext.Discord/Extensions/MathExt.md) | Extensions for math operations |
| static class [PlayerExt](./Oxide.Ext.Discord/Extensions/PlayerExt.md) | IPlayer Extensions for sending Discord Message to an IPlayer |
| static class [SpanExt](./Oxide.Ext.Discord/Extensions/SpanExt.md) | Span Extension Methods |
| static class [StreamExt](./Oxide.Ext.Discord/Extensions/StreamExt.md) | Stream Extension Methods |
| static class [StringBuilderExt](./Oxide.Ext.Discord/Extensions/StringBuilderExt.md) | StringBuilder extension methods |

## Oxide.Ext.Discord.Factory namespace

| public type | description |
| --- | --- |
| class [DiscordClientFactory](./Oxide.Ext.Discord/Factory/DiscordClientFactory.md) | Factory for creating [`DiscordClient`](./Oxide.Ext.Discord/Clients/DiscordClient.md) |
| class [SnowflakeIdFactory](./Oxide.Ext.Discord/Factory/SnowflakeIdFactory.md) | Generates a unique snowflake ID |

## Oxide.Ext.Discord.Helpers namespace

| public type | description |
| --- | --- |
| static class [DiscordAppRoutes](./Oxide.Ext.Discord/Helpers/DiscordAppRoutes.md) | Discord App Routes for navigating the client within the discord app using links Sourced from: https://gist.github.com/ghostrider-05/8f1a0bfc27c7c4509b4ea4e8ce718af0 |
| static class [DiscordCdn](./Oxide.Ext.Discord/Helpers/DiscordCdn.md) | Represents Discord [CDN Endpoints](https://discord.com/developers/docs/reference#image-formatting-cdn-endpoints) |
| static class [DiscordFormatting](./Oxide.Ext.Discord/Helpers/DiscordFormatting.md) | Represents [Message text formatting options](https://discord.com/developers/docs/reference#message-formatting-formats) |
| static class [ServerFormatting](./Oxide.Ext.Discord/Helpers/ServerFormatting.md) | Server Text Formatting |
| enum [SettingsPage](./Oxide.Ext.Discord/Helpers/SettingsPage.md) | App Settings Pages |
| enum [TimestampStyles](./Oxide.Ext.Discord/Helpers/TimestampStyles.md) | Available flags for timestamp formatting |

## Oxide.Ext.Discord.Interfaces namespace

| public type | description |
| --- | --- |
| interface [IBulkTemplate&lt;T&gt;](./Oxide.Ext.Discord/Interfaces/IBulkTemplate%7BT%7D.md) | Represents a Template that supports bulk operations |
| interface [IDebugLoggable](./Oxide.Ext.Discord/Interfaces/IDebugLoggable.md) | Represents an object that supports debug logging |
| interface [IDiscordCacheable&lt;T&gt;](./Oxide.Ext.Discord/Interfaces/IDiscordCacheable%7BT%7D.md) | Represents entities that are cacheable by the DiscordExtension |
| interface [IDiscordKey](./Oxide.Ext.Discord/Interfaces/IDiscordKey.md) | Represents a Key in Discord |
| interface [IDiscordLoggingConfig](./Oxide.Ext.Discord/Interfaces/IDiscordLoggingConfig.md) | Interface for Discord Logging Configuration |
| interface [IDiscordMessageTemplate](./Oxide.Ext.Discord/Interfaces/IDiscordMessageTemplate.md) | Interfaces for [`DiscordMessageTemplates`](./Oxide.Ext.Discord/Libraries/DiscordMessageTemplates.md) Messages |
| interface [IDiscordPlugin](./Oxide.Ext.Discord/Interfaces/IDiscordPlugin.md) | Represents a plugin that uses the Discord Extension |
| interface [IDiscordPool](./Oxide.Ext.Discord/Interfaces/IDiscordPool.md) | Interface for plugins to use that need access to a pool |
| interface [IDiscordQueryString](./Oxide.Ext.Discord/Interfaces/IDiscordQueryString.md) | Interface for Discord Query Strings |
| interface [IFileAttachments](./Oxide.Ext.Discord/Interfaces/IFileAttachments.md) | Represents and interface for entities that can upload files |
| interface [ILogger](./Oxide.Ext.Discord/Interfaces/ILogger.md) | Represents an interface for a logger |
| interface [IOutputLogger](./Oxide.Ext.Discord/Interfaces/IOutputLogger.md) | Represents a specific logger output |
| interface [IPendingPromise](./Oxide.Ext.Discord/Interfaces/IPendingPromise.md) | Represents a promise the is still pending waiting to be resolved |
| interface [IPendingPromise&lt;TPromised&gt;](./Oxide.Ext.Discord/Interfaces/IPendingPromise%7BTPromised%7D.md) | Represents a promise waiting to be resolved |
| interface [IPluginBase](./Oxide.Ext.Discord/Interfaces/IPluginBase.md) | Represents an interface for a plugin |
| interface [IPromise](./Oxide.Ext.Discord/Interfaces/IPromise.md) | Implements a non-generic C# promise, this is a promise that simply resolves without delivering a value. https://developer.mozilla.org/en/docs/Web/JavaScript/Reference/Global_Objects/Promise |
| interface [IPromise&lt;TPromised&gt;](./Oxide.Ext.Discord/Interfaces/IPromise%7BTPromised%7D.md) | Implements a C# promise. https://developer.mozilla.org/en/docs/Web/JavaScript/Reference/Global_Objects/Promise |
| interface [IRejectable](./Oxide.Ext.Discord/Interfaces/IRejectable.md) | Interface for a promise that can be rejected. |
| interface [ISnowflakeEntity](./Oxide.Ext.Discord/Interfaces/ISnowflakeEntity.md) | Interface used to get the entity ID from an entity |
| interface [IWebSocketEventHandler](./Oxide.Ext.Discord/Interfaces/IWebSocketEventHandler.md) | Represents a Handler for Websocket Events |

## Oxide.Ext.Discord.Json namespace

| public type | description |
| --- | --- |
| class [DiscordColorConverter](./Oxide.Ext.Discord/Json/DiscordColorConverter.md) | Handles the JSON Serialization / Deserialization for DiscordColor |
| class [DiscordEnumConverter](./Oxide.Ext.Discord/Json/DiscordEnumConverter.md) | Handles deserializing JSON values as strings. If the value doesn't exist, return the default value. |
| class [DiscordImageDataConverter](./Oxide.Ext.Discord/Json/DiscordImageDataConverter.md) | Represents the JsonConverter for [`DiscordImageData`](./Oxide.Ext.Discord/Entities/DiscordImageData.md) |
| class [DiscordJsonReader](./Oxide.Ext.Discord/Json/DiscordJsonReader.md) | This is a pooled JSON reader that can read as string, deserialize object, or populate a given object async |
| class [DiscordJsonWriter](./Oxide.Ext.Discord/Json/DiscordJsonWriter.md) | This is a pooled JSON writer that can write JSON to a stream |
| class [DiscordSoundDataConverter](./Oxide.Ext.Discord/Json/DiscordSoundDataConverter.md) | Represents the JsonConverter for [`DiscordSoundData`](./Oxide.Ext.Discord/Entities/DiscordSoundData.md) |
| class [EventPayloadConverter](./Oxide.Ext.Discord/Json/EventPayloadConverter.md) | JSON converter for [`EventPayload`](./Oxide.Ext.Discord/Entities/EventPayload.md) |
| class [HashListConverter&lt;TValue&gt;](./Oxide.Ext.Discord/Json/HashListConverter%7BTValue%7D.md) | Converts to and from a list in JSON to a hash |
| class [MessageComponentsConverter](./Oxide.Ext.Discord/Json/MessageComponentsConverter.md) | Converter for a list of message components |
| class [PermissionFlagsStringConverter](./Oxide.Ext.Discord/Json/PermissionFlagsStringConverter.md) | Converts Permission Flags to and from a JSON string |
| class [RoleTagsConverter](./Oxide.Ext.Discord/Json/RoleTagsConverter.md) | Handles converting [`RoleTags`](./Oxide.Ext.Discord/Entities/RoleTags.md) This type contains special deserialization types |
| class [SnowflakeConverter](./Oxide.Ext.Discord/Json/SnowflakeConverter.md) | Converts a snowflake to and from its JSON string value |
| class [TemplateComponentsConverter](./Oxide.Ext.Discord/Json/TemplateComponentsConverter.md) | Converter for a list of message components |
| class [TemplateKeyConverter](./Oxide.Ext.Discord/Json/TemplateKeyConverter.md) | JSON Template Key Converter |
| class [UnixDateTimeConverter](./Oxide.Ext.Discord/Json/UnixDateTimeConverter.md) | Converts a DateTimeOffset to and from a json long |

## Oxide.Ext.Discord.Libraries namespace

| public type | description |
| --- | --- |
| class [AppCommandKeys](./Oxide.Ext.Discord/Libraries/AppCommandKeys.md) | Placeholder Keys for [`DiscordApplicationCommand`](./Oxide.Ext.Discord/Entities/DiscordApplicationCommand.md) |
| static class [ApplicationCommandPlaceholders](./Oxide.Ext.Discord/Libraries/ApplicationCommandPlaceholders.md) | [`DiscordApplicationCommand`](./Oxide.Ext.Discord/Entities/DiscordApplicationCommand.md) placeholders |
| class [ArgumentLocalization](./Oxide.Ext.Discord/Libraries/ArgumentLocalization.md) | Localization for Application Command Arguments |
| abstract class [BaseComponentTemplate](./Oxide.Ext.Discord/Libraries/BaseComponentTemplate.md) | Base Template for Message Components |
| abstract class [BaseDiscordLibrary](./Oxide.Ext.Discord/Libraries/BaseDiscordLibrary.md) | Represents the base class for Discord Libraries |
| abstract class [BaseDiscordLibrary&lt;TLibrary&gt;](./Oxide.Ext.Discord/Libraries/BaseDiscordLibrary%7BTLibrary%7D.md) | Base Discord Library for Oxide Libraries |
| abstract class [BaseMessageTemplateLibrary&lt;TTemplate&gt;](./Oxide.Ext.Discord/Libraries/BaseMessageTemplateLibrary%7BTTemplate%7D.md) | Library for Discord Message templates |
| abstract class [BaseTemplateLibrary&lt;TTemplate&gt;](./Oxide.Ext.Discord/Libraries/BaseTemplateLibrary%7BTTemplate%7D.md) | Oxide Library for Discord Templates |
| class [BulkTemplateRegistration&lt;T&gt;](./Oxide.Ext.Discord/Libraries/BulkTemplateRegistration%7BT%7D.md) | Used for bulk template registration |
| class [ButtonTemplate](./Oxide.Ext.Discord/Libraries/ButtonTemplate.md) | Template for Button Components |
| class [ChannelKeys](./Oxide.Ext.Discord/Libraries/ChannelKeys.md) | Placeholder Keys for [`DiscordChannel`](./Oxide.Ext.Discord/Entities/DiscordChannel.md) |
| static class [ChannelPlaceholders](./Oxide.Ext.Discord/Libraries/ChannelPlaceholders.md) | [`DiscordChannel`](./Oxide.Ext.Discord/Entities/DiscordChannel.md) Placeholders |
| class [ChoicesLocalization](./Oxide.Ext.Discord/Libraries/ChoicesLocalization.md) | Localization for Select Menu Choices |
| class [CommandLocalization](./Oxide.Ext.Discord/Libraries/CommandLocalization.md) | Localization for Application Commands |
| class [DateTimeKeys](./Oxide.Ext.Discord/Libraries/DateTimeKeys.md) | Placeholder Keys for DateTime |
| static class [DateTimePlaceholders](./Oxide.Ext.Discord/Libraries/DateTimePlaceholders.md) | DateTime placeholders |
| static class [DefaultKeys](./Oxide.Ext.Discord/Libraries/DefaultKeys.md) | Default Discord Extension provided Placeholder Keys |
| class [DiscordAppCommand](./Oxide.Ext.Discord/Libraries/DiscordAppCommand.md) | Application Command Oxide Library handler Routes Application Commands to their respective hook method handlers instead of having to manually handle it. |
| class [DiscordAutoCompleteChoiceTemplate](./Oxide.Ext.Discord/Libraries/DiscordAutoCompleteChoiceTemplate.md) | Template for Discord Auto Completes |
| class [DiscordAutoCompleteChoiceTemplates](./Oxide.Ext.Discord/Libraries/DiscordAutoCompleteChoiceTemplates.md) | Auto Complete Choice Templates Library |
| class [DiscordButtonTemplates](./Oxide.Ext.Discord/Libraries/DiscordButtonTemplates.md) | Button Templates Library |
| class [DiscordChannelSubscription](./Oxide.Ext.Discord/Libraries/DiscordChannelSubscription.md) | Represents a channel subscription for a plugin |
| class [DiscordCommand](./Oxide.Ext.Discord/Libraries/DiscordCommand.md) | Represents a library for discord commands |
| class [DiscordCommandLocalization](./Oxide.Ext.Discord/Libraries/DiscordCommandLocalization.md) | Command Localizations for Application Commands |
| class [DiscordCommandLocalizations](./Oxide.Ext.Discord/Libraries/DiscordCommandLocalizations.md) | Library for localizing [`DiscordApplicationCommand`](./Oxide.Ext.Discord/Entities/DiscordApplicationCommand.md)s |
| class [DiscordEmbedFieldTemplate](./Oxide.Ext.Discord/Libraries/DiscordEmbedFieldTemplate.md) | Discord Template for Embed Field |
| class [DiscordEmbedFieldTemplates](./Oxide.Ext.Discord/Libraries/DiscordEmbedFieldTemplates.md) | Embed Field Templates Library |
| class [DiscordEmbedTemplate](./Oxide.Ext.Discord/Libraries/DiscordEmbedTemplate.md) | Discord Template for embed |
| class [DiscordEmbedTemplates](./Oxide.Ext.Discord/Libraries/DiscordEmbedTemplates.md) | Embed Templates Library |
| class [DiscordInputTextTemplates](./Oxide.Ext.Discord/Libraries/DiscordInputTextTemplates.md) | InputText Templates Library |
| class [DiscordLink](./Oxide.Ext.Discord/Libraries/DiscordLink.md) | Represents a library for discord linking |
| struct [DiscordLocale](./Oxide.Ext.Discord/Libraries/DiscordLocale.md) | Represents a Locale in Discord |
| class [DiscordLocales](./Oxide.Ext.Discord/Libraries/DiscordLocales.md) | Converts discord locale codes into oxide locale codes |
| class [DiscordMessageTemplate](./Oxide.Ext.Discord/Libraries/DiscordMessageTemplate.md) | Discord Message Template for sending localized Discord Messages |
| class [DiscordMessageTemplates](./Oxide.Ext.Discord/Libraries/DiscordMessageTemplates.md) | Modal Templates Library |
| class [DiscordModalTemplate](./Oxide.Ext.Discord/Libraries/DiscordModalTemplate.md) | Template used for Modal Message Component |
| class [DiscordModalTemplates](./Oxide.Ext.Discord/Libraries/DiscordModalTemplates.md) | Modal Templates Library |
| class [DiscordPlaceholders](./Oxide.Ext.Discord/Libraries/DiscordPlaceholders.md) | Discord Placeholders Library |
| class [DiscordPool](./Oxide.Ext.Discord/Libraries/DiscordPool.md) | Discord Pool Library |
| class [DiscordSelectMenuTemplates](./Oxide.Ext.Discord/Libraries/DiscordSelectMenuTemplates.md) | InputText Templates Library |
| class [DiscordSubscriptions](./Oxide.Ext.Discord/Libraries/DiscordSubscriptions.md) | Represents Discord Subscriptions Oxide Library Allows for plugins to subscribe to discord channels |
| class [EmbedFooterTemplate](./Oxide.Ext.Discord/Libraries/EmbedFooterTemplate.md) | Discord Template for Embed Footer |
| class [EmojiTemplate](./Oxide.Ext.Discord/Libraries/EmojiTemplate.md) | Discord Template for Emoji |
| class [GuildKeys](./Oxide.Ext.Discord/Libraries/GuildKeys.md) | Placeholder Keys for [`DiscordGuild`](./Oxide.Ext.Discord/Entities/DiscordGuild.md) |
| static class [GuildPlaceholders](./Oxide.Ext.Discord/Libraries/GuildPlaceholders.md) | [`DiscordGuild`](./Oxide.Ext.Discord/Entities/DiscordGuild.md) placeholders |
| interface [IDiscordLink](./Oxide.Ext.Discord/Libraries/IDiscordLink.md) | Represents a plugin that supports Discord Link library |
| class [InputTextTemplate](./Oxide.Ext.Discord/Libraries/InputTextTemplate.md) | Input Text Message Component Template |
| class [InteractionKeys](./Oxide.Ext.Discord/Libraries/InteractionKeys.md) | Placeholder Keys for [`DiscordInteraction`](./Oxide.Ext.Discord/Entities/DiscordInteraction.md) |
| static class [InteractionPlaceholders](./Oxide.Ext.Discord/Libraries/InteractionPlaceholders.md) | [`DiscordInteraction`](./Oxide.Ext.Discord/Entities/DiscordInteraction.md) placeholders |
| class [IpKeys](./Oxide.Ext.Discord/Libraries/IpKeys.md) | Placeholder Keys for [`IpPlaceholders`](./Oxide.Ext.Discord/Libraries/IpPlaceholders.md) |
| static class [IpPlaceholders](./Oxide.Ext.Discord/Libraries/IpPlaceholders.md) | IP Address Placeholders |
| class [MemberKeys](./Oxide.Ext.Discord/Libraries/MemberKeys.md) | Placeholder Keys for [`GuildMember`](./Oxide.Ext.Discord/Entities/GuildMember.md) |
| static class [MemberPlaceholders](./Oxide.Ext.Discord/Libraries/MemberPlaceholders.md) | [`GuildMember`](./Oxide.Ext.Discord/Entities/GuildMember.md) placeholders |
| class [MessageKeys](./Oxide.Ext.Discord/Libraries/MessageKeys.md) | Placeholder Keys for [`DiscordMessage`](./Oxide.Ext.Discord/Entities/DiscordMessage.md) |
| static class [MessagePlaceholders](./Oxide.Ext.Discord/Libraries/MessagePlaceholders.md) | [`DiscordMessage`](./Oxide.Ext.Discord/Entities/DiscordMessage.md) placeholders |
| class [PlaceholderData](./Oxide.Ext.Discord/Libraries/PlaceholderData.md) | Placeholder Data for placeholders |
| struct [PlaceholderDataKey](./Oxide.Ext.Discord/Libraries/PlaceholderDataKey.md) | Represents a Placeholder Data Key This is the key used to store a value into Placeholder Data |
| struct [PlaceholderKey](./Oxide.Ext.Discord/Libraries/PlaceholderKey.md) | Represents a Placeholder Key. This is the key for placeholder usage and lookup |
| class [PlaceholderState](./Oxide.Ext.Discord/Libraries/PlaceholderState.md) | Represents the current state for a matched placeholder |
| struct [PlayerId](./Oxide.Ext.Discord/Libraries/PlayerId.md) | Represents a [`DiscordLink`](./Oxide.Ext.Discord/Libraries/DiscordLink.md) Player ID |
| class [PlayerKeys](./Oxide.Ext.Discord/Libraries/PlayerKeys.md) | Placeholder Keys for IPlayer |
| static class [PlayerPlaceholders](./Oxide.Ext.Discord/Libraries/PlayerPlaceholders.md) | IPlayer placeholders |
| class [PluginKeys](./Oxide.Ext.Discord/Libraries/PluginKeys.md) | Placeholder Keys for Plugin |
| static class [PluginPlaceholders](./Oxide.Ext.Discord/Libraries/PluginPlaceholders.md) | Plugin placeholders |
| class [ResponseErrorKeys](./Oxide.Ext.Discord/Libraries/ResponseErrorKeys.md) | Placeholder Keys for [`ResponseError`](./Oxide.Ext.Discord/Entities/ResponseError.md) |
| static class [ResponseErrorPlaceholders](./Oxide.Ext.Discord/Libraries/ResponseErrorPlaceholders.md) | [`ResponseError`](./Oxide.Ext.Discord/Entities/ResponseError.md) placeholders |
| class [RoleKeys](./Oxide.Ext.Discord/Libraries/RoleKeys.md) | Placeholder Keys for [`DiscordRole`](./Oxide.Ext.Discord/Entities/DiscordRole.md) |
| static class [RolePlaceholders](./Oxide.Ext.Discord/Libraries/RolePlaceholders.md) | [`DiscordRole`](./Oxide.Ext.Discord/Entities/DiscordRole.md) placeholders |
| class [SelectMenuOptionTemplate](./Oxide.Ext.Discord/Libraries/SelectMenuOptionTemplate.md) | Template for Select Menu Options |
| class [SelectMenuTemplate](./Oxide.Ext.Discord/Libraries/SelectMenuTemplate.md) | Represents a template for select menus |
| class [ServerKeys](./Oxide.Ext.Discord/Libraries/ServerKeys.md) | Placeholder Keys for IServer |
| struct [ServerLocale](./Oxide.Ext.Discord/Libraries/ServerLocale.md) | Represents a Server Locale |
| static class [ServerPlaceholders](./Oxide.Ext.Discord/Libraries/ServerPlaceholders.md) | IServer placeholders |
| class [SnowflakeKeys](./Oxide.Ext.Discord/Libraries/SnowflakeKeys.md) | Placeholder Keys for [`Snowflake`](./Oxide.Ext.Discord/Entities/Snowflake.md) |
| static class [SnowflakePlaceholders](./Oxide.Ext.Discord/Libraries/SnowflakePlaceholders.md) | [`Snowflake`](./Oxide.Ext.Discord/Entities/Snowflake.md) placeholders |
| struct [TemplateKey](./Oxide.Ext.Discord/Libraries/TemplateKey.md) | Represents a Template Key. This is the key for template lookup |
| enum [TemplateType](./Oxide.Ext.Discord/Libraries/TemplateType.md) | Represents available template type |
| struct [TemplateVersion](./Oxide.Ext.Discord/Libraries/TemplateVersion.md) | Version of a specific template |
| class [TimespanKeys](./Oxide.Ext.Discord/Libraries/TimespanKeys.md) | Placeholder Keys for TimeSpan |
| static class [TimeSpanPlaceholders](./Oxide.Ext.Discord/Libraries/TimeSpanPlaceholders.md) | TimeSpan placeholders |
| class [TimestampKeys](./Oxide.Ext.Discord/Libraries/TimestampKeys.md) | Placeholder Keys for Int64 |
| static class [TimestampPlaceholders](./Oxide.Ext.Discord/Libraries/TimestampPlaceholders.md) | Timestamp placeholders |
| class [UserKeys](./Oxide.Ext.Discord/Libraries/UserKeys.md) | Placeholder Keys for [`DiscordUser`](./Oxide.Ext.Discord/Entities/DiscordUser.md) |
| static class [UserPlaceholders](./Oxide.Ext.Discord/Libraries/UserPlaceholders.md) | [`DiscordUser`](./Oxide.Ext.Discord/Entities/DiscordUser.md) placeholders |

## Oxide.Ext.Discord.Logging namespace

| public type | description |
| --- | --- |
| class [DebugLogger](./Oxide.Ext.Discord/Logging/DebugLogger.md) | Debug Logger used for logging debug information |
| class [DiscordLogger](./Oxide.Ext.Discord/Logging/DiscordLogger.md) | Represents a discord extension logger |
| class [DiscordLoggerFactory](./Oxide.Ext.Discord/Logging/DiscordLoggerFactory.md) | Factory for creating DiscordLoggers |
| enum [DiscordLogLevel](./Oxide.Ext.Discord/Logging/DiscordLogLevel.md) | Represents the log level for a logger |
| static class [LoggerExt](./Oxide.Ext.Discord/Logging/LoggerExt.md) |  |

## Oxide.Ext.Discord.Plugins namespace

| public type | description |
| --- | --- |
| struct [PluginId](./Oxide.Ext.Discord/Plugins/PluginId.md) | Represents a Plugin ID |
| class [PluginSetup](./Oxide.Ext.Discord/Plugins/PluginSetup.md) | Build Discord Extension Setup Data for a plugin |

## Oxide.Ext.Discord.Rest namespace

| public type | description |
| --- | --- |
| abstract class [BaseRequest](./Oxide.Ext.Discord/Rest/BaseRequest.md) | Represents a base request class for REST API calls |
| class [Bucket](./Oxide.Ext.Discord/Rest/Bucket.md) | Contains bucket information for a REST API Bucket |
| struct [BucketId](./Oxide.Ext.Discord/Rest/BucketId.md) | Represents an ID for a bucket |
| class [Request](./Oxide.Ext.Discord/Rest/Request.md) | Represents a Request that does not return data |
| class [Request&lt;T&gt;](./Oxide.Ext.Discord/Rest/Request%7BT%7D.md) | Represents a REST API request that returns {T} data |
| enum [RequestCompletedStatus](./Oxide.Ext.Discord/Rest/RequestCompletedStatus.md) | Represents the completed status for the request |
| class [RequestHandler](./Oxide.Ext.Discord/Rest/RequestHandler.md) | Represent a Discord API request |
| struct [RequestOptions](./Oxide.Ext.Discord/Rest/RequestOptions.md) | Options the the REST request |
| enum [RequestStatus](./Oxide.Ext.Discord/Rest/RequestStatus.md) | Discord API Request Status |
| class [RestHandler](./Oxide.Ext.Discord/Rest/RestHandler.md) | Represents a REST handler for a bot |

## Oxide.Ext.Discord.Types namespace

| public type | description |
| --- | --- |
| abstract class [BasePool&lt;TPooled,TPool&gt;](./Oxide.Ext.Discord/Types/BasePool%7BTPooled,TPool%7D.md) | Represents a BasePool in Discord |
| abstract class [BasePoolable](./Oxide.Ext.Discord/Types/BasePoolable.md) | Represents a poolable object |
| class [BasePromise](./Oxide.Ext.Discord/Types/BasePromise.md) | Represents the base class for all promises |
| abstract class [BaseRateLimit](./Oxide.Ext.Discord/Types/BaseRateLimit.md) | Represents a base rate limit for websocket and rest api requests |
| class [DiscordPluginPool](./Oxide.Ext.Discord/Types/DiscordPluginPool.md) | Built in pooling for discord entities |
| class [DiscordStreamContent](./Oxide.Ext.Discord/Types/DiscordStreamContent.md) | Stream content that is sent over HTTP This is used because StreamContent disposes the underlying stream when disposed and we don't want that since we cache our stream |
| interface [IPool](./Oxide.Ext.Discord/Types/IPool.md) | Represents a pool |
| interface [IPool&lt;T&gt;](./Oxide.Ext.Discord/Types/IPool%7BT%7D.md) | Represents a pool of type T |
| class [PoolSettings](./Oxide.Ext.Discord/Types/PoolSettings.md) | Settings for the pools |
| struct [PoolSize](./Oxide.Ext.Discord/Types/PoolSize.md) | Represents size constraints for a pool |
| class [Promise](./Oxide.Ext.Discord/Types/Promise.md) | Implements a non-generic C# promise; this is a promise that simply resolves without delivering a value. https://developer.mozilla.org/en/docs/Web/JavaScript/Reference/Global_Objects/Promise |
| class [Promise&lt;TPromised&gt;](./Oxide.Ext.Discord/Types/Promise%7BTPromised%7D.md) | Implements a C# promise. https://developer.mozilla.org/en/docs/Web/JavaScript/Reference/Global_Objects/Promise |
| enum [PromiseState](./Oxide.Ext.Discord/Types/PromiseState.md) | Specifies the state of a promise. |
| struct [RejectHandler](./Oxide.Ext.Discord/Types/RejectHandler.md) | Represents a handler invoked when the promise is rejected. |
| class [RestRateLimit](./Oxide.Ext.Discord/Types/RestRateLimit.md) | Represents a rate limit for rest requests |
| abstract class [Singleton&lt;T&gt;](./Oxide.Ext.Discord/Types/Singleton%7BT%7D.md) | Represents a singleton of type {T} |
| class [UkkonenTrie&lt;T&gt;](./Oxide.Ext.Discord/Types/UkkonenTrie%7BT%7D.md) | A Ukkonen Suffix Trie |
| struct [ValueStringBuilder](./Oxide.Ext.Discord/Types/ValueStringBuilder.md) | A non-heap-allocation allocating string builder |
| class [WebsocketRateLimit](./Oxide.Ext.Discord/Types/WebsocketRateLimit.md) | Represents a WebSocket Rate Limit |

## Oxide.Ext.Discord.WebSockets namespace

| public type | description |
| --- | --- |
| enum [DiscordDispatchCode](./Oxide.Ext.Discord/WebSockets/DiscordDispatchCode.md) | Represents the [Gateway Event Codes](https://discord.com/developers/docs/topics/gateway#commands-and-events-gateway-events) |
| class [DiscordHeartbeatHandler](./Oxide.Ext.Discord/WebSockets/DiscordHeartbeatHandler.md) | Handles the heartbeating for the websocket connection |
| class [DiscordWebSocket](./Oxide.Ext.Discord/WebSockets/DiscordWebSocket.md) | Represents a websocket that connects to discord |
| enum [DiscordWebsocketCloseCode](./Oxide.Ext.Discord/WebSockets/DiscordWebsocketCloseCode.md) | Represents [Socket Close Event Codes](https://discord.com/developers/docs/topics/opcodes-and-status-codes#gateway-gateway-close-event-codes) |
| enum [SocketState](./Oxide.Ext.Discord/WebSockets/SocketState.md) | Represents our current state for the websocket |
| class [WebSocketCommandHandler](./Oxide.Ext.Discord/WebSockets/WebSocketCommandHandler.md) | Handles command queueing when the websocket is down |
| class [WebSocketEventHandler](./Oxide.Ext.Discord/WebSockets/WebSocketEventHandler.md) | Handles websocket events |

<!-- DO NOT EDIT: generated by xmldocmd for Oxide.Ext.Discord.dll -->
