using Skybrud.Social.Json;

namespace Skybrud.Social.Instagram.Objects {

    public class InstagramMetaData : SocialJsonObject {

        #region Properties

        public int Code { get; private set; }

        public string ErrorType { get; private set; }

        public string ErrorMessage { get; private set; }

        #endregion

        #region Constructors

        private InstagramMetaData(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Parse error from instagram basic api
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static InstagramMetaData ParseMeta(JsonObject obj) {
            if (obj == null) return null;
            return new InstagramMetaData(obj) {
                Code = obj.GetInt32("code"),
                ErrorType = obj.GetString("error_type"),
                ErrorMessage = obj.GetString("error_message")
            };
        }

        /// <summary>
        /// Parse error from facebook graph api
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static InstagramMetaData ParseError(JsonObject obj)
        {
            if (obj == null) return null;
            return new InstagramMetaData(obj)
            {
                Code = obj.GetInt32("code"),
                ErrorType = obj.GetString("type"),
                ErrorMessage = obj.GetString("message")
            };
        }

        #endregion

    }

}