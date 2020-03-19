using System;

namespace Skybrud.Social.Instagram {
    
    public enum InstagramUserField
    {
        /// <summary>
        /// The User's account type. Can be BUSINESS, MEDIA_CREATOR, or PERSONAL.
        /// </summary>
        account_type,
        /// <summary>
        /// The User's ID.
        /// </summary>
        id,
        /// <summary>
        /// The number of Media on the User. This field requires the instagram_graph_user_media permission.
        /// </summary>
        media_count,
        /// <summary>
        /// The User's username.
        /// </summary>
        username
    }

}