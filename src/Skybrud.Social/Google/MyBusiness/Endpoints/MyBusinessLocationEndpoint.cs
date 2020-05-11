using Skybrud.Social.Google.MyBusiness.Endpoints.Raw;
using Skybrud.Social.Google.MyBusiness.Objects;
using Skybrud.Social.Google.MyBusiness.Objects.Accounts;
using Skybrud.Social.Google.MyBusiness.Options;
using Skybrud.Social.Google.MyBusiness.Responses;
using Skybrud.Social.Json;
using System;
using System.Linq;

namespace Skybrud.Social.Google.MyBusiness.Endpoints {
    
    public class MyBusinessLocationEndpoint
    {

        #region Properties

        /// <summary>
        /// Gets the parent service of this endpoint.
        /// </summary>
        public GoogleService Service { get; private set; }

        /// <summary>
        /// Gets the parent endpoint of this endpoint.
        /// </summary>
        public MyBusinessEndpoint MyBusinessEnpoint { get; private set; }

        public MyBusinessLocationRawEndpoint Raw {
            get { return MyBusinessEnpoint.Service.Client.MyBusiness.Locations; }
        }

        #endregion

        #region Constructors

        internal MyBusinessLocationEndpoint(MyBusinessEndpoint endpoint) {
            MyBusinessEnpoint = endpoint;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets the specified account. Returns NOT_FOUND if the account does not exist or if the caller does not have access rights to it.
        /// </summary>
        /// <param name="options">The options for the call to the API.</param>
        public GenericResponse<MyBusinessLocation> Get(string accountId, string name) {
            return GenericResponse<MyBusinessLocation>.ParseResponse(Raw.Get(accountId, name), MyBusinessLocation.Parse);
        }

        /// <summary>
        /// Lists all of the accounts for the authenticated user. This includes all accounts that the user owns, as well as any accounts for which the user has management rights.
        /// </summary>
        /// <param name="options">The options for the call to the API.</param>
        public GenericResponse<GenericListResponse<MyBusinessLocation>> List(string accountId, MyBusinessLocationListOptions options = null)
        {            
            if(options == null)
            {
                options = new MyBusinessLocationListOptions();
            }
            return GenericResponse<GenericListResponse<MyBusinessLocation>>.ParseResponse(Raw.List(accountId, options), Parse);
        }

        /// <summary>
        /// Get top 200 items for default, use options to change this
        /// </summary>
        /// <param name="locationUrl">accounts/{accountId}/locations/{locationId}</param>
        /// <param name="options"></param>
        /// <param name="filter">location reviews filter function</param>
        /// <returns></returns>
        public GenericResponse<ReviewListResponse> GetReviews(string locationUrl, MyBusinessGenericListOptions options = null, Func<LocationReview, bool> filter = null)
        {
            if (options == null)
            {
                options = new MyBusinessGenericListOptions();
            }

            var result = GenericResponse<ReviewListResponse>.ParseResponse(Raw.GetReviews(locationUrl, options), ParseReviews);
            if (filter != null && result.Body.Items != null)
            {
                result.Body.Items = result.Body.Items.Where(filter).ToList();
            }
            if (options.Top > 0)
            {
                options.NextPageToken = result.Body.NextPageToken;
                while (result.Body.CountBody() < options.Top && !string.IsNullOrEmpty(result.Body.NextPageToken))
                {                    
                    var response = GenericResponse<ReviewListResponse>.ParseResponse(Raw.GetReviews(locationUrl, options), ParseReviews);
                    result.Body.AppendItems(filter != null ? response.Body.Items.Where(filter) : response.Body.Items);
                    options.NextPageToken = response.Body.NextPageToken;
                }
                result.Body.EnsureItemsCount(options.Top);
            }

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="locationUrl"></param>
        /// <param name="hasCommentOny"></param>
        /// <param name="top"></param>
        /// <returns></returns>
        public GenericResponse<ReviewListResponse> GetFiveStarReviews(string locationUrl, bool hasCommentOny, int top)
        {
            if(top < 1)
            {
                return null;
            }            
            var options = new MyBusinessGenericListOptions
            {
                OrderBy = "rating desc",
                Top = top
            };
            if(top > options.MaxResults)
            {
                top = options.MaxResults;
            }
            var result = hasCommentOny? 
                GetReviews(locationUrl, options, (e) => e.StarRating == ReviewStarRating.FIVE && !string.IsNullOrEmpty(e.Comment)): 
                GetReviews(locationUrl, options, (e) => e.StarRating == ReviewStarRating.FIVE);
            if (result.Body.Items.Any()) {
                result.Body.Items = result.Body.Items.Take(top).ToList();
            }
            return result;
        }


        private GenericListResponse<MyBusinessLocation> Parse(JsonObject obj)
        {
            return GenericListResponse<MyBusinessLocation>.Parse(obj, MyBusinessLocation.Parse, "locations");
        }

        private ReviewListResponse ParseReviews(JsonObject obj)
        {
            return ReviewListResponse.Parse(obj, LocationReview.Parse);
        }

        #endregion

    }

}