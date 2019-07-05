using Afonsoft.Amadeus.Resources;

namespace Afonsoft.Amadeus.shopping
{

    /// <summary>
    /// <para>
    ///   A namespaced client for the
    ///   <code>/v2/shopping/hotel-offers/by-hotel</code> endpoints.
    /// </para>
    /// 
    /// <para>
    ///   Access via the Amadeus client object.
    /// </para>
    /// 
    /// <pre>
    /// Amadeus amadeus = Amadeus.builder("clientId", "secret").build();
    /// amadeus.shopping.HotelOffersByHotel;</pre>
    /// </summary>
    public class HotelOffersByHotel
    {
        private readonly Amadeus client;

        /// <summary>
        /// Constructor.
        /// @hide
        /// </summary>
        public HotelOffersByHotel(Amadeus client)
        {
            this.client = client;
        }

        /// <summary>
        /// <para>
        ///   Get all offers for a dedicated hotel.
        /// </para>
        /// 
        /// <pre>
        /// amadeus.shopping.HotelOffersByHotel.get(Params
        ///   .with("hotelId", "XKPARC12"));</pre>
        /// </summary>
        /// <param name="params"> the parameters to send to the API </param>
        /// <returns> an API response object </returns>
        /// <exception cref="ResponseException"> when an exception occurs </exception>

        //public com.amadeus.resources.HotelOffer get(com.amadeus.Params params) throws com.amadeus.exceptions.ResponseException
        public virtual Afonsoft.Amadeus.Resources.HotelOffer Get(Params @params)
        {
            Response response = client.Get("/v2/shopping/hotel-offers/by-hotel", @params);
            return (Afonsoft.Amadeus.Resources.HotelOffer)Resource.FromObject(response, typeof(Afonsoft.Amadeus.Resources.HotelOffer));
        }

        /// <summary>
        /// Convenience method for calling <code>get</code> without any parameters. </summary>
        /// <seealso cref= HotelOffersByHotel#get() </seealso>

        //public com.amadeus.resources.HotelOffer get() throws com.amadeus.exceptions.ResponseException
        public virtual Afonsoft.Amadeus.Resources.HotelOffer Get()
        {
            return Get(null);
        }
    }
}