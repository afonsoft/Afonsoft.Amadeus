using Afonsoft.Amadeus.referenceData.locations.pointsOfInterest;
using Afonsoft.Amadeus.Resources;

namespace Afonsoft.Amadeus.referenceData.locations
{
    /// <summary>
    /// <para>
    ///   A namespaced client for the
    ///   <code>/v1/reference-data/locations/pois</code> endpoints.
    /// </para>
    /// 
    /// <para>
    ///   Access via the Amadeus client object.
    /// </para>
    /// 
    /// <pre>
    /// Amadeus amadeus = Amadeus.builder("clientId", "secret").build();
    /// amadeus.referenceData.locations.pointsOfInterest;</pre>
    /// </summary>
    public class PointsOfInterest
    {
        private readonly Amadeus client;


        /// <summary>
        /// <para>
        ///   A namespaced client for the
        ///   <code>/v1/reference-data/locations/pois/by-square</code> endpoints.
        /// </para>
        /// </summary>
        public BySquare BySquare { get; private set; }

        /// <summary>
        /// Constructor.
        /// @hide
        /// </summary>
        public PointsOfInterest(Amadeus client)
        {
            this.client = client;
            this.BySquare = new BySquare(client);
        }


        /// <summary>
        /// <para>
        ///   Returns a list of relevant point of interests near to a given point.
        /// </para>
        /// 
        /// <pre>
        /// amadeus.referenceData.locations.pointsOfInterest.get(Params
        ///   .with("longitude", 2.160873)
        ///   .and("latitude", 41.397158));</pre>
        /// </summary>
        /// <param name="params"> the parameters to send to the API </param>
        /// <returns> an API response object </returns>
        /// <exception cref="ResponseException"> when an exception occurs </exception>

        //public com.amadeus.resources.PointOfInterest[] get(com.amadeus.Params params) throws com.amadeus.exceptions.ResponseException
        public virtual PointOfInterest[] Get(Params @params)
        {
            Response response = client.Get("/v1/reference-data/locations/pois", @params);
            return (PointOfInterest[])Resource.FromArray(response, typeof(PointOfInterest[]));
        }

        /// <summary>
        /// Convenience method for calling <code>get</code> without any parameters. </summary>
        /// <seealso cref= PointsOfInterest#get() </seealso>

        //public com.amadeus.resources.PointOfInterest[] get() throws com.amadeus.exceptions.ResponseException
        public virtual PointOfInterest[] Get()
        {
            return Get(null);
        }
    }
}