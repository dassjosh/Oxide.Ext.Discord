using Oxide.Ext.Discord.Entities;

namespace Oxide.Ext.Discord.Connections;

/// <summary>
/// Represents the parsed Bot Token data
/// </summary>
public class BotTokenData
{
    /// <summary>
    /// Hidden Token. Used when Displaying
    /// </summary>
    public readonly string HiddenToken;
        
    /// <summary>
    /// Application ID of the token
    /// </summary>
    public readonly Snowflake ApplicationId;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="hiddenToken"></param>
    /// <param name="applicationId"></param>
    public BotTokenData(string hiddenToken, Snowflake applicationId)
    {
        HiddenToken = hiddenToken;
        ApplicationId = applicationId;
    }
}