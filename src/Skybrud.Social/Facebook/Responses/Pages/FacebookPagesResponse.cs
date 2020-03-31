using Skybrud.Social.Facebook.Objects.Pages;
using Skybrud.Social.Http;
using Skybrud.Social.Json;

namespace Skybrud.Social.Facebook.Responses.Pages {

    public class FacebookPagesResponse : FacebookResponse<FacebookPagesCollection> {

        #region Constructors

        private FacebookPagesResponse(SocialHttpResponse response) : base(response) { }

        #endregion

        #region Static methods

        public static FacebookPagesResponse ParseResponse(SocialHttpResponse response) {

            if (response == null) return null;

            // Parse the raw JSON response
            JsonObject obj = response.GetBodyAsJsonObject();
            if (obj == null) return null;

            // Validate the response
            ValidateResponse(response, obj);

            // Initialize the response object
            return new FacebookPagesResponse(response) {
                Body = FacebookPagesCollection.Parse(obj)
            };

        }

        #endregion

    }

}