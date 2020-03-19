using System;
using Skybrud.Social.Json;

namespace Skybrud.Social.Instagram.Objects {

    public class InstagramUser : SocialJsonObject {

        #region Properties

        /// <summary>
        /// The ID of the user.
        /// </summary>
        public long Id { get; private set; }

        /// <summary>
        /// The username of the user.
        /// </summary>
        public string Username { get; private set; }

        /// <summary>
        /// The full name of the user. A user may not have specified a full name.
        /// </summary>
        [Obsolete("Not supported in Instagram Basic Display API")]
        public string FullName { get; private set; }

        /// <summary>
        /// The profile picture of the user.
        /// </summary>
        [Obsolete("Not supported in Instagram Basic Display API")]
        public string ProfilePicture { get; private set; }

        /// <summary>
        /// The website of the user. A user may not have specified a website.
        /// </summary>
        [Obsolete("Not supported in Instagram Basic Display API")]
        public string Website { get; private set; }

        /// <summary>
        /// The bio of the user. A user may not have specified a bio.
        /// </summary>
        [Obsolete("Not supported in Instagram Basic Display API")]
        public string Bio { get; private set; }

        [Obsolete("Not supported in Instagram Basic Display API")]
        public InstagramUserCounts Counts { get; private set; }
        
        /// <summary>
        /// The User's account type. Can be BUSINESS, MEDIA_CREATOR, or PERSONAL.
        /// </summary>
        public string AccountType { get; private set; }

        /// <summary>
        /// The number of Media on the User. This field requires the instagram_graph_user_media permission.
        /// </summary>
        public int MediaCount { get; private set; }

        #endregion

        #region Constructors

        private InstagramUser(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Loads a user from the JSON file at the specified <var>path</var>.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        public static InstagramUser LoadJson(string path) {
            return JsonObject.LoadJson(path, Parse);
        }

        /// <summary>
        /// Gets a user from the specified JSON string.
        /// </summary>
        /// <param name="json">The JSON string representation of the object.</param>
        public static InstagramUser ParseJson(string json) {
            return JsonObject.ParseJson(json, Parse);
        }

        /// <summary>
        /// Gets a user from the specified <var>JsonObject</var>.
        /// </summary>
        /// <param name="obj">The instance of <var>JsonObject</var> to parse.</param>
        public static InstagramUser Parse(JsonObject obj) {
            if (obj == null) return null;            
            return new InstagramUser(obj) {
                Id = obj.GetInt64(InstagramUserField.id.ToString()),
                Username = obj.GetString(InstagramUserField.username.ToString()),
                AccountType = obj.GetString(InstagramUserField.account_type.ToString()),
                MediaCount = obj.GetInt32(InstagramUserField.media_count.ToString())   
            };
        }

        #endregion

    }

}
