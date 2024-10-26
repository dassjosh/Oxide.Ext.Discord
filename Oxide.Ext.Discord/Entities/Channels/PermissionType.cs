namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents the type of permission
    /// </summary>
    public enum PermissionType : byte
    {
        /// <summary>
        /// This permission belongs to a role
        /// </summary>
        Role = 0,
        
        /// <summary>
        /// This permission belongs to a member
        /// </summary>
        Member = 1
    }
}