using System;
using System.Collections.Generic;
using System.Linq;
using Oxide.Core.Plugins;
using Oxide.Ext.Discord.Attributes;
using Oxide.Ext.Discord.Builders;
using Oxide.Ext.Discord.Clients;
using Oxide.Ext.Discord.Entities;
using Oxide.Ext.Discord.Factory;
using Oxide.Ext.Discord.Libraries;
using Oxide.Ext.Discord.Logging;
using Oxide.Plugins;

namespace Oxide.Ext.Discord.Plugins
{
    internal partial class DiscordExtensionCore
    {
        private readonly Hash<Snowflake, CommandCache> _commandCache = new();
        private CommandCreate _create;
        private PluginSetup _setup;

        private void RegisterApplicationCommands()
        {
            _setup = new PluginSetup(this, DiscordExtension.GlobalLogger);
            ApplicationCommandBuilder builder = new ApplicationCommandBuilder(AppCommandKeys.DeCommand, "Discord Extension Commands", ApplicationCommandType.ChatInput)
                .AddDefaultPermissions(PermissionFlags.Administrator)
                .AddSubCommandGroup(AppCommandKeys.AppCommandGroup, "Application Commands",
                    group => group.AddSubCommand(AppCommandKeys.DeleteAppCommand, "Delete a registered application command",
                        sub => sub.AddOption(CommandOptionType.String, AppCommandKeys.DeleteAppCommandArgument, "Application Command To Delete",
                            options => options.AutoComplete().Required())));
            builder.AllowInDirectMessages(false);

            CommandCreate create = builder.Build();
            DiscordCommandLocalization localization = builder.BuildCommandLocalization();
            TemplateKey template = new(nameof(DiscordExtension));
            DiscordExtension.DiscordCommandLocalizations.RegisterCommandLocalizationAsync(this, template, localization, new TemplateVersion(1, 0, 0), new TemplateVersion(1, 0, 0)).Then(_ =>
            {
                DiscordExtension.DiscordCommandLocalizations.ApplyCommandLocalizationsAsync(this, create, template).Then(() =>
                {
                    _create = create;
                    foreach (BotClient client in BotClientFactory.Instance.Clients.ToList())
                    {
                        ApplyApplicationCommands(client);
                    }
                });
            });
        }

        public void ApplyApplicationCommands(BotClient client)
        {
            _logger.Verbose($"{nameof(DiscordExtensionCore)}.{nameof(ApplyApplicationCommands)} Create Exists: {{0}} Client Is Ready: {{1}}", _create != null, client.IsReady);
            if (_create != null && client.IsReady)
            {
                client.Application.CreateGlobalCommand(client.GetFirstClient(), _create);
                DiscordAppCommand.Instance.RegisterApplicationCommands(this, _setup, client.Connection);
            }
        }

        // ReSharper disable once UnusedMember.Local
        [HookMethod(nameof(HandleDeleteApplicationCommand))]
        [DiscordApplicationCommand(AppCommandKeys.DeCommand, AppCommandKeys.DeleteAppCommand, AppCommandKeys.AppCommandGroup)]
        private void HandleDeleteApplicationCommand(DiscordInteraction interaction, InteractionDataParsed parsed)
        {
            DiscordClient client = BotClientFactory.Instance.GetByApplicationId(interaction.ApplicationId)?.GetFirstClient();
            if (client == null)
            {
                return;
            }
            
            string argString = parsed.Args.GetString(AppCommandKeys.DeleteAppCommandArgument);
            string[] args = argString.Split(':');

            if (!Snowflake.TryParse(args.Length == 1 ? args[0] : args[1], out Snowflake commandId))
            {
                SendTemplateMessage(client, TemplateKeys.Commands.Delete.Errors.InvalidSelection, interaction);
                return;
            }
            
            Snowflake guildId = default;
            if (args.Length == 2 && !Snowflake.TryParse(args[0], out guildId))
            {
                SendTemplateMessage(client, TemplateKeys.Commands.Delete.Errors.InvalidSelection, interaction);
                return;
            }

            if (guildId.IsValid())
            {
                client.Bot.Application.GetGuildCommand(client, guildId, commandId)
                    .Then(command => DeleteGetSuccess(client, interaction, command))
                    .Catch<ResponseError>(ex => DeleteGetError(client, interaction, ex));
            }
            else
            {
                client.Bot.Application.GetGlobalCommand(client, commandId)                     
                    .Then(command => DeleteGetSuccess(client, interaction, command))
                    .Catch<ResponseError>(ex => DeleteGetError(client, interaction, ex));
            }
        }

