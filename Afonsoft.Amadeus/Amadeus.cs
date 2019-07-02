using System.Collections.Generic;

namespace Afonsoft.Amadeus
{
    /// <summary>
    /// <para>
    /// The Amadeus API client. To initialize, use the builder as follows:
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
    public class Amadeus : HTTPClient
    {
        /// <summary>
        /// The API version.
        /// </summary>
        public const string VERSION = "3.1.0";

        /// <summary>
        /// <para>
        /// A namespaced client for the <code>/v2/reference-data</code> endpoints.
        /// </para>
        /// </summary>
        public ReferenceData referenceData;

        /// <summary>
        /// <para>
        /// A namespaced client for the <code>/v1/travel</code> endpoints.
        /// </para>
        /// </summary>
        public Travel travel;

        /// <summary>
        /// <para>
        /// A namespaced client for the <code>/v1/shopping</code> endpoints.
        /// </para>
        /// </summary>
        public Shopping shopping;

        protected internal Amadeus(Configuration configuration) : base(configuration)
        {
            this.referenceData = new ReferenceData(this);
            this.travel = new Travel(this);
            this.shopping = new Shopping(this);
        }

        /// <summary>
        /// Creates a builder object that can be used to build an Amadeus com.amadeus.client.
        /// 
        /// <pre>
        /// Amadeus amadeus = Amadeus.builder("CLIENT_ID", "CLIENT_SECRET").build();
        /// </pre>
        /// </summary>
        /// <param name="clientId">     Your API com.amadeus.client credential ID </param>
        /// <param name="clientSecret"> Your API com.amadeus.client credential secret </param>
        /// <returns> a Configuration object </returns>

        //public static Configuration builder(@NonNull String clientId, @NonNull String clientSecret)
        public static Configuration Builder(string clientId, string clientSecret)
        {
            return new Configuration(clientId, clientSecret);
        }

        /// <summary>
        /// Creates a builder object initialized with the environment variables that can be used to build
        /// an Amadeus API com.amadeus.client.
        /// 
        /// <pre>
        /// Amadeus amadeus = Amadeus.builder(System.getenv()).build();
        /// </pre>
        /// </summary>
        /// <param name="environment"> The system environment </param>
        /// <returns> a Configuration object </returns>
        public static Configuration builder(IDictionary<string, string> environment)
        {
            string clientId = environment["AMADEUS_CLIENT_ID"];
            string clientSecret = environment["AMADEUS_CLIENT_ID"];

            Configuration configuration = Amadeus.Builder(clientId, clientSecret);
            configuration.parseEnvironment(environment);

            return configuration;
        }
    }
}