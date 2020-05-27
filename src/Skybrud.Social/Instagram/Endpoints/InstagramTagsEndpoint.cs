using Skybrud.Social.Instagram.Endpoints.Raw;
using Skybrud.Social.Instagram.Objects;
using Skybrud.Social.Instagram.Responses;
using System.Collections.Generic;
using System.Linq;

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
        /// Gets the most recent photo and video IG Media objects (not album) that have been tagged with this.
        /// </summary>
        /// <param name="tagId">The name of the tag.</param>
        /// <param name="count">The maximum amount of media to be returned.</param>
        /// <param name="minTagId">Get media that after this tagId</param>        
        public InstagramRecentMediaResponse GetRecentMedia(string tagId, string userId, int count)
        {
            var mediaResponse = InstagramMediasResponseBody.Parse(InstagramRecentMediaResponse.ParseResponse(Raw.GetRecentMedia(tagId, userId)));
            var result = new InstagramRecentMediaResponse();
            //have to use hashset here because the tag API returns duplicated images
            var hashset = new HashSet<InstagramMedia>(mediaResponse.Data.Where(e => e.IsMediaType(InstagramMediaType.IMAGE)), new InstagramMediaComparer());

            while (hashset.Count < count && mediaResponse.Pagination != null && !string.IsNullOrEmpty(mediaResponse.Pagination.NextUrl))
            {
                mediaResponse = InstagramMediasResponseBody.Parse(InstagramRecentMediaResponse.ParseResponse(Raw.Client.DoAuthenticatedGetRequest(mediaResponse.Pagination.NextUrl)));
                hashset.UnionWith(mediaResponse.Data.Where(e => e.IsMediaType(InstagramMediaType.IMAGE)));
            }
            result.SetBody(hashset.Take(count).ToList());

            return result;
        }

        /// <summary>
        /// Gets the most popular photo and video IG Media objects (not album) that have been tagged with this.
        /// </summary>
        /// <param name="tagId">The name of the tag.</param>
        /// <param name="count">The maximum amount of media to be returned.</param>
        /// <param name="minTagId">Get media that after this tagId</param>        
        public InstagramRecentMediaResponse GetTopMedia(string tagId, string userId, int count)
        {
            var mediaResponse = InstagramMediasResponseBody.Parse(InstagramRecentMediaResponse.ParseResponse(Raw.GetTopMedia(tagId, userId)));
            var result = new InstagramRecentMediaResponse();
            var hashset = new HashSet<InstagramMedia>(mediaResponse.Data.Where(e => e.IsMediaType(InstagramMediaType.IMAGE)), new InstagramMediaComparer());                        

            while (hashset.Count < count && mediaResponse.Pagination != null && !string.IsNullOrEmpty(mediaResponse.Pagination.NextUrl))
            {
                mediaResponse = InstagramMediasResponseBody.Parse(InstagramRecentMediaResponse.ParseResponse(Raw.Client.DoAuthenticatedGetRequest(mediaResponse.Pagination.NextUrl)));
                hashset.UnionWith(mediaResponse.Data.Where(e => e.IsMediaType(InstagramMediaType.IMAGE)));                
            }
            result.SetBody(hashset.Take(count).ToList());

            return result;
        }

        /// <summary>
        /// get thumbnail_url of videos and albums
        /// This API doesn't work atm, this's a bug maybe
        /// </summary>
        /// <param name="mediaResponse"></param>
        private void EnsureMediaHasThumbnail(InstagramRecentMediaResponse mediaResponse)
        {            
            foreach (var media in mediaResponse.Body)
            {
                if (!media.IsMediaType(Objects.InstagramMediaType.IMAGE))
                {
                    try
                    {
                        var singleMediaResult = InstagramMediaResponse.ParseResponse(Service.Client.Media.GetMedia(media.Id, InstagramMediaField.thumbnail_url));
                        media.Thumbnail = singleMediaResult.Body.Data.Thumbnail;
                    }
                    catch 
                    {
                        //ignore it
                    }
                }
            }
        }

        #endregion

    }

}