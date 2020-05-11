using System;
using Skybrud.Social.Http;
using Skybrud.Social.Interfaces;

namespace Skybrud.Social.Google.MyBusiness.Options {
    
    public class MyBusinessLocationListOptions : MyBusinessGenericListOptions
    {

        #region Properties


        /// <summary>
        /// A filter constraining the accounts to return. The response includes only entries that 
        /// match the filter. If filter is empty, then no constraints are applied and all accounts 
        /// (paginated) are retrieved for the requested account. For example, a request with the
        /// filter type=USER_GROUP will only return user groups.
        /// </summary>
        public string Filter { get; set; }

        /// <summary>
        /// The BCP 47 code of language to get display location properties in. If this language is not available, 
        /// they will be provided in the language of the location. If neither is available, they will be provided in English. 
        /// </summary>
        public string LanguageCode { get; set; }

        #endregion

        #region Constructors

        public MyBusinessLocationListOptions() :base() {            
        }

        public override SocialQueryString GetQueryString()
        {
            var query = base.GetQueryString();
            if (!String.IsNullOrWhiteSpace(LanguageCode)) query.Add("languageCode", LanguageCode);
            if (!String.IsNullOrWhiteSpace(Filter)) query.Add("filter", Filter);
            return query;
        }

        #endregion        

    }

}