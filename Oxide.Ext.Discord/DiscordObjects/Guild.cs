using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using uMod.Ext.Discord.REST;

namespace uMod.Ext.Discord.DiscordObjects
{
    public class Guild
    {
        public string id { get; set; }

        public string name { get; set; }

        public string icon { get; set; }

        public string splash { get; set; }

        public string discovery_splash { get; set; }

        public bool owner { get; set; }

        public string owner_id { get; set; }

        public int? permissions { get; set; }

        public string region { get; set; }

        public string afk_channel_id { get; set; }

        public int? afk_timeout { get; set; }

        public bool? embed_enabled { get; set; }

        public string embed_channel_id { get; set; }

        public GuildVerificationLevel? verification_level { get; set; }

        public int? default_message_notifications { get; set; }

        public int? explicit_content_filter { get; set; }

        public List<Role> roles { get; set; } = new List<Role>();

        public List<Emoji> emojis { get; set; }

        public List<string> features { get; set; }

        public GuildMFALevel? mfa_level { get; set; }

        public string application_id { get; set; }

        public bool? widget_enabled { get; set; }

        public string widget_channel_id { get; set; }

        public string system_channel_id { get; set; }

        public string rules_channel_id { get; set; }

        public string joined_at { get; set; }

        public bool? large { get; set; }

        public bool? unavailable { get; set; }

        public int? member_count { get; set; }

        public List<VoiceState> voice_states { get; set; }

        public List<GuildMember> members { get; set; } = new List<GuildMember>();

        public List<Channel> channels { get; set; } = new List<Channel>();

        public List<Presence> presences { get; set; }

        public int? max_presences { get; set; }

        public int? max_members { get; set; }

        public string vanity_url_code { get; set; }

        public string description { get; set; }

        public string banner { get; set; }

        public GuildPremiumTier? premium_tier { get; set; }

        public int? premium_subscription_count { get; set; }

        public string preferred_locale { get; set; }

        public string public_updates_channel_id { get; set; }

        public static void CreateGuild(DiscordClient client, string name, string region, string icon, GuildVerificationLevel? verificationLevel, int? defaultMessageNotifications, List<Role> roles, List<Channel> channels, Action<Guild> callback = null)
        {
            var jsonObj = new Dictionary<string, object>()
            {
                { "name", name },
                { "region", region },
                { "icon", icon },
                { "verification_level", verificationLevel },
                { "default_message_notifications", defaultMessageNotifications },
                { "roles", roles },
                { "channels", channels }
            };

            client.REST.DoRequest($"/guilds", RequestMethod.POST, jsonObj, callback);
        }

        public static void GetGuild(DiscordClient client, string guildID, Action<Guild> callback = null)
        {
            client.REST.DoRequest($"/guilds/{guildID}", RequestMethod.GET, null, callback);
        }

        public void ModifyGuild(DiscordClient client, Action<Guild> callback = null)
        {
            client.REST.DoRequest($"/guilds/{id}", RequestMethod.PATCH, this, callback);
        }

        public void DeleteGuild(DiscordClient client, Action callback = null)
        {
            client.REST.DoRequest($"/guilds/{id}", RequestMethod.DELETE, null, callback);
        }

        public void GetGuildChannels(DiscordClient client, Action<List<Channel>> callback = null)
        {
            client.REST.DoRequest($"/guilds/{id}/channels", RequestMethod.GET, null, callback);
        }

        public void CreateGuildChannel(DiscordClient client, Channel channel, Action<Channel> callback = null) => CreateGuildChannel(client, channel.name, channel.type, channel.bitrate, channel.user_limit, channel.permission_overwrites, channel.parent_id, callback);

        public void CreateGuildChannel(DiscordClient client, string name, ChannelType? type, int? bitrate, int? userLimit, List<Overwrite> permissionOverwrites, string parent_id, Action<Channel> callback = null)
        {
            var jsonObj = new Dictionary<string, object>()
            {
                { "name", name },
                { "type", type },
                { "bitrate", bitrate },
                { "user_limit", userLimit },
                { "permission_overwrites", permissionOverwrites },
                { "parent_id", parent_id }
            };

            client.REST.DoRequest($"/guilds/{id}/channels", RequestMethod.POST, jsonObj, callback);
        }

        public void ModifyGuildChannelPositions(DiscordClient client, List<ObjectPosition> positions, Action callback = null)
        {
            client.REST.DoRequest($"/guilds/{id}/channels", RequestMethod.PATCH, positions, callback);
        }

        public void GetGuildMember(DiscordClient client, string userID, Action<GuildMember> callback = null)
        {
            client.REST.DoRequest($"/guilds/{id}/members/{userID}", RequestMethod.GET, null, callback);
        }

