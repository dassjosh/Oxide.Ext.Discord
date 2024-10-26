using System;
using System.Collections.Generic;
using System.Linq;
using Oxide.Core.Libraries.Covalence;
using Oxide.Core.Plugins;
using Oxide.Ext.Discord.Cache;
using Oxide.Ext.Discord.Entities;
using Oxide.Ext.Discord.Exceptions;
using Oxide.Ext.Discord.Libraries;

namespace Oxide.Ext.Discord.Builders
{
    /// <summary>
    /// Builder for Auto Complete Interaction
    /// </summary>
    public class InteractionAutoCompleteBuilder
    {
        private readonly InteractionAutoCompleteMessage _message;
        
        /// <summary>
        /// Number of added choices
        /// </summary>
        public int Count => _message.Choices.Count;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="interaction">Interaction this build is for</param>
        /// <param name="message">Starting <see cref="InteractionAutoCompleteMessage"/></param>
        public InteractionAutoCompleteBuilder(DiscordInteraction interaction, InteractionAutoCompleteMessage message = null)
        {
            InteractionResponseBuilderException.ThrowIfInteractionIsNotAutoComplete(interaction.Type);
            _message = message ?? new InteractionAutoCompleteMessage();
            _message.Choices ??= new List<CommandOptionChoice>();
        }

        /// <summary>
        /// Adds a <see cref="CommandOptionChoice"/> to the response
        /// </summary>
        /// <param name="name">Name of the choice</param>
        /// <param name="value">Value of the choice</param>
        /// <returns>This</returns>
        public InteractionAutoCompleteBuilder AddChoice(string name, object value)
        {
            InvalidAutoCompleteChoiceException.ThrowIfInvalidName(name);
            InvalidAutoCompleteChoiceException.ThrowIfInvalidValue(value);
            return AddChoice(new CommandOptionChoice(name, value));
        }

        /// <summary>
        /// Adds a <see cref="CommandOptionChoice"/> to the response
        /// </summary>
        /// <param name="name">Name of the choice</param>
        /// <param name="value">Value of the choice</param>
        /// <param name="plugin">Plugin to lookup the langkey for</param>
        /// <param name="langKey">Lang key for the name</param>
        /// <returns>This</returns>
        public InteractionAutoCompleteBuilder AddChoice(string name, object value, Plugin plugin, string langKey)
        {
            InvalidAutoCompleteChoiceException.ThrowIfInvalidName(name);
            InvalidAutoCompleteChoiceException.ThrowIfInvalidValue(value);
            return AddChoice(new CommandOptionChoice(name, value,  DiscordLocales.Instance.GetDiscordLocalizations(plugin, langKey)));
        }
        
        /// <summary>
        /// Adds a <see cref="CommandOptionChoice"/> to the response
        /// </summary>
        /// <param name="choice">Choice to be added</param>
        /// <returns>This</returns>
        public InteractionAutoCompleteBuilder AddChoice(CommandOptionChoice choice)
        {
            if (choice == null) throw new ArgumentNullException(nameof(choice));
            InvalidCommandOptionChoiceException.ThrowIfMaxChoices(_message.Choices.Count + 1);
            _message.Choices.Add(choice);
            return this;
        }
        
        /// <summary>
        /// Adds a collection of <see cref="CommandOptionChoice"/> to the response
        /// </summary>
        /// <param name="choices">Choices to be added</param>
        /// <returns>This</returns>
        public InteractionAutoCompleteBuilder AddChoices(ICollection<CommandOptionChoice> choices)
        {
            if (choices == null) throw new ArgumentNullException(nameof(choices));

            InvalidCommandOptionChoiceException.ThrowIfMaxChoices(_message.Choices.Count + choices.Count);
            _message.Choices.AddRange(choices);
            return this;
        }

        /// <summary>
        /// Returns if the Auto Complete can add any more choices
        /// </summary>
        /// <returns></returns>
        public bool CanAddChoice() => Count < 25;

        /// <summary>
        /// Returns the built message
        /// </summary>
        /// <returns><see cref="InteractionAutoCompleteMessage"/></returns>
        public InteractionAutoCompleteMessage Build() => _message;

        #region Oxide
        /// <summary>
        /// Adds Oxide Groups to the AutoComplete
        /// </summary>
        /// <param name="filter">String to filter by</param>
        /// <param name="comparison"><see cref="StringComparison"/> to use</param>
        /// <param name="search"><see cref="AutoCompleteSearchMode"/> Filter search mode</param>
        public void AddGroups(string filter = null, StringComparison comparison = StringComparison.OrdinalIgnoreCase, AutoCompleteSearchMode search = AutoCompleteSearchMode.StartsWith)
        {
            AddList(OxideLibrary.Instance.Permission.GetGroups(), filter, comparison, search);
        }
        
