using Skybrud.Social.Json;

namespace Skybrud.Social.Google {
    
    /// <summary>
    /// Class representing an object in the Google ecosystem.
    /// </summary>
    public class GoogleApiObject : SocialJsonObject {

        #region Constructor

        protected GoogleApiObject(JsonObject obj) : base(obj) { }

        #endregion

        #region public methods

        /// <summary>
        /// Parse ID from name, ie: accounts/{accountId}
        /// </summary>
        /// <returns></returns>
        public string ParseId()
        {
            var name = JsonObject.GetString("name");
            var slashIndex = name.LastIndexOf('/');
            if (!string.IsNullOrEmpty(name) && slashIndex > 0)
            {
                return name.Substring(slashIndex + 1);
            }
            return string.Empty;
        }

        #endregion

    }

}