using System;
using Skybrud.Social.Google.MyBusiness.Options;
using Skybrud.Social.Google.OAuth;
using Skybrud.Social.Http;

namespace Skybrud.Social.Google.MyBusiness.Endpoints.Raw {

    public class MyBusinessAccountsRawEndpoint
    {

        #region Properties

        public GoogleOAuthClient Client { get; private set; }

        #endregion

        #region Constructors

        public MyBusinessAccountsRawEndpoint(GoogleOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets the specified account. Returns NOT_FOUND if the account does not exist or if the caller does not have access rights to it.
        /// </summary>
        /// <param name="name">The name of the account to fetch.</param>
        public SocialHttpResponse Get(string name) {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name");
            }            
            return Client.DoAuthenticatedGetRequest("https://mybusiness.googleapis.com/v4/accounts/?topicName=" + name);
        }

        public SocialHttpResponse List(MyBusinessGenericListOptions options)
        {            
            return Client.DoAuthenticatedGetRequest("https://mybusiness.googleapis.com/v4/accounts", options);
        }

        #endregion

    }

}