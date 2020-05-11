using Skybrud.Social.Google.MyBusiness.Endpoints.Raw;

namespace Skybrud.Social.Google.MyBusiness.Endpoints {

    public class MyBusinessEndpoint
    {

        #region Private fields
        
        private MyBusinessAccountsEndpoint _accounts;
        private MyBusinessLocationEndpoint _locations;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the parent service of this endpoint.
        /// </summary>
        public GoogleService Service { get; private set; }
        
        public MyBusinessRawEndpoint Raw {
            get { return Service.Client.MyBusiness; }
        }        


        /// <summary>
        /// Gets a reference to the channels endpoint.
        /// </summary>
        public MyBusinessAccountsEndpoint Accounts
        {
            get { return _accounts ?? (_accounts = new MyBusinessAccountsEndpoint(this)); }
        }

        /// <summary>
        /// Gets a reference to the channels endpoint.
        /// </summary>
        public MyBusinessLocationEndpoint Locations
        {
            get { return _locations ?? (_locations = new MyBusinessLocationEndpoint(this)); }
        }

        #endregion

        #region Constructors

        internal MyBusinessEndpoint(GoogleService service) {
            Service = service;
        }

        #endregion

    }

}