        /// <summary>
        /// Adds Oxide Permissions to the AutoComplete
        /// </summary>
        /// <param name="filter">String to filter by</param>
        /// <param name="comparison"><see cref="StringComparison"/> to use</param>
        /// <param name="search"><see cref="AutoCompleteSearchMode"/> Filter search mode</param>
        public void AddPermissions(string filter = null, StringComparison comparison = StringComparison.OrdinalIgnoreCase, AutoCompleteSearchMode search = AutoCompleteSearchMode.StartsWith)
        {
            AddList(OxideLibrary.Instance.Permission.GetPermissions(), filter, comparison, search);
        }

        /// <summary>
        /// Adds The List of Groups that have this permission
        /// </summary>
        /// <param name="permission">Permission to get groups for</param>
        /// <param name="filter">String to filter by</param>
        /// <param name="comparison"><see cref="StringComparison"/> to use</param>
        /// <param name="search"><see cref="AutoCompleteSearchMode"/> Filter search mode</param>
        public void AddGroupsWithPermission(string permission, string filter = null, StringComparison comparison = StringComparison.OrdinalIgnoreCase, AutoCompleteSearchMode search = AutoCompleteSearchMode.StartsWith)
        {
            AddList(OxideLibrary.Instance.Permission.GetPermissionGroups(permission), filter, comparison, search);
        }
        
        /// <summary>
        /// Adds The List of Groups that have this permission
        /// </summary>
        /// <param name="permission">Permission to get groups for</param>
        /// <param name="filter">String to filter by</param>
        /// <param name="comparison"><see cref="StringComparison"/> to use</param>
        /// <param name="search"><see cref="AutoCompleteSearchMode"/> Filter search mode</param>
        public void AddGroupsWithoutPermission(string permission, string filter = null, StringComparison comparison = StringComparison.OrdinalIgnoreCase, AutoCompleteSearchMode search = AutoCompleteSearchMode.StartsWith)
        {
            string[] groups = OxideLibrary.Instance.Permission.GetPermissionGroups(permission);
            AddList(OxideLibrary.Instance.Permission.GetGroups().Except(groups), filter, comparison, search);
        }
        
        /// <summary>
        /// Adds List of Permissions that are in the given group
        /// </summary>
        /// <param name="group">Group to get permissions for</param>
        /// <param name="filter">Permission filter</param>
        /// <param name="comparison"><see cref="StringComparison"/> to use</param>
        /// <param name="search"><see cref="AutoCompleteSearchMode"/> Filter search mode</param>
        public void AddPermissionsInGroup(string group, string filter = null, StringComparison comparison = StringComparison.OrdinalIgnoreCase, AutoCompleteSearchMode search = AutoCompleteSearchMode.StartsWith)
        {
            AddList(OxideLibrary.Instance.Permission.GetGroupPermissions(group), filter, comparison, search);
        }
        
        /// <summary>
        /// Adds a List of Permissions that are not in a given group
        /// </summary>
        /// <param name="group">Group that doesn't have the permissions</param>
        /// <param name="filter">Permission filter</param>
        /// <param name="comparison"><see cref="StringComparison"/> to use</param>
        /// <param name="search"><see cref="AutoCompleteSearchMode"/> Filter search mode</param>
        public void AddPermissionsNotInGroup(string group, string filter = null, StringComparison comparison = StringComparison.OrdinalIgnoreCase, AutoCompleteSearchMode search = AutoCompleteSearchMode.StartsWith)
        {
            string[] perms = OxideLibrary.Instance.Permission.GetPermissions();
            AddList(perms.Except(OxideLibrary.Instance.Permission.GetGroupPermissions(group)), filter, comparison, search);
        }

        /// <summary>
        /// Adds The List of Groups that playerId has
        /// </summary>
        /// <param name="playerId">Player ID to get groups for</param>
        /// <param name="filter">String to filter by</param>
        /// <param name="comparison"><see cref="StringComparison"/> to use</param>
        /// <param name="search"><see cref="AutoCompleteSearchMode"/> Filter search mode</param>
        public void AddGroupsWithPlayer(string playerId, string filter = null, StringComparison comparison = StringComparison.OrdinalIgnoreCase, AutoCompleteSearchMode search = AutoCompleteSearchMode.StartsWith)
        {
            AddList(OxideLibrary.Instance.Permission.GetUserGroups(playerId), filter, comparison, search);
        }
        
        /// <summary>
        /// Adds The List of Groups that playerId has
        /// </summary>
        /// <param name="playerId">Player ID to get groups for</param>
        /// <param name="filter">String to filter by</param>
        /// <param name="comparison"><see cref="StringComparison"/> to use</param>
        /// <param name="search"><see cref="AutoCompleteSearchMode"/> Filter search mode</param>
        public void AddGroupsWithoutPlayer(string playerId, string filter = null, StringComparison comparison = StringComparison.OrdinalIgnoreCase, AutoCompleteSearchMode search = AutoCompleteSearchMode.StartsWith)
        {
            string[] groups = OxideLibrary.Instance.Permission.GetGroups();
            AddList(groups.Except(OxideLibrary.Instance.Permission.GetUserGroups(playerId)), filter, comparison, search);
        }
        
