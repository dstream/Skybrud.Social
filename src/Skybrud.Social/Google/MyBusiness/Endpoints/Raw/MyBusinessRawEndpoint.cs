using Skybrud.Social.Google.OAuth;

namespace Skybrud.Social.Google.MyBusiness.Endpoints.Raw {
    
    public class MyBusinessRawEndpoint
    {

        #region Properties

        public GoogleOAuthClient Client { get; private set; }        

        public MyBusinessAccountsRawEndpoint Accounts { get; private set; }

        public MyBusinessLocationRawEndpoint Locations { get; private set; }

        #endregion

        #region Constructors

        public MyBusinessRawEndpoint(GoogleOAuthClient client) {
            Client = client;            
            Accounts = new MyBusinessAccountsRawEndpoint(client);
            Locations = new MyBusinessLocationRawEndpoint(client);
        }

        #endregion

    }

}