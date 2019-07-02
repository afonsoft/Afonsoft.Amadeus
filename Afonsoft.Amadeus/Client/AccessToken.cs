using Newtonsoft.Json.Linq;

namespace Afonsoft.Amadeus.Client
{
           /// <summary>
        /// A memoized Access Token, with the ability to auto-refresh when needed.
        /// @hide as only used internally
        /// </summary>
        public class AccessToken
        {
            // Renew the token 10 seconds earlier than required,
            // just to account for system lag
            private const long TOKEN_BUFFER = 10000L;
            // An instance of the API client
            private readonly HTTPClient client;
            // The access token value
            private string accessToken = null;
            // The (UNIX) expiry time of this token
            private long expiresAt;

            /// <summary>
            /// Constructor.
            /// @hides as only used internally
            /// </summary>
            public AccessToken(HTTPClient client)
            {
                this.client = client;
            }

            /// <summary>
            /// Creates a Bearer header using the cached Access Token.
            /// @hides as only used internally
            /// </summary>
            
            //public String getBearerToken() throws com.amadeus.exceptions.ResponseException
            public virtual string BearerToken
            {
                get
                {
                    lazyUpdateAccessToken();
                    return string.Format("Bearer {0}", accessToken);
                }
            }

            // Loads the access token if it's still null
            // or has expired.
            
            //private void lazyUpdateAccessToken() throws com.amadeus.exceptions.ResponseException
            private void lazyUpdateAccessToken()
            {
                if (needsRefresh())
                {
                    updateAccessToken();
                }
            }

            // Fetches the access token and then parses the resuling values.
            
            //private void updateAccessToken() throws com.amadeus.exceptions.ResponseException
            private void updateAccessToken()
            {
                Response response = fetchAccessToken();
                storeAccessToken(response.Result);
            }

            // Checks if this access token needs a refresh.
            private bool needsRefresh()
            {
                bool isNull = string.ReferenceEquals(accessToken, null);
                bool expired = (DateTimeHelper.CurrentUnixTimeMillis() + TOKEN_BUFFER) > expiresAt;
                return isNull || expired;
            }

            // Fetches a new Access Token using the credentials from the client
            
            //private com.amadeus.Response fetchAccessToken() throws com.amadeus.exceptions.ResponseException
            private Response fetchAccessToken()
            {
                Configuration config = client.Configuration;
                return client.UnauthenticatedRequest(Constants.POST, Constants.AUTH_URL, Params.with(Constants.GRANT_TYPE, Constants.CLIENT_CREDENTIALS).and(Constants.CLIENT_ID, config.ClientId).and(Constants.CLIENT_SECRET, config.ClientSecret), null);
            }

            // Store the fetched access token and expiry date
            private void storeAccessToken(JObject result)
            {
                this.accessToken = result[Constants.ACCESS_TOKEN].ToString();
                int expiresIn = (int)result[Constants.EXPIRES_IN];
                this.expiresAt = DateTimeHelper.CurrentUnixTimeMillis() + expiresIn * 1000L;
            }
        }

    }
