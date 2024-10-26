using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents <a href="https://discord.com/developers/docs/interactions/application-commands#application-command-object-application-command-interaction-data-option-structure">Application Command Interaction Data Option</a>
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class InteractionDataOption
    {
        /// <summary>
        /// The name of the parameter
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
        
        /// <summary>
        /// Value of ApplicationCommandOptionType
        /// </summary>
        [JsonProperty("type")]
        public CommandOptionType Type { get; set; }
        
        /// <summary>
        /// The value of the option resulting from user input
        /// Value can be string, integer, or double, or boolean type
        /// </summary>
        [JsonProperty("value")]
        private object Value { get; set; }

        /// <summary>
        /// Returns the value as a string
        /// </summary>
        /// <returns></returns>
        public string GetString() => (string)Value ?? string.Empty;

        /// <summary>
        /// Returns the value as an int
        /// </summary>
        /// <returns></returns>
        public int GetInt() => Convert.ToInt32(Value);

        /// <summary>
        /// Returns the value as a bool
        /// </summary>
        /// <returns></returns>
        public bool GetBool() => Convert.ToBoolean(Value);

        /// <summary>
        /// Returns the value as a double
        /// </summary>
        /// <returns></returns>
        public double GetNumber() => Convert.ToDouble(Value);

        /// <summary>
        /// Returns the value as a Snowflake
        /// </summary>
        /// <returns></returns>
        public Snowflake GetSnowflake() => new(Convert.ToUInt64(Value));

        /// <summary>
        /// Present if this option is a group or subcommand
        /// See <see cref="InteractionDataOption"/>
        /// </summary>
        [JsonProperty("options")]
        public List<InteractionDataOption> Options { get; set; }
        
        /// <summary>
        /// True if this option is the currently focused option for autocomplete
        /// </summary>
        [JsonProperty("focused")]
        public bool? Focused { get; set; }
    }
}