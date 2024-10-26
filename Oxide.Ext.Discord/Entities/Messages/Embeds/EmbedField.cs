using Newtonsoft.Json;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents <a href="https://discord.com/developers/docs/resources/channel#embed-object-embed-field-structure">Embed Field Structure</a>
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class EmbedField
    {
        /// <summary>
        /// Represents a blank character to be used in embeds for empty text
        /// </summary>
        public const string Blank = "\u200b";
        
        /// <summary>
        /// Name of the field
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Value of the field
        /// </summary>
        [JsonProperty("value")]
        public string Value { get; set; }

        /// <summary>
        /// Whether or not this field should display inline
        /// </summary>
        [JsonProperty("inline")]
        public bool Inline { get; set; }

        /// <summary>
        /// Embed Field constructor
        /// </summary>
        public EmbedField() { }
        
        /// <summary>
        /// Embed Field constructor
        /// </summary>
        /// <param name="name">Field Name</param>
        /// <param name="value">Field Value</param>
        /// <param name="inline">Should field be inlined</param>
        public EmbedField(string name, string value, bool inline)
        {
            Name = !string.IsNullOrEmpty(name) ? name : Blank;
            Value = !string.IsNullOrEmpty(value) ? value : Blank;
            Inline = inline;
        }
    }
}