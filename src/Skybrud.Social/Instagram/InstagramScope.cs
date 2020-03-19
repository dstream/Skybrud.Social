using System;

namespace Skybrud.Social.Instagram {

    [Flags]
    public enum InstagramScope {

        /// <summary>
        /// Grants your app permission to read the app user's profile. (e.g. following/followed-by lists, photos, etc.) (granted by default).
        /// </summary>
        user_profile = 0,

        /// <summary>
        /// Grants your app permission to read the app user's IG Media objects.
        /// Allowed Usage:
        /// - Creating physical or digital books from the app user's photos, including exporting photos for printing
        /// - Displaying the app users photos to other app users within the app (e.g, for Dating or Social Network Applications)
        /// - Editing or creating new photos or videos based on the app user's existing photos and videos (Photo/Video Editing Apps)
        /// - Displaying the app user's photos and videos in an external device such as a TV or digital photo frame
        /// </summary>
        user_media = 1,            
    }    
}