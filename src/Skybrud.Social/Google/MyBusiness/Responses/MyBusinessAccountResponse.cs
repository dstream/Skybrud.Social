using Skybrud.Social.Google.MyBusiness.Objects.Accounts;
using Skybrud.Social.Http;
using Skybrud.Social.Json;

namespace Skybrud.Social.Google.MyBusiness.Responses {

    public class MyBusinessAccountResponse : MyBusinessResponse<MyBusinessAccount> {

        #region Constructors

        private MyBusinessAccountResponse(SocialHttpResponse response) : base(response) { }

        #endregion

        #region Static methods

        public static MyBusinessAccountResponse ParseResponse(SocialHttpResponse response) {

            if (response == null) return null;

            // Parse the raw JSON response
            JsonObject obj = response.GetBodyAsJsonObject();
            if (obj == null) return null;

            // Validate the response
            ValidateResponse(response, obj);

            // Initialize the response object
            return new MyBusinessAccountResponse(response) {
                Body = MyBusinessAccount.Parse(obj)
            };

        }

        #endregion

    }

}