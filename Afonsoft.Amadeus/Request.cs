using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;

namespace Afonsoft.Amadeus
{

    /// <summary>
    /// An object containing all the details of the request made, including the host,
    /// path, port, params, and Headers. Generally this object can be accessed as part of
    /// an API response, and can be used to debug the API call made.
    /// </summary>
    public class Request
    {
        /// <summary>
        /// The HTTPClient verb to use for API calls.
        /// </summary>
        public string Verb;
        /// <summary>
        /// The scheme to use for API calls.
        /// </summary>
        public string Scheme;
        /// <summary>
        /// The host domain to use for API calls.
        /// </summary>
        public string Host;
        /// <summary>
        /// The path use for API calls.
        /// </summary>
        public string Path;
        /// <summary>
        /// The params to send to the API endpoint.
        /// </summary>
        public Params @Params;
        /// <summary>
        /// The bearer token used to authenticate the API call.
        /// </summary>
        public string BearerToken;
        /// <summary>
        /// The version of the SDK used.
        /// </summary>
        public string ClientVersion;
        /// <summary>
        /// The version of Java used.
        /// </summary>
        public string LanguageVersion;
        /// <summary>
        /// The custom Application ID passed in the user agent.
        /// </summary>
        public string AppId;
        /// <summary>
        /// The custom Application Version passed in the user agent.
        /// </summary>
        public string AppVersion;
        /// <summary>
        /// Whether this connection uses SSL.
        /// </summary>
        public bool Ssl;
        /// <summary>
        /// The port to use for this request.
        /// </summary>
        public int Port;
        /// <summary>
        /// The Headers for this request.
        /// </summary>
        public Dictionary<string, string> Headers;
        /// <summary>
        /// The full URI for this request, based on the
        /// verb, port, path, host, etc.
        /// </summary>
        public string Uri;
        // The connection used to make the API call.

        public HttpClient Connection { get; set; }

        protected internal Request(string verb, string path, Params @params, string bearerToken, HTTPClient client)
        {
            Configuration config = client.Configuration;

            this.Verb = verb;
            this.Host = config.Host;
            this.Path = path;
            this.@Params = @params;
            this.BearerToken = bearerToken;
            this.LanguageVersion = "netstandard2.0";
            this.ClientVersion = Amadeus.VERSION;
            this.AppId = config.CustomAppId;
            this.AppVersion = config.CustomAppVersion;
            this.Port = config.Port;
            this.Ssl = config.Ssl;

            determineScheme();
            prepareUrl();
            prepareHeaders();
        }

        // Builds a HttpURLConnection using all the data for this request.
        protected internal virtual void establishConnection()
        {
            this.Connection = new HttpClient();
            this.Connection.BaseAddress = new Uri(Uri);

            foreach (KeyValuePair<string, string> entry in Headers)
            {
                this.Connection.DefaultRequestHeaders.TryAddWithoutValidation(entry.Key, entry.Value);
            }
        }

        // Determines the scheme based on the SSL value
        private void determineScheme()
        {
            this.Scheme = Ssl ? Constants.HTTPS : Constants.HTTP;
        }

        // Prepares the full URL based on the scheme, host, port and path.
        private void prepareUrl()
        {
            this.Uri = string.Format("{0}://{1}:{2}{3}?{4}", Scheme, Host, Port, Path, QueryParams);
        }
        public override string ToString()
        {
            return this.Uri;
        }
        // Prepares the Headers to be sent in the request
        private void prepareHeaders()
        {
            this.Headers = new Dictionary<string, string>();
            Headers.Add(Constants.USER_AGENT, buildUserAgent());
            Headers.Add(Constants.ACCEPT, "application/json, application/vnd.amadeus+json, application/x-www-form-urlencoded, multipart/form-data");
            if (BearerToken != null)
            {
                Headers.Add(Constants.AUTHORIZATION, BearerToken);
            }
        }

        // Determines the User-Agent header, based on the client version, language version, and custom
        // app information.
        private string buildUserAgent()
        {
            string userAgent = string.Format("amadeus-csharp/{0}", ClientVersion);
            userAgent = userAgent + string.Format(" charp/{0}", LanguageVersion);
            if (AppId != null)
            {
                userAgent = userAgent + string.Format(" {0}/{1}", AppId, AppVersion);
            }
            return userAgent;
        }

        // Gets the serialized params, only if this is a Get call
        private string QueryParams
        {
            get
            {
                if (Verb == Constants.GET && @Params != null)
                {
                    return @Params.toQueryString();
                }
                else
                {
                    return "";
                }
            }
        }
    }
}