using System;
using System.Diagnostics.Contracts;
using System.Globalization;
using Newtonsoft.Json;
using Oxide.Ext.Discord.Exceptions;
using Oxide.Ext.Discord.Json;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents a Discord Color
    /// </summary>
    [JsonConverter(typeof(DiscordColorConverter))]
    public readonly struct DiscordColor : IEquatable<DiscordColor>
    {
        /// <summary>
        /// Default Role Color
        /// </summary>
        public static readonly DiscordColor Default = new(0);
        
        /// <summary>
        /// Teal Role Color
        /// </summary>
        public static readonly DiscordColor Teal = new(0x1ABC9C);
        
        /// <summary>
        /// Dark Teal Role Color
        /// </summary>
        public static readonly DiscordColor DarkTeal = new(0x11806A);
        
        /// <summary>
        /// Green Role Color
        /// </summary>
        public static readonly DiscordColor Green = new(0x2ECC71);
        
        /// <summary>
        /// Dark Green Role Color
        /// </summary>
        public static readonly DiscordColor DarkGreen = new(0x1F8B4C);
        
        /// <summary>
        /// Blue Role Color
        /// </summary>
        public static readonly DiscordColor Blue = new(0x3498DB);
        
        /// <summary>
        /// Dark Blue Role Color
        /// </summary>
        public static readonly DiscordColor DarkBlue = new(0x206694);
        
        /// <summary>
        /// Purple Role Color
        /// </summary>
        public static readonly DiscordColor Purple = new(0x9B59B6);
        
        /// <summary>
        /// Dark Purple Role Color
        /// </summary>
        public static readonly DiscordColor DarkPurple = new(0x71368A);
        
        /// <summary>
        /// Magenta Role Color
        /// </summary>
        public static readonly DiscordColor Magenta = new(0xE91E63);
        
        /// <summary>
        /// Dark Magenta Role Color
        /// </summary>
        public static readonly DiscordColor DarkMagenta = new(0xAD1457);
        
        /// <summary>
        /// Gold Role Color
        /// </summary>
        public static readonly DiscordColor Gold = new(0xF1C40F);
        
        /// <summary>
        /// Light Orange Role Color
        /// </summary>
        public static readonly DiscordColor LightOrange = new(0xC27C0E);
        
        /// <summary>
        /// Orange Role Color
        /// </summary>
        public static readonly DiscordColor Orange = new(0xE67E22);
        
        /// <summary>
        /// Dark Orange Role Color
        /// </summary>
        public static readonly DiscordColor DarkOrange = new(0xA84300);
        
        /// <summary>
        /// Red Role Color
        /// </summary>
        public static readonly DiscordColor Red = new(0xE74C3C);
        
        /// <summary>
        /// Dark Red Role Color
        /// </summary>
        public static readonly DiscordColor DarkRed = new(0x992D22);
        
        /// <summary>
        /// Light Gray Role Color
        /// </summary>
        public static readonly DiscordColor LightGrey = new(0x979C9F);
        
        /// <summary>
        /// Lighter Gray Role Color
        /// </summary>
        public static readonly DiscordColor LighterGrey = new(0x95A5A6);
        
        /// <summary>
        /// Dark Gray Role Color
        /// </summary>
        public static readonly DiscordColor DarkGrey = new(0x607D8B);
        
        /// <summary>
        /// Darker Gray Role Color
        /// </summary>
        public static readonly DiscordColor DarkerGrey = new(0x546E7A);
        
        /// <summary>
        /// Discord Success Color
        /// </summary>
        public static readonly DiscordColor Success = new(0x57F287);
        
        /// <summary>
        /// Discord Warning Color
        /// </summary>
        public static readonly DiscordColor Warning = new(0xFEE75C);
        
        /// <summary>
        /// Discord Danger Color
        /// </summary>
        public static readonly DiscordColor Danger = new(0xED4245);
        
        /// <summary>
        /// Discord Old Blurple Color
        /// </summary>
        public static readonly DiscordColor BlurpleOld = new(0x7289DA);
        
        /// <summary>
        /// Discord Blurple Color
        /// </summary>
        public static readonly DiscordColor Blurple = new(0x5865F2);
        
        /// <summary>
        /// Discord Fuchsia Color
        /// </summary>
        public static readonly DiscordColor Fuchsia = new(0xEB459E);

        /// <summary>
        /// uint value of the hex color code
        /// </summary>
        public readonly uint Color;

        /// <summary>
        /// DiscordColor Constructor
        /// </summary>
        /// <param name="color">uint value of hex color code</param>
        public DiscordColor(uint color)
        {
            InvalidDiscordColorException.ThrowIfInvalidColor(color);

            Color = color;
        }

        /// <summary>
        /// DiscordColor Constructor
        /// </summary>
        /// <param name="color">string hex color code</param>
        /// <exception cref="Exception">Throw if color is greater than #FFFFFF</exception>
        public DiscordColor(string color) : this(uint.Parse(color.TrimStart('#'), NumberStyles.AllowHexSpecifier)) { }

        /// <summary>
        /// DiscordColor Constructor
        /// </summary>
        /// <param name="red">Red color (0-255)</param>
        /// <param name="green">Green color (0-255)</param>
        /// <param name="blue">Blue color (0-255)</param>
        public DiscordColor(byte red, byte green, byte blue)
        {
            Color = (uint)((red << 16) + (green << 8) + blue);
        }
        
        /// <summary>
        /// DiscordColor Constructor
        /// </summary>
        /// <param name="red">Red color (0-255)</param>
        /// <param name="green">Green color (0-255)</param>
        /// <param name="blue">Blue color (0-255)</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if any of the colors are &lt; 0 or &gt; 255</exception>
        public DiscordColor(int red, int green, int blue)
        {
            InvalidDiscordColorException.ThrowIfOutOfColorRange(nameof(red), red);
            InvalidDiscordColorException.ThrowIfOutOfColorRange(nameof(green), green);
            InvalidDiscordColorException.ThrowIfOutOfColorRange(nameof(blue), blue);

            Color = (uint)((red << 16) + (green << 8) + blue);
        }
        
        /// <summary>
        /// DiscordColor Constructor
        /// </summary>
        /// <param name="red">Red color (0-255)</param>
        /// <param name="green">Green color (0-255)</param>
        /// <param name="blue">Blue color (0-255)</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if any of the colors are &gt; 255</exception>
        public DiscordColor(uint red, uint green, uint blue)
        {
            InvalidDiscordColorException.ThrowIfOutOfColorRange(nameof(red), red);
            InvalidDiscordColorException.ThrowIfOutOfColorRange(nameof(green), green);
            InvalidDiscordColorException.ThrowIfOutOfColorRange(nameof(blue), blue);

            Color = (red << 16) + (green << 8) + blue;
        }

        /// <summary>
        /// DiscordColor Constructor
        /// </summary>
        /// <param name="red">Red color (0.0 - 1.0)</param>
        /// <param name="green">Green color (0.0 - 1.0)</param>
        /// <param name="blue">Blue color (0.0 - 1.0)</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if any of the colors are &lt; 0.0 or &gt; 1.0</exception>
        public DiscordColor(float red, float green, float blue)
        {
            InvalidDiscordColorException.ThrowIfOutOfColorRange(nameof(red), red);
            InvalidDiscordColorException.ThrowIfOutOfColorRange(nameof(green), green);
            InvalidDiscordColorException.ThrowIfOutOfColorRange(nameof(blue), blue);
            
            Color = ((uint)(red * 255) << 16) + ((uint)(green * 255)  << 8) + (uint)(blue * 255);
        }
        
        /// <summary>
        /// DiscordColor Constructor
        /// </summary>
        /// <param name="red">Red color (0.0 - 1.0)</param>
        /// <param name="green">Green color (0.0 - 1.0)</param>
        /// <param name="blue">Blue color (0.0 - 1.0)</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if any of the colors are &lt; 0.0 or &gt; 1.0</exception>
        public DiscordColor(double red, double green, double blue) : this((float)red, (float)green, (float)blue) { }

        /// <summary>
        /// Returns the color as a string
        /// </summary>
        /// <returns></returns>
        public override string ToString() => Color.ToString();
        
        /// <summary>
        /// Returns the color as a hex color code
        /// </summary>
        /// <returns></returns>
        [Pure]
        public string ToHex() => $"#{Color.ToString("X6")}";
        
        /// <inheritdoc />
        public bool Equals(DiscordColor other) => Color == other.Color;

        /// <inheritdoc />
        public override bool Equals(object obj) => obj is DiscordColor other && Equals(other);

        /// <inheritdoc />
        public override int GetHashCode() => (int)Color;
    }
}