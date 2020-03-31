using System;
using System.Collections.Generic;
using System.Linq;
using Skybrud.Social.Http;
using Skybrud.Social.Instagram.OAuth;
using Skybrud.Social.Instagram.Options.Users;

namespace Skybrud.Social.Instagram.Endpoints.Raw {
    
    /// <see>
    ///     <cref>https://instagram.com/developer/endpoints/users/</cref>
    /// </see>
    public class InstagramUsersRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the Instagram OAuth client.
        /// </summary>
        public InstagramOAuthClient Client { get; private set; }

        #endregion

        #region Constructors

        internal InstagramUsersRawEndpoint(InstagramOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets information about the user with the specified <code>identifier</code>.
        /// </summary>
        /// <param name="identifier">The identifier of the user: UserId or Me.</param>
        /// <param name="fields">A comma-separated list of fields and edges you want returned. If omitted, default fields will be returned.</param>
        public SocialHttpResponse GetUser(string identifier, IEnumerable<InstagramUserField> fields = null) {
            var url = "https://graph.instagram.com/" + identifier;
            if (fields == null)
            {
                url += "?fields=" + string.Join(",", Enum.GetValues(typeof(InstagramUserField)).Cast<InstagramUserField>().Select(v => v.ToString()));
            }

            return Client.DoAuthenticatedGetRequest(url);
        }                
        
        /// <summary>
        /// Get user's medias (image, video, or album)
        /// You will need the instagram_graph_user_profile permission, so request the user_profile scope when you get authorization from the user.
        /// </summary>
        /// <param name="identifier">UserId or Me</param>
        /// <param name="count"></param>
        /// <returns></returns>
        public SocialHttpResponse GetRecentMedia(string identifier)
        {
            var fields = string.Join(",", Enum.GetValues(typeof(InstagramMediaField)).Cast<InstagramMediaField>().Select(v => v.ToString()));
            var url = $"https://graph.instagram.com/{identifier}/media?fields={fields}";
            if (Client.UseInstagramGraphAPI)
            {
                var extrafields = string.Join(",", Enum.GetValues(typeof(InstagramMediaExtraField)).Cast<InstagramMediaExtraField>().Select(v => v.ToString())); 
                url = $"https://graph.facebook.com{Client.GetVersionUrl()}{identifier}/media?fields={fields + "," + extrafields}";
            }

            return Client.DoAuthenticatedGetRequest(url);
        }
        
        #endregion

    }

}