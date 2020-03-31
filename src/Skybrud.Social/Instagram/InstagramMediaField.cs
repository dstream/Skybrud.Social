using System;

namespace Skybrud.Social.Instagram {
    
    public enum InstagramMediaField
    {
        /// <summary>
        /// The Media's ID.
        /// </summary>
        id,
        /// <summary>
        /// The Media's caption text. Not returnable for Media in albums.
        /// </summary>
        caption,
        /// <summary>
        /// The Media's type. Can be IMAGE, VIDEO, or CAROUSEL_ALBUM.
        /// </summary>
        media_type,
        /// <summary>
        /// The Media's URL.
        /// </summary>
        media_url,
        /// <summary>
        /// The Media's permanent URL.
        /// </summary>
        permalink,
        /// <summary>
        /// The Media's thumbnail image URL. Only available on VIDEO Media.
        /// </summary>
        thumbnail_url,
        /// <summary>
        /// The Media's publish date in ISO 8601 format.
        /// </summary>
        timestamp,
        /// <summary>
        /// The Media owner's username.
        /// </summary>
        username
    }

    /// <summary>
    /// Only available when using Facebook Graph API
    /// </summary>
    public enum InstagramMediaExtraField
    {
        /// <summary>
        /// excludes album children and the caption, includes replies
        /// </summary>
        comments_count,
        /// <summary>
        /// excludes album children and likes on promoted posts created from the media object, includes replies
        /// </summary>
        like_count,
    }

}