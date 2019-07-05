using Afonsoft.Amadeus.Resources;

namespace Afonsoft.Amadeus.referenceData
{

    /// <summary>
    /// <para>
    ///   A namespaced client for the
    ///   <code>/v1/reference-data/airlines</code> endpoints.
    /// </para>
    /// 
    /// <para>
    ///   Access via the Amadeus client object.
    /// </para>
    /// 
    /// <pre>
    /// Amadeus amadeus = Amadeus.builder("clientId", "secret").build();
    /// amadeus.referenceData.airlines;</pre>
    /// </summary>
    public class Airlines
    {
        private readonly Amadeus client;

        /// <summary>
        /// Constructor.
        /// @hide
        /// </summary>
        public Airlines(Amadeus client)
        {
            this.client = client;
        }

        /// <summary>
        /// <para>
        ///  Returns the airline name and code.
        /// </para>
        /// 
        /// <pre>
        /// amadeus.referenceData.airlines.Get(Params
        ///   .with("airlineCodes", "BA"));</pre>
        /// </summary>
        /// <param name="params"> the parameters to send to the API </param>
        /// <returns> an API response object </returns>
        /// <exception cref="ResponseException"> when an exception occurs </exception>
        public virtual Airline[] Get(Params @params)
        {
            Response response = client.Get("/v1/reference-data/airlines", @params);
            return (Airline[])Resource.FromArray(response, typeof(Airline[]));
        }

        /// <summary>
        /// Convenience method for calling <code>get</code> without any parameters. </summary>
        /// <seealso cref= Airlines#Get() </seealso>
        public virtual Airline[] Get()
        {
            return Get(null);
        }
    }
}