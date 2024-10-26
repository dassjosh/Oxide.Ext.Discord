using System.Collections.Generic;
using Oxide.Ext.Discord.Clients;
using Oxide.Ext.Discord.Entities;
using Oxide.Ext.Discord.Libraries;

namespace Oxide.Ext.Discord.Plugins
{
    internal partial class DiscordExtensionCore
    {
        private void CreateTemplates()
        {
            DiscordMessageTemplate success = CreateTemplateEmbed($"You have successfully deleted application command {DefaultKeys.AppCommand.Name}", DiscordColor.Success);
            DiscordExtension.DiscordMessageTemplates.RegisterLocalizedTemplateAsync(this, TemplateKeys.Commands.Delete.Success, success, new TemplateVersion(1, 0, 0), new TemplateVersion(1, 0, 0));
            
            DiscordMessageTemplate deleteError = CreateTemplateEmbed($"An error occured deleting command {DefaultKeys.AppCommand.Name}. Please try the command again. \nError: {DefaultKeys.ResponseError.Message}", DiscordColor.Danger);
            DiscordExtension.DiscordMessageTemplates.RegisterLocalizedTemplateAsync(this, TemplateKeys.Commands.Delete.Errors.DeleteCommandError, deleteError, new TemplateVersion(1, 0, 0), new TemplateVersion(1, 0, 0));
            
            DiscordMessageTemplate commandNotFound = CreateTemplateEmbed("We failed to find a matching command. Please make sure you select a command from the drop down.", DiscordColor.Danger);
            DiscordExtension.DiscordMessageTemplates.RegisterLocalizedTemplateAsync(this, TemplateKeys.Commands.Delete.Errors.CommandIdNotFound, commandNotFound, new TemplateVersion(1, 0, 0), new TemplateVersion(1, 0, 0));
            
            DiscordMessageTemplate invalidSelection = CreateTemplateEmbed("You have selected an invalid command. Please try the command again and be sure to select an option from the drop down.", DiscordColor.Danger);
            DiscordExtension.DiscordMessageTemplates.RegisterLocalizedTemplateAsync(this, TemplateKeys.Commands.Delete.Errors.InvalidSelection, invalidSelection, new TemplateVersion(1, 0, 0), new TemplateVersion(1, 0, 0));
        }

        private DiscordMessageTemplate CreateTemplateEmbed(string description, DiscordColor color)
        {
            return new DiscordMessageTemplate
            {
                Embeds = new List<DiscordEmbedTemplate>
                {
                    new()
                    {
                        Description = description,
                        Color = color.ToHex()
                    }
                },
            };
        }

        private void SendTemplateMessage(DiscordClient client, TemplateKey key, DiscordInteraction interaction, PlaceholderData placeholders = null)
        {
            InteractionCallbackData message = new()
            {
                Flags = interaction.GuildId.HasValue ? MessageFlags.Ephemeral : null
            };
            DiscordMessageTemplate template = DiscordExtension.DiscordMessageTemplates.GetLocalizedTemplate(this, key, interaction);
            template.ToMessage(placeholders, message);
            interaction.CreateResponse(client, InteractionResponseType.ChannelMessageWithSource, message);
        }
    }
}