using System;
using Oxide.Ext.Discord.Cache;
using Oxide.Ext.Discord.Entities;

namespace Oxide.Ext.Discord.Helpers
{
    /// <summary>
    /// Represents Discord <a href="https://discord.com/developers/docs/reference#image-formatting-cdn-endpoints">CDN Endpoints</a>
    /// </summary>
    public static class DiscordCdn
    {
        /// <summary>
        /// Base CDN Url
        /// </summary>
        public const string CdnUrl = "https://cdn.discordapp.com";

        /// <summary>
        /// Returns the Url to the custom emoji
        /// </summary>
        /// <param name="emojiId">ID of the emoji</param>
        /// <param name="format">The format the emoji is in</param>
        /// <returns>Url of the emoji</returns>
        /// <exception cref="ArgumentException">Thrown if the format is Jpg or WebP</exception>
        public static string GetCustomEmojiUrl(Snowflake emojiId, DiscordImageFormat format)
        {
            return format switch
            {
                DiscordImageFormat.Jpg or DiscordImageFormat.Png or DiscordImageFormat.WebP or DiscordImageFormat.Gif => $"{CdnUrl}/emojis/{emojiId.ToString()}.{GetExtension(format)}",
                _ => throw new ArgumentException("ImageFormat is not valid for Custom Emoji. Valid types are (Auto, Png, Jpeg, WebP, Gif)", nameof(format))
            };
        }
        
        /// <summary>
        /// Returns the Url to the Guild Icon
        /// </summary>
        /// <param name="guildId">Guild ID for the icon</param>
        /// <param name="guildIcon">Guild Icon from guild</param>
        /// <param name="format">Format the icon is in</param>
        /// <returns>Url of the guild icon</returns>
        public static string GetGuildIconUrl(Snowflake guildId, string guildIcon, DiscordImageFormat format = DiscordImageFormat.Auto)
        {
            return format switch
            {
                DiscordImageFormat.Auto or DiscordImageFormat.Jpg or DiscordImageFormat.Png or DiscordImageFormat.WebP or DiscordImageFormat.Gif => $"{CdnUrl}/icons/{guildId.ToString()}/{guildIcon}.{GetExtension(format, guildIcon)}",
                _ => throw new ArgumentException("ImageFormat is not valid for Guild Icon. Valid types are (Auto, Png, Jpeg, WebP, Gif)", nameof(format))
            };
        }
        
        /// <summary>
        /// Returns the Url of the Guild Splash
        /// </summary>
        /// <param name="guildId">Guild ID for the icon</param>
        /// <param name="guildSplash">Guild Splash from guild</param>
        /// <param name="format">Format the icon is in</param>
        /// <returns>Url of the guild splash</returns>
        /// <exception cref="ArgumentException">Thrown if the format is GIF</exception>
        public static string GetGuildSplashUrl(Snowflake guildId, string guildSplash, DiscordImageFormat format = DiscordImageFormat.Auto)
        {
            return format switch
            {
                DiscordImageFormat.Jpg or DiscordImageFormat.Png or DiscordImageFormat.WebP => $"{CdnUrl}/splashes/{guildId.ToString()}/{guildSplash}.{GetExtension(format)}",
                _ => throw new ArgumentException("ImageFormat is not valid for Guild Splash. Valid types are (Png, Jpeg, WebP)", nameof(format))
            };
        }
        
        /// <summary>
        /// Return the Url of the Guild Discovery Splash
        /// </summary>
        /// <param name="guildId">Guild ID for the icon</param>
        /// <param name="guildDiscoverySplash">Guild Discovery Splash from guild</param>
        /// <param name="format">Format the icon is in</param>
        /// <returns>Url of the guild discovery splash</returns>
        /// <exception cref="ArgumentException">Thrown if the format is GIF</exception>
        public static string GetGuildDiscoverySplashUrl(Snowflake guildId, string guildDiscoverySplash, DiscordImageFormat format = DiscordImageFormat.Auto)
        {
            return format switch
            {
                DiscordImageFormat.Auto or DiscordImageFormat.Jpg or DiscordImageFormat.Png or DiscordImageFormat.WebP => $"{CdnUrl}/discovery-splashes/{guildId.ToString()}/{guildDiscoverySplash}.{GetExtension(format, guildDiscoverySplash)}",
                _ => throw new ArgumentException("ImageFormat is not valid for Guild Discovery Splash. Valid types are (Auto, Png, Jpeg, WebP)", nameof(format))
            };
        }
        
