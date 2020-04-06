using Skybrud.Social.Instagram.Endpoints.Raw;
using Skybrud.Social.Instagram.Responses;
using System.Collections.Generic;

namespace Skybrud.Social.Instagram.Endpoints {

    /// <see cref="http://instagram.com/developer/endpoints/tags/"/>
    public class InstagramTagsEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the parent Instagram service.
        /// </summary>
        public InstagramService Service { get; private set; }

        /// <summary>
        /// A reference to the raw endpoint.
        /// </summary>
        public InstagramTagsRawEndpoint Raw {
            get { return Service.Client.Tags; }
        }

        #endregion

        #region Constructors

        internal InstagramTagsEndpoint(InstagramService service) {
            Service = service;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets information about the specified tagId.
        /// </summary>
        /// <param name="tagId">The Id of the tag.</param>
        public InstagramTagResponse GetTagInfo(string tagId) {
            return InstagramTagResponse.ParseResponse(Raw.GetTagInfo(tagId));
        }

        /// <summary>
        /// Search for tags by name. Results are IG Hashtag IDs.
        /// </summary>
        /// <param name="userId">The ID of the IG User performing the request</param>
        /// <param name="tag">A valid tag name without a leading #. (eg. snowy, nofilter)</param>
        public InstagramSearchTagsResponse Search(string userId, string tag) {
            return InstagramSearchTagsResponse.ParseResponse(Raw.Search(userId, tag));
        }

        /// <summary>
        /// Gets the most recent photo and video IG Media objects that have been tagged with this.
        /// </summary>
        /// <param name="tagId">The name of the tag.</param>
        /// <param name="count">The maximum amount of media to be returned.</param>
        /// <param name="minTagId">Get media that after this tagId</param>        
        public InstagramRecentMediaResponse GetRecentMedia(string tagId, string userId, int count)
        {
            var mediaResponse = InstagramMediasResponseBody.Parse(InstagramRecentMediaResponse.ParseResponse(Raw.GetRecentMedia(tagId, userId)));
            var result = new InstagramRecentMediaResponse();
            result.AppendBody(mediaResponse.Data);

            while (result.CountBody() < count && mediaResponse.Pagination != null && !string.IsNullOrEmpty(mediaResponse.Pagination.NextUrl))
            {
                mediaResponse = InstagramMediasResponseBody.Parse(InstagramRecentMediaResponse.ParseResponse(Raw.Client.DoAuthenticatedGetRequest(mediaResponse.Pagination.NextUrl)));
                result.AppendBody(mediaResponse.Data);
            }
            result.EnsureBodyCount(count);

            EnsureVideoHasThumbnail(result);

            return result;
        }

        /// <summary>
        /// Gets the most popular photo and video IG Media objects that have been tagged with this.
        /// </summary>
        /// <param name="tagId">The name of the tag.</param>
        /// <param name="count">The maximum amount of media to be returned.</param>
        /// <param name="minTagId">Get media that after this tagId</param>        
        public InstagramRecentMediaResponse GetTopMedia(string tagId, string userId, int count)
        {
            var mediaResponse = InstagramMediasResponseBody.Parse(InstagramRecentMediaResponse.ParseResponse(Raw.GetTopMedia(tagId, userId)));
            var result = new InstagramRecentMediaResponse();
            result.AppendBody(mediaResponse.Data);

            while (result.CountBody() < count && mediaResponse.Pagination != null && !string.IsNullOrEmpty(mediaResponse.Pagination.NextUrl))
            {
                mediaResponse = InstagramMediasResponseBody.Parse(InstagramRecentMediaResponse.ParseResponse(Raw.Client.DoAuthenticatedGetRequest(mediaResponse.Pagination.NextUrl)));
                result.AppendBody(mediaResponse.Data);
            }
            result.EnsureBodyCount(count);

            EnsureVideoHasThumbnail(result);

            return result;
        }

        private void EnsureVideoHasThumbnail(InstagramRecentMediaResponse mediaResponse)
        {
            //get thumbnail_url of videos
            foreach (var media in mediaResponse.Body)
            {
                if (media.Type == "VIDEO")
                {
                    var singleMediaResult = InstagramMediaResponse.ParseResponse(Service.Client.Media.GetMedia(media.Id, InstagramMediaField.thumbnail_url));
                    media.Thumbnail = singleMediaResult.Body.Data.Thumbnail;
                }
            }
        }

        #endregion

    }

}