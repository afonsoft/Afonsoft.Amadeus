using System.Text;
using System.IO;
using System.Net.Http;
using Afonsoft.Exceptions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Net;
using System;
using System.Threading.Tasks;

namespace Afonsoft.Amadeus
{

    /// <summary>
    /// A generic response as received from an API call. Contains the status code, body,
    /// and parsed JSON (if any).
    /// </summary>
    public class Response
    {

        internal string ReasonPhrase;
        /// <summary>
        /// The HTTP status code for the response, if any.
        /// </summary>
        public int StatusCode { get; set; }
        /// <summary>
        /// Wether the raw body has been parsed into JSON.
        /// </summary>
        public bool Parsed { get; set; }
        /// <summary>
        /// The parsed JSON received from the API, if the result was JSON.
        /// </summary>
        public JObject Result { get; set; }
        /// <summary>
        /// The data extracted from the JSON data - if the body contained JSON.
        /// </summary>
        public JContainer Data { get; set; }
        /// <summary>
        /// The raw body received from the API.
        /// </summary>
        public string Body { get; set; }
        /// <summary>
        /// The actual Request object used to make this API call.
        /// </summary>
        public Request Request { get; set; }

        protected internal Response(Request request)
        {
            this.Request = request;
        }

        // Tries to parse the raw response from the request.
        protected internal virtual void parse(HTTPClient client)
        {
            parseData(client);
        }

        // Detects of any exceptions have occured and throws the appropriate exceptions.
        protected internal virtual void detectError(HTTPClient client)
        {
            ResponseException exception = null;
            string reason = string.Format("{0} {1}", StatusCode, ReasonPhrase);
            if (StatusCode >= 500)
            {
                exception = new ServerException(this, new Exception(reason));
            }
            else if (StatusCode == 404)
            {
                exception = new NotFoundException(this, new Exception(reason));
            }
            else if (StatusCode == 401)
            {
                exception = new AuthenticationException(this, new Exception(reason));
            }
            else if (StatusCode >= 400)
            {
                exception = new ClientException(this, new Exception(reason));
            }
            else if (!Parsed)
            {
                exception = new ParserException(this, new Exception(reason));
            }

            if (exception != null)
            {
                exception.log(client.Configuration, this);
                throw exception;
            }
        }

        // Tries to parse the status code. Catches any exceptions and defaults to
        // status 0 if an error occurred.
        private void parseStatusCode(int statusCode)
        {
            try
            {
                this.StatusCode = statusCode;
            }
            catch (IOException)
            {
                this.StatusCode = 0;
            }
        }

        // Tries to parse the data
        private void parseData(HTTPClient client)
        {
            this.Parsed = false;
            this.Body = readBody(client);
            this.Result = parseJson(client);
            this.Parsed = this.Result != null;
            this.Data = null;
            if (Parsed && Result.ContainsKey("data"))
            {
                if (Result["data"].Type == JTokenType.Array)
                {
                    this.Data = (JArray)Result["data"];
                }
                if (Result["data"].Type == JTokenType.Object)
                {
                    this.Data = (JObject)Result["data"];
                }
            }
        }

        // Tries to read the body.
        private string readBody(HTTPClient client)
        {
            // Get the connection
            HttpClient connection = Request.Connection;
            try
            {
                ReasonPhrase = "";
                Task<HttpResponseMessage> response = connection.SendAsync(client.HttpRequestMessage);
                if (response.Result.IsSuccessStatusCode)
                {
                    parseStatusCode((int)response.Result.StatusCode);
                    return JsonConvert.DeserializeObject(response.Result.Content.ReadAsStringAsync().Result).ToString();
                }
                else
                {
                    parseStatusCode((int)response.Result.StatusCode);
                    ReasonPhrase = response.Result.ReasonPhrase;
                    return JsonConvert.DeserializeObject(response.Result.Content.ReadAsStringAsync().Result).ToString();
                }
            }
            catch (Exception ex)
            {
                parseStatusCode(500);
                throw new ServerException(this, ex);
            }

        }

        // Ties to parse the response body into a JSON Object
        private JObject parseJson(HTTPClient client)
        {
            if (Json)
            {
                return JObject.Parse(Body);
            }
            return null;
        }

        // Checks if the response is likely to be JSON.
        private bool Json
        {
            get
            {
                return hasJsonHeader() && hasBody();
            }
        }

        // Checks if the response headers include a JSON mime-type.
        private bool hasJsonHeader()
        {
            //string contentType = Request.Connection.. [Constants.CONTENT_TYPE];
            //string[] expectedContentTypes = new string[] { "application/json", "application/vnd.amadeus+json" };
            //return expectedContentTypes.Contains(contentType);
            return true;
        }

        // Checks if the response has a body
        private bool hasBody()
        {
            return !(Body == null || string.IsNullOrEmpty(Body));
        }

        public override string ToString()
        {
            return this.Body;
        }
    }
}