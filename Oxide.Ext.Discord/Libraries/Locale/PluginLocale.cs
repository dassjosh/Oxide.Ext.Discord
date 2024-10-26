using System;
using Oxide.Core.Plugins;
using Oxide.Ext.Discord.Extensions;
using Oxide.Ext.Discord.Plugins;

namespace Oxide.Ext.Discord.Libraries
{
    internal readonly struct PluginLocale : IEquatable<PluginLocale>
    {
        internal readonly PluginId PluginId;
        private readonly ServerLocale _language;

        public PluginLocale(Plugin plugin, ServerLocale language)
        {
            if(!language.IsValid) throw new ArgumentNullException(nameof(language));
            PluginId = plugin?.Id() ?? throw new ArgumentNullException(nameof(plugin));
            _language = language;
        }

        public override string ToString()
        {
            return $"Plugin: {PluginId.ToString()} Language: {_language}";
        }
        
        public bool Equals(PluginLocale other) => PluginId.Equals(other.PluginId) && _language.Equals(other._language);
        public override bool Equals(object obj) => obj is PluginLocale other && Equals(other);
        public override int GetHashCode() => HashCode.Combine(PluginId, _language);
    }
}