        private void DeleteGetSuccess(DiscordClient client, DiscordInteraction interaction, DiscordApplicationCommand command)
        {
            command.Delete(client).Then(() =>
            {
                SendTemplateMessage(client, TemplateKeys.Commands.Delete.Success, interaction, GetPlaceholderData().AddCommand(command));
                _commandCache[interaction.ApplicationId]?.RemoveCommand(command.Id);
            }).Catch<ResponseError>(error =>
            {
                SendTemplateMessage(client, TemplateKeys.Commands.Delete.Errors.DeleteCommandError, interaction, GetPlaceholderData().AddCommand(command).AddRequestError(error));
            });
        }

        private void DeleteGetError(DiscordClient client, DiscordInteraction interaction, ResponseError error)
        {
            SendTemplateMessage(client, TemplateKeys.Commands.Delete.Success, interaction, GetPlaceholderData().AddRequestError(error));
        }

        // ReSharper disable once UnusedMember.Local
        [HookMethod(nameof(HandleDeleteApplicationAutoComplete))]
        [DiscordAutoCompleteCommand(AppCommandKeys.DeCommand, AppCommandKeys.DeleteAppCommandArgument, AppCommandKeys.DeleteAppCommand, AppCommandKeys.AppCommandGroup)]
        private void HandleDeleteApplicationAutoComplete(DiscordInteraction interaction, InteractionDataOption focused)
        {
            string search = focused.GetString();
            CommandCache cache = _commandCache[interaction.ApplicationId];
            InteractionAutoCompleteBuilder builder = new(interaction);
            BotClient client = BotClientFactory.Instance.GetByApplicationId(interaction.ApplicationId);
            if (client == null)
            {
                return;
            }
            
            if (cache is {IsExpired: false})
            {
                AddCommands(builder, search, cache.Commands);
                interaction.CreateResponse(client.GetFirstClient(), builder.Build());
                return;
            }

            CacheCommands(client, commandCache =>
            {
                AddCommands(builder, search, commandCache.Commands);
                interaction.CreateResponse(client.GetFirstClient(), builder.Build());
            });
        }
        
        private static void AddCommands(InteractionAutoCompleteBuilder builder, string search, List<DiscordApplicationCommand> commands)
        {
            for (int index = 0; index < commands.Count && builder.CanAddChoice(); index++)
            {
                DiscordApplicationCommand command = commands[index];
                if (!string.IsNullOrEmpty(search) && command.Name.IndexOf(search, StringComparison.OrdinalIgnoreCase) == -1)
                {
                    continue;
                }

                if (command.GuildId.HasValue && command.GuildId.Value.IsValid())
                {
                    builder.AddChoice($"[Guild] {command.Name}", $"{command.GuildId.Value}:{command.Id}");
                }
                else
                {
                    builder.AddChoice($"[Global] {command.Name}", command.Id.ToString());
                }
            }
        }

        private void CacheCommands(BotClient bot, Action<CommandCache> callback)
        {
            bot.Application.GetAllCommands(bot.GetFirstClient())
                .Then(commands =>
                {
                    CommandCache cache = new(commands);
                    _commandCache[bot.Application.Id] = cache;
                    callback.Invoke(cache);
                });
        }

        private PlaceholderData GetPlaceholderData()
        {
            return DiscordPlaceholders.Instance.CreateData(this);
        }
    }
}