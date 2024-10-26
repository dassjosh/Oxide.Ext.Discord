using System;
using System.Collections.Generic;
using Oxide.Core.Plugins;
using Oxide.Ext.Discord.Entities;
using Oxide.Ext.Discord.Exceptions;
using Oxide.Ext.Discord.Libraries;
using Oxide.Plugins;

namespace Oxide.Ext.Discord.Builders
{
    /// <summary>
    /// Represents a Subcommand Option Builder for SubCommands
    /// </summary>
    public class ApplicationCommandOptionBuilder
    {
        private readonly CommandOption _option;

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
        /// The Name of the Option
        /// </summary>
        public readonly string OptionName;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="type"></param>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="defaultLanguage"></param>
        /// <param name="commandName"></param>
        /// <param name="groupName"></param>
        /// <param name="subCommandName"></param>
        internal ApplicationCommandOptionBuilder(List<CommandOption> parent, CommandOptionType type, string name, string description, ServerLocale defaultLanguage, string commandName, string groupName, string subCommandName)
        {
            InvalidCommandOptionException.ThrowIfInvalidName(name, false);
            InvalidCommandOptionException.ThrowIfInvalidDescription(description, false);
            InvalidCommandOptionException.ThrowIfInvalidType(type);

            _option = new CommandOption(name, description, type);

            parent.Add(_option);
            AddNameLocalization(name, defaultLanguage);
            AddDescriptionLocalization(description, defaultLanguage);
            CommandName = commandName;
            GroupName = groupName;
            SubCommandName = subCommandName;
            OptionName = name;
        }

        /// <summary>
        /// Adds command name localizations for a given plugin and lang key
        /// </summary>
        /// <param name="plugin">Plugin containing the localizations</param>
        /// <param name="langKey">Lang Key containing the localized text</param>
        /// <returns></returns>
        [Obsolete("AddNameLocalizations(Plugin plugin, string langKey) has been deprecated and will be removed in the future. Please use AddNameLocalization(string name, string lang) instead.")]
        public ApplicationCommandOptionBuilder AddNameLocalizations(Plugin plugin, string langKey)
        {
            _option.NameLocalizations = DiscordLocales.Instance.GetDiscordLocalizations(plugin, langKey);
            return this;
        }

        /// <summary>
        /// Adds Application Command Option Name Localization
        /// </summary>
        /// <param name="name">Localized name value</param>
        /// <param name="serverLocale">Oxide lang the value is in</param>
        /// <returns>This</returns>
        public ApplicationCommandOptionBuilder AddNameLocalization(string name, ServerLocale serverLocale)
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
        public ApplicationCommandOptionBuilder AddDescriptionLocalizations(Plugin plugin, string langKey)
        {
            _option.DescriptionLocalizations = DiscordLocales.Instance.GetDiscordLocalizations(plugin, langKey);
            return this;
        }

        /// <summary>
        /// Adds Application Command Option Description Localization
        /// </summary>
        /// <param name="description">Localized description value</param>
        /// <param name="serverLocale">Oxide lang the value is in</param>
        /// <returns>This</returns>
        public ApplicationCommandOptionBuilder AddDescriptionLocalization(string description, ServerLocale serverLocale)
        {
            DiscordLocale discordLocale = serverLocale.GetDiscordLocale();
            if (discordLocale.IsValid)
            {
                _option.DescriptionLocalizations[discordLocale.Id] = description;
            }

            return this;
        }

        /// <summary>
        /// Set the required state for the option
        /// </summary>
        /// <param name="required">If the option is required (Default: true)</param>
        /// <returns>This</returns>
        public ApplicationCommandOptionBuilder Required(bool required = true)
        {
            _option.Required = required;
            return this;
        }

        /// <summary>
        /// Enable auto complete for the option
        /// </summary>
        /// <param name="autoComplete">If the option supports auto complete (Default: true)</param>
        /// <returns>This</returns>
        public ApplicationCommandOptionBuilder AutoComplete(bool autoComplete = true)
        {
            _option.Autocomplete = autoComplete;
            return this;
        }

        /// <summary>
        /// Min Value for Integer Option
        /// </summary>
        /// <param name="minValue">Min Value</param>
        /// <returns>This</returns>
        public ApplicationCommandOptionBuilder MinValue(int minValue)
        {
            InvalidCommandOptionException.ThrowIfInvalidMinIntegerType(_option.Type);
            _option.MinValue = minValue;
            return this;
        }

        /// <summary>
        /// Min Value for Number Option
        /// </summary>
        /// <param name="minValue">Min Value</param>
        /// <returns>This</returns>
        public ApplicationCommandOptionBuilder MinValue(double minValue)
        {
            InvalidCommandOptionException.ThrowIfInvalidMinNumberType(_option.Type);
            _option.MinValue = minValue;
            return this;
        }

