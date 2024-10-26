using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using Oxide.Core.Plugins;
using Oxide.Ext.Discord.Callbacks;
using Oxide.Ext.Discord.Entities;
using Oxide.Ext.Discord.Extensions;
using Oxide.Ext.Discord.Interfaces;
using Oxide.Ext.Discord.Logging;
using Oxide.Ext.Discord.Plugins;
using Oxide.Ext.Discord.Types;
using Oxide.Plugins;

namespace Oxide.Ext.Discord.Libraries
{
    /// <summary>
    /// Auto Complete Choice Templates Library
    /// </summary>
    public class DiscordAutoCompleteChoiceTemplates : BaseTemplateLibrary<DiscordAutoCompleteChoiceTemplate>
    {
        private readonly ConcurrentDictionary<TemplateId, DiscordAutoCompleteChoiceTemplate> _globalCache = new();
        private readonly ConcurrentDictionary<TemplateId, List<LocalizedTemplate>> _localizedCache = new();

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger"></param>
        public DiscordAutoCompleteChoiceTemplates(ILogger logger) : base(TemplateType.AutoCompleteChoice, logger) { }

        /// <summary>
        /// Registers a global template for Auto Complete Choices
        /// </summary>
        /// <param name="plugin">Plugin the template is for</param>
        /// <param name="templateName">Name of the template</param>
        /// <param name="template">The template to register</param>
        /// <param name="version">Current version of the template</param>
        /// <param name="minVersion">Minimum supported version of the template</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Throw if plugin or templateName is null</exception>
        public IPromise<DiscordAutoCompleteChoiceTemplate> RegisterGlobalTemplate(Plugin plugin, TemplateKey templateName, DiscordAutoCompleteChoiceTemplate template, TemplateVersion version, TemplateVersion minVersion)
        {
            if (plugin == null) throw new ArgumentNullException(nameof(plugin));
            if (!templateName.IsValid) throw new ArgumentNullException(nameof(templateName));

            TemplateId id = TemplateId.CreateGlobal(plugin, templateName);
            return RegisterTemplate(id, template, version, minVersion);
        }

        /// <summary>
        /// Registers a global template for Auto Complete Choices
        /// </summary>
        /// <param name="plugin">Plugin the template is for</param>
        /// <param name="templateName">Name of the template</param>
        /// <param name="template">The template to register</param>
        /// <param name="version">Current version of the template</param>
        /// <param name="minVersion">Minimum supported version of the template</param>
        /// <param name="language">Server Language for the localized template</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Throw if plugin, templateName, or language is null/empty</exception>
        public IPromise<DiscordAutoCompleteChoiceTemplate> RegisterLocalizedTemplate(Plugin plugin, TemplateKey templateName, DiscordAutoCompleteChoiceTemplate template, TemplateVersion version, TemplateVersion minVersion, string language = DiscordLocales.DefaultServerLanguage)
        {
            if (plugin == null) throw new ArgumentNullException(nameof(plugin));
            if (!templateName.IsValid) throw new ArgumentNullException(nameof(templateName));
            if (string.IsNullOrEmpty(language)) throw new ArgumentNullException(nameof(language));

            TemplateId id = TemplateId.CreateLocalized(plugin, templateName, ServerLocale.Parse(language));
            return RegisterTemplate(id, template, version, minVersion);
        }

        private IPromise<DiscordAutoCompleteChoiceTemplate> RegisterTemplate(TemplateId id, DiscordAutoCompleteChoiceTemplate template, TemplateVersion version, TemplateVersion minVersion)
        {
            if (template == null) throw new ArgumentNullException(nameof(template));
            IPendingPromise<DiscordAutoCompleteChoiceTemplate> promise = Promise<DiscordAutoCompleteChoiceTemplate>.Create();
            RegisterTemplateCallback<DiscordAutoCompleteChoiceTemplate>.Start(this, id, template, version, minVersion, promise);
            return promise;
        }

        /// <summary>
        /// Returns a global Auto Complete Template for the given plugin and template name
        /// </summary>
        /// <param name="plugin">Plugin for the template</param>
        /// <param name="templateName">Name of the template</param>
        /// <returns></returns>
        public DiscordAutoCompleteChoiceTemplate GetGlobalTemplate(Plugin plugin, TemplateKey templateName)
        {
            TemplateId id = TemplateId.CreateGlobal(plugin, templateName);
            if (_globalCache.TryGetValue(id, out DiscordAutoCompleteChoiceTemplate cached))
            {
                return cached;
            }

            DiscordTemplate<DiscordAutoCompleteChoiceTemplate> template = LoadTemplate(id);
            
            if (template == null)
            {
                Logger.Error("Plugin {0} is using the {1} Template API but message template name '{2}' is not registered", id.GetPluginName(), GetType().GetRealTypeName(), id.TemplateName);
                return new DiscordAutoCompleteChoiceTemplate();
            }
            
            SetCache(id, template.Template);

            return template.Template;
        }

        /// <summary>
        /// Applies a Global Template to a <see cref="CommandOptionChoice"/> with optional placeholders
        /// </summary>
        /// <param name="plugin">Plugin for the template</param>
        /// <param name="templateName">Name of the template</param>
        /// <param name="choice">Choice to be applied to</param>
        /// <param name="placeholders">Placeholders to apply</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Thrown if plugin or templateName is null/empty</exception>
        public CommandOptionChoice ApplyGlobal(Plugin plugin, TemplateKey templateName, CommandOptionChoice choice = null, PlaceholderData placeholders = null)
        {
            if (plugin == null) throw new ArgumentNullException(nameof(plugin));
            if (!templateName.IsValid) throw new ArgumentNullException(nameof(templateName));
            
            choice ??= new CommandOptionChoice();
            
            TemplateId id = TemplateId.CreateGlobal(plugin, templateName);
            ApplyGlobal(id, choice, placeholders);
            return choice;
        }

