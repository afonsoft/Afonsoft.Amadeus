using Afonsoft.Amadeus.Resources;

namespace Afonsoft.Amadeus.travel.analytics.airTraffic
{

    /// <summary>
    /// <para>
    /// A namespaced client for the
    /// <code>/v1/travel/analytics/air-traffic/searched</code> endpoints.
    /// </para>
    /// 
    /// <para>
    /// Access via the Amadeus client object.
    /// </para>
    /// 
    /// <pre>
    /// Amadeus amadeus = Amadeus.builder("API_KEY", "API_SECRET").build();
    /// amadeus.travel.analytics.airTraffis.Searched;</pre>
    /// </summary>
    public class Searched
    {

        private readonly Amadeus client;

        /// <summary>
        /// Constructor.
        /// 
        /// @hide
        /// </summary>
        public Searched(Amadeus client)
        {
            this.client = client;
        }

        /// <summary>
        /// <para>
        /// Returns a list of air traffic reports based on the number of searches.
        /// </para>
        /// 
        /// <pre>
        /// amadeus.travel.analytics.airTraffic.searched.get(Params
        ///   .with("originCityCode", "MAD")
        ///   .and("searchPeriod", "2017-08")
        ///   .and("marketCountryCode", "ES"));</pre>
        /// </summary>
        /// <param name="params"> the parameters to send to the API </param>
        /// <returns> an API response object </returns>
        /// <exception cref="ResponseException"> when an exception occurs </exception>
        public virtual Search[] Get(Params @params)
        {
            Response response = client.Get("/v1/travel/analytics/air-traffic/searched", @params);
            return (Search[])Resource.FromArray(response, typeof(Search[]));
        }

        /// <summary>
        /// Convenience method for calling <code>get</code> without any parameters.
        /// </summary>
        /// <seealso cref= Searched#get() </seealso>
        public virtual Search[] Get()
        {
            return Get(null);
        }
    }
}