        public void ListGuildMembers(DiscordClient client, Action<List<GuildMember>> callback = null)
        {
            client.REST.DoRequest($"/guilds/{id}/members?limit=1000", RequestMethod.GET, null, callback);
        }

        public void AddGuildMember(DiscordClient client, GuildMember member, string accessToken, List<Role> roles, Action<GuildMember> callback = null) => this.AddGuildMember(client, member.user.id, accessToken, member.nick, roles, member.mute, member.deaf, callback);

        public void AddGuildMember(DiscordClient client, string userID, string accessToken, string nick, List<Role> roles, bool mute, bool deaf, Action<GuildMember> callback = null)
        {
            var jsonObj = new Dictionary<string, object>()
            {
                { "access_token", accessToken },
                { "nick", nick },
                { "roles", roles },
                { "mute", mute },
                { "deaf", deaf }
            };

            client.REST.DoRequest($"/guilds/{id}/members/{userID}", RequestMethod.PUT, jsonObj, callback);
        }

        public void ModifyGuildMember(DiscordClient client, GuildMember member, List<string> roles, string channelId, Action callback = null) => this.ModifyGuildMember(client, member.user.id, member.nick, roles, member.deaf, member.mute, channelId, callback);

        public void ModifyGuildMember(DiscordClient client, string userID, string nick, List<string> roles, bool mute, bool deaf, string channelId, Action callback = null)
        {
            var jsonObj = new Dictionary<string, object>()
            {
                { "nick", nick },
                { "roles", roles },
                { "mute", mute },
                { "deaf", deaf },
                { "channel_id", channelId }
            };

            client.REST.DoRequest($"/guilds/{id}/members/{userID}", RequestMethod.PATCH, jsonObj, callback);
        }

        public void ModifyUsersNick(DiscordClient client, string userID, string nick, Action callback = null)
        {
            var jsonObj = new Dictionary<string, object>()
            {
                { "nick", nick }
            };

            client.REST.DoRequest($"/guilds/{id}/members/{userID}", RequestMethod.PATCH, jsonObj, callback);
        }

        public void ModifyCurrentUsersNick(DiscordClient client, string nick, Action<string> callback = null)
        {
            var jsonObj = new Dictionary<string, object>()
            {
                { "nick", nick }
            };

            client.REST.DoRequest($"/guilds/{id}/members/@me/nick", RequestMethod.PATCH, jsonObj, callback);
        }

        public void AddGuildMemberRole(DiscordClient client, User user, Role role, Action callback = null) => AddGuildMemberRole(client, user.id, role.id, callback);

        public void AddGuildMemberRole(DiscordClient client, string userID, string roleID, Action callback = null)
        {
            client.REST.DoRequest($"/guilds/{id}/members/{userID}/roles/{roleID}", RequestMethod.PUT, null, callback);
        }

        public void RemoveGuildMemberRole(DiscordClient client, User user, Role role, Action callback = null) => RemoveGuildMemberRole(client, user.id, role.id, callback);

        public void RemoveGuildMemberRole(DiscordClient client, string userID, string roleID, Action callback = null)
        {
            client.REST.DoRequest($"/guilds/{id}/members/{userID}/roles/{roleID}", RequestMethod.DELETE, null, callback);
        }

        public void RemoveGuildMember(DiscordClient client, GuildMember member, Action callback = null) => RemoveGuildMember(client, member.user.id, callback);

        public void RemoveGuildMember(DiscordClient client, string userID, Action callback = null)
        {
            client.REST.DoRequest($"/guilds/{id}/members/{userID}", RequestMethod.DELETE, null, callback);
        }

        public void GetGuildBans(DiscordClient client, Action<List<Ban>> callback = null)
        {
            client.REST.DoRequest($"/guilds/{id}/bans", RequestMethod.GET, null, callback);
        }

        public void CreateGuildBan(DiscordClient client, GuildMember member, int? deleteMessageDays, Action callback = null) => CreateGuildBan(client, member.user.id, deleteMessageDays, callback);

        public void CreateGuildBan(DiscordClient client, string userID, int? deleteMessageDays, Action callback = null)
        {
            var jsonObj = new Dictionary<string, object>()
            {
                { "delete-message-days", deleteMessageDays }
            };

            client.REST.DoRequest($"/guilds/{id}/bans/{userID}", RequestMethod.PUT, jsonObj, callback);
        }

        public void RemoveGuildBan(DiscordClient client, string userID, Action callback = null)
        {
            client.REST.DoRequest($"/guilds/{id}/bans/{userID}", RequestMethod.DELETE, null, callback);
        }

        public void GetGuildRoles(DiscordClient client, Action<List<Role>> callback = null)
        {
            client.REST.DoRequest<List<Role>>($"/guilds/{id}/roles", RequestMethod.GET, null, (returnValue) =>
            {
                callback?.Invoke(returnValue as List<Role>);
            });
        }

