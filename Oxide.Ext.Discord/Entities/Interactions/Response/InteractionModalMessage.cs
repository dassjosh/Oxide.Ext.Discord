using System.Collections.Generic;
using Newtonsoft.Json;

namespace Oxide.Ext.Discord.Entities;

/// <summary>
/// Represents an Interaction Modal Message
/// </summary>
public class InteractionModalMessage
{
    /// <summary>
    /// Developer-defined identifier for the interactable form
    /// Max 100 characters
    /// </summary>
    [JsonProperty("custom_id")]
    public string CustomId { get; set; }
        
    /// <summary>
    /// Title of the modal if Modal Response
    /// Max 45 characters
    /// </summary>
    [JsonProperty("title")]
    public string Title { get; set; }
        
    /// <summary>
    /// Used to create message components on a message
    /// </summary>
    [JsonProperty("components")]
    public List<ActionRowComponent> Components { get; set; }
}