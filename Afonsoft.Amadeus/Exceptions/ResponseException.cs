using Afonsoft.Amadeus;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System;
using System.Text;

namespace Afonsoft.Exceptions
{
    /// <summary>
    ///  A custom generic Amadeus error.
    /// </summary>
    public class ResponseException : Exception
    {

        public string Code;

        public Response Response;

        public string Description;


        /// <summary>
        /// Constructor.
        /// </summary>
        public ResponseException(Response response) : base(determineDescription(response))
        {
            this.Response = response;
            this.Description = determineDescription(response);
            determineCode();
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        public ResponseException(Response response, Exception ex) : base(determineDescription(response), ex)
        {
            this.Response = response;
            this.Description = determineDescription(response) + Environment.NewLine + determineDescription(ex);
            determineCode();
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        public ResponseException(Exception ex) : base(ex.Message, ex)
        {
            this.Response = null;
            this.Description = determineDescription(ex);
            determineCode();
        }

        /// <summary>
        /// Logs the response.
        /// @hides as only used internally
        /// </summary>
        public virtual void log(Configuration configuration)
        {
            if (configuration.LogLevel != LogLevel.None)
            {
                string warning = string.Format("Amadeus {0} {1}", Code, Description);
                ILogger logger = configuration.Logger;
                if (logger != null)
                    logger.Log(configuration.LogLevel, warning);
            }
        }
        public virtual void log(Configuration configuration, object @object)
        {
            if (configuration.LogLevel != LogLevel.None)
            {
                string warning = string.Format("Amadeus {0} {1}", Code, Description);
                ILogger logger = configuration.Logger;
                if (logger != null)
                    logger.Log(configuration.LogLevel, warning, @object);
            }
        }

        private void determineCode()
        {
            this.Code = this.GetType().Name;
        }

        private static string determineDescription(Response response)
        {
            StringBuilder description = determineShortDescription(response);
            description.Append(determineLongDescription(response));
            return description.ToString();
        }

        private static string determineDescription(Exception ex)
        {
            StringBuilder description = determineShortDescription(ex);
            description.Append(determineLongDescription(ex));
            return description.ToString();
        }

        private static StringBuilder determineShortDescription(Exception ex)
        {
            StringBuilder message = new StringBuilder();
            if (ex == null)
            {
                message.Append("[---]");
            }
            else
            {
                message.Append(string.Format("[{0}]", ex.Message));
            }
            return message;
        }

        private static StringBuilder determineShortDescription(Response response)
        {
            StringBuilder message = new StringBuilder();
            if (response == null || response.StatusCode == 0)
            {
                message.Append("[---]");
            }
            else
            {
                message.Append(string.Format("[{0}]", response.StatusCode));
            }
            return message;
        }

        private static StringBuilder determineLongDescription(Response response)
        {
            StringBuilder description = new StringBuilder();
            if (response != null && response.Parsed)
            {
                if (response.Result.ContainsKey("error_description"))
                {
                    description.Append(getErrorDescription(response));
                }
                if (response.Result.ContainsKey("errors"))
                {
                    description.Append(getErrorsDescription(response));
                }
            }
            return description;
        }

        private static StringBuilder determineLongDescription(Exception ex)
        {
            StringBuilder description = new StringBuilder();
            if (ex != null  && ex.InnerException != null)
            {
                Exception tmpEx = ex.InnerException;
                while (tmpEx != null)
                {
                    description.Append(getErrorDescription(tmpEx));
                    tmpEx = tmpEx.InnerException;
                }
                
            }
            return description;
        }

        private static StringBuilder getErrorDescription(Exception ex)
        {
            StringBuilder message = new StringBuilder();
            if (ex != null)
            {
                message.Append(string.Format("\n\"detail\":\"{0}\"", ex.Message));
                if (ex.StackTrace != null)
                {
                    message.Append(string.Format("\n\"Stack\":\"{0}\"", ex.StackTrace ));
                }
               
            }
            return message;
        }

        private static StringBuilder getErrorDescription(Response response)
        {
            StringBuilder message = new StringBuilder();
            if (response != null)
            {
                JObject result = response.Result;
                if (response.Result.ContainsKey("error"))
                {
                    message.Append(string.Format("\n{0}", result["error"]));
                }
                message.Append(string.Format("\n{0}", result["error_description"]));
            }
            return message;
        }

        private static StringBuilder getErrorsDescription(Response response)
        {
            StringBuilder message = new StringBuilder();
            if (response != null)
            {
                foreach (JObject json in ((JArray)response.Result["errors"]))
                {

                    message.Append("\n");
                    if (json.ContainsKey("source"))
                    {
                        JObject source = json["source"] as JObject;
                        if (source != null && source.ContainsKey("parameter"))
                        {
                            message.Append(string.Format("[{0}] ", source["parameter"]));
                        }
                    }
                    message.Append(string.Format("{0}", json["detail"]));
                }
            }
            return message;
        }
    }
}