using Skybrud.Social.Facebook.Objects.Pagination;
using Skybrud.Social.Json;

namespace Skybrud.Social.Facebook.Objects.Pages {

    public class FacebookPagesCollection : SocialJsonObject {

        #region Properties

        public FacebookPage[] Data { get; private set; }

        public FacebookCursorBasedPagination Paging { get; private set; }

        #endregion
        
        #region Constructors

        private FacebookPagesCollection(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        public static FacebookPagesCollection Parse(JsonObject obj) {
            if (obj == null) return null;
            return new FacebookPagesCollection(obj) {
                Data = obj.GetArray("data", FacebookPage.Parse),
                Paging = obj.GetObject("paging", FacebookCursorBasedPagination.Parse)
            };
        }

        #endregion
    
    }

}