using Skybrud.Social.Google.OAuth;

namespace Skybrud.Social.Google.MyBusiness
{

    /// <summary>
    /// Static class containing references to known scopes of the MyBusiness API.
    /// </summary>    
    public static class MyBusinessScopes
    {

        #region Readonly properties

        /// <summary>
        /// Manage your Business location.
        /// </summary>
        public static readonly GoogleScope MyBusinessManage = new GoogleScope(
            "https://www.googleapis.com/auth/business.manage",
            "Manage your Business location."
        );

        /// <summary>
        /// Manage your Business location (Plus).
        /// </summary>
        public static readonly GoogleScope MyBusinessManagePlus = new GoogleScope(
            "https://www.googleapis.com/auth/plus.business.manage",
            "Manage your Business location."
        );

        #endregion

    }

}