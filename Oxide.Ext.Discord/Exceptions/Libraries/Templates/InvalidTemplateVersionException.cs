namespace Oxide.Ext.Discord.Exceptions
{
    /// <summary>
    /// Thrown when the minimum template version is higher than the current template version
    /// </summary>
    public class InvalidTemplateVersionException : BaseDiscordException
    {
        internal InvalidTemplateVersionException(string message) : base(message) { }
    }
}