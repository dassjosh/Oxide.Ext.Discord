namespace Oxide.Ext.Discord.Exceptions
{
    /// <summary>
    /// Exception returns from promise when a request is cancelled
    /// </summary>
    public class RequestCancelledException : BaseDiscordException
    {
        internal RequestCancelledException() : base("The request was cancelled") { }
    }
}