        private void ApplyGlobal(TemplateId id, CommandOptionChoice choice, PlaceholderData placeholders)
        {
            LoadTemplate(id)?.Template.ApplyName(choice, placeholders);
        }

        /// <summary>
        /// Applies a Localized Template to a <see cref="CommandOptionChoice"/> with optional placeholders
        /// </summary>
        /// <param name="plugin">Plugin for the template</param>
        /// <param name="templateName">Name of the template</param>
        /// <param name="choice">Choice to be applied to</param>
        /// <param name="placeholders">Placeholders to apply</param>
        /// <param name="language">Server Language to apply</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Thrown if plugin or templateName is null/empty</exception>
        public CommandOptionChoice ApplyLocalized(Plugin plugin, TemplateKey templateName, CommandOptionChoice choice = null, PlaceholderData placeholders = null, string language = DiscordLocales.DefaultServerLanguage)
        {
            if (plugin == null) throw new ArgumentNullException(nameof(plugin));
            if (!templateName.IsValid) throw new ArgumentNullException(nameof(templateName));

            choice ??= new CommandOptionChoice();
            
            ServerLocale locale = ServerLocale.Parse(language);
            TemplateId id = TemplateId.CreateLocalized(plugin, templateName, locale);
            ApplyLocalizations(id, choice, placeholders);
            return choice;
        }

        /// <summary>
        /// Applies a Localized Template to a <see cref="CommandOptionChoice"/> with optional placeholders
        /// </summary>
        /// <param name="plugin">Plugin for the template</param>
        /// <param name="templateName">Name of the template</param>
        /// <param name="interaction">Interaction for the localization</param>
        /// <param name="choice">Choice to be applied to</param>
        /// <param name="placeholders">Placeholders to apply</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Thrown if plugin or templateName is null/empty</exception>
        public CommandOptionChoice ApplyLocalized(Plugin plugin, TemplateKey templateName, DiscordInteraction interaction, CommandOptionChoice choice = null, PlaceholderData placeholders = null)
        {
            if (plugin == null) throw new ArgumentNullException(nameof(plugin));
            if (!templateName.IsValid) throw new ArgumentNullException(nameof(templateName));

            choice ??= new CommandOptionChoice();
            
            TemplateId id = TemplateId.CreateInteraction(plugin, templateName, interaction);
            ApplyLocalizations(id, choice, placeholders);
            return choice;
        }

        private void ApplyLocalizations(TemplateId id, CommandOptionChoice choice, PlaceholderData data)
        {
            choice.NameLocalizations ??= new Hash<string, string>();
            
            data?.IncrementDepth();
            
            //Apply global template to the name field if it exists
            ApplyGlobal(id, choice, data);

            List<LocalizedTemplate> list = GetLocalizedTemplates(id);
            for (int index = 0; index < list.Count; index++)
            {
                LocalizedTemplate template = list[index];
                template.Template.ApplyLocalization(template.Locale, choice, data);
            }

            data?.DecrementDepth();
            data?.AutoDispose();
        }

        private List<LocalizedTemplate> GetLocalizedTemplates(TemplateId id)
        {
            if(_localizedCache.TryGetValue(id, out List<LocalizedTemplate> templates))
            {
                return templates;
            }

            templates = new List<LocalizedTemplate>();

            foreach (string dir in Directory.EnumerateDirectories(GetTemplateFolder(id.PluginId)))
            {
                ServerLocale locale = ServerLocale.Parse(Path.GetFileName(dir));
                DiscordLocale discordLocale = locale.GetDiscordLocale();
                if (!discordLocale.IsValid)
                {
                    continue;
                }
                
                DiscordAutoCompleteChoiceTemplate template = LoadTemplate(id.WithLanguage(locale))?.Template;
                if (template != null)
                {
                    templates.Add(new LocalizedTemplate(discordLocale, template));    
                }
            }

            _localizedCache[id] = templates;

            return templates;
        }
        
        private void SetCache(TemplateId id, DiscordAutoCompleteChoiceTemplate template)
        {
            if (id.IsGlobal)
            {
                _globalCache[id] = template;
            }
        }

        internal override void OnTemplateRegistered(TemplateId id, DiscordAutoCompleteChoiceTemplate template)
        {
            if (id.IsGlobal)
            {
                _globalCache[id] = template;
            }
        }
        
        ///<inheritdoc/>
        protected override void OnPluginUnloaded(Plugin plugin)
        {
            base.OnPluginUnloaded(plugin);
            PluginId pluginId = plugin.Id();
            _globalCache.RemoveAll(t => t.PluginId == pluginId);
            _localizedCache.RemoveAll(t => t.PluginId == pluginId);
        }
        
        private struct LocalizedTemplate
        {
            public readonly DiscordLocale Locale;
            public readonly DiscordAutoCompleteChoiceTemplate Template;

            public LocalizedTemplate(DiscordLocale locale, DiscordAutoCompleteChoiceTemplate template)
            {
                Locale = locale;
                Template = template;
            }
        }
    }
}