using Skybrud.Social.Json;

namespace Skybrud.Social.Instagram.Objects {
    
    public class InstagramAccessTokenSummary : SocialJsonObject {

        #region Properties
        /// <summary>
        /// Gets the access token.
        /// </summary>
        public string AccessToken { get; private set; }

        /// <summary>
        /// Gets user_id
        /// </summary>
        public long UserId { get; private set; }

        /// <summary>
        /// bearer if it's long-lived token, empty otherwise
        /// </summary>
        public string TokenType { get; set; }

        /// <summary>
        /// Long-lived tokend expired timestamp, in seconds, it's 60 days normally
        /// </summary>
        public long ExpiresIn { get; set; }

        #endregion

        #region Constructors

        private InstagramAccessTokenSummary(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <code>InstagramAccessTokenSummary</code> from the specified <code>JsonObject</code>.
        /// </summary>
        /// <param name="obj">The instance of <code>JsonObject</code> to parse.</param>
        public static InstagramAccessTokenSummary Parse(JsonObject obj) {
            if (obj == null) return null;
            return new InstagramAccessTokenSummary(obj) {
                AccessToken = obj.GetString("access_token"),
                UserId = obj.GetInt64("user_id"),
                TokenType = obj.GetString("token_type"),
                ExpiresIn = obj.GetInt64("expires_in")
            };
        }

        #endregion

    }

}