using System.Text;
using Oxide.Ext.Discord.Cache;
using Oxide.Ext.Discord.Libraries;

namespace Oxide.Ext.Discord.Builders.Ansi
{
    /// <summary>
    /// Builder for ANSI colored text
    /// </summary>
    public class AnsiBuilder
    {
        private readonly StringBuilder _sb;

        /// <summary>
        /// Constructor
        /// </summary>
        public AnsiBuilder()
        {
            _sb = DiscordPool.Internal.GetStringBuilder();
            _sb.AppendLine("```ansi");
        }

        /// <summary>
        /// Appends text with the given color, background, and font style
        /// </summary>
        /// <param name="text">Text to add</param>
        /// <param name="color">Color of the text</param>
        /// <param name="background">Background color of the text</param>
        /// <param name="style">Font style of the text</param>
        public void Append(string text, TextColor color = TextColor.Default, BackgroundColor background = BackgroundColor.Default, FontStyle style = FontStyle.Default)
        {
            _sb.Append("\u001b[");
            ProcessStyles(style);

            if (background != BackgroundColor.Default)
            {
                _sb.Append(EnumCache<BackgroundColor>.Instance.ToString(background));
                if (color != TextColor.Default)
                {
                    _sb.Append(';');
                }
            }

            if (color != TextColor.Default)
            {
                _sb.Append(EnumCache<TextColor>.Instance.ToString(color));
            }

            _sb.Append('m');
            _sb.Append(text);
            Reset();
        }

        /// <summary>
        /// Appends text with a line terminator with the given color, background, and font style
        /// </summary>
        /// <param name="text">Text to add</param>
        /// <param name="color">Color of the text</param>
        /// <param name="background">Background color of the text</param>
        /// <param name="style">Font style of the text</param>
        public void AppendLine(string text, TextColor color = TextColor.Default, BackgroundColor background = BackgroundColor.Default, FontStyle style = FontStyle.Default)
        {
            Append(text, color, background, style);
            _sb.AppendLine();
        }

        /// <summary>
        /// Appends a line
        /// </summary>
        public void AppendLine()
        {
            _sb.AppendLine();
        }
        
        private void ProcessStyles(FontStyle style)
        {
            if (style == FontStyle.Default)
            {
                _sb.Append("0;");
                return;
            }
            
            if (HasFlag(style, FontStyle.Bold))
            {
                _sb.Append("1;");
            }
            
            if (HasFlag(style, FontStyle.Underline))
            {
                _sb.Append("4;");
            }
        }

        private void Reset()
        {
            _sb.Append("\u001b[0;0m");
        }

        private bool HasFlag(FontStyle style, FontStyle flag)
        {
            return (style & flag) == flag;
        }

        /// <summary>
        /// Returns the build Ansi Text
        /// </summary>
        /// <returns></returns>
        public string Build()
        {
            _sb.AppendLine();
            _sb.Append("```");
            return DiscordPool.Internal.ToStringAndFree(_sb);
        }
    }
}