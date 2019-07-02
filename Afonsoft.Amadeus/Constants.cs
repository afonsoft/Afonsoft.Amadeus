namespace Afonsoft.Amadeus
{
    /// <summary>
    /// A class for constant variables.
    /// 
    /// <pre>
    ///  To use: Constants.VARIABLE
    /// </pre>
    /// </summary>
    public sealed class Constants
    {
        // HTTP verbs
        public const string GET = "GET";
        public const string POST = "POST";
        public const string PUT = "PUT";


        public const string HTTPS = "https";
        public const string HTTP = "http";

        public const string USER_AGENT = "User-Agent";
        public const string ACCEPT = "Accept";
        public const string AUTHORIZATION = "Authorization";
        public const string CONTENT_TYPE = "Content-Type";

        // Pagination
        public const string FIRST = "first";
        public const string LAST = "last";
        public const string NEXT = "next";
        public const string PREVIOUS = "previous";

        // Authorization
        public const string GRANT_TYPE = "grant_type";
        public const string CLIENT_CREDENTIALS = "client_credentials";
        public const string CLIENT_ID = "client_id";
        public const string CLIENT_SECRET = "client_secret";
        public const string AUTH_URL = "/v1/security/oauth2/token";
        public const string ACCESS_TOKEN = "access_token";
        public const string EXPIRES_IN = "expires_in";

    }
}