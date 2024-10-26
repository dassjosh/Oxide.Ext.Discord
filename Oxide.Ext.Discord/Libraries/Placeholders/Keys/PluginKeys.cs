using Oxide.Core.Plugins;
using Oxide.Ext.Discord.Extensions;

namespace Oxide.Ext.Discord.Libraries
{
    /// <summary>
    /// Placeholder Keys for <see cref="Plugin"/>
    /// </summary>
    public class PluginKeys
    {
        /// <summary>
        /// <see cref="PlaceholderKey"/> for <see cref="Plugin.Name"/>
        /// </summary>
        public readonly PlaceholderKey Name;
        
        /// <summary>
        /// <see cref="PlaceholderKey"/> for <see cref="Plugin.Title"/>
        /// </summary>
        public readonly PlaceholderKey Title;
        
        /// <summary>
        /// <see cref="PlaceholderKey"/> for <see cref="Plugin.Author"/>
        /// </summary>
        public readonly PlaceholderKey Author;
        
        /// <summary>
        /// <see cref="PlaceholderKey"/> for <see cref="Plugin.Version"/>
        /// </summary>
        public readonly PlaceholderKey Version;
        
        /// <summary>
        /// <see cref="PlaceholderKey"/> for <see cref="Plugin.Description"/>
        /// </summary>
        public readonly PlaceholderKey Description;
        
        /// <summary>
        /// <see cref="PlaceholderKey"/> for <see cref="PluginExt.FullName(Oxide.Core.Plugins.Plugin)"/>
        /// </summary>
        public readonly PlaceholderKey Fullname;
        
        /// <summary>
        /// <see cref="PlaceholderKey"/> for <see cref="Plugin.TotalHookTime"/>
        /// </summary>
        public readonly PlaceholderKey HookTime;
        
        /// <summary>
        /// <see cref="PlaceholderKey"/> for <see cref="Core.Libraries.Lang.GetMessage"/>
        /// </summary>
        public readonly PlaceholderKey Lang;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="prefix">Placeholder Key Prefix</param>
        public PluginKeys(string prefix)
        {
            Name = new PlaceholderKey(prefix, "name");
            Title = new PlaceholderKey(prefix, "title");
            Author = new PlaceholderKey(prefix, "author");
            Version = new PlaceholderKey(prefix, "version");
            Description = new PlaceholderKey(prefix, "description");
            Fullname = new PlaceholderKey(prefix, "fullname");
            HookTime = new PlaceholderKey(prefix, "hooktime");
            Lang = new PlaceholderKey(prefix, "lang");
        }
    }
}