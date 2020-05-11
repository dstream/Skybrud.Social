using Skybrud.Social.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Skybrud.Social.Google.MyBusiness.Objects.Accounts
{
    public class MyBusinessLocation : GoogleApiResource
    {
        #region Properties

        /// <summary>
        /// accounts/{accountId}/locations/{location_id}
        /// </summary>
        public string Url { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string WebsiteUrl { get; set; }
        public LocationLatLng LatLng { get; set;}
        public PostalAddress Address { get; set; }

        #endregion

        #region Constructors

        protected MyBusinessLocation(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <code>YouTubeChannel</code> from the specified <code>JsonObject</code>.
        /// </summary>
        /// <param name="obj">The instance of <code>JsonObject</code> to parse.</param>
        public static MyBusinessLocation Parse(JsonObject obj)
        {
            if (obj == null) return null;
            var result = new MyBusinessLocation(obj)
            {
                Url = obj.GetString("name"),
                Name = obj.GetString("locationName"),
                WebsiteUrl = obj.GetString("websiteUrl"),
                LatLng = obj.GetObject("latlng", LocationLatLng.Parse),
                Address = obj.GetObject("address", PostalAddress.Parse)
            };
            result.Id = result.ParseId();
            return result;
        }

        #endregion

    }

    public class LocationLatLng : GoogleApiResource
    {
        #region Properties

        public string Latitude { get; set; }
        public string Longitude { get; set; }        

        #endregion

        #region Constructors

        protected LocationLatLng(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <code>YouTubeChannel</code> from the specified <code>JsonObject</code>.
        /// </summary>
        /// <param name="obj">The instance of <code>JsonObject</code> to parse.</param>
        public static LocationLatLng Parse(JsonObject obj)
        {
            if (obj == null) return null;
            var result = new LocationLatLng(obj)
            {
                Latitude = obj.GetString("latitude"),
                Longitude = obj.GetString("longitude")
            };            
            return result;
        }

        #endregion

    }    

    public class LocationMetadata: GoogleApiResource
    {
        #region Properties

        public string MapsUrl { get; set; }
        public string NewReviewUrl { get; set; }
        //TODO: add duplicate property

        #endregion

        #region Constructors

        protected LocationMetadata(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <code>YouTubeChannel</code> from the specified <code>JsonObject</code>.
        /// </summary>
        /// <param name="obj">The instance of <code>JsonObject</code> to parse.</param>
        public static LocationMetadata Parse(JsonObject obj)
        {
            if (obj == null) return null;
            var result = new LocationMetadata(obj)
            {
                MapsUrl = obj.GetString("mapsUrl"),
                NewReviewUrl = obj.GetString("newReviewUrl")
            };
            return result;
        }

        #endregion
    }

    public class LocationReview : GoogleApiResource
    {
        #region Properties

        /// <summary>
        /// accounts/{accountId}/locations/{location_id}/reviews/{reviewId}
        /// </summary>
        public string Url { get; set; }
        public string Id { get; set; }
        public string ReviewId { get; set; }
        public string NewReviewUrl { get; set; }
        public LocationReviewer Reviewer { get; set; }
        public ReviewStarRating StarRating { get; set; }
        public string Comment { get; set; }
        public string CreateTime { get; set; }
        public string UpdateTime { get; set; }
        public LocationReviewReply ReviewReply { get; set; }

        #endregion

        #region Constructors

        protected LocationReview(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <code>YouTubeChannel</code> from the specified <code>JsonObject</code>.
        /// </summary>
        /// <param name="obj">The instance of <code>JsonObject</code> to parse.</param>
        public static LocationReview Parse(JsonObject obj)
        {
            if (obj == null) return null;
            var result = new LocationReview(obj)
            {
                Url = obj.GetString("name"),
                ReviewId = obj.GetString("reviewId"),
                Reviewer = obj.GetObject("reviewer", LocationReviewer.Parse),
                StarRating = obj.GetEnum<ReviewStarRating>("starRating"),
                Comment = obj.GetString("comment"),
                CreateTime = obj.GetString("createTime"),
                UpdateTime = obj.GetString("updateTime"),
                ReviewReply = obj.GetObject("reviewReply", LocationReviewReply.Parse),
            };
            return result;
        }

        #endregion
    }

    public class LocationReviewer : GoogleApiResource
    {
        #region Properties

        public string ProfilePhotoUrl { get; set; }
        public string DisplayName { get; set; }
        public bool IsAnonymous { get; set; }        

        #endregion

        #region Constructors

        protected LocationReviewer(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <code>YouTubeChannel</code> from the specified <code>JsonObject</code>.
        /// </summary>
        /// <param name="obj">The instance of <code>JsonObject</code> to parse.</param>
        public static LocationReviewer Parse(JsonObject obj)
        {
            if (obj == null) return null;
            var result = new LocationReviewer(obj)
            {
                ProfilePhotoUrl = obj.GetString("profilePhotoUrl"),
                DisplayName = obj.GetString("displayName"),
                IsAnonymous = obj.GetBoolean("isAnonymous")
            };
            return result;
        }

        #endregion
    }

    public class LocationReviewReply : GoogleApiResource
    {
        #region Properties

        public string Comment { get; set; }
        public string UpdateTime { get; set; }        

        #endregion

        #region Constructors

        protected LocationReviewReply(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <code>YouTubeChannel</code> from the specified <code>JsonObject</code>.
        /// </summary>
        /// <param name="obj">The instance of <code>JsonObject</code> to parse.</param>
        public static LocationReviewReply Parse(JsonObject obj)
        {
            if (obj == null) return null;
            var result = new LocationReviewReply(obj)
            {
                Comment = obj.GetString("comment"),
                UpdateTime = obj.GetString("updateTime"),                
            };
            return result;
        }

        #endregion
    }
}
