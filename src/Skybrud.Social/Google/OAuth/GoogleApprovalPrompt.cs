namespace Skybrud.Social.Google.OAuth {

    /// <summary>
    /// A space-delimited, case-sensitive list of prompts to present the user. If you don't specify this parameter, 
    /// the user will be prompted only the first time your project requests access. 
    /// </summary>
    public enum GoogleApprovalPrompt {
        /// <summary>
        /// Do not display any authentication or consent screens. Must not be specified with other values.
        /// </summary>
        none,
        /// <summary>
        /// Prompt the user for consent.
        /// </summary>
        consent,
        /// <summary>
        /// Prompt the user to select an account.
        /// </summary>
        select_account
    }

}