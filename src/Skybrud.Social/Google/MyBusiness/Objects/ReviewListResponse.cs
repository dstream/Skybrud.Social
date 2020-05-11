using Skybrud.Social.Google.MyBusiness.Objects.Accounts;
using Skybrud.Social.Json;
using System.Collections.Generic;

namespace Skybrud.Social.Google.MyBusiness.Objects {

    public class ReviewListResponse : GenericListResponse<LocationReview>
    {

        #region Properties

        public float AverageRating { get; private set; }        
        public int TotalReviewCount { get; private set; }

        #endregion

        #region Constructors

        protected ReviewListResponse(JsonObject obj) : base(obj) { }
       
        #endregion

        #region Static methods

        public static ReviewListResponse Parse(JsonObject obj, System.Func<JsonObject, LocationReview> itemParse) {
            if (obj == null) return null;
            var result = GenericListResponse<LocationReview>.Parse(obj, itemParse, "reviews");            
            return new ReviewListResponse(obj) {
                Items = result.Items,
                NextPageToken = result.NextPageToken,
                PrevPageToken = result.PrevPageToken,
                AverageRating = obj.GetFloat("averageRating"),   
                TotalReviewCount = obj.GetInt32("totalReviewCount")
            };
        }

        #endregion

    }

}