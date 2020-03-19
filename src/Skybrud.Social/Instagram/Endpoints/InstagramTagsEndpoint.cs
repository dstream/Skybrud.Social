using Skybrud.Social.Instagram.Endpoints.Raw;
using Skybrud.Social.Instagram.Responses;

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
        /// Gets information about the specified <code>tag</code>.
        /// </summary>
        /// <param name="tag">The name of the tag.</param>
        public InstagramTagResponse GetTagInfo(string tag) {
            return InstagramTagResponse.ParseResponse(Raw.GetTagInfo(tag));
        }
        
        /// <summary>
        /// Search for tags by name. Results are ordered first as an exact match, then by popularity. Short tags will be treated as exact matches.
        /// </summary>
        /// <param name="tag">A valid tag name without a leading #. (eg. snowy, nofilter)</param>
        public InstagramSearchTagsResponse Search(string tag) {
            return InstagramSearchTagsResponse.ParseResponse(Raw.Search(tag));
        }

        #endregion

    }

}