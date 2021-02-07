using System;

namespace uMod.Ext.Discord.Exceptions
{
    public class PluginNullException : Exception
    {
        public PluginNullException() : base("Error! Please supply a valid plugin object!")
        {
        }
    }
}
