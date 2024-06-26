using System;
using Oxide.Core.Plugins;
using Oxide.Ext.Discord.Entities;
using Oxide.Ext.Discord.Extensions;
using Oxide.Ext.Discord.Plugins;

namespace Oxide.Ext.Discord.Libraries
{
    internal struct TemplateId : IEquatable<TemplateId>
    {
        internal readonly PluginId PluginId;
        public readonly TemplateKey TemplateName;
        public readonly ServerLocale Language;
        
        public bool IsGlobal => !Language.IsValid;
        
        private TemplateId(Plugin plugin, TemplateKey templateName, ServerLocale language) : this(plugin?.Id() ?? throw new ArgumentNullException(nameof(plugin)), templateName, language) { }

        private TemplateId(PluginId pluginName, TemplateKey templateName, ServerLocale language)
        {
            PluginId = pluginName;
            TemplateName = templateName;
            Language = language;
        }

        public static TemplateId CreateGlobal(Plugin plugin, TemplateKey templateName) => new TemplateId(plugin, templateName, default(ServerLocale));
        public static TemplateId CreateLocalized(Plugin plugin, TemplateKey templateName, ServerLocale language) => new TemplateId(plugin, templateName, language);
        public static TemplateId CreateInteraction(Plugin plugin, TemplateKey templateName, DiscordInteraction interaction) => new TemplateId(plugin, templateName, interaction.Locale.GetServerLocale());
        public static TemplateId CreatePlayer(Plugin plugin, TemplateKey templateName, string playerId) => new TemplateId(plugin, templateName, DiscordLocales.Instance.GetPlayerLanguage(playerId));

        public string GetPluginName()
        {
            return PluginExt.GetFullName(PluginId);
        }

        public TemplateId WithLanguage(ServerLocale language)
        {
            return new TemplateId(PluginId, TemplateName, language);
        }

        public string GetLanguageName() => IsGlobal ? "Global" : Language.Id;
        
        public bool Equals(TemplateId other) => PluginId == other.PluginId && TemplateName == other.TemplateName && Language == other.Language;

        public override bool Equals(object obj) => obj is TemplateId other && Equals(other);

        public override string ToString() => $"Plugin: {PluginId} Template: {TemplateName} Language: {GetLanguageName()}";

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = PluginId.GetHashCode();
                hashCode = (hashCode * 397) ^ (TemplateName.IsValid ? TemplateName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Language.IsValid ? Language.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}