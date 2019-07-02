using System;

namespace Afonsoft.Amadeus.Resources
{

    /// <summary>
    /// An FlightOffer object as returned by the FlightOffers API. </summary>
    /// <seealso cref= com.amadeus.shopping.FlightOffers#get() </seealso>
    public class FlightOffer : Resource
    {
        private string type;
        private string id;
        private OfferItem[] offerItems;

        /// <summary>
        /// An FlightOffer-related object as returned by the FlightOffers API. </summary>
        /// <seealso cref= com.amadeus.shopping.FlightOffers#get() </seealso>
        public class OfferItem
        {

            public Service[] services;
            public Price price;
            public Price pricePerAdult;
            public Price pricePerInfant;
            public Price pricePerChild;
            public Price pricePerSenior;
        }

        /// <summary>
        /// An FlightOffer-related object as returned by the FlightOffers API. </summary>
        /// <seealso cref= com.amadeus.shopping.FlightOffers#get() </seealso>
        public class Service
        {
            public Segment[] segments;
        }

        /// <summary>
        /// An FlightOffer-related object as returned by the FlightOffers API. </summary>
        /// <seealso cref= com.amadeus.shopping.FlightOffers#get() </seealso>
        public class Segment
        {
            public FlightSegment flightSegment;
            public PricingDetail pricingDetailPerAdult;
            public PricingDetail pricingDetailPerInfant;
            public PricingDetail pricingDetailPerChild;
            public PricingDetail pricingDetailPerSenior;
        }

        /// <summary>
        /// An FlightOffer-related object as returned by the FlightOffers API. </summary>
        /// <seealso cref= com.amadeus.shopping.FlightOffers#get() </seealso>
        public class FlightSegment
        {
            public FlightEndPoint departure;
            public FlightEndPoint arrival;
            public string carrierCode;
            public string number;
            public OperatingFlight operating;
            public string duration;
            public FlightStop[] stops;
        }

        /// <summary>
        /// An FlightOffer-related object as returned by the FlightOffers API. </summary>
        /// <seealso cref= com.amadeus.shopping.FlightOffers#get() </seealso>
        public class FlightEndPoint
        {
            public string iataCode;
            public string terminal;
            public string at;
        }

        /// <summary>
        /// An FlightOffer-related object as returned by the FlightOffers API. </summary>
        /// <seealso cref= com.amadeus.shopping.FlightOffers#get() </seealso>
        public class OperatingFlight
        {
            public string carrierCode;
            public string number;
        }

        /// <summary>
        /// An FlightOffer-related object as returned by the FlightOffers API. </summary>
        /// <seealso cref= com.amadeus.shopping.FlightOffers#get() </seealso>
        public class FlightStop
        {
            public string iataCode;
            public AircraftEquipment newAircraft;
            public string duration;
            public DateTime arrivalAt;
            public DateTime departureAt;
        }

        /// <summary>
        /// An FlightOffer-related object as returned by the FlightOffers API. </summary>
        /// <seealso cref= com.amadeus.shopping.FlightOffers#get() </seealso>
        public class AircraftEquipment
        {
            public string code;
        }

        /// <summary>
        /// An FlightOffer-related object as returned by the FlightOffers API. </summary>
        /// <seealso cref= com.amadeus.shopping.FlightOffers#get() </seealso>
        public class Price
        {
            public double total;
            public double totalTaxes;
        }

        /// <summary>
        /// An FlightOffer-related object as returned by the FlightOffers API. </summary>
        /// <seealso cref= com.amadeus.shopping.FlightOffers#get() </seealso>
        public class PricingDetail
        {
            public string travelClass;
            public string fareClass;
            public int availability;
            public string fareBasis;
        }
    }
}