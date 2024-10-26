using Oxide.Core.Plugins;
using Oxide.Ext.Discord.Configuration;
using Oxide.Ext.Discord.Data.Ip;
using Oxide.Ext.Discord.Plugins;
using Oxide.Plugins;

namespace Oxide.Ext.Discord.Libraries
{
    /// <summary>
    /// IP Address Placeholders
    /// </summary>
    public static class IpPlaceholders
    {
        private static readonly Hash<string, string> FlagCache = new();
        
        /// <summary>
        /// IP Country Name placeholder 
        /// </summary>
        public static string CountryName(string ip) => DiscordIpData.Instance.GetCountryName(ip);

        /// <summary>
        /// IP Country Code placeholder 
        /// </summary>
        public static string CountryCode(string ip) => DiscordIpData.Instance.GetCountryCode(ip);
        
        /// <summary>
        /// IP Country Emoji placeholder 
        /// </summary>
        public static string CountryEmoji(string ip)
        {
            string country = CountryCode(ip) ?? string.Empty;
            if (FlagCache.TryGetValue(country, out string flag))
            {
                return flag;
            }

            flag = !string.IsNullOrEmpty(country) ? $":flag_{country}:" : DiscordConfig.Instance.Ip.UnknownCountryEmoji;
            FlagCache[country] = flag;
            return flag;
        }

        internal static void RegisterPlaceholders()
        {
            RegisterPlaceholders(DiscordExtensionCore.Instance, DefaultKeys.Ip, new PlaceholderDataKey("ip"));
        }
        
        /// <summary>
        /// Registers placeholders for the given plugin. 
        /// </summary>
        /// <param name="plugin">Plugin to register placeholders for</param>
        /// <param name="keys">Prefix to use for the placeholders</param>
        /// <param name="dataKey">Data key in <see cref="PlaceholderData"/></param>
        public static void RegisterPlaceholders(Plugin plugin, IpKeys keys, PlaceholderDataKey dataKey)
        {
            DiscordPlaceholders placeholders = DiscordPlaceholders.Instance;
            placeholders.RegisterPlaceholder<string>(plugin, keys.Ip, dataKey);
            placeholders.RegisterPlaceholder<string, string>(plugin, keys.CountryName, dataKey, CountryName);
            placeholders.RegisterPlaceholder<string, string>(plugin, keys.CountryCode, dataKey, CountryCode);
            placeholders.RegisterPlaceholder<string, string>(plugin, keys.CountryEmoji, dataKey, CountryEmoji);
        }
    }
}