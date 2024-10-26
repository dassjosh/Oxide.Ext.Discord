using System.Collections.Concurrent;
using System.Collections.Generic;
using Oxide.Core.Plugins;
using Oxide.Ext.Discord.Entities;
using Oxide.Ext.Discord.Extensions;
using Oxide.Ext.Discord.Interfaces;
using Oxide.Ext.Discord.Logging;
using Oxide.Ext.Discord.Plugins;

namespace Oxide.Ext.Discord.Libraries
{
    internal class AppCommandHandler
    {
        public bool IsEmpty => _commands.Count == 0;
        private readonly ConcurrentDictionary<AppCommandId, BaseAppCommand> _commands = new();
        private readonly List<ComponentCommand> _components = new();
        private readonly ILogger _logger;

        public AppCommandHandler(ILogger logger) 
        {
            _logger = logger;
        }

        public BaseAppCommand GetCommandById(AppCommandId id)
        {
            return id.Type switch
            {
                InteractionType.ApplicationCommand or InteractionType.ApplicationCommandAutoComplete => _commands.GetValueOrDefault(id),
                InteractionType.MessageComponent or InteractionType.ModalSubmit => GetComponentCommand(id),
                _ => null
            };

        }

        public void AddAppCommand(BaseAppCommand command)
        {
            if (command is ComponentCommand component)
            {
                _components.Add(component);
            }
            else
            {
                _commands[command.CommandId] = command;
            }
            
            _logger.Verbose($"{nameof(AppCommandHandler)}.{nameof(AddAppCommand)} Command: {{0}}", command.CommandId);
        }

        public bool RemoveAppCommand(BaseAppCommand command)
        {
            _logger.Verbose($"{nameof(AppCommandHandler)}.{nameof(RemoveAppCommand)} Command: {{0}}", command.CommandId);
            if (command is ComponentCommand component)
            {
                return _components.Remove(component);
            }
            
            return _commands.TryRemove(command.CommandId, out _);
        }

        private ComponentCommand GetComponentCommand(AppCommandId id)
        {
            for (int index = 0; index < _components.Count; index++)
            {
                ComponentCommand command = _components[index];
                if (command.IsForCommand(id))
                {
                    return command;
                }
            }

            return null;
        }

        public IEnumerable<BaseAppCommand> GetCommandsForPlugin(Plugin plugin)
        {
            PluginId id = plugin.Id();
            foreach (BaseAppCommand command in _commands.Values)
            {
                if (command.IsForPlugin(id))
                {
                    yield return command;
                }
            }

            for (int index = 0; index < _components.Count; index++)
            {
                ComponentCommand command = _components[index];
                if (command.IsForPlugin(id))
                {
                    yield return command;
                }
            }
        }

        public IEnumerable<BaseAppCommand> GetCommands()
        {
            foreach (BaseAppCommand command in _commands.Values)
            {
                yield return command;
            }
            
            for (int index = 0; index < _components.Count; index++)
            {
                yield return _components[index];
            }
        }
    }
}