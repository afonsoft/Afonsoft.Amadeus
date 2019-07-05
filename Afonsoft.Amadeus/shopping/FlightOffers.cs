using Afonsoft.Amadeus.Resources;

namespace Afonsoft.Amadeus.shopping
{
    /// <summary>
    /// <para>
    ///   A namespaced client for the
    ///   <code>/v1/shopping/flight-offers</code> endpoints.
    /// </para>
    /// 
    /// <para>
    ///   Access via the Amadeus client object.
    /// </para>
    /// 
    /// <pre>
    /// Amadeus amadeus = Amadeus.builder("clientId", "secret").build();
    /// amadeus.shopping.flightOffers;</pre>
    /// </summary>
    public class FlightOffers
    {
        private readonly Amadeus client;

        /// <summary>
        /// Constructor.
        /// @hide
        /// </summary>
        public FlightOffers(Amadeus client)
        {
            this.client = client;
        }

        /// <summary>
        /// <para>
        ///   Find the cheapest bookable flights.
        /// </para>
        /// 
        /// <pre>
        /// amadeus.shopping.flightOffers.get(Params
        ///   .with("origin", "LHR")
        ///   .and("destination", "LAX")
        ///   .and("departureDate", "2017-12-24"));</pre>
        /// </summary>
        /// <param name="params"> the parameters to send to the API </param>
        /// <returns> an API response object </returns>
        /// <exception cref="ResponseException"> when an exception occurs </exception>

        //public com.amadeus.resources.FlightOffer[] get(com.amadeus.Params params) throws com.amadeus.exceptions.ResponseException
        public virtual FlightOffer[] Get(Params @params)
        {
            Response response = client.Get("/v1/shopping/flight-offers", @params);
            return (FlightOffer[])Resource.FromArray(response, typeof(FlightOffer[]));
        }

        /// <summary>
        /// Convenience method for calling <code>get</code> without any parameters. </summary>
        /// <seealso cref= FlightOffers#get() </seealso>

        //public com.amadeus.resources.FlightOffer[] get() throws com.amadeus.exceptions.ResponseException
        public virtual FlightOffer[] Get()
        {
            return Get(null);
        }
    }
}