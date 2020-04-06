using Skybrud.Social.Http;
using Skybrud.Social.Instagram.OAuth;
using Skybrud.Social.Instagram.Objects;
using Skybrud.Social.Instagram.Options.Tags;

namespace Skybrud.Social.Instagram.Endpoints.Raw {
    
    /// <summary>
    /// Class for handling the raw communication with the tags endpoint. Only available for Instagram Graph API, not for Basic API
    /// </summary>
    /// <see cref="http://instagram.com/developer/endpoints/tags/"/>
    public class InstagramTagsRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the parent OAuth client.
        /// </summary>
        public InstagramOAuthClient Client { get; private set; }

        #endregion

        #region Constructors

        internal InstagramTagsRawEndpoint(InstagramOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the raw JSON response from the Instagram API with information about the specified tagId.
        /// </summary>
        /// <param name="tagId">The Id of the tag.</param>
        public SocialHttpResponse GetTagInfo(string tagId) {
            return Client.DoAuthenticatedGetRequest("https://graph.facebook.com/" + tagId + "?fields=id,name");
        }

        /// <summary>
        /// Gets the raw JSON response from the Instagram API with the most recently published photo and video IG Media objects that have been tagged with this.
        /// </summary>
        /// <param name="tagId">The name of the tag.</param>
        /// <param name="userId">The ID of the Instagram Business or Creator Account performing the query</param>
        /// <param name="count">The maximum amount of media to be returned.</param>
        /// <param name="minTagId">Get media that after this tagId</param>       
        /// <see cref="https://developers.facebook.com/docs/instagram-api/reference/hashtag/recent-media"/>
        public SocialHttpResponse GetRecentMedia(string tagId, string userId, int count, string minTagId = null) {
            return GetRecentMedia(tagId, userId, new InstagramTagRecentMediaOptions {
                Count = count,
                MinTagId = minTagId,                
            });
        }

        /// <summary>
        /// Gets the raw JSON response from the Instagram API with the most recently published photo and video IG Media objects that have been tagged with this.
        /// </summary>
        /// <param name="tagId"></param>
        /// <param name="userId">The ID of the Instagram Business or Creator Account performing the query</param>
        /// <param name="options">The options for the call to the API: limit, min tagId, max tagId</param>
        /// <see cref="https://developers.facebook.com/docs/instagram-api/reference/hashtag/recent-media"/>
        public SocialHttpResponse GetRecentMedia(string tagId, string userId, InstagramTagRecentMediaOptions options = null) {

            var qs = new SocialQueryString();
            qs.Add("user_id", userId);
            qs.Add("fields", InstagramMedia.HashTagMediaFields);
            if (options != null)
            {
                qs.Combine(options.GetQueryString());
            }            

            return Client.DoAuthenticatedGetRequest("https://graph.facebook.com/" + tagId + "/recent_media", qs);
        }

        /// <summary>
        /// Gets the raw JSON response from the Instagram API with the most popular photo and video IG Media objects that have been tagged with this.
        /// </summary>
        /// <param name="tagId"></param>
        /// <param name="userId">The ID of the Instagram Business or Creator Account performing the query</param>
        /// <param name="options"></param>
        /// <returns></returns>
        /// <see cref="https://developers.facebook.com/docs/instagram-api/reference/hashtag/top-media"/>
        public SocialHttpResponse GetTopMedia(string tagId, string userId, InstagramTagRecentMediaOptions options = null)
        {
            var qs = new SocialQueryString();
            qs.Add("user_id", userId);
            qs.Add("fields", InstagramMedia.HashTagMediaFields);
            if (options != null)
            {
                qs.Combine(options.GetQueryString());
            }

            return Client.DoAuthenticatedGetRequest("https://graph.facebook.com/" + tagId + "/top_media", qs);            
        }

        /// <summary>
        /// Gets the raw JSON response from the Instagram API with the most popular photo and video IG Media objects that have been tagged with this.
        /// </summary>
        /// <param name="tagId">The name of the tag.</param>
        /// <param name="userId">The ID of the Instagram Business or Creator Account performing the query</param>
        /// <param name="count">The maximum amount of media to be returned.</param>
        /// <param name="minTagId">Get media that after this tagId</param>        
        /// <see cref="https://developers.facebook.com/docs/instagram-api/reference/hashtag/top-media"/>
        public SocialHttpResponse GetTopMedia(string tagId, string userId, int count, string minTagId = null)
        {
            return GetTopMedia(tagId, userId, new InstagramTagRecentMediaOptions
            {
                Count = count,
                MinTagId = minTagId,
            });
        }

        /// <summary>
        /// Search for tags by name. Results are IG Hashtag IDs.
        /// </summary>
        /// <param name="userId">The ID of the IG User performing the request</param>
        /// <param name="tag">A valid tag name without a leading #. (eg. snowy, nofilter)</param>
        public SocialHttpResponse Search(string userId, string tag) {

            // Declare the query string
            SocialQueryString qs = new SocialQueryString();
            qs.Add("user_id", userId);
            qs.Add("q", tag);

            // Perform the call to the API
            return Client.DoAuthenticatedGetRequest($"https://graph.facebook.com{Client.GetVersionUrl()}ig_hashtag_search", qs);

        }

        #endregion

    }

}
