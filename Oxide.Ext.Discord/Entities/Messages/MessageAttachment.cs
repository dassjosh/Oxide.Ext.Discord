﻿using Newtonsoft.Json;
using Oxide.Ext.Discord.Interfaces;

namespace Oxide.Ext.Discord.Entities;

/// <summary>
/// Represents a message <a href="https://discord.com/developers/docs/resources/channel#attachment-object">Attachment Structure</a>
/// </summary>
[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
public class MessageAttachment : ISnowflakeEntity
{
    /// <summary>
    /// Attachment ID
    /// </summary>
    [JsonProperty("id")]
    public Snowflake Id { get; set; }

    /// <summary>
    /// Name of file attached
    /// </summary>
    [JsonProperty("filename")]
    public string Filename { get; set; }
        
    /// <summary>
    /// Title of the file      
    /// </summary>
    [JsonProperty("title")]
    public string Title { get; set; }
        
    /// <summary>
    /// Description for the file
    /// </summary>
    [JsonProperty("description")]
    public string Description { get; set; }
        
    /// <summary>
    /// The attachment's <a href="https://en.wikipedia.org/wiki/Media_type">media type</a>
    /// </summary>
    [JsonProperty("content_type")]
    public string ContentType { get; set; }

    /// <summary>
    /// Size of file in bytes
    /// </summary>
    [JsonProperty("size")]
    public int? Size { get; set; }

    /// <summary>
    /// Source url of file
    /// </summary>
    [JsonProperty("url")]
    public string Url { get; set; }

    /// <summary>
    /// A proxied url of file
    /// </summary>
    [JsonProperty("proxy_url")]
    public string ProxyUrl { get; set; }

    /// <summary>
    /// Height of file (if image)
    /// </summary>
    [JsonProperty("height")]
    public int? Height { get; set; }

    /// <summary>
    /// Width of file (if image)
    /// </summary>
    [JsonProperty("width")]
    public int? Width { get; set; }
        
    /// <summary>
    /// Whether this attachment is ephemeral
    /// </summary>
    [JsonProperty("ephemeral")]
    public bool? Ephemeral { get; set; }
        
    /// <summary>
    /// The duration of the audio file (currently for voice messages)
    /// </summary>
    [JsonProperty("duration_secs")]
    public float? DurationSecs { get; set; }
        
    /// <summary>
    /// base64 encoded bytearray representing a sampled waveform (currently for voice messages)
    /// </summary>
    [JsonProperty("waveform")]
    public string Waveform { get; set; }
        
    /// <summary>
    /// Attachment Flags
    /// </summary>
    [JsonProperty("flags")]
    public AttachmentFlags? Flags { get; set; }
}