namespace SASTokenAuthCustomBinding.Binding
{
    using System;
    using System.Security.Claims;

    /// <summary>
    /// Contains the result of an sas token check.
    /// </summary>
    public sealed class SASTokenResult
    {
        private SASTokenResult() { }

        /// <summary>
        /// Gets the security principal associated with a valid token.
        /// </summary>
        public ApimUser User
        { get; private set; }

        /// <summary>
        /// Gets the status of the token, i.e. whether it is valid.
        /// </summary>
        public SASTokenStatus Status
        { get; private set; }

        /// <summary>
        /// Gets any exception encountered when validating a token.
        /// </summary>
        public string ErrorMessage
        { get; private set; }

        /// <summary>
        /// Returns a valid token.
        /// </summary>
        public static SASTokenResult Success(ApimUser user)
        {
            return new SASTokenResult
            {
                User = user,
                Status = SASTokenStatus.Valid
            };
        }

        /// <summary>
        /// Returns a result that indicates the submitted token has expired.
        /// </summary>
        public static SASTokenResult Expired()
        {
            return new SASTokenResult
            {
                Status = SASTokenStatus.Expired
            };
        }

        /// <summary>
        /// Returns a result to indicate that there was an error when processing the token.
        /// </summary>
        public static SASTokenResult Error(string errorMessage)
        {
            return new SASTokenResult
            {
                Status = SASTokenStatus.Error,
                ErrorMessage = errorMessage
            };
        }

        /// <summary>
        /// Returns a result in response to no token being in the request.
        /// </summary>
        /// <returns></returns>
        public static SASTokenResult NoToken()
        {
            return new SASTokenResult
            {
                Status = SASTokenStatus.NoToken
            };
        }
    }
}