using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace Afonsoft.Amadeus
{

    /// <summary>
    /// <para>
    /// The configuration for the Amadeus API client. To initialize, use the builder as follows:
    /// </para>
    /// 
    /// <pre>
    /// Amadeus amadeus =
    ///     Amadeus.builder("REPLACE_BY_YOUR_API_KEY", "REPLACE_BY_YOUR_API_SECRET").build();
    /// </pre>
    /// 
    /// <para>
    /// Or pass in environment variables directly:
    /// </para>
    /// 
    /// <pre>
    /// Amadeus.builder(System.getenv()).build();
    /// </pre>
    /// </summary>
    public class Configuration
    {
        private static readonly Params HOSTS = Params.with("production", "api.amadeus.com").and("test", "test.api.amadeus.com");

        /// <summary>
        /// The client ID used to authenticate the API calls.
        /// </summary>
        /// <returns> The client ID </returns>
        public string ClientId { get; set; }
        /// <summary>
        /// The client secret used to authenticate the API calls.
        /// </summary>
        /// <returns> The client secret </returns>

        public string ClientSecret { get; set; }
        /// <summary>
        /// The logger that will be used to debug or warn to.
        /// </summary>
        /// <param name="logger"> The logger object </param>
        /// <returns> The logger object </returns>

        public ILogger Logger;
        /// <summary>
        /// The log level. Can be Trace, Debug, Information, Warning, Error, Critical, None. Defaults to 'None'.
        /// </summary>
        /// <param name="logLevel"> The log level for the logger </param>
        /// <returns> The log level for the logger </returns>
        public LogLevel LogLevel { get; set; } = LogLevel.None;
        /// <summary>
        /// The the name of the server API calls are made to, 'production' or 'test'. Defaults to 'test'
        /// </summary>
        /// <param name="hostname"> The name of the server API calls are made to </param>
        /// <returns> The name of the server API calls are made to </returns>
        public string Hostname { get; set; } = "test";
        /// <summary>
        /// The optional custom host domain to use for API calls. Defaults to internal value for
        /// 'hostname'.
        /// </summary>
        /// <param name="host"> The optional custom host domain to use for API calls. </param>
        /// <returns> The optional custom host domain to use for API calls. </returns>
        public string Host { get; set; } = "test.api.amadeus.com";
        /// <summary>
        /// Wether to use SSL. Defaults to True
        /// </summary>
        /// <param name="ssl"> A boolean specifying if the connection should use SSL </param>
        /// <returns> A boolean specifying if the connection should use SSL </returns>
        public bool Ssl { get; set; } = true;
        /// <summary>
        /// The port to use. Defaults to 443 for an SSL connection, and 80 for a non SSL connection.
        /// </summary>
        /// <param name="port"> The port to use for the connection </param>
        /// <returns> The port to use for the connection </returns>
        public int Port { get; set; } = 443;
        /// <summary>
        /// An optional custom App ID to be passed in the User Agent to the server (Defaults to null).
        /// </summary>
        /// <param name="customAppId"> An optional custom App ID </param>
        /// <returns> The optional custom App ID </returns>
        public string CustomAppId { get; set; }
        /// <summary>
        /// An optional custom App version to be passed in the User Agent to the server (Defaults to null).
        /// </summary>
        /// <param name="customAppVersion"> An optional custom App version </param>
        /// <returns> The optional custom App version </returns>
        public string CustomAppVersion { get; set; }

        protected internal Configuration(string clientId, string clientSecret)
        {
            this.ClientId = clientId;
            this.ClientSecret = clientSecret;
        }

        /// <summary>
        /// Builds an Amadeus client with the provided credentials.
        /// </summary>
        /// <returns> an Amadeus client </returns>
        /// <exception cref="NullPointerException"> when a client ID or client secret is missing </exception>
        public virtual Amadeus build()
        {
            return new Amadeus(this);
        }

        /// <summary>
        /// The the name of the server API calls are made to, 'production' or 'test'. Defaults to 'test'.
        /// </summary>
        /// <param name="hostname"> The name of the server API calls are made to </param>
        /// <returns> The name of the server API calls are made to </returns>
        public virtual Configuration setHostname(string hostname)
        {
            if (!HOSTS.ContainsKey(hostname))
            {
                throw new System.ArgumentException(string.Format("Hostname {0} not found in {1}", hostname, HOSTS.Keys.ToString()));
            }
            this.Hostname = hostname;
            this.Host = HOSTS[hostname];
            return this;
        }

        /// <summary>
        /// Whether to use SSL. Defaults to True.
        /// </summary>
        /// <param name="ssl"> A boolean specifying if the connection should use SSL </param>
        /// <returns> A boolean specifying if the connection should use SSL </returns>
        public virtual Configuration setSsl(bool ssl)
        {
            this.Ssl = ssl;
            if (!ssl && Port == 443)
            {
                Port = 80;
            }
            return this;
        }

        // Parses environment variables and initializes the values.
        protected internal virtual Configuration parseEnvironment(IDictionary<string, string> environment)
        {
            Hostname = getOrDefault(environment, "HOSTNAME", Hostname);
            Host = getOrDefault(environment, "HOST", Host);
            LogLevel = LogLevel.None;
            Ssl = bool.Parse(getOrDefault(environment, "SSL", Ssl.ToString()));
            Port = int.Parse(getOrDefault(environment, "PORT", Port.ToString()));
            CustomAppId = getOrDefault(environment, "CUSTOM_APP_ID", CustomAppId);
            CustomAppVersion = getOrDefault(environment, "CUSTOM_APP_VERSION", CustomAppVersion);
            return this;
        }

        // Helper method for Java 7, as it's missing the getOrDefault method for Maps
        private string getOrDefault(IDictionary<string, string> environment, string key, string defaultValue)
        {
            string value = environment[string.Format("AMADEUS_{0}", key)];
            return (string.ReferenceEquals(value, null)) ? defaultValue : value;
        }
    }
}