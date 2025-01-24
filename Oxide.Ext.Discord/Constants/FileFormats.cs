using System.Text;

namespace Oxide.Ext.Discord.Constants
{
    internal class FileFormats
    {
        #region Images
        internal static readonly byte[] Gif = Encoding.UTF8.GetBytes("GIF");
        internal static readonly byte[] Png = {137, 80, 78, 71};
        internal static readonly byte[] Jpeg = {255, 216, 255, 224};
        internal static readonly byte[] Jpeg2 = {255, 216, 255, 225};
        #endregion

        #region Audio
        internal static readonly byte[] Mp3 = { 0x49, 0x44, 0x33 };
        internal static readonly byte[] Ogg = { 0x4F, 0x67, 0x67, 0x53 };
        #endregion
    }
}