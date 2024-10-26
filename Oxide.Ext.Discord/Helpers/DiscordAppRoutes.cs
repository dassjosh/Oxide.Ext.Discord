using System;
using Oxide.Ext.Discord.Interfaces;

namespace Oxide.Ext.Discord.Helpers
{
    /// <summary>
    /// Discord App Routes for navigating the client within the discord app using links
    /// Sourced from: https://gist.github.com/ghostrider-05/8f1a0bfc27c7c4509b4ea4e8ce718af0
    /// </summary>
    public static class DiscordAppRoutes
    {
        private const string BaseUrl = "discord://-";

        /// <summary>
        /// User App Route
        /// </summary>
        public static string User(IDiscordKey userId) => $"{BaseUrl}/users/{userId.ToString()}";

        /// <summary>
        /// Message Requests App Route
        /// </summary>
        public const string MessageRequests = BaseUrl + "/message-requests";
        
        /// <summary>
        /// General App Routes
        /// </summary>
        public static class General
        {
            /// <summary>
            /// Apps App Route
            /// </summary>
            public const string Apps = BaseUrl + "/apps";
            
            /// <summary>
            /// Guild Discovery App Route
            /// </summary>
            public const string GuildDiscovery = BaseUrl + "/guild-discovery";
            
            /// <summary>
            /// Create Guild App Route
            /// </summary>
            public const string CreateGuild = BaseUrl + "/guilds/create";

            /// <summary>
            /// Gift App Route
            /// </summary>
            public static string Gift(string code) => $"{BaseUrl}/gifts/{code}";
            
            /// <summary>
            /// Server Invite App Route
            /// </summary>
            public static string ServerInvite(string code) => $"{BaseUrl}/invite/{code}";

            /// <summary>
            /// App Settings Page Routes
            /// </summary>
            /// <exception cref="ArgumentOutOfRangeException"></exception>
            public static string Settings(SettingsPage page)
            {
                string path = page switch
                {
                    SettingsPage.Account => "account",
                    SettingsPage.ProfileCustomization => "profile-customization",
                    SettingsPage.PrivacyAndSafety => "privacy-and-safety",
                    SettingsPage.AuthorizedApps => "authorized-apps",
                    SettingsPage.Connections => "connections",
                    SettingsPage.Premium => "premium",
                    SettingsPage.PremiumGuildSubscriptions => "premium-guild-subscription",
                    SettingsPage.Subscriptions => "subscriptions",
                    SettingsPage.Inventory => "inventory",
                    SettingsPage.Billing => "billing",
                    SettingsPage.Appearance => "appearance",
                    SettingsPage.Accessibility => "accessibility",
                    SettingsPage.Voice => "voice",
                    SettingsPage.Text => "text",
                    SettingsPage.Notifications => "notifications",
                    SettingsPage.Keybinds => "keybinds",
                    SettingsPage.Locale => "locale",
                    SettingsPage.Windows => "windows",
                    SettingsPage.Linux => "linux",
                    SettingsPage.StreamerMode => "streamer-mode",
                    SettingsPage.Advanced => "advanced",
                    SettingsPage.ActivityStatus => "activity-status",
                    SettingsPage.Overlay => "overlay",
                    SettingsPage.HypesquadOnline => "hypesquad-online",
                    SettingsPage.Changelogs => "changelogs",
                    SettingsPage.Experiments => "experiments",
                    SettingsPage.DeveloperOptions => "developer-options",
                    SettingsPage.HotspotOptions => "hotspot-options",
                    SettingsPage.DismissibleContentOptions => "dismissible-content-options",
                    SettingsPage.FamilyCenter => "family-center",
                    SettingsPage.Sessions => "sessions",
                    SettingsPage.FriendRequests => "friend-requests",
                    SettingsPage.RegisteredGames => "registered-games",
                    _ => throw new ArgumentOutOfRangeException(nameof(page), page, null)
                };

                return $"{BaseUrl}/{path}";
            }
        }

        /// <summary>
        /// DM App routes
        /// </summary>
        public static class DMs
        {
            /// <summary>
            /// DM Channel App Route
            /// </summary>
            public static string Channel(IDiscordKey channelId) => $"{BaseUrl}/channels/@me/{channelId.ToString()}";
            
            /// <summary>
            /// DM Message App Route
            /// </summary>
            public static string Message(IDiscordKey channelId, IDiscordKey messageId) => $"{BaseUrl}/channels/@me/{channelId.ToString()}/{messageId.ToString()}";
        }

        /// <summary>
        /// Guild App Routes
        /// </summary>
        public static class Guilds
        {
            /// <summary>
            /// Favorite Channels App Route
            /// </summary>
            public const string Favorites = BaseUrl + "/channels/@favorites";
            
            /// <summary>
            /// Favorites Channel App Route
            /// </summary>
            public static string FavoritesChannel(IDiscordKey channelId) => $"{BaseUrl}/channels/@favorites/{channelId.ToString()}";
            
            /// <summary>
            /// Guild App Route
            /// </summary>
            public static string Guild(IDiscordKey guildId) => $"{BaseUrl}/channels/{guildId.ToString()}";
            
            /// <summary>
            /// Guild Channel App Route
            /// </summary>
            public static string Channel(IDiscordKey guildId, IDiscordKey channelId) => $"{BaseUrl}/channels/{guildId.ToString()}/{channelId.ToString()}";
            
            /// <summary>
            /// Browse Guild Channels App Route
            /// </summary>
            public static string BrowseChannel(IDiscordKey guildId) => $"{BaseUrl}/channels/{guildId.ToString()}/channel-browser";
            
            /// <summary>
            /// Server Guide App Route
            /// </summary>
            public static string ServerGuide(IDiscordKey guildId) => $"{BaseUrl}/channels/{guildId.ToString()}/@home";
            
            /// <summary>
            /// Event App Route
            /// </summary>
            public static string Event(IDiscordKey guildId, IDiscordKey eventId) => $"{BaseUrl}/events/{guildId.ToString()}/{eventId}";
            
            /// <summary>
            /// Message App Route
            /// </summary>
            public static string Message(IDiscordKey guildId, IDiscordKey channelId, IDiscordKey messageId) => $"{BaseUrl}/channels/{guildId.ToString()}/{channelId.ToString()}/{messageId.ToString()}";
            
            /// <summary>
            /// Membership Screening App Route
            /// </summary>
            public static string MembershipScreening(IDiscordKey guildId) => $"{BaseUrl}/member-verification/{guildId.ToString()}";
            
            /// <summary>
            /// Role Subscriptions App Route
            /// </summary>
            public static string RoleSubscriptions(IDiscordKey guildId) => $"{BaseUrl}/guild-role-subscriptions/{guildId.ToString()}";
        }
    }
}