        /// <summary>
        /// Returns the Url of the Guild Banner
        /// </summary>
        /// <param name="guildId">Guild ID for the icon</param>
        /// <param name="guildBanner">Guild Banner from guild</param>
        /// <param name="format">Format the icon is in</param>
        /// <returns>Url of the guild banner</returns>
        /// <exception cref="ArgumentException">Thrown if the format is GIF</exception>
        public static string GetGuildBannerUrl(Snowflake guildId, string guildBanner, DiscordImageFormat format = DiscordImageFormat.Auto)
        {
            return format switch
            {
                DiscordImageFormat.Auto or DiscordImageFormat.Jpg or DiscordImageFormat.Png or DiscordImageFormat.WebP or DiscordImageFormat.Gif => $"{CdnUrl}/banners/{guildId.ToString()}/{guildBanner}.{GetExtension(format, guildBanner)}",
                _ => throw new ArgumentException("ImageFormat is not valid for Guild Banner. Valid types are (Auto, Png, Jpeg, WebP, GIF)", nameof(format))
            };
        }
        
        /// <summary>
        /// Returns the Url of the User Banner
        /// </summary>
        /// <param name="userId">User ID for the Banner</param>
        /// <param name="userBanner">User Banner from user</param>
        /// <param name="format">Format the icon is in</param>
        /// <returns>Url of the User banner</returns>
        /// <exception cref="ArgumentException">Thrown if the format is GIF</exception>
        public static string GetUserBanner(Snowflake userId, string userBanner, DiscordImageFormat format = DiscordImageFormat.Auto)
        {
            return format switch
            {
                DiscordImageFormat.Auto or DiscordImageFormat.Jpg or DiscordImageFormat.Png or DiscordImageFormat.WebP or DiscordImageFormat.Gif => $"{CdnUrl}/banners/{userId.ToString()}/{userBanner}.{GetExtension(format, userBanner)}",
                _ => throw new ArgumentException("ImageFormat is not valid for User Banner. Valid types are (Auto, Png, Jpeg, WebP, GIF)", nameof(format))
            };
        }

        /// <summary>
        /// Returns the Url of the users default avatar
        /// </summary>
        /// <param name="userDiscriminator">Discord User Discriminator</param>
        /// <returns>Url of the default avatar url</returns>
        public static string GetUserDefaultAvatarUrl(string userDiscriminator)
        {
            uint discriminator = uint.Parse(userDiscriminator) % 5;
            return $"{CdnUrl}/embed/avatars/{discriminator.ToString()}.png";
        }
        
        /// <summary>
        /// Returns the Url of the users avatar
        /// </summary>
        /// <param name="userId">Discord User ID</param>
        /// <param name="userAvatar">User avatar from user</param>
        /// <param name="format">Format the avatar is in</param>
        /// <returns>Url of the user's avatar</returns>
        public static string GetUserAvatarUrl(Snowflake userId, string userAvatar, DiscordImageFormat format = DiscordImageFormat.Auto)
        {
            return format switch
            {
                DiscordImageFormat.Auto or DiscordImageFormat.Jpg or DiscordImageFormat.Png or DiscordImageFormat.WebP or DiscordImageFormat.Gif => $"{CdnUrl}/avatars/{userId.ToString()}/{userAvatar}.{GetExtension(format, userAvatar)}",
                _ => throw new ArgumentException("ImageFormat is not valid for User Avatar. Valid types are (Auto, Png, Jpeg, WebP, Gif)", nameof(format))
            };
        }

        /// <summary>
        /// Returns the Url of the Guild Member avatar
        /// </summary>
        /// <param name="guildId">Guild ID of the Guild Member</param>
        /// <param name="userId">Discord User ID</param>
        /// <param name="memberAvatar">Guild Member avatar</param>
        /// <param name="format">Format the avatar is in</param>
        /// <returns>Url of the Guild Member avatar</returns>
        public static string GetGuildMemberAvatar(Snowflake guildId, Snowflake userId, string memberAvatar, DiscordImageFormat format = DiscordImageFormat.Auto)
        {
            return format switch
            {
                DiscordImageFormat.Auto or DiscordImageFormat.Jpg or DiscordImageFormat.Png or DiscordImageFormat.WebP or DiscordImageFormat.Gif => $"{CdnUrl}/guilds/{guildId.ToString()}/users/{userId.ToString()}/avatars/{memberAvatar}.{GetExtension(format, memberAvatar)}",
                _ => throw new ArgumentException("ImageFormat is not valid for Guild Member Avatar. Valid types are (Auto, Png, Jpeg, WebP, Gif)", nameof(format))
            };
        }

