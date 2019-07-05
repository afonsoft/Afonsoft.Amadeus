using Afonsoft.Amadeus.travel.analytics.airTraffic;

namespace Afonsoft.Amadeus.travel.analytics
{

    /// <summary>
    /// <para>
    ///   A namespaced client for the
    ///   <code>/v1/travel/analytics/air-traffic</code> endpoints.
    /// </para>
    /// 
    /// <para>
    ///   Access via the Amadeus client object.
    /// </para>
    /// 
    /// <pre>
    /// Amadeus amadeus = Amadeus.builder("clientId", "secret").build();
    /// amadeus.travel.analytics.airTraffic;</pre>
    /// 
    /// @hide
    /// </summary>
    public class AirTraffic
    {
        /// <summary>
        /// <para>
        ///   A namespaced client for the
        ///   <code>/v1/travel/analytics/air-traffic/searched</code> endpoints.
        /// </para>
        /// </summary>
        public Searched Searched { get; private set; }

        /// <summary>
        /// <para>
        ///   A namespaced client for the
        ///   <code>/v1/travel/analytics/air-traffic/searched/by-destination</code> endpoints.
        /// </para>
        /// </summary>
        public SearchedByDestination SearchedByDestination { get; private set; }

        /// <summary>
        /// <para>
        ///   A namespaced client for the
        ///   <code>/v1/travel/analytics/air-traffic/traveled</code> endpoints.
        /// </para>
        /// </summary>
        public Traveled Traveled { get; private set; }

        /// <summary>
        /// <para>
        ///   A namespaced client for the
        ///   <code>/v1/travel/analytics/air-traffic/booked</code> endpoints.
        /// </para>
        /// </summary>
        public Booked Booked { get; private set; }

        /// <summary>
        /// <para>
        ///   A namespaced client for the
        ///   <code>/v1/travel/analytics/air-traffic/busiest-period</code> endpoints.
        /// </para>
        /// </summary>
        public BusiestPeriod BusiestPeriod { get; private set; }

        /// <summary>
        /// Constructor.
        /// @hide
        /// </summary>
        public AirTraffic(Amadeus client)
        {
            this.Searched = new Searched(client);
            this.SearchedByDestination = new SearchedByDestination(client);
            this.Traveled = new Traveled(client);
            this.Booked = new Booked(client);
            this.BusiestPeriod = new BusiestPeriod(client);
        }
    }
}