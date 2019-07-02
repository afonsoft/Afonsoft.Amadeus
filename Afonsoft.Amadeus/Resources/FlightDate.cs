using System;

namespace Afonsoft.Amadeus.Resources
{

    /// <summary>
    /// An FlightDate object as returned by the FlightDates API. </summary>
    /// <seealso cref= com.amadeus.shopping.FlightDates#get() </seealso>
    public class FlightDate : Resource
    {
        public string type;
        public string origin;
        public string destination;
        public DateTime departureDate;
        public DateTime returnDate;
        public Price price;

        /// <summary>
        /// An FlightDate-related object as returned by the FlightDates API. </summary>
        /// <seealso cref= com.amadeus.shopping.FlightDates#get() </seealso>
        public class Price
        {
            public double total;
        }
    }
}