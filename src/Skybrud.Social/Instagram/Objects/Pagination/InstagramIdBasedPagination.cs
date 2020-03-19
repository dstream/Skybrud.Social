using Skybrud.Social.Json;

namespace Skybrud.Social.Instagram.Objects.Pagination {

    public class InstagramIdBasedPagination : SocialJsonObject {

        #region Properties

        public string NextUrl { get; set; }

        public InstagramIdBasedPaginationCursors Cursors { get; set; }

        #endregion

        #region Constructors

        private InstagramIdBasedPagination(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        public static InstagramIdBasedPagination Parse(JsonObject obj) {
            if (obj == null) return null;            
            return new InstagramIdBasedPagination(obj) {
                NextUrl = obj.GetString("next"),
                Cursors = obj.GetObject("cursors", InstagramIdBasedPaginationCursors.Parse)
            };
        }

        #endregion

    }

    public class InstagramIdBasedPaginationCursors : SocialJsonObject
    {
        public string After { get; set; }
        public string Before { get; set; }

        private InstagramIdBasedPaginationCursors(JsonObject obj) : base(obj) { }

        public static InstagramIdBasedPaginationCursors Parse(JsonObject obj)
        {
            if (obj == null) return null;
            return new InstagramIdBasedPaginationCursors(obj)
            {
                After = obj.GetString("after"),
                Before = obj.GetString("before")
            };
        }
    }

}