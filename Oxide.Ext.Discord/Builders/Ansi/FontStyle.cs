using System;

namespace Oxide.Ext.Discord.Builders.Ansi
{
    /// <summary>
    /// Font Styles for ANSI text
    /// </summary>
    [Flags]
    public enum FontStyle : byte
    {
        /// <summary>
        /// Default
        /// </summary>
        Default = 0,
        
        /// <summary>
        /// Bold
        /// </summary>
        Bold = 1 << 1,
        
        /// <summary>
        /// Underline
        /// </summary>
        Underline = 1 << 2
    }
}