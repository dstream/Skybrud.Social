using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Skybrud.Social.Instagram.Endpoints.Raw;
using Skybrud.Social.Instagram.Objects;
using Skybrud.Social.Instagram.Options.Users;
using Skybrud.Social.Instagram.Responses;

namespace Skybrud.Social.Instagram.Endpoints {

    /// <see>
    ///     <cref>https://instagram.com/developer/endpoints/users/</cref>
    /// </see>
    public class InstagramUsersEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the Instagram service.
        /// </summary>
        public InstagramService Service { get; private set; }

        /// <summary>
        /// Gets a reference to the raw endpoint.
        /// </summary>
        public InstagramUsersRawEndpoint Raw {
            get { return Service.Client.Users; }
        }

        #endregion

        #region Constructors

        internal InstagramUsersEndpoint(InstagramService service) {
            Service = service;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets information about the authenticated user.
        /// </summary>
        public InstagramUserResponse GetSelf() {
            return InstagramUserResponse.ParseResponse(Raw.GetUser("me"));
        }
                
        /// <summary>
        /// Gets information about the user with the specified <code>userId</code>.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        public InstagramUserResponse GetUser(long userId) {
            return InstagramUserResponse.ParseResponse(Raw.GetUser(userId.ToString(CultureInfo.InvariantCulture)));
        }

        /// <summary>
        /// Gets information about the user with the specified <code>id</code>.
        /// </summary>
        /// <param name="id">The ID of the user.</param>
        [Obsolete("Use the GetInfo() instead.")]
        public InstagramUserResponse GetInfo(long id) {
            return InstagramUserResponse.ParseResponse(Raw.GetUser(id.ToString(CultureInfo.InvariantCulture)));
        }
        
        /// <summary>
        /// Gets the most recent media of the user with the specified <code>userId</code>.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="count">The maximum amount of media to be returned.</param>
        public InstagramRecentMediaResponse GetRecentMedia(string userId, int count) {
            var mediaResponse = InstagramMediasResponseBody.Parse(InstagramRecentMediaResponse.ParseResponse(Raw.GetRecentMedia(userId)));
            var result = new InstagramRecentMediaResponse();
            var hashset = new List<InstagramMedia>(mediaResponse.Data);

            while (hashset.Count < count && mediaResponse.Pagination != null && !string.IsNullOrEmpty(mediaResponse.Pagination.NextUrl))
            {                 
                mediaResponse = InstagramMediasResponseBody.Parse(InstagramRecentMediaResponse.ParseResponse(Raw.Client.DoAuthenticatedGetRequest(mediaResponse.Pagination.NextUrl)));
                hashset.AddRange(mediaResponse.Data);
            }            
            result.SetBody(hashset.Take(count).ToList());
            return result;
        }
       
        #endregion

    }

}