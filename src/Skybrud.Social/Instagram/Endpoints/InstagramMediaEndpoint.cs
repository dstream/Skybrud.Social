using Skybrud.Social.Instagram.Endpoints.Raw;
using Skybrud.Social.Instagram.Options;
using Skybrud.Social.Instagram.Responses;

namespace Skybrud.Social.Instagram.Endpoints {

    /// <see cref="http://instagram.com/developer/endpoints/media/"/>
    public class InstagramMediaEndpoint {

        #region Properties

        public InstagramService Service { get; private set; }

        /// <summary>
        /// A reference to the raw endpoint.
        /// </summary>
        public InstagramMediaRawEndpoint Raw {
            get { return Service.Client.Media; }
        }

        #endregion

        #region Constructors

        internal InstagramMediaEndpoint(InstagramService service) {
            Service = service;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets information about a media object.
        /// </summary>
        /// <param name="mediaId">The ID of the media.</param>
        public InstagramMediaResponse GetMedia(string mediaId) {
            return InstagramMediaResponse.ParseResponse(Raw.GetMedia(mediaId));
        }                

        #endregion

    }

}