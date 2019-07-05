using Afonsoft.Amadeus.shopping;

namespace Afonsoft.Amadeus
{
    /// <summary>
    /// <para>
    ///   A namespaced client for the
    ///   <code>/v2/shopping</code> endpoints.
    /// </para>
    /// 
    /// <para>
    ///   Access via the Amadeus client object.
    /// </para>
    /// 
    /// <pre>
    /// Amadeus amadeus = Amadeus.builder("clientId", "secret").build();
    /// amadeus.Shopping;</pre>
    /// 
    /// @hide
    /// </summary>
    public class Shopping
    {
        private Amadeus client;

        /// <summary>
        /// <para>
        ///   A namespaced client for the
        ///   <code>/v1/shopping/flight-dates</code> endpoints.
        /// </para>
        /// </summary>
        public FlightDates FlightDates { get; private set; }

        /// <summary>
        /// <para>
        ///   A namespaced client for the
        ///   <code>/v1/shopping/flight-destinations</code> endpoints.
        /// </para>
        /// </summary>
        public FlightDestinations FlightDestinations { get; private set; }

        /// <summary>
        /// <para>
        ///   A namespaced client for the
        ///   <code>/v1/shopping/flight-offers</code> endpoints.
        /// </para>
        /// </summary>
        public FlightOffers FlightOffers { get; private set; }

        /// <summary>
        /// <para>
        ///   A namespaced client for the
        ///   <code>/v2/shopping/hotel-offers</code> endpoints.
        /// </para>
        /// </summary>
        public HotelOffers HotelOffers { get; private set; }

        /// <summary>
        /// <para>
        ///   A namespaced client for the
        ///   <code>/v2/shopping/hotel-offers/by-hotel</code> endpoints.
        /// </para>
        /// </summary>
        public HotelOffersByHotel HotelOffersByHotel { get; private set; }

        /// <summary>
        /// Constructor.
        /// @hide
        /// </summary>
        public Shopping(Amadeus client)
        {
            this.client = client;
            this.FlightDates = new FlightDates(client);
            this.FlightDestinations = new FlightDestinations(client);
            this.FlightOffers = new FlightOffers(client);
            this.HotelOffers = new HotelOffers(client);
            this.HotelOffersByHotel = new HotelOffersByHotel(client);
        }

        /// <summary>
        /// <para>
        ///   A namespaced client for the
        ///   <code>/v1/shopping/hotel/:hotel_id</code> endpoints.
        /// </para>
        /// </summary>
        public virtual HotelOffer HotelOffer(string hotelId)
        {
            return new HotelOffer(client, hotelId);
        }
    }
}