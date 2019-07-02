using Afonsoft.Amadeus;
using System;

namespace Afonsoft.Exceptions
{

    /// <summary>
    /// This error occurs when there is some kind of error in the network.
    /// </summary>
    public class NetworkException : ResponseException
    {
        /// <summary>
        /// Constructor.
        /// @hides as only used internally
        /// </summary>
        public NetworkException(Response response) : base(response)
        {
        }

        public NetworkException(Response response, Exception ex) : base(response, ex)
        {
        }

        public NetworkException(Exception ex) : base(ex)
        {
        }
    }
}