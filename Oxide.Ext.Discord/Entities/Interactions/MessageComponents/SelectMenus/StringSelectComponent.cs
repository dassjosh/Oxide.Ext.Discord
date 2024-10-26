using System.Collections.Generic;
using Newtonsoft.Json;
using Oxide.Ext.Discord.Exceptions;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents a <a href="https://discord.com/developers/docs/interactions/message-components#select-menus">Select Menus Component</a> within discord.
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class StringSelectComponent : BaseSelectMenuComponent
    {
        /// <summary>
        /// The choices in the select
        /// Max 25 options
        /// </summary>
        [JsonProperty("options")]
        public List<SelectMenuOption> Options { get; } = new();

        /// <summary>
        /// Select Menu Component Constructor
        /// </summary>
        public StringSelectComponent() : base(MessageComponentType.StringSelect) { }

        ///<inheritdoc />
        public override void Validate()
        {
            base.Validate();
            if (Options != null)
            {
                InvalidSelectMenuComponentException.ThrowIfInvalidSelectMenuOptionCount(Options.Count);
                for (int index = 0; index < Options.Count; index++)
                {
                    SelectMenuOption option = Options[index];
                    option.Validate();
                }
            }
        }
    }
}