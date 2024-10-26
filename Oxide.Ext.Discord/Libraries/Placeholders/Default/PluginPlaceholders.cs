using System;
using Oxide.Core.Libraries.Covalence;
using Oxide.Core.Plugins;
using Oxide.Ext.Discord.Cache;
using Oxide.Ext.Discord.Extensions;
using Oxide.Ext.Discord.Plugins;

namespace Oxide.Ext.Discord.Libraries
{
    /// <summary>
    /// <see cref="Plugin"/> placeholders
    /// </summary>
    public static class PluginPlaceholders
    {
        /// <summary>
        /// <see cref="Plugin.Name"/> placeholder
        /// </summary>
        public static string Name(Plugin plugin) => plugin.Name;
        
        /// <summary>
        /// <see cref="Plugin.Title"/> placeholder
        /// </summary>
        public static string Title(Plugin plugin) => plugin.Title;
        
        /// <summary>
        /// <see cref="Plugin.Author"/> placeholder
        /// </summary>
        public static string Author(Plugin plugin) => plugin.Author;
        
        /// <summary>
        /// <see cref="Plugin.Version"/> placeholder
        /// </summary>
        public static string Version(Plugin plugin) => plugin.Version.ToString();
        
        /// <summary>
        /// <see cref="Plugin.Description"/> placeholder
        /// </summary>
        public static string Description(Plugin plugin) => plugin.Description;
        
        /// <summary>
        /// <see cref="PluginExt.FullName(Oxide.Core.Plugins.Plugin)"/> placeholder
        /// </summary>
        public static string FullName(Plugin plugin) => plugin.FullName();
        
        /// <summary>
        /// <see cref="Plugin.TotalHookTime"/> placeholder
        /// </summary>
        
        public static TimeSpan HookTime(Plugin plugin) => TimeSpan.FromSeconds(plugin.TotalHookTime);
        
        /// <summary>
        /// Lang message for a plugin
        /// </summary>
        public static string LangMessage(PlaceholderState state, Plugin plugin) => OxideLibrary.Instance.Lang.GetMessage(state.Format, plugin, state.Data.Get<IPlayer>()?.Id);

        internal static void RegisterPlaceholders()
        {
            RegisterPlaceholders(DiscordExtensionCore.Instance, DefaultKeys.Plugin, new PlaceholderDataKey(nameof(Plugin)));
        }
        
        /// <summary>
        /// Registers placeholders for the given plugin. 
        /// </summary>
        /// <param name="plugin">Plugin to register placeholders for</param>
        /// <param name="keys">Prefix to use for the placeholders</param>
        /// <param name="dataKey">Data key in <see cref="PlaceholderData"/></param>
        public static void RegisterPlaceholders(Plugin plugin, PluginKeys keys, PlaceholderDataKey dataKey)
        {
            DiscordPlaceholders placeholders = DiscordPlaceholders.Instance;
            placeholders.RegisterPlaceholder<Plugin, string>(plugin, keys.Name, dataKey, Name);
            placeholders.RegisterPlaceholder<Plugin, string>(plugin, keys.Title, dataKey, Title);
            placeholders.RegisterPlaceholder<Plugin, string>(plugin, keys.Author, dataKey, Author);
            placeholders.RegisterPlaceholder<Plugin, string>(plugin, keys.Version, dataKey, Version);
            placeholders.RegisterPlaceholder<Plugin, string>(plugin, keys.Description, dataKey, Description);
            placeholders.RegisterPlaceholder<Plugin, string>(plugin, keys.Fullname, dataKey, FullName);
            placeholders.RegisterPlaceholder<Plugin, TimeSpan>(plugin, keys.HookTime, dataKey, HookTime);
            placeholders.RegisterPlaceholder<Plugin, string>(plugin, keys.Lang, dataKey, LangMessage);
        }
    }
}