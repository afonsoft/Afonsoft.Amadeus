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
        public string Verb { get; private set; }
        /// <summary>
        /// The scheme to use for API calls.
        /// </summary>
        public string Scheme { get; private set; }
        /// <summary>
        /// The host domain to use for API calls.
        /// </summary>
        public string Host { get; private set; }
        /// <summary>
        /// The path use for API calls.
        /// </summary>
        public string Path { get; private set; }
        /// <summary>
        /// The params to send to the API endpoint.
        /// </summary>
        public Params @Params { get; private set; }
        /// <summary>
        /// The bearer token used to authenticate the API call.
        /// </summary>
        public string BearerToken { get; private set; }
        /// <summary>
        /// The version of the SDK used.
        /// </summary>
        public string ClientVersion { get; private set; }
        /// <summary>
        /// The version of Java used.
        /// </summary>
        public string LanguageVersion { get; private set; }
        /// <summary>
        /// The custom Application ID passed in the user agent.
        /// </summary>
        public string AppId { get; private set; }
        /// <summary>
        /// The custom Application Version passed in the user agent.
        /// </summary>
        public string AppVersion { get; private set; }
        /// <summary>
        /// Whether this connection uses SSL.
        /// </summary>
        public bool Ssl { get; private set; }
        /// <summary>
        /// The port to use for this request.
        /// </summary>
        public int Port { get; private set; }
        /// <summary>
        /// The Headers for this request.
        /// </summary>
        public Dictionary<string, string> Headers { get; private set; }
        /// <summary>
        /// The full URI for this request, based on the
        /// verb, port, path, host, etc.
        /// </summary>
        public string Uri { get; private set; }
        // The connection used to make the API call.

        public HttpClient Connection { get; private set; }

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

            DetermineScheme();
            PrepareUrl();
            PrepareHeaders();
        }

        // Builds a HttpURLConnection using all the data for this request.
        protected internal virtual void EstablishConnection()
        {
            this.Connection = new HttpClient();
            this.Connection.BaseAddress = new Uri(Uri);

            foreach (KeyValuePair<string, string> entry in Headers)
            {
                this.Connection.DefaultRequestHeaders.TryAddWithoutValidation(entry.Key, entry.Value);
            }
        }

        // Determines the scheme based on the SSL value
        private void DetermineScheme()
        {
            this.Scheme = Ssl ? Constants.HTTPS : Constants.HTTP;
        }

        // Prepares the full URL based on the scheme, host, port and path.
        private void PrepareUrl()
        {
            this.Uri = string.Format("{0}://{1}:{2}{3}?{4}", Scheme, Host, Port, Path, QueryParams);
        }
        public override string ToString()
        {
            return this.Uri;
        }
        // Prepares the Headers to be sent in the request
        private void PrepareHeaders()
        {
            this.Headers = new Dictionary<string, string>();
            Headers.Add(Constants.USER_AGENT, BuildUserAgent());
            Headers.Add(Constants.ACCEPT, "application/json, application/vnd.amadeus+json, application/x-www-form-urlencoded, multipart/form-data");
            if (BearerToken != null)
            {
                Headers.Add(Constants.AUTHORIZATION, BearerToken);
            }
        }

        // Determines the User-Agent header, based on the client version, language version, and custom
        // app information.
        private string BuildUserAgent()
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