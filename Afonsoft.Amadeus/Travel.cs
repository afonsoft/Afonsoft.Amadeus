namespace Afonsoft.Amadeus
{

    /// <summary>
    /// <para>
    ///   A namespaced client for the
    ///   <code>/v2/travel</code> endpoints.
    /// </para>
    /// 
    /// <para>
    ///   Access via the Amadeus client object.
    /// </para>
    /// 
    /// <pre>
    /// Amadeus amadeus = Amadeus.builder("clientId", "secret").build();
    /// amadeus.travel;</pre>
    /// 
    /// @hide
    /// </summary>
    public class Travel
    {
        /// <summary>
        /// <para>
        ///   A namespaced client for the
        ///   <code>/v2/travel/analytics</code> endpoints.
        /// </para>
        /// </summary>
        public Afonsoft.Amadeus.travel.analytics.Analytics Analytics { get; private set; }

        /// <summary>
        /// Constructor.
        /// @hide
        /// </summary>
        public Travel(Amadeus client)
        {
            this.Analytics = new Afonsoft.Amadeus.travel.analytics.Analytics(client);
        }
    }
}