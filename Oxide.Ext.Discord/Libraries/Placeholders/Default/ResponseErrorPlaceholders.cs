using Oxide.Core.Plugins;
using Oxide.Ext.Discord.Entities;
using Oxide.Ext.Discord.Plugins;

namespace Oxide.Ext.Discord.Libraries
{
    /// <summary>
    /// <see cref="ResponseError"/> placeholders
    /// </summary>
    public static class ResponseErrorPlaceholders
    {
        /// <summary>
        /// <see cref="ResponseError.HttpStatusCode"/> placeholder
        /// </summary>
        public static DiscordHttpStatusCode HttpCode(ResponseError error) => error.HttpStatusCode;
        
        /// <summary>
        /// <see cref="ResponseError.ResponseMessage"/> placeholder
        /// </summary>
        public static string Message(ResponseError error) => error.DiscordError?.Message ?? error.ResponseMessage;

        internal static void RegisterPlaceholders()
        {
            RegisterPlaceholders(DiscordExtensionCore.Instance, DefaultKeys.ResponseError, new PlaceholderDataKey(nameof(ResponseError)));
        }
        
        /// <summary>
        /// Registers placeholders for the given plugin. 
        /// </summary>
        /// <param name="plugin">Plugin to register placeholders for</param>
        /// <param name="keys">Prefix to use for the placeholders</param>
        /// <param name="dataKey">Data key in <see cref="PlaceholderData"/></param>
        public static void RegisterPlaceholders(Plugin plugin, ResponseErrorKeys keys, PlaceholderDataKey dataKey)
        {
            DiscordPlaceholders placeholders = DiscordPlaceholders.Instance;
            placeholders.RegisterPlaceholder<ResponseError, DiscordHttpStatusCode>(plugin, keys.Code, dataKey, HttpCode);
            placeholders.RegisterPlaceholder<ResponseError, string>(plugin, keys.Message, dataKey, Message);
        }
    }
}