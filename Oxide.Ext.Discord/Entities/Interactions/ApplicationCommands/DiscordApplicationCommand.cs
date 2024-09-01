using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Oxide.Ext.Discord.Cache;
using Oxide.Ext.Discord.Clients;
using Oxide.Ext.Discord.Exceptions;
using Oxide.Ext.Discord.Helpers;
using Oxide.Ext.Discord.Interfaces;
using Oxide.Ext.Discord.Types;
using Oxide.Plugins;

namespace Oxide.Ext.Discord.Entities;

/// <summary>
/// Represents <a href="https://discord.com/developers/docs/interactions/application-commands#application-command-object-application-command-structure">ApplicationCommand</a>
/// </summary>
[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
public class DiscordApplicationCommand
{
    /// <summary>
    /// Unique id of the command
    /// </summary>
    [JsonProperty("id")]
    public Snowflake Id { get; set; }
        
    /// <summary>
    /// The type of command, defaults to 1
    /// </summary>
    [JsonProperty("type")]
    public ApplicationCommandType? Type { get; set; }
        
    /// <summary>
    /// ID of the parent application
    /// </summary>
    [JsonProperty("application_id")]
    public Snowflake ApplicationId { get; set; }
        
    /// <summary>
    /// Guild ID of the command, if not global
    /// </summary>
    [JsonProperty("guild_id")]
    public Snowflake? GuildId { get; set; }
        
    /// <summary>
    /// 1-32 lowercase character name matching ^[\w-]{1,32}$
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; }
        
    /// <summary>
    /// Localization dictionary for the name field. Values follow the same restrictions as name
    /// </summary>
    [JsonProperty("name_localizations")]
    public Hash<string, string> NameLocalizations { get; set; }
        
    /// <summary>
    /// Description of the command (1-100 characters)
    /// </summary>
    [JsonProperty("description")]
    public string Description { get; set; }
        
    /// <summary>
    /// Localization dictionary for the description field. Values follow the same restrictions as description
    /// </summary>
    [JsonProperty("description_localizations")]
    public Hash<string, string> DescriptionLocalizations { get; set; }
        
    /// <summary>
    /// The parameters for the command
    /// See <see cref="CommandOption"/>
    /// </summary>
    [JsonProperty("options")]
    public List<CommandOption> Options { get; set; }

    [JsonProperty("default_member_permissions")]
    private string _defaultMemberPermissions;

    /// <summary>
    /// Set of permissions represented as a bit set
    /// </summary>
    public PermissionFlags DefaultMemberPermissions
    {
        get => !string.IsNullOrEmpty(_defaultMemberPermissions) ? (PermissionFlags)ulong.Parse(_defaultMemberPermissions) : default;
        set => _defaultMemberPermissions = StringCache<ulong>.Instance.ToString((ulong)value);
    }
        
    /// <summary>
    /// Indicates whether the command is available in DMs with the app, only for globally-scoped commands. By default, commands are visible.
    /// </summary>
    [JsonProperty("dm_permission")]
    public bool? DmPermission { get; set; }

    /// <summary>
    /// Indicates whether the command is age-restricted
    /// </summary>
    [JsonProperty("nsfw")]
    public bool? Nsfw { get; set; }
        
    /// <summary>
    /// Installation context(s) where the command is available, only for globally-scoped commands.
    /// Defaults to GUILD_INSTALL (0)
    /// </summary>
    [JsonProperty("integration_types")]
    public List<ApplicationIntegrationType> IntegrationTypes { get; set; }
        
    /// <summary>
    /// Interaction context(s) where the command can be used, only for globally-scoped commands.
    /// By default, all interaction context types included for new commands..
    /// </summary>
    [JsonProperty("contexts")]
    public List<InteractionContextTypes> Contexts { get; set; }
        
    /// <summary>
    /// Auto incrementing version identifier updated during substantial record changes
    /// </summary>
    [JsonProperty("version")]
    public Snowflake Version { get; set; }
    
    /// <summary>
    /// Determines whether the interaction is handled by the app's interactions handler or by Discord
    /// </summary>
    [JsonProperty("handler")]
    public ApplicationCommandHandlerType Handler { get; set; }

    /// <summary>
    /// Mention the <see cref="DiscordApplicationCommand"/>
    /// </summary>
    public string Mention => DiscordFormatting.MentionApplicationCommand(Id, Name);

    /// <summary>
    /// Mention the <see cref="DiscordApplicationCommand"/> using a custom command string
    /// </summary>
    /// <param name="command">Custom commands string</param>
    /// <returns>Mentioned Custom Command string</returns>
    public string MentionCustom(string command) => DiscordFormatting.MentionApplicationCommandCustom(Id, command);
        
    /// <summary>
    /// Edit a command.
    /// Updates will be available in all guilds after 1 hour.
    /// See <a href="https://discord.com/developers/docs/interactions/application-commands#edit-global-application-command">Edit Global Application Command</a>
    /// See <a href="https://discord.com/developers/docs/interactions/application-commands#edit-guild-application-command">Edit Guild Application Command</a>
    /// </summary>
    /// <param name="client">Client to use</param>
    /// <param name="update">Command Update</param>
    public IPromise<DiscordApplicationCommand> Edit(DiscordClient client, CommandUpdate update)
    {
        if (update == null) throw new ArgumentNullException(nameof(update));
        if (GuildId.HasValue)
        {
            return client.Bot.Rest.Patch<DiscordApplicationCommand>(client,$"applications/{ApplicationId}/guilds/{GuildId}/commands/{Id}", update);
        }
            
        return client.Bot.Rest.Patch<DiscordApplicationCommand>(client,$"applications/{ApplicationId}/commands/{Id}", update);
    }
        
    /// <summary>
    /// Deletes a command
    /// See <a href="https://discord.com/developers/docs/interactions/application-commands#delete-global-application-command">Delete Global Application Command</a>
    /// See <a href="https://discord.com/developers/docs/interactions/application-commands#delete-guild-application-command">Delete Guild Application Command</a>
    /// </summary>
    /// <param name="client">Client to use</param>
    public IPromise Delete(DiscordClient client)
    {
        if (GuildId.HasValue)
        {
            return client.Bot.Rest.Delete(client,$"applications/{ApplicationId}/guilds/{GuildId}/commands/{Id}");
        }
            
        return client.Bot.Rest.Delete(client,$"applications/{ApplicationId}/commands/{Id}");
    }

    /// <summary>
    /// Fetches command permissions for a specific command for your application in a guild. Returns a <see cref="GuildCommandPermissions"/> object.
    /// See <a href="https://discord.com/developers/docs/interactions/application-commands#get-application-command-permissions">Get Application Command Permissions</a>
    /// </summary>
    /// <param name="client">Client to use</param>
    /// <param name="guildId">Guild ID of the guild to get permissions for</param>
    public IPromise<GuildCommandPermissions> GetPermissions(DiscordClient client, Snowflake guildId)
    {
        InvalidSnowflakeException.ThrowIfInvalid(guildId);
        IPendingPromise<GuildCommandPermissions> promise = Promise<GuildCommandPermissions>.Create();

        client.Bot.Rest.Get<GuildCommandPermissions>(client, $"applications/{ApplicationId}/guilds/{guildId}/commands/{Id}/permissions")
            .Then(perms => promise.Resolve(perms))
            .Catch<ResponseError>(ex =>
            {
                if (ex.DiscordError?.Code != 10066)
                {
                    promise.Reject(ex);
                    return;
                }
                      
                ex.SuppressErrorMessage();
                //If the command is synced we need to lookup by application ID instead
                client.Bot.Rest.Get<GuildCommandPermissions>(client, $"applications/{ApplicationId}/guilds/{guildId}/commands/{ApplicationId}/permissions")
                    .Then(perms => promise.Resolve(perms))
                    .Catch<ResponseError>(ex1 => promise.Reject(ex1));
            });
        return promise;
    }

    /// <summary>
    /// Edits command permissions for a specific command for your application in a guild.
    /// Warning: This endpoint will overwrite existing permissions for the command in that guild
    /// Warning: Deleting or renaming a command will permanently delete all permissions for that command
    /// See <a href="https://discord.com/developers/docs/interactions/application-commands#edit-application-command-permissions">Edit Application Command Permissions</a>
    /// </summary>
    /// <param name="client">Client to use</param>
    /// <param name="guildId">Guild ID of the guild to edit permissions for</param>
    /// <param name="permissions">List of permissions for the command</param>
    public IPromise EditPermissions(DiscordClient client, Snowflake guildId, CommandUpdatePermissions permissions)
    {
        InvalidSnowflakeException.ThrowIfInvalid(guildId);
        return client.Bot.Rest.Put(client,$"applications/{ApplicationId}/guilds/{guildId}/commands/{Id}/permissions", permissions);
    }
}