using Afonsoft.Amadeus.referenceData;

namespace Afonsoft.Amadeus
{
    /// <summary>
    /// <para>
    ///   A namespaced client for the
    ///   <code>/v2/reference-data</code> endpoints.
    /// </para>
    /// 
    /// <para>
    ///   Access via the Amadeus client object.
    /// </para>
    /// 
    /// <pre>
    /// Amadeus amadeus = Amadeus.builder("clientId", "secret").build();
    /// amadeus.referenceData;</pre>
    /// 
    /// @hide
    /// </summary>
    public class ReferenceData
    {
        private Amadeus client;

        /// <summary>
        /// <para>
        ///   A namespaced client for the
        ///   <code>/v2/reference-data/urls</code> endpoints.
        /// </para>
        /// </summary>
        public Urls urls;

        /// <summary>
        /// <para>
        ///   A namespaced client for the
        ///   <code>/v2/reference-data/locations</code> endpoints.
        /// </para>
        /// </summary>
        public Locations locations;

        /// <summary>
        /// <para>
        ///   A namespaced client for the
        ///   <code>/v2/reference-data/airlines</code> endpoints.
        /// </para>
        /// </summary>
        public Airlines airlines;


        /// <summary>
        /// Constructor.
        /// @hide
        /// </summary>
        public ReferenceData(Amadeus client)
        {
            this.client = client;
            this.urls = new Urls(client);
            this.locations = new Locations(client);
            this.airlines = new Airlines(client);
        }

        /// <summary>
        /// <para>
        ///   A namespaced client for the
        ///   <code>/v2/reference-data/location/:hotel_id</code> endpoints.
        /// </para>
        /// </summary>
        public virtual Location location(string locationId)
        {
            return new Location(client, locationId);
        }
    }
}