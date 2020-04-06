using Skybrud.Social.Http;
using Skybrud.Social.Instagram.OAuth;
using Skybrud.Social.Instagram.Objects;
using Skybrud.Social.Instagram.Options;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Skybrud.Social.Instagram.Endpoints.Raw {

    /// <see cref="http://instagram.com/developer/endpoints/media/"/>
    public class InstagramMediaRawEndpoint {

        #region Properties

        public InstagramOAuthClient Client { get; private set; }

        #endregion

        #region Constructors

        internal InstagramMediaRawEndpoint(InstagramOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets information about a media object. Please note that this API doesn't store result in data attribute like others
        /// </summary>
        /// <param name="mediaId">The ID of the media.</param>
        /// <see cref="https://developers.facebook.com/docs/instagram-basic-display-api/reference/media"/>
        public SocialHttpResponse GetMedia(string mediaId, params InstagramMediaField[] fields) {
            var fieldsStr = fields != null 
                    ? string.Join(",", fields.Select(v => v.ToString()))
                    : InstagramMedia.DefaultFields;
            if (Client.UseInstagramGraphAPI)
            {
                return Client.DoAuthenticatedGetRequest($"https://graph.facebook.com/{mediaId}?fields={fieldsStr}");
            }
            return Client.DoAuthenticatedGetRequest($"https://graph.instagram.com/{mediaId}?fields={fieldsStr}");
        }

        /// <summary>
        /// Gets a collection of IG Media Id on an album IG Media.
        /// </summary>
        /// <param name="mediaId">The ID of the media.</param>
        /// <see cref="https://developers.facebook.com/docs/instagram-api/reference/media/children"/>
        public SocialHttpResponse GetChildren(string mediaId)
        {
            if (Client.UseInstagramGraphAPI)
            {
                return Client.DoAuthenticatedGetRequest($"https://graph.facebook.com/{mediaId}?children");
            }
            return Client.DoAuthenticatedGetRequest($"https://graph.instagram.com/{mediaId}/children");
        }

        #endregion

    }

}