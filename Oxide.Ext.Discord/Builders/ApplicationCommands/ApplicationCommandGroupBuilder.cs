using System;
using System.Collections.Generic;
using Oxide.Core.Plugins;
using Oxide.Ext.Discord.Entities;
using Oxide.Ext.Discord.Libraries;

namespace Oxide.Ext.Discord.Builders
{
    /// <summary>
    /// Builder for Sub Command Groups
    /// </summary>
    public class ApplicationCommandGroupBuilder
    {
        private readonly CommandOption _option;
        private readonly ServerLocale _defaultLanguage;
        
        /// <summary>
        /// The Name of the command
        /// </summary>
        public readonly string CommandName;
        
        /// <summary>
        /// The Name of the group
        /// </summary>
        public readonly string GroupName;

        internal ApplicationCommandGroupBuilder(List<CommandOption> options, string name, string description, ServerLocale defaultLanguage, string commandName)
        {
            _defaultLanguage = defaultLanguage;
            _option = new CommandOption(name, description, CommandOptionType.SubCommandGroup, new List<CommandOption>());
            options.Add(_option);
            AddNameLocalization(name, _defaultLanguage);
            AddDescriptionLocalization(description, _defaultLanguage);
            CommandName = commandName;
            GroupName = name;
        }

        /// <summary>
        /// Adds command name localizations for a given plugin and lang key
        /// </summary>
        /// <param name="plugin">Plugin containing the localizations</param>
        /// <param name="langKey">Lang Key containing the localized text</param>
        /// <returns></returns>
        [Obsolete("AddNameLocalizations(Plugin plugin, string langKey) has been deprecated and will be removed in the future. Please use AddNameLocalization(string name, string lang) instead.")]
        public ApplicationCommandGroupBuilder AddNameLocalizations(Plugin plugin, string langKey)
        {
            _option.NameLocalizations = DiscordLocales.Instance.GetDiscordLocalizations(plugin, langKey);
            return this;
        }

        /// <summary>
        /// Adds Application Sub Command Group Name Localizations
        /// </summary>
        /// <param name="name">Localized name value</param>
        /// <param name="serverLocale">Oxide lang the value is in</param>
        /// <returns>This</returns>
        public ApplicationCommandGroupBuilder AddNameLocalization(string name, ServerLocale serverLocale)
        {
            DiscordLocale discordLocale = serverLocale.GetDiscordLocale();
            if (discordLocale.IsValid)
            {
                _option.NameLocalizations[discordLocale.Id] = name;
            }

            return this;
        }

        /// <summary>
        /// Adds command description localizations for a given plugin and lang key
        /// </summary>
        /// <param name="plugin">Plugin containing the localizations</param>
        /// <param name="langKey">Lang Key containing the localized text</param>
        /// <returns></returns>
        [Obsolete("AddDescriptionLocalizations(Plugin plugin, string langKey) has been deprecated and will be removed in the future. Please use AddDescriptionLocalization(string name, string lang) instead.")]
        public ApplicationCommandGroupBuilder AddDescriptionLocalizations(Plugin plugin, string langKey)
        {
            _option.DescriptionLocalizations = DiscordLocales.Instance.GetDiscordLocalizations(plugin, langKey);
            return this;
        }

        /// <summary>
        /// Adds Application Command Description Localizations
        /// </summary>
        /// <param name="description">Localized description value</param>
        /// <param name="serverLocale">Oxide lang the value is in</param>
        /// <returns>This</returns>
        private ApplicationCommandGroupBuilder AddDescriptionLocalization(string description, ServerLocale serverLocale)
        {
            DiscordLocale discordLocale = serverLocale.GetDiscordLocale();
            if (discordLocale.IsValid)
            {
                _option.DescriptionLocalizations[discordLocale.Id] = description;
            }

            return this;
        }

        /// <summary>
        /// Adds a sub command to this sub command group
        /// </summary>
        /// <param name="name">Name of the command</param>
        /// <param name="description">Description of the command</param>
        /// <param name="builder">Callback with the <see cref="ApplicationSubCommandBuilder"/></param>
        /// <returns>this</returns>
        public ApplicationCommandGroupBuilder AddSubCommand(string name, string description, Action<ApplicationSubCommandBuilder> builder = null)
        {
            ApplicationSubCommandBuilder sub = new(_option.Options, name, description, _defaultLanguage, CommandName, GroupName);
            builder?.Invoke(sub);
            return this;
        }
    }
}