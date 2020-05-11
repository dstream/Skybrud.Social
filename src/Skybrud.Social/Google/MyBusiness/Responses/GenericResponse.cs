using Skybrud.Social.Google.MyBusiness.Objects.Accounts;
using Skybrud.Social.Http;
using Skybrud.Social.Json;
using System.Collections.Generic;

namespace Skybrud.Social.Google.MyBusiness.Responses {

    public class GenericResponse<T> : MyBusinessResponse<T> {

        #region Constructors        

        private GenericResponse(SocialHttpResponse response) : base(response) { }


        #endregion

        #region Static methods

        public static GenericResponse<T> ParseResponse(SocialHttpResponse response, System.Func<JsonObject, T> parse) {

            if (response == null) return null;

            // Parse the raw JSON response
            JsonObject obj = response.GetBodyAsJsonObject();
            if (obj == null) return null;

            // Validate the response
            ValidateResponse(response, obj);

            // Initialize the response object
            return new GenericResponse<T>(response) {
                Body = parse(obj)
            };

        }        

        #endregion

    }

}