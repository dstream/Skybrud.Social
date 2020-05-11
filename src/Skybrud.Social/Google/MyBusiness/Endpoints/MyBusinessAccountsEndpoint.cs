using Skybrud.Social.Google.MyBusiness.Endpoints.Raw;
using Skybrud.Social.Google.MyBusiness.Objects;
using Skybrud.Social.Google.MyBusiness.Objects.Accounts;
using Skybrud.Social.Google.MyBusiness.Options;
using Skybrud.Social.Google.MyBusiness.Responses;
using Skybrud.Social.Json;

namespace Skybrud.Social.Google.MyBusiness.Endpoints {
    
    public class MyBusinessAccountsEndpoint
    {

        #region Properties

        /// <summary>
        /// Gets the parent service of this endpoint.
        /// </summary>
        public GoogleService Service { get; private set; }

        /// <summary>
        /// Gets the parent endpoint of this endpoint.
        /// </summary>
        public MyBusinessEndpoint MyBusinessEnpoint { get; private set; }

        public MyBusinessAccountsRawEndpoint Raw {
            get { return MyBusinessEnpoint.Service.Client.MyBusiness.Accounts; }
        }

        #endregion

        #region Constructors

        internal MyBusinessAccountsEndpoint(MyBusinessEndpoint endpoint) {
            MyBusinessEnpoint = endpoint;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets the specified account. Returns NOT_FOUND if the account does not exist or if the caller does not have access rights to it.
        /// </summary>
        /// <param name="options">The options for the call to the API.</param>
        public GenericResponse<MyBusinessAccount> Get(string name) {
            return GenericResponse<MyBusinessAccount>.ParseResponse(Raw.Get(name), MyBusinessAccount.Parse);
        }

        /// <summary>
        /// Lists all of the accounts for the authenticated user. This includes all accounts that the user owns, as well as any accounts for which the user has management rights.
        /// </summary>
        /// <param name="options">The options for the call to the API.</param>
        public GenericResponse<GenericListResponse<MyBusinessAccount>> List(MyBusinessGenericListOptions options = null)
        {            
            if(options == null)
            {
                options = new MyBusinessGenericListOptions
                {
                    MaxResults = 50
                };
            }
            return GenericResponse<GenericListResponse<MyBusinessAccount>>.ParseResponse(Raw.List(options), Parse);
        }

        private GenericListResponse<MyBusinessAccount> Parse(JsonObject obj)
        {
            return GenericListResponse<MyBusinessAccount>.Parse(obj, MyBusinessAccount.Parse, "accounts");
        }

        #endregion

    }

}