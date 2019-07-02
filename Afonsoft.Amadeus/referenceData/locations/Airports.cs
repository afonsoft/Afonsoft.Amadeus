using Afonsoft.Amadeus.Resources;

namespace Afonsoft.Amadeus.referenceData.locations
{

    /// <summary>
    /// <para>
    ///   A namespaced client for the
    ///   <code>/v1/reference-data/locations/airports</code> endpoints.
    /// </para>
    /// 
    /// <para>
    ///   Access via the Amadeus client object.
    /// </para>
    /// 
    /// <pre>
    /// Amadeus amadeus = Amadeus.builder("clientId", "secret").build();
    /// amadeus.referenceData.locations.airports;</pre>
    /// </summary>
    public class Airports
    {
        private Amadeus client;

        /// <summary>
        /// Constructor.
        /// @hide
        /// </summary>
        public Airports(Amadeus client)
        {
            this.client = client;
        }

        /// <summary>
        /// <para>
        ///   Returns a list of relevant airports near to a given point.
        /// </para>
        /// 
        /// <pre>
        /// amadeus.referenceData.locations.airports.get(Params
        ///   .with("longitude", 49.0000)
        ///   .and("latitude", 2.55));</pre>
        /// </summary>
        /// <param name="params"> the parameters to send to the API </param>
        /// <returns> an API response object </returns>
        /// <exception cref="ResponseException"> when an exception occurs </exception>

        //public com.amadeus.resources.Location[] get(com.amadeus.Params params) throws com.amadeus.exceptions.ResponseException
        public virtual Afonsoft.Amadeus.Resources.Location[] Get(Params @params)
        {
            Response response = client.Get("/v1/reference-data/locations/airports", @params);
            return (Afonsoft.Amadeus.Resources.Location[])Resource.FromArray(response, typeof(Afonsoft.Amadeus.Resources.Location[]));
        }

        /// <summary>
        /// Convenience method for calling <code>get</code> without any parameters. </summary>
        /// <seealso cref= Airports#get() </seealso>

        //public com.amadeus.resources.Location[] get() throws com.amadeus.exceptions.ResponseException
        public virtual Afonsoft.Amadeus.Resources.Location[] Get()
        {
            return Get(null);
        }
    }
}