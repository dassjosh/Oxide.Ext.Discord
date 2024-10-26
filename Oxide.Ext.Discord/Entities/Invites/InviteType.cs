namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents <a href="https://discord.com/developers/docs/resources/invite#invite-types">Invite Types</a>
    /// </summary>
    public enum InviteType : byte
    {
        /// <summary>
        /// Guild Invite
        /// </summary>
        Guild = 0,
        
        /// <summary>
        /// Guild Invite
        /// </summary>
        GroupDm = 1,
        
        /// <summary>
        /// Guild Invite
        /// </summary>
        Friend = 2,
    }
}