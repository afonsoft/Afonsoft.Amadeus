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
        private readonly Amadeus client;


        /// <summary>
        /// <para>
        ///   A namespaced client for the
        ///   <code>/v2/reference-data/urls</code> endpoints.
        /// </para>
        /// </summary>
        public Urls Urls { get; private set; }

        /// <summary>
        /// <para>
        ///   A namespaced client for the
        ///   <code>/v2/reference-data/locations</code> endpoints.
        /// </para>
        /// </summary>
        public Locations Locations { get; private set; }

        /// <summary>
        /// <para>
        ///   A namespaced client for the
        ///   <code>/v2/reference-data/airlines</code> endpoints.
        /// </para>
        /// </summary>
        public Airlines Airlines { get; private set; }


        /// <summary>
        /// Constructor.
        /// @hide
        /// </summary>
        public ReferenceData(Amadeus client)
        {
            this.client = client;
            this.Urls = new Urls(client);
            this.Locations = new Locations(client);
            this.Airlines = new Airlines(client);
        }

        /// <summary>
        /// <para>
        ///   A namespaced client for the
        ///   <code>/v2/reference-data/location/:hotel_id</code> endpoints.
        /// </para>
        /// </summary>
        public virtual Location Location(string locationId)
        {
            return new Location(client, locationId);
        }
    }
}