        public void CreateGuildRole(DiscordClient client, Role role, Action<Role> callback = null)
        {
            client.REST.DoRequest<Role>($"/guilds/{id}/roles", RequestMethod.POST, role, callback);
        }

        public void ModifyGuildRolePositions(DiscordClient client, List<ObjectPosition> positions, Action<List<Role>> callback = null)
        {
            client.REST.DoRequest<List<Role>>($"/guilds/{id}/roles", RequestMethod.PATCH, positions, callback);
        }

        public void ModifyGuildRole(DiscordClient client, Role role, Action<Role> callback = null) => ModifyGuildRole(client, role.id, role, callback);

        public void ModifyGuildRole(DiscordClient client, string roleID, Role role, Action<Role> callback = null)
        {
            client.REST.DoRequest<Role>($"/guilds/{id}/roles/{roleID}", RequestMethod.PATCH, role, (returnValue) =>
            {
                callback?.Invoke(returnValue as Role);
            });
        }

        public void DeleteGuildRole(DiscordClient client, Role role, Action callback = null) => DeleteGuildRole(client, role.id, callback);

        public void DeleteGuildRole(DiscordClient client, string roleID, Action callback = null)
        {
            client.REST.DoRequest($"/guilds/{id}/roles/{roleID}", RequestMethod.DELETE, null, callback);
        }

        public void GetGuildPruneCount(DiscordClient client, int? days, Action<int?> callback = null)
        {
            client.REST.DoRequest<JObject>($"/guilds/{id}/prune?days={days}", RequestMethod.GET, null, (returnValue) =>
            {
                var pruned = returnValue.GetValue("pruned").ToObject<int?>();

                callback?.Invoke(pruned);
            });
        }

        public void BeginGuildPrune(DiscordClient client, int? days, Action<int?> callback = null)
        {
            client.REST.DoRequest<JObject>($"/guilds/{id}/prune?days={days}", RequestMethod.POST, null, (returnValue) =>
            {
                var pruned = returnValue.GetValue("pruned").ToObject<int?>();

                callback?.Invoke(pruned);
            });
        }

        public void GetGuildVoiceRegions(DiscordClient client, Action<List<VoiceRegion>> callback = null)
        {
            client.REST.DoRequest($"/guilds/{id}/regions", RequestMethod.GET, null, callback);
        }

        public void GetGuildInvites(DiscordClient client, Action<List<Invite>> callback = null)
        {
            client.REST.DoRequest($"/guilds/{id}/invites", RequestMethod.GET, null, callback);
        }

        public void GetGuildIntegrations(DiscordClient client, Action<List<Integration>> callback = null)
        {
            client.REST.DoRequest($"/guilds/{id}/integrations", RequestMethod.GET, null, callback);
        }

        public void CreateGuildIntegration(DiscordClient client, Integration integration, Action callback = null) => CreateGuildIntegration(client, integration.type, integration.id, callback);

        public void CreateGuildIntegration(DiscordClient client, string type, string id, Action callback = null)
        {
            var jsonObj = new Dictionary<string, object>()
            {
                { "type", type },
                { "id", id }
            };

            client.REST.DoRequest($"/guilds/{id}/integrations", RequestMethod.POST, jsonObj, callback);
        }

        public void ModifyGuildIntegration(DiscordClient client, Integration integration, bool? enableEmoticons, Action callback = null) => ModifyGuildIntegration(client, integration.id, integration.expire_behaviour, integration.expire_grace_peroid, enableEmoticons, callback);

        public void ModifyGuildIntegration(DiscordClient client, string integrationID, int? expireBehaviour, int? expireGracePeroid, bool? enableEmoticons, Action callback = null)
        {
            var jsonObj = new Dictionary<string, object>()
            {
                { "expire_behaviour", expireBehaviour },
                { "expire_grace_peroid", expireGracePeroid },
                { "enable_emoticons", enableEmoticons }
            };

            client.REST.DoRequest($"/guilds/{id}/integrations/{integrationID}", RequestMethod.PATCH, jsonObj, callback);
        }

        public void DeleteGuildIntegration(DiscordClient client, Integration integration, Action callback = null) => DeleteGuildIntegration(client, integration.id, callback);

        public void DeleteGuildIntegration(DiscordClient client, string integrationID, Action callback = null)
        {
            client.REST.DoRequest($"/guilds/{id}/integrations/{integrationID}", RequestMethod.DELETE, null, callback);
        }

        public void SyncGuildIntegration(DiscordClient client, Integration integration, Action callback = null) => SyncGuildIntegration(client, integration.id, callback);