        /// <summary>
        /// Returns the Url of the User Avatar Decoration
        /// </summary>
        /// <param name="data">Avatar Decoration Data</param>
        /// <param name="format">Format the avatar is in</param>
        /// <returns>Url of the Guild Member avatar</returns>
        public static string GetUserAvatarDecoration(AvatarDecorationData data, DiscordImageFormat format = DiscordImageFormat.Auto)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));
            return format switch
            {
                DiscordImageFormat.Auto or DiscordImageFormat.Png => $"{CdnUrl}/avatar-decoration-presets/{data.Asset}.{GetExtension(format, data.Asset)}",
                _ => throw new ArgumentException("ImageFormat is not valid for User Avatar Decoration. Valid types are (Auto, Png)", nameof(format))
            };
        }
        
        /// <summary>
        /// Returns the url to the application icon
        /// </summary>
        /// <param name="applicationId">Application ID</param>
        /// <param name="icon">Icon field from application</param>
        /// <param name="format">Format the icon is in</param>
        /// <returns>Url of the application icon</returns>
        /// <exception cref="ArgumentException">Throw if the format is GIF</exception>
        public static string GetApplicationIconUrl(Snowflake applicationId, string icon, DiscordImageFormat format = DiscordImageFormat.Auto)
        {
            return format switch
            {
                DiscordImageFormat.Auto or DiscordImageFormat.Jpg or DiscordImageFormat.Png or DiscordImageFormat.WebP => $"{CdnUrl}/app-icons/{applicationId.ToString()}/{icon}.{GetExtension(format, icon)}",
                _ => throw new ArgumentException("ImageFormat is not valid for Application Icon. Valid types are (Auto, Png, Jpeg, WebP)", nameof(format))
            };
        }
        
        /// <summary>
        /// Returns the url to the application cover
        /// </summary>
        /// <param name="applicationId">Application ID</param>
        /// <param name="coverImage">Icon field from application</param>
        /// <param name="format">Format the icon is in</param>
        /// <returns>Url of the application icon</returns>
        /// <exception cref="ArgumentException">Throw if the format is GIF</exception>
        public static string GetApplicationCoverUrl(Snowflake applicationId, string coverImage, DiscordImageFormat format = DiscordImageFormat.Auto)
        {
            return format switch
            {
                DiscordImageFormat.Auto or DiscordImageFormat.Jpg or DiscordImageFormat.Png or DiscordImageFormat.WebP => $"{CdnUrl}/app-icons/{applicationId.ToString()}/{coverImage}.{GetExtension(format, coverImage)}",
                _ => throw new ArgumentException("ImageFormat is not valid for Application Cover. Valid types are (Auto, Png, Jpeg, WebP)", nameof(format))
            };
        }
        
        /// <summary>
        /// Returns the applications asset icon url
        /// </summary>
        /// <param name="applicationId">Application ID of the icon</param>
        /// <param name="assetId">Asset ID for the application</param>
        /// <param name="format">Format the icon is in</param>
        /// <returns>Url of the application asset icon</returns>
        /// <exception cref="ArgumentException">Throw if the format is GIF</exception>
        public static string GetApplicationAssetUrl(Snowflake applicationId, string assetId, DiscordImageFormat format = DiscordImageFormat.Auto)
        {
            return format switch
            {
                DiscordImageFormat.Auto or DiscordImageFormat.Jpg or DiscordImageFormat.Png or DiscordImageFormat.WebP => $"{CdnUrl}/app-assets/{applicationId.ToString()}/{assetId}.{GetExtension(format, assetId)}",
                _ => throw new ArgumentException("ImageFormat is not valid for Application Asset. Valid types are (Auto, Png, Jpeg, WebP)", nameof(format))
            };
        }
        
        /// <summary>
        /// Returns the Url of the Achievement Icon
        /// </summary>
        /// <param name="applicationId">Application ID of the icon</param>
        /// <param name="achievementId">Achievement ID</param>
        /// <param name="iconHash">Achievement Icon Hash</param>
        /// <returns>Url of the achievement icon</returns>
        /// <exception cref="ArgumentException">Throw if the format is GIF</exception>
        public static string GetAchievementIconUrl(Snowflake applicationId, Snowflake achievementId, string iconHash)
        {
            return $"{CdnUrl}/app-assets/{applicationId.ToString()}/achievements/{achievementId.ToString()}/icons/{iconHash}.png";
        }
        
        /// <summary>
        /// Returns the Store Page Asset Url
        /// </summary>
        /// <param name="applicationId">Application ID of the icon</param>
        /// <param name="assetId">Asset ID</param>
        /// <param name="format">Format the icon is in</param>
        /// <returns>Url of the achievement icon</returns>
        /// <exception cref="ArgumentException">Throw if the format is GIF</exception>
        public static string GetStorePageAssetUrl(Snowflake applicationId, ulong assetId, DiscordImageFormat format = DiscordImageFormat.Auto)
        {
            return format switch
            {
                DiscordImageFormat.Auto or DiscordImageFormat.Jpg or DiscordImageFormat.Png or DiscordImageFormat.WebP => $"{CdnUrl}/app-assets/{applicationId.ToString()}/store/{StringCache<ulong>.Instance.ToString(assetId)}.{GetExtension(format)}",
                _ => throw new ArgumentException("ImageFormat is not valid for Store Page Asset Url. Valid types are (Auto, Png, Jpeg, WebP)", nameof(format))
            };
        }
        
        /// <summary>
        /// Returns the Url of the Team Icon
        /// </summary>
        /// <param name="teamId">Team ID of the Icon</param>
        /// <param name="teamIcon">Icon field from Team</param>
        /// <param name="format">Format the icon is in</param>
        /// <returns>Url of the achievement icon</returns>
        /// <exception cref="ArgumentException">Throw if the format is GIF</exception>
        public static string GetTeamIconUrl(Snowflake teamId, string teamIcon, DiscordImageFormat format = DiscordImageFormat.Auto)
        {
            return format switch
            {
                DiscordImageFormat.Auto or DiscordImageFormat.Jpg or DiscordImageFormat.Png or DiscordImageFormat.WebP => $"{CdnUrl}/team-icons/{teamId.ToString()}/{teamIcon}.{GetExtension(format, teamIcon)}",
                _ => throw new ArgumentException("ImageFormat is not valid for Team Icon. Valid types are (Auto, Png, Jpeg, WebP)", nameof(format))
            };
        }
        

        /// <summary>
        /// Returns the banner for a given sticker pack
        /// </summary>
        /// <param name="applicationId">Application ID for the stickers</param>
        /// <param name="bannerAssetId">Banner Asset ID for the stickers</param>
        /// <param name="format">Image Formatting for the banner</param>
        /// <returns>Url to the sticker pack banner</returns>
        /// <exception cref="ArgumentException">Thrown if the image type is not PNG, JPEG, or WebP</exception>
        public static string GetStickerPackBanner(Snowflake applicationId, Snowflake bannerAssetId, DiscordImageFormat format = DiscordImageFormat.Auto)
        {
            return format switch
            {
                DiscordImageFormat.Auto or DiscordImageFormat.Jpg or DiscordImageFormat.Png or DiscordImageFormat.WebP => $"{CdnUrl}/app-assets/{applicationId.ToString()}/store/{bannerAssetId.ToString()}.{GetExtension(format)}",
                _ => throw new ArgumentException("ImageFormat is not valid for Sticker Pack Banner. Valid types are (Auto, Png, Jpeg, WebP)", nameof(format))
            };
        }
        
        /// <summary>
        /// Returns the sticker url with the given ID
        /// </summary>
        /// <param name="sticker">Sticker to get the url for</param>
        /// <returns>Return url for the sticker</returns>
        public static string GetSticker(DiscordSticker sticker)
        {
            if (sticker == null) throw new ArgumentNullException(nameof(sticker));
            return sticker.FormatType switch
            {
                StickerFormatType.Png or StickerFormatType.Apng => $"{CdnUrl}/stickers/{sticker.Id.ToString()}.{GetExtension(DiscordImageFormat.Png)}",
                StickerFormatType.Lottie => $"{CdnUrl}/stickers/{sticker.Id.ToString()}.{GetExtension(DiscordImageFormat.Lottie)}",
                StickerFormatType.Gif => $"{CdnUrl}/stickers/{sticker.Id.ToString()}.{GetExtension(DiscordImageFormat.Gif)}",
                _ => throw new ArgumentException("Sticker does not container a valid format type", nameof(sticker.FormatType))
            };
        }
        
        /// <summary>
        /// Returns the sticker url with the given ID
        /// </summary>
        /// <param name="roleId">ID of the role</param>
        /// <param name="format">Format for the icon to be returned in</param>
        /// <returns>Return url for the role icon</returns>
        /// <exception cref="ArgumentException">Thrown if the image type is not PNG or Lottie</exception>
        public static string GetRoleIcon(Snowflake roleId, DiscordImageFormat format = DiscordImageFormat.Auto)
        {
            return format switch
            {
                DiscordImageFormat.Auto or DiscordImageFormat.Jpg or DiscordImageFormat.Png or DiscordImageFormat.WebP => $"{CdnUrl}/role-icons/{roleId.ToString()}.{GetExtension(format)}",
                _ => throw new ArgumentException("ImageFormat is not valid for Role Icon. Valid types are (Auto, Png, Jpeg, WebP)", nameof(format))
            };
        }
        
        /// <summary>
        /// Returns the guild schedule event cover icon with the given ID
        /// </summary>
        /// <param name="scheduledEventId">Scheduled Event ID</param>
        /// <param name="format">Format for the icon to be returned in</param>
        /// <returns>Return url for the guild schedule event cover icon</returns>
        /// <exception cref="ArgumentException">Thrown if the image type is not PNG or Lottie</exception>
        public static string GetGuildScheduledEventCover(Snowflake scheduledEventId, DiscordImageFormat format = DiscordImageFormat.Auto)
        {
            return format switch
            {
                DiscordImageFormat.Auto or DiscordImageFormat.Jpg or DiscordImageFormat.Png or DiscordImageFormat.WebP => $"{CdnUrl}/guild-events/{scheduledEventId.ToString()}/scheduled_event_cover_image.{GetExtension(format)}",
                _ => throw new ArgumentException("ImageFormat is not valid for Guild Scheduled Event Cover. Valid types are (Auto, Png, Jpeg, WebP)", nameof(format))
            };
        }
        
        /// <summary>
        /// Returns the guild member banner for the given guild / user ID
        /// </summary>
        /// <param name="guildId">Guild ID of the user</param>
        /// <param name="userId">User ID of the user</param>
        /// <param name="format">Format for the icon to be returned in</param>
        /// <returns>Return url for the guild member banner</returns>
        /// <exception cref="ArgumentException">Thrown if the image type is not PNG or Lottie</exception>
        public static string GetGuildMemberBanner(Snowflake guildId, Snowflake userId, DiscordImageFormat format = DiscordImageFormat.Auto)
        {
            return format switch
            {
                DiscordImageFormat.Auto or DiscordImageFormat.Jpg or DiscordImageFormat.Png or DiscordImageFormat.WebP or DiscordImageFormat.Gif => $"{CdnUrl}/guilds/{guildId.ToString()}/users/{userId.ToString()}/banners/member_banner.{GetExtension(format)}",
                _ => throw new ArgumentException("ImageFormat is not valid for Guild Member Banner. Valid types are (Auto, Png, Jpeg, WebP, Gif)", nameof(format))
            };
        }
        
        /// <summary>
        /// Returns the icon for a given channel
        /// </summary>
        /// <param name="channelId">Channel ID for the Icon</param>
        /// <param name="icon">Icon hash for the channel</param>
        /// <returns></returns>
        public static string GetChannelIcon(Snowflake channelId, string icon)
        {
            return $"{CdnUrl}/channel-icons/{channelId.ToString()}/{icon}.png";
        }

        /// <summary>
        /// Returns the extension to use for the image
        /// </summary>
        /// <param name="format">Image format that is requested</param>
        /// <param name="image">Image data from the field</param>
        /// <returns>Image extension for the image format and image data</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if Image Format is out of range</exception>
        public static string GetExtension(DiscordImageFormat format, string image)
        {
            if (format == DiscordImageFormat.Auto)
            {
                format = image.StartsWith("a_") ? DiscordImageFormat.Gif : DiscordImageFormat.Png;
            }

            return GetExtension(format);
        }

        private static string GetExtension(DiscordImageFormat format)
        {
            return format switch
            {
                DiscordImageFormat.Jpg => "jpeg",
                DiscordImageFormat.Auto or DiscordImageFormat.Png => "png",
                DiscordImageFormat.WebP => "webp",
                DiscordImageFormat.Gif => "gif",
                DiscordImageFormat.Lottie => "json",
                _ => throw new ArgumentOutOfRangeException(nameof(format), format.ToString(), "Format is not a valid ImageFormat")
            };
        }
    }
}