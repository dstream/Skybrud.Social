using System;
using Skybrud.Social.Http;
using Skybrud.Social.Interfaces;

namespace Skybrud.Social.Instagram.Options.Tags {
    
    public class InstagramTagRecentMediaOptions : IGetOptions {

        #region Properties

        /// <summary>
        /// Gets or sets the maximum amount of media to return.
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Get media that after this tagId
        /// </summary>
        public string MinTagId { get; set; }        

        #endregion

        #region Constructors

        public InstagramTagRecentMediaOptions() { }

        public InstagramTagRecentMediaOptions(int count) {
            Count = count;
        }

        public InstagramTagRecentMediaOptions(string minTagId) {
            MinTagId = minTagId;           
        }

        public InstagramTagRecentMediaOptions(int count, string minTagId) {
            Count = count;
            MinTagId = minTagId;            
        }

        #endregion

        #region Member methods

        public SocialQueryString GetQueryString() {
            SocialQueryString qs = new SocialQueryString();
            if (Count > 0) qs.Add("limit", Count);
            if (!String.IsNullOrWhiteSpace(MinTagId)) qs.Add("after", MinTagId);            
            return qs;
        }

        #endregion

    }

}