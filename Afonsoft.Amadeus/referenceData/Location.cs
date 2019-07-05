using Afonsoft.Amadeus.Resources;

namespace Afonsoft.Amadeus.referenceData
{

    /// <summary>
    /// <para>
    ///   A namespaced client for the
    ///   <code>/v2/reference-data/locations/:location_id</code> endpoints.
    /// </para>
    /// 
    /// <para>
    ///   Access via the Amadeus client object
    /// </para>
    /// 
    /// <pre>
    /// Amadeus amadeus = Amadeus.builder(API_KEY, API_SECRET).build();
    /// amadeus.referenceData.location(locationId);</pre>
    /// 
    /// @hide
    /// </summary>
    public class Location
    {
        private readonly Amadeus client;
        private readonly string locationId;

        /// <summary>
        /// Constructor.
        /// @hide
        /// </summary>
        public Location(Amadeus client, string locationId)
        {
            this.locationId = locationId;
            this.client = client;
        }

        /// <summary>
        /// <para>
        ///   Returns details for a specific airport.
        /// </para>
        /// 
        /// <pre>
        /// amadeus.referenceData.locations("ALHR').get();</pre>
        /// </summary>
        /// <param name="params"> the parameters to send to the API </param>
        /// <returns> an API response object </returns>
        /// <exception cref="ResponseException"> when an exception occurs </exception>
        public virtual Afonsoft.Amadeus.Resources.Location Get(Params @params)
        {
            string path = string.Format("/v1/reference-data/locations/{0}", locationId);
            Response response = client.Get(path, @params);
            return (Afonsoft.Amadeus.Resources.Location)Resource.FromObject(response, typeof(Afonsoft.Amadeus.Resources.Location));
        }

        /// <summary>
        /// Convenience method for calling <code>get</code> without any parameters. </summary>
        /// <seealso cref= Airports#Get() </seealso>
        public virtual Afonsoft.Amadeus.Resources.Location Get()
        {
            return Get(null);
        }
    }
}