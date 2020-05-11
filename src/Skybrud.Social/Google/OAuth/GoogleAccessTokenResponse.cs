using System;
using System.Collections.Generic;
using System.Linq;
using Skybrud.Social.Json;

namespace Skybrud.Social.Google.OAuth {
    
    public class GoogleAccessTokenResponse {

        /// <summary>
        /// The token that can be sent to a Google API.
        /// </summary>
        public string AccessToken { get; private set; }

        /// <summary>
        /// A token that may be used to obtain a new access token. Refresh tokens are valid until the user revokes
        /// access. This field is only present if <var>access_type=offline</var> is included in the authorization
        /// code request.
        /// </summary>
        public string RefreshToken { get; private set; }

        /// <summary>
        /// The remaining lifetime on the access token.
        /// </summary>
        public TimeSpan ExpiresIn { get; private set; }

        /// <summary>
        /// The scopes of access granted by the access_token expressed as a list of space-delimited, case-sensitive strings.
        /// </summary>
        public string Scope { get; private set; }

        /// <summary>
        /// The type of token returned. At this time, this field's value is always set to Bearer.
        /// </summary>
        public string TokenType { get; private set; }

        public static GoogleAccessTokenResponse Parse(JsonObject obj) {
            return new GoogleAccessTokenResponse {
                AccessToken = obj.GetString("access_token"),
                RefreshToken = obj.GetString("refresh_token"),
                ExpiresIn = TimeSpan.FromSeconds(obj.GetInt32("expires_in")),                
                Scope = obj.GetString("scope"),
                TokenType = obj.GetString("token_type")
            };
        }

        /// <summary>
        /// Check all stope granted, return null if all good
        /// </summary>
        /// <param name="requestScopes"></param>
        /// <returns>List of missing permission name, null if all good</returns>
        public IEnumerable<string> IsAllScopeGranted(string requestScopes) {
            if (string.IsNullOrEmpty(requestScopes))
            {
                return null;
            }
            
            if (string.IsNullOrEmpty(Scope))
            {
                return requestScopes.Split(new[] { ' '});
            }
            var scopes = Scope.Split(new[] { ' ' });
            var requestScopeList = requestScopes.Split(new[] { ' ' });
            if (!ArraysEqual(scopes, requestScopeList))
            {
                return requestScopeList.Except(scopes);
            }
            return null;
        }

        private bool ArraysEqual(string[] array1, string[] array2)
        {
            if (array1 == null && array2 == null)
                return true;
            if (array1 == null || array2 == null)
                return false;
            return array1.Count() == array2.Count() && !array1.Except(array2).Any();
        }
    }

}