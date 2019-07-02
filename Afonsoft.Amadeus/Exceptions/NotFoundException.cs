using Afonsoft.Amadeus;
using System;

namespace Afonsoft.Exceptions
{

    /// <summary>
    /// This error occurs when the path could not be found.
    /// </summary>
    public class NotFoundException : ResponseException
    {
        public NotFoundException(Response response) : base(response)
        {
        }
        public NotFoundException(Response response, Exception ex) : base(response, ex)
        {
        }

        public NotFoundException(Exception ex) : base(ex)
        {
        }
    }
}