        /// <summary>
        /// Adds The List of Permissions that playerId has
        /// </summary>
        /// <param name="playerId">Player ID to get permissions for</param>
        /// <param name="filter">String to filter by</param>
        /// <param name="comparison"><see cref="StringComparison"/> to use</param>
        /// <param name="search"><see cref="AutoCompleteSearchMode"/> Filter search mode</param>
        public void AddPermissionsPlayerIn(string playerId, string filter = null, StringComparison comparison = StringComparison.OrdinalIgnoreCase, AutoCompleteSearchMode search = AutoCompleteSearchMode.StartsWith)
        {
            AddList(OxideLibrary.Instance.Permission.GetUserPermissions(playerId), filter, comparison, search);
        }
        
        /// <summary>
        /// Adds The List of Permissions that playerId does not have
        /// </summary>
        /// <param name="playerId">Player ID to get permissions for</param>
        /// <param name="filter">String to filter by</param>
        /// <param name="comparison"><see cref="StringComparison"/> to use</param>
        /// <param name="search"><see cref="AutoCompleteSearchMode"/> Filter search mode</param>
        public void AddPermissionsPlayerNotIn(string playerId, string filter = null, StringComparison comparison = StringComparison.OrdinalIgnoreCase, AutoCompleteSearchMode search = AutoCompleteSearchMode.StartsWith)
        {
            string[] perms = OxideLibrary.Instance.Permission.GetPermissions();
            AddList(perms.Except(OxideLibrary.Instance.Permission.GetUserPermissions(playerId)), filter, comparison, search);
        }

        /// <summary>
        /// Adds Online Players to the list
        /// </summary>
        /// <param name="filter">String to filter by</param>
        /// <param name="formatter">Formatter for the player name</param>
        public void AddOnlinePlayers(string filter = null, PlayerNameFormatter formatter = null)
        {
            AddPlayerList(ServerPlayerCache.Instance.GetOnlinePlayers(filter), formatter ?? PlayerNameFormatter.Default, null);
        }
        
        /// <summary>
        /// Adds Online Players to the list
        /// </summary>
        /// <param name="filter">String to filter by</param>
        /// <param name="formatter">Formatter for the player name</param>
        public void AddOfflinePlayers(string filter = null, PlayerNameFormatter formatter = null)
        {
            AddPlayerList(ServerPlayerCache.Instance.GetAllPlayers(filter).Where(p => !p.IsConnected), formatter ?? PlayerNameFormatter.Default, null);
        }
        
        /// <summary>
        /// Adds Online Players to the list first
        /// If there is still space add Offline Players
        /// </summary>
        /// <param name="filter">String to filter by</param>
        /// <param name="formatter">Formatter for the player name</param>
        public void AddAllOnlineFirstPlayers(string filter = null, PlayerNameFormatter formatter = null)
        {
            HashSet<string> addedList = DiscordPool.Internal.GetHashSet<string>();
            AddPlayerList(ServerPlayerCache.Instance.GetOnlinePlayers(filter), formatter ?? PlayerNameFormatter.Default, addedList);
            AddPlayerList(ServerPlayerCache.Instance.GetAllPlayers(filter), formatter ?? PlayerNameFormatter.Default, addedList);
            DiscordPool.Internal.FreeHashSet(addedList);
        }

        /// <summary>
        /// Adds Any Player to the list
        /// </summary>
        /// <param name="filter">String to filter by</param>
        /// <param name="formatter">Formatter for the player name</param>
        public void AddAllPlayers(string filter = null, PlayerNameFormatter formatter = null)
        {
            AddPlayerList(ServerPlayerCache.Instance.GetAllPlayers(filter), formatter ?? PlayerNameFormatter.Default, null);
        }
        
        /// <summary>
        /// Add a custom list of players that are filtered by player name or player ID
        /// </summary>
        /// <param name="filter">Filter to filter by</param>
        /// <param name="list">Custom list of players</param>
        /// <param name="formatter">Formatter for the player name</param>
        /// <param name="addedList">List of already added players</param>
        /// <param name="search">Mode to match on player name</param>
        public void AddPlayerList(string filter, IEnumerable<IPlayer> list, PlayerNameFormatter formatter, HashSet<string> addedList = null, AutoCompleteSearchMode search = AutoCompleteSearchMode.Contains)
        {
            if (!CanAddChoice())
            {
                return;
            }
            
            foreach (IPlayer player in list)
            {
                if (!IsMatch(player.Name, filter, StringComparison.OrdinalIgnoreCase, search) && player.Id != filter)
                {
                    continue;
                }

                if (!AddPlayer(player, formatter, addedList))
                {
                    return;
                }
            }
        }

