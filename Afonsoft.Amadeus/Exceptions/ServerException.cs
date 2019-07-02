using Afonsoft.Amadeus;
using System;

namespace Afonsoft.Exceptions
{

    /// <summary>
    /// This error occurs when there is an error on the server.
    /// </summary>
    public class ServerException : ResponseException
    {
        /// <summary>
        /// Constructor.
        /// @hides as only used internally
        /// </summary>
        public ServerException(Response response) : base(response)
        {
        }
        public ServerException(Response response, Exception ex) : base(response, ex)
        {
        }

        public ServerException(Exception ex) : base(ex)
        {
        }
    }
}