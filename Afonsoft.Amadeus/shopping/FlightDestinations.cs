using Afonsoft.Amadeus.Resources;

namespace Afonsoft.Amadeus.shopping
{

    /// <summary>
    /// <para>
    ///   A namespaced client for the
    ///   <code>/v1/shopping/flight-destinations</code> endpoints.
    /// </para>
    /// 
    /// <para>
    ///   Access via the Amadeus client object.
    /// </para>
    /// 
    /// <pre>
    /// Amadeus amadeus = Amadeus.builder("clientId", "secret").build();
    /// amadeus.shopping.flightDestinations;</pre>
    /// </summary>
    public class FlightDestinations
    {
        private readonly Amadeus client;

        /// <summary>
        /// Constructor.
        /// @hide
        /// </summary>
        public FlightDestinations(Amadeus client)
        {
            this.client = client;
        }

        /// <summary>
        /// <para>
        ///   Find the cheapest destinations where
        ///   you can fly to.
        /// </para>
        /// 
        /// <pre>
        /// amadeus.shopping.flightDestinations.get(Params
        ///   .with("origin", "LHR"));</pre>
        /// </summary>
        /// <param name="params"> the parameters to send to the API </param>
        /// <returns> an API response object </returns>
        /// <exception cref="ResponseException"> when an exception occurs </exception>

        //public com.amadeus.resources.FlightDestination[] get(com.amadeus.Params params) throws com.amadeus.exceptions.ResponseException
        public virtual FlightDestination[] Get(Params @params)
        {
            Response response = client.Get("/v1/shopping/flight-destinations", @params);
            return (FlightDestination[])Resource.FromArray(response, typeof(FlightDestination[]));
        }

        /// <summary>
        /// Convenience method for calling <code>get</code> without any parameters. </summary>
        /// <seealso cref= FlightDestinations#get() </seealso>

        //public com.amadeus.resources.FlightDestination[] get() throws com.amadeus.exceptions.ResponseException
        public virtual FlightDestination[] Get()
        {
            return Get(null);
        }
    }
}