        public void SyncGuildIntegration(DiscordClient client, string integrationID, Action callback = null)
        {
            client.REST.DoRequest($"/guilds/{id}/integrations/{integrationID}/sync", RequestMethod.POST, null, callback);
        }

        public void GetGuildEmbed(DiscordClient client, Action<GuildEmbed> callback = null)
        {
            client.REST.DoRequest($"/guilds/{id}/embed", RequestMethod.GET, null, callback);
        }

        public void ModifyGuildEmbed(DiscordClient client, GuildEmbed guildEmbed, Action<GuildEmbed> callback = null)
        {
            client.REST.DoRequest($"/guilds/{id}/embed", RequestMethod.PATCH, guildEmbed, callback);
        }

        public void GetGuildVanityURL(DiscordClient client, Action<Invite> callback = null)
        {
            client.REST.DoRequest($"/guilds/{id}/vanity-url", RequestMethod.GET, null, callback);
        }

        public void Update(Guild UpdatedGuild)
        {
            if (UpdatedGuild.name != null)
                this.name = UpdatedGuild.name;
            if (UpdatedGuild.icon != null)
                this.icon = UpdatedGuild.icon;
            if (UpdatedGuild.splash != null)
                this.splash = UpdatedGuild.splash;
            if (UpdatedGuild.owner_id != null)
                this.owner_id = UpdatedGuild.owner_id;
            if (UpdatedGuild.region != null)
                this.region = UpdatedGuild.region;
            if (UpdatedGuild.afk_channel_id != null)
                this.afk_channel_id = UpdatedGuild.afk_channel_id;
            if (UpdatedGuild.afk_timeout != null)
                this.afk_timeout = UpdatedGuild.afk_timeout;
            if (UpdatedGuild.embed_enabled != null)
                this.embed_enabled = UpdatedGuild.embed_enabled;
            if (UpdatedGuild.embed_channel_id != null)
                this.embed_channel_id = UpdatedGuild.embed_channel_id;
            if (UpdatedGuild.verification_level != null)
                this.verification_level = UpdatedGuild.verification_level;
            if (UpdatedGuild.default_message_notifications != null)
                this.default_message_notifications = UpdatedGuild.default_message_notifications;
            if (UpdatedGuild.explicit_content_filter != null)
                this.explicit_content_filter = UpdatedGuild.explicit_content_filter;
            if (UpdatedGuild.roles != null)
                this.roles = UpdatedGuild.roles;
            if (UpdatedGuild.emojis != null)
                this.emojis = UpdatedGuild.emojis;
            if (UpdatedGuild.features != null)
                this.features = UpdatedGuild.features;
            if (UpdatedGuild.mfa_level != null)
                this.mfa_level = UpdatedGuild.mfa_level;
            if (UpdatedGuild.application_id != null)
                this.application_id = UpdatedGuild.application_id;
            if (UpdatedGuild.widget_enabled != null)
                this.widget_enabled = UpdatedGuild.widget_enabled;
            if (UpdatedGuild.widget_channel_id != null)
                this.widget_channel_id = UpdatedGuild.widget_channel_id;
            if (UpdatedGuild.system_channel_id != null)
                this.system_channel_id = UpdatedGuild.system_channel_id;
            if (UpdatedGuild.joined_at != null)
                this.joined_at = UpdatedGuild.joined_at;
            if (UpdatedGuild.large != null)
                this.large = UpdatedGuild.large;
            if (UpdatedGuild.unavailable != null)
                this.unavailable = UpdatedGuild.unavailable;
            if (UpdatedGuild.member_count != null)
                this.member_count = UpdatedGuild.member_count;
            if (UpdatedGuild.voice_states != null)
                this.voice_states = UpdatedGuild.voice_states;
            if (UpdatedGuild.members != null)
                this.members = UpdatedGuild.members;
            if (UpdatedGuild.channels != null)
                this.channels = UpdatedGuild.channels;
            if (UpdatedGuild.presences != null)
                this.presences = UpdatedGuild.presences;
            if (UpdatedGuild.max_presences != null)
                this.max_presences = UpdatedGuild.max_presences;
            if (UpdatedGuild.max_members != null)
                this.max_members = UpdatedGuild.max_members;
            if (UpdatedGuild.vanity_url_code != null)
                this.vanity_url_code = UpdatedGuild.vanity_url_code;
            if (UpdatedGuild.description != null)
                this.description = UpdatedGuild.description;
            if (UpdatedGuild.banner != null)
                this.banner = UpdatedGuild.banner;
            if (UpdatedGuild.premium_tier != null)
                this.premium_tier = UpdatedGuild.premium_tier;
            if (UpdatedGuild.premium_subscription_count != null)
                this.premium_subscription_count = UpdatedGuild.premium_subscription_count;
        }
    }
}
