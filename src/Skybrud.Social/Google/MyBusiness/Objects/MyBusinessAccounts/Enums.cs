using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Skybrud.Social.Google.MyBusiness.Objects.Accounts
{
    /// <summary>
    /// Indicates what kind of account this is: either a personal/user account or a business account.
    /// <see cref="https://developers.google.com/my-business/reference/rest/v4/accounts?authuser=1#accounttype"/>
    /// </summary>
    public enum AccountType
    {
        ACCOUNT_TYPE_UNSPECIFIED,
        /// <summary>
        /// An end-user account.
        /// </summary>
        PERSONAL,
        /// <summary>
        /// A group of Locations. For more information
        /// </summary>
        LOCATION_GROUP,
        /// <summary>
        /// A user Group for segregating organization staff in groups. For more information
        /// </summary>
        USER_GROUP,
        /// <summary>
        /// An organization representing a company. For more information
        /// </summary>
        ORGANIZATION
    }

    /// <summary>
    /// Indicates the access level that the authenticated user has for this account
    /// <see cref="https://developers.google.com/my-business/reference/rest/v4/accounts?authuser=1#accountrole"/>
    /// </summary>
    public enum AccountRole
    {
        ACCOUNT_ROLE_UNSPECIFIED,
        /// <summary>
        /// The user owns this account. (Displays as 'Primary owner' in UI).
        /// </summary>
        OWNER,
        /// <summary>
        /// The user is a co-owner of the account. (Displays as 'owner' in UI).
        /// </summary>
        CO_OWNER,
        /// <summary>
        /// The user can manage this account.
        /// </summary>
        MANAGER,
        /// <summary>
        /// The user can manage social (Google+) pages for the account. (Displays as 'Site Manager' in UI).
        /// </summary>
        COMMUNITY_MANAGER
    }

    /// <summary>
    /// <see cref="https://developers.google.com/my-business/reference/rest/v4/accounts?authuser=1#Account.AccountStatus"/>
    /// </summary>
    public enum AccountStatus {
        ACCOUNT_STATUS_UNSPECIFIED,
        /// <summary>
        /// verified account.
        /// </summary>
        VERIFIED,
        /// <summary>
        /// Account that is not verified, and verification has not been requested.
        /// </summary>
        UNVERIFIED,
        /// <summary>
        /// Account that is not verified, but verification has been requested.
        /// </summary>
        VERIFICATION_REQUESTED,
    }

    /// <summary>
    /// Indicates the access level that the authenticated user has for this account.
    /// <see cref="https://developers.google.com/my-business/reference/rest/v4/accounts?authuser=1#permissionlevel"/>
    /// </summary>
    public enum PermissionLevel
    {
        PERMISSION_LEVEL_UNSPECIFIED,
        /// <summary>
        /// The user has owner level permission.
        /// </summary>
        OWNER_LEVEL,
        /// <summary>
        /// The user has member level permission.
        /// </summary>
        MEMBER_LEVEL
    }

    /// <summary>
    /// The star rating out of five, where five is the highest rated.
    /// <see cref="https://developers.google.com/my-business/reference/rest/v4/accounts.locations.reviews#StarRating"/>
    /// </summary>
    public enum ReviewStarRating
    {
        /// <summary>
        /// Not specified.
        /// </summary>
        STAR_RATING_UNSPECIFIED = 0,
        ONE = 1,
        TWO = 2,
        THREE = 3,
        FOUR = 4,
        FIVE = 5
    }
}
