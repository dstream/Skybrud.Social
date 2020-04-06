using System;
using Skybrud.Social.Interfaces;
using Skybrud.Social.Json;

namespace Skybrud.Social.Instagram.Objects {
    
    public class InstagramMedia : SocialJsonObject, ISocialTimelineEntry {

        #region Properties

        // A photo/media may specify an attribution property, but the Instagram documentation has
        // no information regarding this property. However this Google Groups discussion sheds a
        // little light on what attribution is:
        //
        // https://groups.google.com/forum/#!topic/instagram-api-developers/KvGH1cnjljQ
        //
        // However since I haven't been able to find any media with the attribution property, and
        // that the official documentation doesn't have any information about this property, it is
        // currently not supported in Skybrud.Social.

        /// <summary>
        /// The ID of the media.
        /// </summary>
        public string Id { get; internal set; }

        /// <summary>
        /// The Media's type. Can be IMAGE, VIDEO, or CAROUSEL_ALBUM.
        /// </summary>
        public string Type { get; internal set; }

        /// <summary>
        /// The Media's caption text. Not returnable for Media in albums.
        /// </summary>
        public string Caption { get; set; }        

        /// <summary>
        /// The Media's URL.
        /// </summary>
        public string MediaUrl { get; set; }

        /// <summary>
        /// The Media's permanent URL.
        /// </summary>
        public string Permalink { get; internal set; }
               
        /// <summary>
        /// The Media's thumbnail image URL. Only available on VIDEO Media.
        /// </summary>
        public string Thumbnail { get; set; }

        /// <summary>
        /// The Media owner's username.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// The Media's publish date, in UTC/GMT 0.
        /// </summary>
        public DateTime Timestamp { get; internal set; }


        public DateTime SortDate => Timestamp;

        #region Extra properties: only available when using Facebook Graph API

        public int CommentsCount { get; set; }

        public int LikesCount { get; set; }

        #endregion

        #endregion

        #region Constructors

        protected InstagramMedia(JsonObject obj) : base(obj) {
            // Hide default constructor
        }

        #endregion        

        public bool IsMediaType(InstagramMediaType type)
        {
            return Type == type.ToString();
        }

        #region Static methods

        /// <summary>
        /// Loads a media from the JSON file at the specified <var>path</var>.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        public static InstagramMedia LoadJson(string path) {
            return JsonObject.LoadJson(path, Parse);
        }

        /// <summary>
        /// Gets a media from the specified JSON string.
        /// </summary>
        /// <param name="json">The JSON string representation of the object.</param>
        public static InstagramMedia ParseJson(string json) {
            return JsonObject.ParseJson(json, Parse);
        }

        /// <summary>
        /// Gets a media from the specified <var>JsonObject</var>.
        /// </summary>
        /// <param name="obj">The instance of <var>JsonObject</var> to parse.</param>
        public static InstagramMedia Parse(JsonObject obj) {

            if (obj == null) return null;
                      
            var media = new InstagramMedia(obj)
            {
                Id = obj.GetString(InstagramMediaField.id.ToString()),
                Type = obj.GetString(InstagramMediaField.media_type.ToString()),
                MediaUrl = obj.GetString(InstagramMediaField.media_url.ToString()),
                Permalink = obj.GetString(InstagramMediaField.permalink.ToString()),
                Thumbnail = obj.GetString(InstagramMediaField.thumbnail_url.ToString()),
                Username = obj.GetString(InstagramMediaField.username.ToString()),
                Timestamp = obj.GetDateTime(InstagramMediaField.timestamp.ToString()),
                LikesCount = obj.GetInt32(InstagramMediaField.like_count.ToString()),
                CommentsCount = obj.GetInt32(InstagramMediaField.comments_count.ToString())
            };

            return media;

        }

        /// <summary>
        /// id,media_type,media_url,permalink,thumbnail_url,username,timestamp
        /// </summary>
        public static string DefaultFields {
            get
            {
                return $"{InstagramMediaField.id},{InstagramMediaField.media_type},{InstagramMediaField.media_url}," +
                    $"{InstagramMediaField.permalink},{InstagramMediaField.thumbnail_url},{InstagramMediaField.username}," +
                    $"{InstagramMediaField.timestamp}";
            }
        }

        /// <summary>
        /// id,media_type,media_url,permalink,thumbnail_url,username,timestamp + like_count,comments_count
        /// </summary>
        public static string DefaultExtraFields
        {
            get
            {
                return $"{InstagramMediaField.id},{InstagramMediaField.media_type},{InstagramMediaField.media_url}," +
                    $"{InstagramMediaField.permalink},{InstagramMediaField.thumbnail_url},{InstagramMediaField.username}," +
                    $"{InstagramMediaField.timestamp},{InstagramMediaField.like_count},{InstagramMediaField.comments_count}";
            }
        }

        /// <summary>
        /// id,media_type,media_url,permalink,caption,like_count,comments_count
        /// </summary>
        public static string HashTagMediaFields
        {
            get
            {
                return $"{InstagramMediaField.id},{InstagramMediaField.media_type},{InstagramMediaField.media_url}," +
                    $"{InstagramMediaField.permalink},{InstagramMediaField.caption},{InstagramMediaField.like_count}," +
                    $"{InstagramMediaField.comments_count}";
            }
        }

        #endregion

    }

    public enum InstagramMediaType
    {
        IMAGE,
        CAROUSEL_ALBUM,
        VIDEO
    }

}
