using System;

namespace Afonsoft.Amadeus.Resources
{
    /// <summary>
    /// An FlightDestination object as returned by the FlightDestinations API. </summary>
    /// <seealso cref= com.amadeus.shopping.FlightDestinations#get() </seealso>
    public class FlightDestination : Resource
    {

        public string type;
        public string origin;
        public string destination;
        public DateTime departureDate;
        public DateTime returnDate;
        public Price price;

        /// <summary>
        /// An FlightDestination-related object as returned by the FlightDestinations API. </summary>
        /// <seealso cref= com.amadeus.shopping.FlightDestinations#get() </seealso>
        public class Price
        {
            public double total;
        }
    }
}