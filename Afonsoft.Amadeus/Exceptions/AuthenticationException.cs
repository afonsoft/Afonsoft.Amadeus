using Afonsoft.Amadeus;
using System;

namespace Afonsoft.Exceptions
{

    /// <summary>
    /// This error occurs when the client did not provide the right credentials.
    /// </summary>
    public class AuthenticationException : ResponseException
    {
        /// <summary>
        /// Constructor.
        /// @hides as only used internally
        /// </summary>
        public AuthenticationException(Response response) : base(response)
        {
        }

        public AuthenticationException(Response response, Exception ex) : base(response, ex)
        {
        }

        public AuthenticationException(Exception ex) : base(ex)
        {
        }
    }
}