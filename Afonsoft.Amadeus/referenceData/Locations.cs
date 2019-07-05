using Afonsoft.Amadeus.referenceData.locations;
using Afonsoft.Amadeus.Resources;

namespace Afonsoft.Amadeus.referenceData
{

    /// <summary>
    /// <para>
    ///   A namespaced client for the
    ///   <code>/v2/reference-data/locations</code> endpoints.
    /// </para>
    /// 
    /// <para>
    ///   Access via the Amadeus client object
    /// </para>
    /// 
    /// <pre>
    /// Amadeus amadeus = Amadeus.builder("clientId", "secret").build();
    /// amadeus.referenceData.locations;</pre>
    /// 
    /// @hide
    /// </summary>
    public class Locations
    {
        public static string ANY = "AIRPORT,CITY";
        public static string AIRPORT = "AIRPORT";
        public static string CITY = "CITY";

        private Amadeus client;

        /// <summary>
        /// <para>
        ///   A namespaced client for the
        ///   <code>/v2/reference-data/locations/airports</code> endpoints.
        /// </para>
        /// </summary>
        public Airports Airports { get; private set; }

        /// <summary>
        /// <para>
        ///   A namespaced client for the
        ///   <code>/v2/reference-data/locations/pois</code> endpoints.
        /// </para>
        /// </summary>
        public PointsOfInterest PointsOfInterest { get; private set; }


        /// <summary>
        /// Constructor.
        /// @hide
        /// </summary>
        public Locations(Amadeus client)
        {
            this.client = client;
            this.Airports = new Airports(client);
            this.PointsOfInterest = new PointsOfInterest(client);
        }

        /// <summary>
        /// <para>
        ///   Returns a list of airports and cities matching a given keyword.
        /// </para>
        /// 
        /// <pre>
        /// amadeus.referenceData.locations.Get(Params
        ///   .with("keyword", "lon)
        ///   .and("subType", Locations.ANY));</pre>
        /// </summary>
        /// <param name="params"> the parameters to send to the API </param>
        /// <returns> an API response object </returns>
        /// <exception cref="ResponseException"> when an exception occurs </exception>
        public virtual Afonsoft.Amadeus.Resources.Location[] Get(Params @params)
        {
            Response response = client.Get("/v1/reference-data/locations", @params);
            return (Afonsoft.Amadeus.Resources.Location[])Resource.FromArray(response, typeof(Afonsoft.Amadeus.Resources.Location[]));
        }

        /// <summary>
        /// Convenience method for calling <code>get</code> without any parameters. </summary>
        /// <seealso cref= Locations#Get() </seealso>
        public virtual Afonsoft.Amadeus.Resources.Location[] Get()
        {
            return Get(null);
        }
    }
}