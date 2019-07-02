using Afonsoft.Amadeus;
using System;

namespace Afonsoft.Exceptions
{

    /// <summary>
    /// This error occurs when the client did not provide the right parameters.
    /// </summary>
    public class ClientException : ResponseException
    {
        /// <summary>
        /// Constructor.
        /// @hides as only used internally
        /// </summary>
        public ClientException(Response response) : base(response)
        {
        }

        public ClientException(Response response, Exception ex) : base(response, ex)
        {
        }

        public ClientException(Exception ex) : base(ex)
        {
        }
    }
}