        /// <summary>
        /// Max Value for Integer Option
        /// </summary>
        /// <param name="maxValue">Max Value</param>
        /// <returns>This</returns>
        public ApplicationCommandOptionBuilder MaxValue(int maxValue)
        {
            InvalidCommandOptionException.ThrowIfInvalidMaxIntegerType(_option.Type);
            _option.MaxValue = maxValue;
            return this;
        }

        /// <summary>
        /// Max Value for Number Option
        /// </summary>
        /// <param name="maxValue">Max Value</param>
        /// <returns>This</returns>
        public ApplicationCommandOptionBuilder MaxValue(double maxValue)
        {
            InvalidCommandOptionException.ThrowIfInvalidMaxNumberType(_option.Type);
            _option.MaxValue = maxValue;
            return this;
        }

        /// <summary>
        /// Min Length for String Option
        /// Max Of 6000
        /// </summary>
        /// <param name="minLength">Min Length for the string</param>
        /// <returns>This</returns>
        public ApplicationCommandOptionBuilder MinLength(int minLength)
        {
            InvalidCommandOptionException.ThrowIfInvalidMinLengthType(_option.Type);
            InvalidCommandOptionException.ThrowIfInvalidMinLength(minLength);
            _option.MinLength = minLength;
            return this;
        }

        /// <summary>
        /// Max Length for String Option
        /// Max Of 6000
        /// </summary>
        /// <param name="maxLength">Max Length</param>
        /// <returns>This</returns>
        public ApplicationCommandOptionBuilder MaxLength(int maxLength)
        {
            InvalidCommandOptionException.ThrowIfInvalidMaxLengthType(_option.Type);
            InvalidCommandOptionException.ThrowIfInvalidMaxLength(maxLength);
            _option.MaxLength = maxLength;
            return this;
        }

        /// <summary>
        /// Set's the channel types for the option
        /// </summary>
        /// <param name="types">Types of channels the option allows</param>
        /// <returns>This</returns>
        /// <exception cref="Exception">Thrown if <see cref="CommandOptionType"/> is not Channel</exception>
        public ApplicationCommandOptionBuilder ChannelTypes(List<ChannelType> types)
        {
            InvalidCommandOptionException.ThrowIfInvalidChannelType(_option.Type);
            _option.ChannelTypes = types;
            return this;
        }

        /// <summary>
        /// Adds a choice to this option of type string
        /// </summary>
        /// <param name="name">Name of the choice</param>
        /// <param name="value">Value of the choice</param>
        /// <param name="nameLocalizations">Localizations for the name</param>
        /// <returns>This</returns>
        /// <exception cref="Exception">Thrown if the option type is not string</exception>
        public ApplicationCommandOptionBuilder AddChoice(string name, string value, Hash<string, string> nameLocalizations = null)
        {
            InvalidCommandOptionChoiceException.ThrowIfInvalidType(_option.Type, CommandOptionType.String);
            InvalidCommandOptionChoiceException.ThrowIfInvalidStringValue(name);
            return AddChoiceInternal(name, value, nameLocalizations);
        }

        /// <summary>
        /// Adds a choice to this option of type int
        /// </summary>
        /// <param name="name">Name of the choice</param>
        /// <param name="value">Value of the choice</param>
        /// <param name="nameLocalizations">Localizations for the name</param>
        /// <returns>This</returns>
        /// <exception cref="Exception">Thrown if the option type is not int</exception>
        public ApplicationCommandOptionBuilder AddChoice(string name, int value, Hash<string, string> nameLocalizations = null)
        {
            InvalidCommandOptionChoiceException.ThrowIfInvalidType(_option.Type, CommandOptionType.Integer);
            return AddChoiceInternal(name, value, nameLocalizations);
        }

        /// <summary>
        /// Adds a choice to this option of type double
        /// </summary>
        /// <param name="name">Name of the choice</param>
        /// <param name="value">Value of the choice</param>
        /// <param name="nameLocalizations">Localizations for the name</param>
        /// <returns>This</returns>
        /// <exception cref="Exception">Thrown if the option type is not double</exception>
        public ApplicationCommandOptionBuilder AddChoice(string name, double value, Hash<string, string> nameLocalizations = null)
        {
            InvalidCommandOptionChoiceException.ThrowIfInvalidType(_option.Type, CommandOptionType.Number);
            return AddChoiceInternal(name, value, nameLocalizations);
        }

        private ApplicationCommandOptionBuilder AddChoiceInternal(string name, object value, Hash<string, string> nameLocalizations)
        {
            InvalidCommandOptionChoiceException.ThrowIfInvalidName(name, false);
            _option.Choices ??= new List<CommandOptionChoice>();
            InvalidCommandOptionChoiceException.ThrowIfMaxChoices(_option.Choices.Count);

            _option.Choices.Add(new CommandOptionChoice(name, value, nameLocalizations));

            return this;
        }
    }
}