        /// <summary>
        /// Adds a player by player ID to the list
        /// </summary>
        /// <param name="playerId">Player ID to add</param>
        /// <param name="formatter">Formatter for the player name</param>
        public void AddByPlayerId(string playerId, PlayerNameFormatter formatter = null)
        {
            IPlayer player = ServerPlayerCache.Instance.GetPlayerById(playerId);
            if (player != null)
            {
                AddPlayer(player, formatter ?? PlayerNameFormatter.Default, null);
            }
        }

        /// <summary>
        /// Adds a list of plugins that can be loaded
        /// </summary>
        /// <param name="filter">String to filter by</param>
        /// <param name="comparison"><see cref="StringComparison"/> to use</param>
        /// <param name="search"><see cref="AutoCompleteSearchMode"/> Filter search mode</param>
        public void AddLoadablePlugins(string filter = null, StringComparison comparison = StringComparison.OrdinalIgnoreCase, AutoCompleteSearchMode search = AutoCompleteSearchMode.StartsWith)
        {
            AddList(DiscordPluginCache.Instance.GetLoadablePlugins(), filter, comparison, search);
        }
        
        /// <summary>
        /// Adds a list of all plugins in the oxide/plugins folder. Includes loaded and unloaded.
        /// </summary>
        /// <param name="filter">String to filter by</param>
        /// <param name="comparison"><see cref="StringComparison"/> to use</param>
        /// <param name="search"><see cref="AutoCompleteSearchMode"/> Filter search mode</param>
        public void AddAllPlugins(string filter = null, StringComparison comparison = StringComparison.OrdinalIgnoreCase, AutoCompleteSearchMode search = AutoCompleteSearchMode.StartsWith)
        {
            AddList(DiscordPluginCache.Instance.GetAllPlugins(), filter, comparison, search);
        }

        /// <summary>
        /// Adds a list of plugins that are currently loaded
        /// </summary>
        /// <param name="filter">String to filter by</param>
        /// <param name="comparison"><see cref="StringComparison"/> to use</param>
        /// <param name="search"><see cref="AutoCompleteSearchMode"/> Filter search mode</param>
        public void AddLoadedPlugins(string filter = null, StringComparison comparison = StringComparison.OrdinalIgnoreCase, AutoCompleteSearchMode search = AutoCompleteSearchMode.StartsWith)
        {
            AddList(DiscordPluginCache.Instance.GetLoadedPlugins(), filter, comparison, search);
        }

        private void AddList(IEnumerable<string> list, string filter, StringComparison comparison, AutoCompleteSearchMode search)
        {
            if (!CanAddChoice())
            {
                return;
            }
            
            List<CommandOptionChoice> choices = _message.Choices;
            foreach (string value in list)
            {
                if (IsMatch(value, filter, comparison, search))
                {
                    choices.Add(new CommandOptionChoice(value, value));
                    if (!CanAddChoice())
                    {
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// Adds a list of players from a custom list
        /// </summary>
        /// <param name="list">Custom list of players</param>
        /// <param name="formatter">Formatter for the player name</param>
        /// <param name="addedList">List of already added players</param>
        public void AddPlayerList(IEnumerable<IPlayer> list, PlayerNameFormatter formatter, HashSet<string> addedList)
        {
            if (!CanAddChoice())
            {
                return;
            }
            
            foreach (IPlayer player in list)
            {
                if (!AddPlayer(player, formatter, addedList))
                {
                    return;
                }
            }
        }
        
        private bool AddPlayer(IPlayer player, PlayerNameFormatter formatter, HashSet<string> addedList)
        {
            if (!CanAddChoice())
            {
                return false;
            }
            
            string name = formatter.Format(player);
            if (addedList == null || addedList.Add(player.Id))
            {
                _message.Choices.Add(new CommandOptionChoice(name, player.Id));
                if (!CanAddChoice())
                {
                    return false;
                }
            }
            
            return true;
        }

        private static bool IsMatch(string value, string filter, StringComparison comparison, AutoCompleteSearchMode search)
        {
            if (string.IsNullOrEmpty(filter))
            {
                return true;
            }

            return search switch
            {
                AutoCompleteSearchMode.StartsWith => value.StartsWith(filter, comparison),
                AutoCompleteSearchMode.Contains => value.IndexOf(filter, comparison) != -1,
                AutoCompleteSearchMode.EndsWith => value.EndsWith(filter, comparison),
                _ => throw new ArgumentOutOfRangeException(nameof(search), search, null)
            };
        }
        #endregion
    }
}