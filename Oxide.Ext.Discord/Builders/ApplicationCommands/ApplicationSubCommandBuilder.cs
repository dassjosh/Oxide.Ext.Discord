using System;
using System.Collections.Generic;
using Oxide.Core.Plugins;
using Oxide.Ext.Discord.Entities;
using Oxide.Ext.Discord.Exceptions;
using Oxide.Ext.Discord.Libraries;

namespace Oxide.Ext.Discord.Builders
{
    /// <summary>
    /// Application Sub Command Builder
    /// </summary>
    public class ApplicationSubCommandBuilder
    {
        private readonly CommandOption _subCommand;
        private readonly ServerLocale _defaultLanguage;

        /// <summary>
        /// The Name of the command
        /// </summary>
        public readonly string CommandName;
        
        /// <summary>
        /// The Name of the group
        /// </summary>
        public readonly string GroupName;
        
        /// <summary>
        /// The Name of the Sub Command
        /// </summary>
        public readonly string SubCommandName;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="options">Options for the sub command</param>
        /// <param name="name">Name of the sub command</param>
        /// <param name="description">Description of the sub command</param>
        /// <param name="defaultLanguage"></param>
        /// <param name="commandName"></param>
        /// <param name="groupName"></param>
        internal ApplicationSubCommandBuilder(List<CommandOption> options, string name, string description, ServerLocale defaultLanguage, string commandName, string groupName)
        {
            _subCommand = new CommandOption(name, description, CommandOptionType.SubCommand, new List<CommandOption>());
            options.Add(_subCommand);
            _defaultLanguage = defaultLanguage;
            AddNameLocalization(name, _defaultLanguage);
            AddDescriptionLocalization(description, _defaultLanguage);
            CommandName = commandName;
            GroupName = groupName;
            SubCommandName = name;
        }

        /// <summary>
        /// Adds command name localizations for a given plugin and lang key
        /// </summary>
        /// <param name="plugin">Plugin containing the localizations</param>
        /// <param name="langKey">Lang Key containing the localized text</param>
        /// <returns></returns>
        [Obsolete("AddNameLocalizations(Plugin plugin, string langKey) has been deprecated and will be removed in the future. Please use AddNameLocalization(string name, string lang) instead.")]
        public ApplicationSubCommandBuilder AddNameLocalizations(Plugin plugin, string langKey)
        {
            _subCommand.NameLocalizations = DiscordLocales.Instance.GetDiscordLocalizations(plugin, langKey);
            return this;
        }
         
        /// <summary>
        /// Adds Application Sub Command Name Localization
        /// </summary>
        /// <param name="name">Localized name value</param>
        /// <param name="serverLocale">Oxide lang the value is in</param>
        /// <returns>This</returns>
        public ApplicationSubCommandBuilder AddNameLocalization(string name, ServerLocale serverLocale)
        {
            DiscordLocale discordLocale = serverLocale.GetDiscordLocale();
            if (discordLocale.IsValid)
            {
                _subCommand.NameLocalizations[discordLocale.Id] = name;
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
        public ApplicationSubCommandBuilder AddDescriptionLocalizations(Plugin plugin, string langKey)
        {
            _subCommand.DescriptionLocalizations = DiscordLocales.Instance.GetDiscordLocalizations(plugin, langKey);
            return this;
        }
        
        /// <summary>
        /// Adds Application Sub Command Description Localizations
        /// </summary>
        /// <param name="description">Localized description value</param>
        /// <param name="serverLocale">Oxide lang the value is in</param>
        /// <returns>This</returns>
        public ApplicationSubCommandBuilder AddDescriptionLocalization(string description, ServerLocale serverLocale)
        {
            DiscordLocale discordLocale = serverLocale.GetDiscordLocale();
            if (discordLocale.IsValid)
            { 
                _subCommand.DescriptionLocalizations[discordLocale.Id] = description;
            }
            
            return this;
        }

        /// <summary>
        /// Adds a new option
        /// </summary>
        /// <param name="type">Option data type (Cannot be SubCommand or SubCommandGroup)</param>
        /// <param name="name">Name of the option</param>
        /// <param name="description">Description of the option</param>
        /// <param name="builder">Callback with the <see cref="ApplicationCommandOptionBuilder"/></param>
        /// <returns>This</returns>
        /// <exception cref="Exception">Thrown if type is <see cref="CommandOptionType.SubCommand"/> or <see cref="CommandOptionType.SubCommandGroup"/></exception>
        public ApplicationSubCommandBuilder AddOption(CommandOptionType type, string name, string description, Action<ApplicationCommandOptionBuilder> builder = null)
        {
            ApplicationCommandBuilderException.ThrowIfInvalidCommandOptionType(type);
            ApplicationCommandOptionBuilder option = new(_subCommand.Options, type, name, description, _defaultLanguage, CommandName, GroupName, SubCommandName);
            builder?.Invoke(option);
            return this;
        }
    }
}