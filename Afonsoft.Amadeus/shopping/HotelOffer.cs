using Afonsoft.Amadeus.Resources;

namespace Afonsoft.Amadeus.shopping
{
    /// <summary>
    /// <para>
    ///   A namespaced client for the
    ///   <code>/v2/shopping/hotel-offers/:offer_id</code> endpoints.
    /// </para>
    /// 
    /// <para>
    ///   Access via the Amadeus client object
    /// </para>
    /// 
    /// <pre>
    /// Amadeus amadeus = Amadeus.builder(API_KEY, API_SECRET).build();
    /// amadeus.shopping.HotelOffer(offerId);</pre>
    /// 
    /// @hide
    /// </summary>
    public class HotelOffer
    {
        private readonly Amadeus client;
        private readonly string offerId;

        /// <summary>
        /// Constructor.
        /// @hide
        /// </summary>
        public HotelOffer(Amadeus client, string offerId)
        {
            this.offerId = offerId;
            this.client = client;
        }

        /// <summary>
        /// <para>
        ///   Returns details for a specific offer.
        /// </para>
        /// 
        /// <pre>
        /// amadeus.shopping.HotelOffer("XXX").get();</pre>
        /// </summary>
        /// <param name="params"> the parameters to send to the API </param>
        /// <returns> an API response object </returns>
        /// <exception cref="ResponseException"> when an exception occurs </exception>

        //public com.amadeus.resources.HotelOffer get(com.amadeus.Params params) throws com.amadeus.exceptions.ResponseException
        public virtual Afonsoft.Amadeus.Resources.HotelOffer Get(Params @params)
        {
            string path = string.Format("/v2/shopping/hotel-offers/{0}", offerId);
            Response response = client.Get(path, @params);
            return (Afonsoft.Amadeus.Resources.HotelOffer)Resource.FromObject(response, typeof(Afonsoft.Amadeus.Resources.HotelOffer));
        }

        /// <summary>
        /// Convenience method for calling <code>get</code> without any parameters. </summary>
        /// <seealso cref= com.amadeus.resources.HotelOffer#get() </seealso>

        //public com.amadeus.resources.HotelOffer get() throws com.amadeus.exceptions.ResponseException
        public virtual Afonsoft.Amadeus.Resources.HotelOffer Get()
        {
            return Get(null);
        }
    }
}