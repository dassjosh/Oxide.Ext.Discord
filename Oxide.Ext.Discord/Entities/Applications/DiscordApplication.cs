using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Oxide.Ext.Discord.Clients;
using Oxide.Ext.Discord.Exceptions;
using Oxide.Ext.Discord.Helpers;
using Oxide.Ext.Discord.Interfaces;
using Oxide.Ext.Discord.Logging;
using Oxide.Ext.Discord.Types;
using Oxide.Plugins;

namespace Oxide.Ext.Discord.Entities;

/// <summary>
/// Represents <a href="https://discord.com/developers/docs/resources/application#application-object">Application Structure</a>
/// </summary>
[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
public class DiscordApplication : IDebugLoggable
{
    /// <summary>
    /// ID of the app
    /// </summary>
    [JsonProperty("id")]
    public Snowflake Id { get; set; }
        
    /// <summary>
    /// Name of the app
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; }
        
    /// <summary>
    /// Icon hash of the app
    /// </summary>
    [JsonProperty("icon")]
    public string Icon { get; set; }
        
    /// <summary>
    /// Description of the app
    /// </summary>
    [JsonProperty("description")]
    public string Description { get; set; }
        
    /// <summary>
    /// List of RPC origin URLs, if RPC is enabled
    /// </summary>
    [JsonProperty("rpc_origins")]
    public List<string> RpcOrigins { get; set; }
        
    /// <summary>
    /// When false only app owner can join the app's bot to guilds
    /// </summary>
    [JsonProperty("bot_public")]
    public bool BotPublic { get; set; }
        
    /// <summary>
    /// When true the app's bot will only join upon completion of the full oauth2 code grant flow
    /// </summary>
    [JsonProperty("bot_require_code_grant")]
    public bool BotRequireCodeGrant { get; set; }
        
    /// <summary>
    /// Partial user object for the bot user associated with the app
    /// </summary>
    [JsonProperty("bot")]
    public DiscordUser Bot { get; set; }
        
    /// <summary>
    /// URL of the app's terms of service
    /// </summary>
    [JsonProperty("terms_of_service_url")]
    public string TermsOfServiceUrl { get; set; }
        
    /// <summary>
    /// URL of the app's privacy policy
    /// </summary>
    [JsonProperty("privacy_policy_url")]
    public string PrivacyPolicyUrl { get; set; }
        
    /// <summary>
    /// Partial user object containing info on the owner of the application
    /// </summary>
    [JsonProperty("owner")]
    public DiscordUser Owner { get; set; }

    /// <summary>
    /// Hex encoded key for verification in interactions and the GameSDK's GetTicket
    /// </summary>
    [JsonProperty("verify_key")]
    public string Verify { get; set; }
        
    /// <summary>
    /// If the application belongs to a team, this will be a list of the members of that team
    /// </summary>
    [JsonProperty("team")]
    public DiscordTeam Team { get; set; }

    /// <summary>
    /// Guild associated with the app. For example, a developer support server.
    /// </summary>
    [JsonProperty("guild_id")]
    public Snowflake? GuildId { get; set; }
        
    /// <summary>
    /// Partial Guild for the application
    /// </summary>
    [JsonProperty("guild")]
    public DiscordGuild Guild { get; set; }
        
    /// <summary>
    /// If this application is a game sold on Discord, this field will be the id of the "Game SKU" that is created, if exists
    /// </summary>
    [JsonProperty("primary_sku_id")]
    public string PrimarySkuId { get; set; }
        
    /// <summary>
    /// If this application is a game sold on Discord, this field will be the URL slug that links to the store page
    /// </summary>
    [JsonProperty("slug")]
    public string Slug { get; set; }
        
    /// <summary>
    /// If this application is a game sold on Discord, this field will be the hash of the image on store embeds
    /// </summary>
    [JsonProperty("cover_image")]
    public string CoverImage { get; set; } 
        
    /// <summary>
    /// App's public flags
    /// </summary>
    [JsonProperty("flags")]
    public ApplicationFlags? Flags { get; set; }
        
    /// <summary>
    /// An approximate count of the app's guild membership.
    /// </summary>
    [JsonProperty("approximate_guild_count")]
    public int? ApproximateGuildCount { get; set; } 
    
    /// <summary>
    /// Approximate count of users that have installed the app
    /// </summary>
    [JsonProperty("approximate_user_install_count")]
    public int? ApproximateUserInstallCount { get; set; }
                
    /// <summary>
    /// Array of redirect URIs for the app
    /// </summary>
    [JsonProperty("redirect_uris")]
    public List<string> RedirectUris { get; set; } 
        
    /// <summary>
    /// Interactions endpoint URL for the app
    /// </summary>
    [JsonProperty("interactions_endpoint_url")]
    public string InteractionsEndpointUrl { get; set; } 
        
    /// <summary>
    /// Role connection verification URL for the app
    /// </summary>
    [JsonProperty("role_connections_verification_url")]
    public string RoleConnectionsVerificationUrl { get; set; } 
        
    /// <summary>
    /// Up to 5 tags describing the content and functionality of the application
    /// </summary>
    [JsonProperty("tags")]
    public List<string> Tags { get; set; } 
        
    /// <summary>
    /// Settings for the application's default in-app authorization link, if enabled
    /// </summary>
    [JsonProperty("install_params")]
    public InstallParams InstallParams { get; set; } 
        
    /// <summary>
    /// Default scopes and permissions for each supported installation context
    /// </summary>
    [JsonProperty("integration_types_config")]
    public Hash<ApplicationIntegrationType, ApplicationIntegrationTypeConfiguration> IntegrationTypesConfig { get; set; }
        
    /// <summary>
    /// The application's default custom authorization link, if enabled
    /// </summary>
    [JsonProperty("custom_install_url")]
    public string CustomInstallUrl { get; set; } 

    /// <summary>
    /// Returns the URL for the applications Icon
    /// </summary>
    public string GetApplicationIconUrl => DiscordCdn.GetApplicationIconUrl(Id, Icon);
        
    /// <summary>
    /// Returns the URL for the application cover
    /// </summary>
    public string GetApplicationCoverUrl => DiscordCdn.GetApplicationIconUrl(Id, CoverImage);
        
    /// <summary>
    /// Returns if the given application has the passed in application flag
    /// If <see cref="Flags"/> is null false is returned
    /// </summary>
    /// <param name="flag">Flag to compare against</param>
    /// <returns>True of application has flag; False Otherwise</returns>
    public bool HasApplicationFlag(ApplicationFlags flag)
    {
        return Flags.HasValue && (Flags.Value & flag) == flag;
    }
        
    /// <summary>
    /// Returns if the given application has any of the passed in application flags
    /// If <see cref="Flags"/> is null false is returned
    /// </summary>
    /// <param name="flag">Flag to compare against</param>
    /// <returns>True of application has flag; False Otherwise</returns>
    public bool HasAnyApplicationFlags(ApplicationFlags flag)
    {
        return Flags.HasValue && (Flags.Value & flag) != 0;
    }

    /// <summary>
    /// Returns the current users application
    /// See <a href="">Get Current Application</a>
    /// </summary>
    public static IPromise<DiscordApplication> Get(DiscordClient client)
    {
        return client.Bot.Rest.Get<DiscordApplication>(client,"applications/@me");
    }

    /// <summary>
    /// Edit properties of the app associated with the requesting bot user. Only properties that are passed will be updated.
    /// </summary>
    /// <param name="client">Client to use</param>
    /// <param name="update">Update to apply</param>
    public IPromise<DiscordApplication> Edit(DiscordClient client, ApplicationUpdate update)
    {
        return client.Bot.Rest.Patch<DiscordApplication>(client, "applications/@me", update);
    }
        
    /// <summary>
    /// Fetch all of the global commands for your application.
    /// Returns a list of ApplicationCommand.
    /// See <a href="https://discord.com/developers/docs/interactions/application-commands#get-global-application-commands">Get Global Application Commands</a>
    /// <param name="client">Client to use</param>
    /// <param name="withLocalizations">Include Command Localizations</param>
    /// </summary>
    public IPromise<List<DiscordApplicationCommand>> GetGlobalCommands(DiscordClient client, bool withLocalizations = false)
    {
        return client.Bot.Rest.Get<List<DiscordApplicationCommand>>(client,$"applications/{Id}/commands?with_localizations={withLocalizations}");
    }

    /// <summary>
    /// Fetch global command by ID
    /// See <a href="https://discord.com/developers/docs/interactions/application-commands#get-global-application-command">Get Global Application Command</a>
    /// </summary>
    /// <param name="client">Client to use</param>
    /// <param name="commandId">ID of command to get</param>
    public IPromise<DiscordApplicationCommand> GetGlobalCommand(DiscordClient client, Snowflake commandId)
    {
        InvalidSnowflakeException.ThrowIfInvalid(commandId);
        return client.Bot.Rest.Get<DiscordApplicationCommand>(client,$"applications/{Id}/commands/{commandId}");
    }
        
    /// <summary>
    /// Create a new global command.
    /// New global commands will be available in all guilds after 1 hour.
    /// Note: Creating a command with the same name as an existing command for your application will overwrite the old command.
    /// See <a href="https://discord.com/developers/docs/interactions/application-commands#create-global-application-command">Create Global Application Command</a>
    /// </summary>
    /// <param name="client">Client to use</param>
    /// <param name="create">Command to create</param>
    public IPromise<DiscordApplicationCommand> CreateGlobalCommand(DiscordClient client, CommandCreate create)
    {
        if (create == null) throw new ArgumentNullException(nameof(create));
        return client.Bot.Rest.Post<DiscordApplicationCommand>(client,$"applications/{Id}/commands", create);
    }

    /// <summary>
    /// Takes a list of application commands, overwriting existing commands that are registered globally for this application. Updates will be available in all guilds after 1 hour.
    /// See <a href="https://discord.com/developers/docs/interactions/application-commands#bulk-overwrite-global-application-commands">Bulk Overwrite Global Application Commands</a>
    /// </summary>
    /// <param name="client">Client to use</param>
    /// <param name="commands">List of commands to overwrite</param>
    public IPromise<List<DiscordApplicationCommand>> BulkOverwriteGlobalCommands(DiscordClient client, List<CommandBulkOverwrite> commands)
    {
        if (commands == null) throw new ArgumentNullException(nameof(commands));
        return client.Bot.Rest.Put<List<DiscordApplicationCommand>>(client,$"applications/{Id}/commands", commands);
    }

    /// <summary>
    /// Fetch all of the guild commands for your application for a specific guild.
    /// See <a href="https://discord.com/developers/docs/interactions/application-commands#get-guild-application-commands">Get Guild Application Commands</a>
    /// </summary>
    /// <param name="client">Client to use</param>
    /// <param name="guildId">ID of the guild to get commands for</param>
    /// <param name="withLocalizations">Include Command Localizations</param>
    public IPromise<List<DiscordApplicationCommand>> GetGuildCommands(DiscordClient client, Snowflake guildId, bool withLocalizations = false)
    {
        InvalidSnowflakeException.ThrowIfInvalid(guildId);
        return client.Bot.Rest.Get<List<DiscordApplicationCommand>>(client,$"applications/{Id}/guilds/{guildId}/commands?with_localizations={withLocalizations}");
    }

    /// <summary>
    /// Get guild command by Id
    /// See <a href="https://discord.com/developers/docs/interactions/application-commands#get-guild-application-command">Get Guild Application Command</a>
    /// </summary>
    /// <param name="client">Client to use</param>
    /// <param name="guildId">ID of the guild to get commands for</param>
    /// <param name="commandId">ID of the command to get</param>
    public IPromise<DiscordApplicationCommand> GetGuildCommand(DiscordClient client, Snowflake guildId, Snowflake commandId)
    {
        InvalidSnowflakeException.ThrowIfInvalid(guildId);
        InvalidSnowflakeException.ThrowIfInvalid(commandId);
        return client.Bot.Rest.Get<DiscordApplicationCommand>(client,$"applications/{Id}/guilds/{guildId}/commands/{commandId}");
    }

    /// <summary>
    /// Create a new guild command.
    /// New guild commands will be available in the guild immediately.
    /// See <a href="https://discord.com/developers/docs/interactions/application-commands#create-guild-application-command">Create Guild Application Command</a>
    /// </summary>
    /// <param name="client">Client to use</param>
    /// <param name="guildId">Guild ID to create the command in</param>
    /// <param name="create">Command to create</param>
    public IPromise<DiscordApplicationCommand> CreateGuildCommand(DiscordClient client, Snowflake guildId, CommandCreate create)
    {
        if (create == null) throw new ArgumentNullException(nameof(create));
        InvalidSnowflakeException.ThrowIfInvalid(guildId);
        return client.Bot.Rest.Post<DiscordApplicationCommand>(client,$"applications/{Id}/guilds/{guildId}/commands", create);
    }

    /// <summary>
    /// Fetches command permissions for all commands for your application in a guild. Returns an array of GuildApplicationCommandPermissions objects.
    /// See <a href="https://discord.com/developers/docs/interactions/application-commands#get-guild-application-command-permissions">Get Guild Application Command Permissions</a>
    /// </summary>
    /// <param name="client">Client to use</param>
    /// <param name="guildId">Guild ID to get the permissions from</param>
    public IPromise<List<GuildCommandPermissions>> GetGuildCommandPermissions(DiscordClient client, Snowflake guildId)
    {
        InvalidSnowflakeException.ThrowIfInvalid(guildId);
        return client.Bot.Rest.Get<List<GuildCommandPermissions>>(client,$"applications/{Id}/guilds/{guildId}/commands/permissions");
    }

    /// <summary>
    /// Returns all commands registered to this application
    /// </summary>
    /// <param name="client">Client to use</param>
    /// <param name="withLocalizations">Should the response include localizations</param>
    public IPromise<List<DiscordApplicationCommand>> GetAllCommands(DiscordClient client, bool withLocalizations = false)
    {
        List<IPromise<List<DiscordApplicationCommand>>> requests =
        [
            GetGlobalCommands(client, withLocalizations)
        ];
        requests.AddRange(client.Bot.Servers.Keys.Select(id => GetGuildCommands(client, id, withLocalizations)));

        return Promise<List<DiscordApplicationCommand>>.All(requests)
            .Then(commands => commands
                .SelectMany(c => c).ToList());
    }
        
    /// <summary>
    /// Returns a list of application role connection metadata objects for the given application.
    /// See <a href="https://discord.com/developers/docs/resources/application-role-connection-metadata#get-application-role-connection-metadata-records">Get Application Role Connection Metadata Records</a>
    /// </summary>
    /// <param name="client">Client to use</param>
    public IPromise<List<ApplicationRoleConnectionMetadata>> GetRoleConnectionMetadata(DiscordClient client)
    {
        return client.Bot.Rest.Get<List<ApplicationRoleConnectionMetadata>>(client,$"applications/{Id}/role-connections/metadata");
    }

    /// <summary>
    /// Updates and returns a list of application role connection metadata objects for the given application.
    /// See <a href="https://discord.com/developers/docs/resources/application-role-connection-metadata#update-application-role-connection-metadata-records">Update Application Role Connection Metadata Records</a>
    /// </summary>
    /// <param name="client">Client to use</param>
    /// <param name="records">The records to update on the application</param>
    public IPromise<List<ApplicationRoleConnectionMetadata>> EditRoleConnectionMetadata(DiscordClient client, List<ApplicationRoleConnectionMetadata> records)
    {
        DiscordApplicationException.ThrowIfInvalidApplicationRoleConnectionMetadataLength(records);
        return client.Bot.Rest.Put<List<ApplicationRoleConnectionMetadata>>(client,$"applications/{Id}/role-connections/metadata", records);
    }

    /// <summary>
    /// Returns the list of all application emojis
    /// </summary>
    /// <param name="client">Client to use</param>
    public IPromise<ApplicationEmojis> GetApplicationEmojis(DiscordClient client)
    {
        return client.Bot.Rest.Get<ApplicationEmojis>(client, $"applications/{Id}/emojis");
    }

    /// <summary>
    /// Return an application emoji by ID
    /// </summary>
    /// <param name="client">Client to use</param>
    /// <param name="emojiId">ID of the emoji</param>
    public IPromise<DiscordEmoji> GetApplicationEmoji(DiscordClient client, Snowflake emojiId)
    {
        InvalidSnowflakeException.ThrowIfInvalid(emojiId);
        return client.Bot.Rest.Get<DiscordEmoji>(client, $"applications/{Id}/emojis/{emojiId}");
    }

    /// <summary>
    /// Creates a new application emoji
    /// </summary>
    /// <param name="client">Client to use</param>
    /// <param name="create">Emoji to create</param>
    public IPromise<DiscordEmoji> CreateApplicationEmoji(DiscordClient client, ApplicationEmojiCreate create)
    {
        return client.Bot.Rest.Post<DiscordEmoji>(client, $"applications/{Id}/emojis", create);
    }

    /// <summary>
    /// Updates an existing application emoji
    /// </summary>
    /// <param name="client">Client to use</param>
    /// <param name="emojiId">ID of the emoji to update</param>
    /// <param name="update">Update to the application emoji</param>
    public IPromise<DiscordEmoji> UpdateApplicationEmoji(DiscordClient client, Snowflake emojiId, ApplicationEmojiUpdate update)
    {
        InvalidSnowflakeException.ThrowIfInvalid(emojiId);
        return client.Bot.Rest.Patch<DiscordEmoji>(client, $"applications/{Id}/emojis/{emojiId}", update);
    }
        
    /// <summary>
    /// Deletes an application emoji
    /// </summary>
    /// <param name="client">Client to use</param>
    /// <param name="emojiId">ID of the emoji to delete</param>
    public IPromise DeleteApplicationEmoji(DiscordClient client, Snowflake emojiId)
    {
        InvalidSnowflakeException.ThrowIfInvalid(emojiId);
        return client.Bot.Rest.Delete(client, $"applications/{Id}/emojis/{emojiId}");
    }

    ///<inheritdoc/>
    public void LogDebug(DebugLogger logger)
    {
        logger.AppendField("ID", Id);
        logger.AppendField("Name", Name);
        logger.AppendFieldEnum("Flags", Flags ?? ApplicationFlags.None);
    }
}