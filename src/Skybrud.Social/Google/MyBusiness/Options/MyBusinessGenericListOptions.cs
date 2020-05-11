using System;
using Skybrud.Social.Http;
using Skybrud.Social.Interfaces;

namespace Skybrud.Social.Google.MyBusiness.Options {
    
    public class MyBusinessGenericListOptions : IGetOptions {

        #region Properties


        /// <summary>
        /// Sorting order for the request. Multiple fields should be comma-separated, following SQL syntax. 
        /// The default sorting order is ascending. To specify descending order, a suffix " desc" should be added.
        /// Valid fields to orderBy are locationName and storeCode. For example: "locationName, storeCode desc" 
        /// or "locationName" or "storeCode desc"         
        /// </summary>
        public string OrderBy { get; set; }
        
        /// <summary>
        /// Gets or sets the maximum amount if items to return on each page (maximum is 50).
        /// </summary>
        public int MaxResults { get; set; }

        /// <summary>
        /// Gets or sets the page token.
        /// </summary>
        public string PageToken { get; set; }        

        /// <summary>
        /// If the number of items exceeded the requested page size, this field is populated with a token
        /// to fetch the next page of reviews on a subsequent call. If there are no more items, this field
        /// is not present in the response. 
        /// </summary>
        public string NextPageToken { get; set; }

        /// <summary>
        /// Select top items
        /// </summary>
        public int Top { get; set; }

        #endregion

        #region Constructors

        public MyBusinessGenericListOptions() {
            MaxResults = 200;
        }

        #endregion

        #region Member methods

        public virtual SocialQueryString GetQueryString() {
            var query = new SocialQueryString();                                    
            if (MaxResults > 0) query.Add("pageSize", MaxResults);            
            if (!String.IsNullOrWhiteSpace(PageToken)) query.Add("pageToken", PageToken);
            if (!String.IsNullOrWhiteSpace(OrderBy)) query.Add("orderBy", OrderBy);
            if (!String.IsNullOrWhiteSpace(NextPageToken)) query.Add("nextPageToken", NextPageToken);
            return query;
        }

        #endregion

    }

}