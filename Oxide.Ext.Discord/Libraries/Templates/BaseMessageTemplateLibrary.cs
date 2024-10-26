using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Oxide.Core.Libraries.Covalence;
using Oxide.Core.Plugins;
using Oxide.Ext.Discord.Callbacks;
using Oxide.Ext.Discord.Entities;
using Oxide.Ext.Discord.Extensions;
using Oxide.Ext.Discord.Interfaces;
using Oxide.Ext.Discord.Logging;
using Oxide.Ext.Discord.Plugins;
using Oxide.Ext.Discord.Types;

namespace Oxide.Ext.Discord.Libraries
{
    /// <summary>
    /// Library for Discord Message templates
    /// </summary>
    public abstract class BaseMessageTemplateLibrary<TTemplate> : BaseTemplateLibrary<TTemplate>
        where TTemplate : class, new()
    {
        private readonly ConcurrentDictionary<TemplateId, TTemplate> _templateCache = new();

        internal BaseMessageTemplateLibrary(TemplateType type, ILogger logger) : base(type, logger) { }

        /// <summary>
        /// Registers a global message template
        /// Global Message templates cannot be localized
        /// </summary>
        /// <param name="plugin">Plugin the template is for</param>
        /// <param name="templateName">Unique name of the template</param>
        /// <param name="template">Template to register</param>
        /// <param name="version">Version of the template</param>
        /// <param name="minVersion">Min supported version for this template</param>
        /// <exception cref="ArgumentNullException"></exception>
        public IPromise<TTemplate> RegisterGlobalTemplateAsync(Plugin plugin, TemplateKey templateName, TTemplate template, TemplateVersion version, TemplateVersion minVersion)
        {
            if (plugin == null) throw new ArgumentNullException(nameof(plugin));
            if (!templateName.IsValid) throw new ArgumentNullException(nameof(templateName));
            if (template == null) throw new ArgumentNullException(nameof(template));

            IPendingPromise<TTemplate> promise = Promise<TTemplate>.Create();
            
            TemplateId id = TemplateId.CreateGlobal(plugin, templateName);
            RegisterTemplateCallback<TTemplate>.Start(this, id, template, version, minVersion, promise);
            return promise;
        }

        /// <summary>
        /// Registers a message template with the given name and language
        /// </summary>
        /// <param name="plugin">Plugin the <see cref="DiscordMessageTemplate"/> is for</param>
        /// <param name="templateName">Name of the <see cref="DiscordMessageTemplate"/></param>
        /// <param name="template">Template to be registered</param>
        /// <param name="version">Version of the template</param>
        /// <param name="minVersion">
        /// The minimum supported template version.<br/>
        /// If an existing template exists and it's version is >=  the minimum supported version then we will use that template.<br/>
        /// If an existing template exists and it's version is &lt; the min supported version. The existing version is backed up and a new template is created 
        /// </param>
        /// <param name="language">Language for the template</param>
        /// <exception cref="ArgumentNullException"></exception>
        public IPromise<TTemplate> RegisterLocalizedTemplateAsync(Plugin plugin, TemplateKey templateName, TTemplate template, TemplateVersion version, TemplateVersion minVersion, string language = DiscordLocales.DefaultServerLanguage)
        {
            if (plugin == null) throw new ArgumentNullException(nameof(plugin));
            if (!templateName.IsValid) throw new ArgumentNullException(nameof(templateName));
            if (template == null) throw new ArgumentNullException(nameof(template));
            
            IPendingPromise<TTemplate> promise = Promise<TTemplate>.Create();

            TemplateId id = TemplateId.CreateLocalized(plugin, templateName, ServerLocale.Parse(language));
            RegisterTemplateCallback<TTemplate>.Start(this, id, template, version, minVersion, promise);
            return promise;
        }

        /// <summary>
        /// Returns a global message template for the plugin with the given name
        /// </summary>
        /// <param name="plugin">Plugin the template is for</param>
        /// <param name="templateName">Name of the template</param>
        /// <returns><see cref="DiscordMessageTemplate"/></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public TTemplate GetGlobalTemplate(Plugin plugin, TemplateKey templateName) => HandleGetLocalizedTemplate(TemplateId.CreateGlobal(plugin, templateName), null);
        
        /// <summary>
        /// Returns a message template for a given <see cref="IPlayer"/> player
        /// </summary>
        /// <param name="plugin">Plugin the template is for</param>
        /// <param name="templateName">Name of the template</param>
        /// <param name="player">IPlayer for the template</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Thrown if Plugin is null or name / language is null or empty</exception>
        public TTemplate GetPlayerTemplate(Plugin plugin, TemplateKey templateName, IPlayer player) => GetPlayerTemplate(plugin, templateName, player?.Id);
        
        /// <summary>
        /// Returns a message template for a given <see cref="IPlayer"/> player
        /// </summary>
        /// <param name="plugin">Plugin the template is for</param>
        /// <param name="templateName">Name of the template</param>
        /// <param name="playerId">Player ID for the template</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Thrown if Plugin is null or name / language is null or empty</exception>
        public TTemplate GetPlayerTemplate(Plugin plugin, TemplateKey templateName, string playerId) => HandleGetLocalizedTemplate(TemplateId.CreatePlayer(plugin, templateName, playerId), null);

        /// <summary>
        /// Returns a message template for a given language
        /// </summary>
        /// <param name="plugin">Plugin the template is for</param>
        /// <param name="templateName">Name of the template</param>
        /// <param name="language">Oxide language of the template</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Thrown if Plugin is null or name / language is null or empty</exception>
        public TTemplate GetLocalizedTemplate(Plugin plugin, TemplateKey templateName, string language = DiscordLocales.DefaultServerLanguage) => HandleGetLocalizedTemplate(TemplateId.CreateLocalized(plugin, templateName, ServerLocale.Parse(language)), null);

        /// <summary>
        /// Returns a message template for a given language
        /// </summary>
        /// <param name="plugin">Plugin the template is for</param>
        /// <param name="templateName">Name of the template</param>
        /// <param name="interaction">Interaction to get the template for</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Thrown if Plugin is null or name / language is null or empty</exception>
        public TTemplate GetLocalizedTemplate(Plugin plugin, TemplateKey templateName, DiscordInteraction interaction) => HandleGetLocalizedTemplate(TemplateId.CreateInteraction(plugin, templateName, interaction), interaction);

        private TTemplate HandleGetLocalizedTemplate(TemplateId id, DiscordInteraction interaction)
        {
            TTemplate cachedTemplate = LoadFromCache(id);
            if (cachedTemplate != null)
            {
                return cachedTemplate;
            }
            
            DiscordTemplate<TTemplate> template;
            if (interaction != null)
            {
                IPlayer player = interaction.User.Player;
                template = LoadTemplate(id)
                           ?? (player != null ? LoadTemplate(id, DiscordLocales.Instance.GetPlayerLanguage(player)) : null)
                           ?? (interaction.GuildLocale.HasValue ? LoadTemplate(id, interaction.GuildLocale.Value.GetServerLocale()) : null)
                           ?? LoadTemplate(id, DiscordLocales.Instance.ServerLanguage)
                           ?? LoadTemplate(id, ServerLocale.Default);
            }
            else if (!id.IsGlobal)
            {
                template = LoadTemplate(id)
                           ?? LoadTemplate(id, DiscordLocales.Instance.ServerLanguage)
                           ?? LoadTemplate(id, ServerLocale.Default);
            }
            else
            {
                template = LoadTemplate(id);
            }

            if (template == null)
            {
                Logger.Error("Plugin {0} is using the {1} Template API but message template name '{2}/{3}' is not registered", id.GetPluginName(), GetType().GetRealTypeName(), id.GetLanguageName(), id.TemplateName);
                return new TTemplate();
            }
            
            SetCache(id, template.Template);

            return template.Template;
        }

        private TTemplate LoadFromCache(TemplateId id) => _templateCache.GetValueOrDefault(id);

        private void SetCache(TemplateId id, TTemplate template)
        {
            _templateCache[id] = template;
        }

        internal override void OnTemplateRegistered(TemplateId id, TTemplate template)
        {
            SetCache(id, template);
        }

        ///<inheritdoc/>
        protected override void OnPluginUnloaded(Plugin plugin)
        {
            base.OnPluginUnloaded(plugin);
            PluginId pluginId = plugin.Id();
            _templateCache.RemoveAll(t => t.PluginId == pluginId);
        }
    }
}