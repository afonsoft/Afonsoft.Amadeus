using Afonsoft.Amadeus;
using System;

namespace Afonsoft.Exceptions
{

    /// <summary>
    /// This error occurs when the response type was JSON but could not be parsed.
    /// </summary>
    public class ParserException : ResponseException
    {
        /// <summary>
        /// Constructor.
        /// @hides as only used internally
        /// </summary>
        public ParserException(Response response) : base(response)
        {
        }
        public ParserException(Response response, Exception ex) : base(response, ex)
        {
        }

        public ParserException(Exception ex) : base(ex)
        {
        }
    }
}