using System;
using Skybrud.Social.Http;
using Skybrud.Social.Json;
using Skybrud.Social.Instagram.Objects;
using Skybrud.Social.Instagram.Objects.Pagination;
using System.Collections.Generic;
using System.Linq;

namespace Skybrud.Social.Instagram.Responses {

    public class InstagramRecentMediaResponse : InstagramResponse<List<InstagramMedia>> {

        #region Constructors        

        public InstagramRecentMediaResponse() {
            Body = new List<InstagramMedia>();
        }

        private InstagramRecentMediaResponse(SocialHttpResponse response) : base(response) { }

        #endregion

        #region Static methods
        
        public static JsonObject ParseResponse(SocialHttpResponse response) {

            // Some input validation
            if (response == null) throw new ArgumentNullException("response");

            // Parse the raw JSON response
            JsonObject obj = response.GetBodyAsJsonObject();
            if (obj == null) return null;

            // Validate the response
            ValidateResponse(response, obj);

            return obj;

        }

        public void AppendBody(IEnumerable<InstagramMedia> body)
        {
            if (body == null) return;
            EnsureBodyNotNull();            
            Body.AddRange(body);
        }

        public int CountBody()
        {
            EnsureBodyNotNull();
            return Body.Count;
        }

        /// <summary>
        /// Ensure only get [count] of data
        /// </summary>
        /// <param name="count"></param>
        public void EnsureBodyCount(int count) {
            Body = Body.Take(count).ToList();
        }

        private void EnsureBodyNotNull()
        {
            if (Body == null)
            {
                Body = new List<InstagramMedia>();
            }
        }

        #endregion

    }

    public class InstagramMediasResponseBody : InstagramResponseBody<InstagramMedia[]> {

        #region Properties

        public InstagramIdBasedPagination Pagination { get; private set; }

        #endregion

        #region Constructors

        protected InstagramMediasResponseBody(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods        

        public static InstagramMediasResponseBody Parse(JsonObject obj) {
            return new InstagramMediasResponseBody(obj) {
                Pagination = obj.GetObject("paging", InstagramIdBasedPagination.Parse),
                Data = obj.GetArray("data", InstagramMedia.Parse)
            };
        }

        #endregion

    }

}