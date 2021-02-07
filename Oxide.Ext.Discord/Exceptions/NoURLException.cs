using System;

namespace uMod.Ext.Discord.Exceptions
{
    public class NoURLException : Exception
    {
        public NoURLException() : base("Error! No Web Socket Url was found.")
        {
        }
    }
}
