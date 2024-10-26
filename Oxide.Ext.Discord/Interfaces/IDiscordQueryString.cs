namespace Oxide.Ext.Discord.Interfaces
{
    /// <summary>
    /// Interface for Discord Query Strings
    /// </summary>
    public interface IDiscordQueryString
    {
        /// <summary>
        /// Returns the request as a query string
        /// </summary>
        /// <returns></returns>
        string ToQueryString();
    }
}