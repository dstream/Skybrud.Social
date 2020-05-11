using Skybrud.Social.Json;
using System.Collections.Generic;

namespace Skybrud.Social.Google.MyBusiness.Objects.Accounts {

    /// <see>
    ///     <cref>https://developers.google.com/youtube/v3/docs/channels#resource</cref>
    /// </see>
    public class MyBusinessAccount : GoogleApiResource {

        #region Properties

        /// <summary>
        /// accounts/{accountId}
        /// </summary>
        public string Url { get; set; }

        public string Id { get; private set; }

        public string Name { get; private set; }
        
        public AccountType Type { get; private set; }

        public AccountRole Role { get; private set; }

        public AccountState State { get; private set; }

        public string ProfilePhotoUrl { get; private set; }

        public string AccountNumber { get; private set; }

        public PermissionLevel PermissionLevel { get; private set; }

        public OrganizationInfo OrganizationInfo { get; private set; }

        #endregion

        #region Constructors

        protected MyBusinessAccount(JsonObject obj) : base(obj) { }

        #endregion
        
        #region Static methods

        /// <summary>
        /// Gets an instance of <code>YouTubeChannel</code> from the specified <code>JsonObject</code>.
        /// </summary>
        /// <param name="obj">The instance of <code>JsonObject</code> to parse.</param>
        public static MyBusinessAccount Parse(JsonObject obj) {
            if (obj == null) return null;
            var result = new MyBusinessAccount(obj)
            {
                Url = obj.GetString("name"),
                Name = obj.GetString("accountName"),
                Type = obj.GetEnum<AccountType>("type"),
                Role = obj.GetEnum<AccountRole>("role"),
                State = obj.GetObject<AccountState>("state", AccountState.Parse)
            };
            result.Id = result.ParseId();
            return result;
        }

        #endregion

    }

    public class AccountState: GoogleApiResource
    {
        public AccountStatus Status { get; set; }

        #region Constructors

        protected AccountState(JsonObject obj) : base(obj) { }

        #endregion

        public static AccountState Parse(JsonObject obj)
        {
            if (obj == null) return null;
            var result = new AccountState(obj)
            {
                Status = obj.GetEnum<AccountStatus>("status")
            };
            return result;
        }
    }

    /// <summary>
    /// <see cref="https://developers.google.com/my-business/reference/rest/v4/accounts?authuser=1#Account.OrganizationInfo"/>
    /// </summary>
    public class OrganizationInfo: GoogleApiResource
    {
        public string RegisteredDomain { get; private set; }
        public PostalAddress PostalAddress { get; private set; }
        public string PhoneNumber { get; private set; }

        public OrganizationInfo(JsonObject obj): base(obj) { }

        public static OrganizationInfo Parse(JsonObject obj)
        {
            if (obj == null) return null;
            var result = new OrganizationInfo(obj)
            {
                RegisteredDomain = obj.GetString("registeredDomain"),
                PostalAddress = obj.GetObject("postalAddress", PostalAddress.Parse),
                PhoneNumber = obj.GetString("phoneNumber")
            };
            return result;
        }
    }

    /// <summary>
    /// <see cref="https://developers.google.com/my-business/reference/rest/v4/PostalAddress?authuser=1"/>
    /// </summary>
    public class PostalAddress: GoogleApiResource
    {
        public int Revision { get; private set; }
        public string RegionCode { get; private set; }
        public string LanguageCode { get; private set; }
        public string PostalCode { get; private set; }
        public string SortingCode { get; private set; }
        public string AdministrativeArea { get; private set; }
        public string Locality { get; private set; }
        public string Sublocality { get; private set; }
        public IEnumerable<string> AddressLines { get; private set; }
        public IEnumerable<string> Recipients { get; private set; }
        public string Organization { get; private set; }

        public PostalAddress(JsonObject obj) : base(obj) { }

        public static PostalAddress Parse(JsonObject obj)
        {
            if (obj == null) return null;
            var result = new PostalAddress(obj)
            {
                Revision = obj.GetInt32("revision"),
                RegionCode = obj.GetString("regionCode"),
                LanguageCode = obj.GetString("languageCode"),
                PostalCode = obj.GetString("postalCode"),
                SortingCode = obj.GetString("sortingCode"),
                AdministrativeArea = obj.GetString("administrativeArea"),
                Locality = obj.GetString("locality"),
                Sublocality = obj.GetString("sublocality"),
                AddressLines = obj.GetArray<string>("addressLines"),
                Recipients = obj.GetArray<string>("recipients"),
                Organization = obj.GetString("organization")
            };
            return result;
        }
    }

}