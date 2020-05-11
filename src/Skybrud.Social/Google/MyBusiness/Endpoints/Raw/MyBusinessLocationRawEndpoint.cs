using System;
using Skybrud.Social.Google.MyBusiness.Options;
using Skybrud.Social.Google.OAuth;
using Skybrud.Social.Http;

namespace Skybrud.Social.Google.MyBusiness.Endpoints.Raw {

    public class MyBusinessLocationRawEndpoint
    {

        #region Properties

        public GoogleOAuthClient Client { get; private set; }

        #endregion

        #region Constructors

        public MyBusinessLocationRawEndpoint(GoogleOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets the specified account. Returns NOT_FOUND if the account does not exist or if the caller does not have access rights to it.
        /// </summary>
        /// <param name="name">The name of the account to fetch.</param>
        public SocialHttpResponse Get(string accountId, string name) {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name");
            }            
            return Client.DoAuthenticatedGetRequest($"https://mybusiness.googleapis.com/v4/accounts/{accountId}/?name=" + name);
        }

        public SocialHttpResponse List(string accountId, MyBusinessLocationListOptions options)
        {            
            return Client.DoAuthenticatedGetRequest($"https://mybusiness.googleapis.com/v4/accounts/{accountId}/locations", options);
        }

        /// <summary>
        /// Get top 200 reviews
        /// </summary>
        /// <param name="locationUrl">accounts/{accountId}/locations/{locationId}</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public SocialHttpResponse GetReviews(string locationUrl, MyBusinessGenericListOptions options)
        {
            return Client.DoAuthenticatedGetRequest($"https://mybusiness.googleapis.com/v4/{locationUrl}/reviews", options);
        }        

        /// <summary>
        /// Get top 200 reviews
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="locationId"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public SocialHttpResponse GetReviews(string accountId, string locationId, MyBusinessGenericListOptions options)
        {
            return GetReviews($"accounts/{accountId}/locations/{locationId}", options);
        }

        #endregion

    }

}