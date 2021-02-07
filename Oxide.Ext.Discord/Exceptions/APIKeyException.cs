using System;

namespace uMod.Ext.Discord.Exceptions
{
    public class APIKeyException : Exception
    {
        public APIKeyException() : base("Error! Please supply a valid API key!")
        {
        }
    }
}
