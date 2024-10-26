using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Oxide.Ext.Discord.Libraries;

namespace Oxide.Ext.Discord.Extensions
{
    /// <summary>
    /// String Extension methods
    /// </summary>
    internal static class StringExt
    {
        public static bool ParseBool(this string input, out bool value)
        {
            if (bool.TryParse(input, out value))
            {
                return true;
            }

            if (char.IsNumber(input[0]))
            {
                value = input[0] != '0';
                return true;
            }

            return false;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string TrimIfLargerThan(this string str, int maxCharacters) => str.Length <= maxCharacters ? str : str.Substring(0, maxCharacters);

        /// <summary>
        /// Parses the specified command into uMod command format
        /// Sourced from CommandHandler.cs of uMod (https://gitlab.com/umod/core/core/-/blob/develop/src/Command/CommandHandler.cs)
        /// </summary>
        /// <param name="argStr"></param>
        /// <param name="command"></param>
        /// <param name="args"></param>
        public static void ParseCommand(this string argStr, out string command, out string[] args)
        {
            List<string> argList = DiscordPool.Internal.GetList<string>();
            StringBuilder stringBuilder = DiscordPool.Internal.GetStringBuilder();
            bool inLongArg = false;

            for (int index = 0; index < argStr.Length; index++)
            {
                char c = argStr[index];
                if (c == '"')
                {
                    if (inLongArg)
                    {
                        string arg = stringBuilder.Trim().ToString();
                        if (!string.IsNullOrEmpty(arg))
                        {
                            argList.Add(arg);
                        }

                        stringBuilder.Clear();
                        inLongArg = false;
                    }
                    else
                    {
                        inLongArg = true;
                    }
                }
                else if (char.IsWhiteSpace(c) && !inLongArg)
                {
                    string arg = stringBuilder.Trim().ToString();
                    if (!string.IsNullOrEmpty(arg))
                    {
                        argList.Add(arg);
                    }

                    stringBuilder.Clear();
                }
                else
                {
                    stringBuilder.Append(c);
                }
            }

            if (stringBuilder.Length > 0)
            {
                string arg = stringBuilder.Trim().ToString();
                if (!string.IsNullOrEmpty(arg))
                {
                    argList.Add(arg);
                }
            }

            if (argList.Count == 0)
            {
                command = null;
                args = null;
                return;
            }

            command = argList[0].ToLower();
            argList.RemoveAt(0);
            args = argList.ToArray();
            DiscordPool.Internal.FreeStringBuilder(stringBuilder);
            DiscordPool.Internal.FreeList(argList);
        }
    }
}