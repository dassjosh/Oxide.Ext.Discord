using System;

namespace uMod.Ext.Discord.Exceptions
{
    public class SettingsNullException : Exception
    {
        public SettingsNullException() : base("Error! Please supply a valid settings object!")
        {
        }
    }
}
