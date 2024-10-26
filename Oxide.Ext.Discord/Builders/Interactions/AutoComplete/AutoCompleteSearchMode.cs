namespace Oxide.Ext.Discord.Builders
{
    /// <summary>
    /// AutoComplete Search Mode for <see cref="InteractionAutoCompleteBuilder"/>
    /// </summary>
    public enum AutoCompleteSearchMode : byte
    {
        /// <summary>
        /// Filter using StartsWith
        /// </summary>
        StartsWith,
        
        /// <summary>
        /// Filter using Contains
        /// </summary>
        Contains,
        
        /// <summary>
        /// Filter using EndsWith
        /// </summary>
        EndsWith
    }
}