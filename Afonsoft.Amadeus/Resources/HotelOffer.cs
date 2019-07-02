
namespace Afonsoft.Amadeus.Resources
{

    /// <summary>
    /// An HotelOffer object as returned by the HotelOffers API. </summary>
    /// <seealso cref= com.amadeus.shopping.HotelOffers#get() </seealso>

    public class HotelOffer : Resource
    {
        public string type;
        public Hotel hotel;
        public bool available;
        public Offer[] offers;

        /// <summary>
        /// An HotelOffer-related object as returned by the HotelOffers API. </summary>
        /// <seealso cref= com.amadeus.shopping.HotelOffers#get() </seealso>
        public class Hotel
        {

            public string type;
            public string hotelId;
            public string chainCode;
            public string brandCode;
            public string dupeId;
            public string name;
            public int rating;
            public TextWithLanguageType description;
            public string[] amenities;
            public MediaURI[] media;
            public string cityCode;
            public double latitude;
            public double longitude;
            public HotelDistance hotelDistance;
            public AddressType address;
            public HotelContact contact;
        }

        /// <summary>
        /// An HotelOffer-related object as returned by the HotelOffers API. </summary>
        /// <seealso cref= com.amadeus.shopping.HotelOffers#get() </seealso>
        public class Offer : Resource
        {
            public string type;
            public string id;
            public int roomQuantity;
            public string rateCode;
            public RateFamily rateFamilyEstimated;
            public string category;
            public TextWithLanguageType description;
            public Commission commission;
            public string boardType;
            public RoomDetails room;
            public Guests guests;
            public HotelPrice price;
            public PolicyDetails policies;
        }

        /// <summary>
        /// An HotelOffer-related object as returned by the HotelOffers API. </summary>
        /// <seealso cref= com.amadeus.shopping.HotelOffers#get() </seealso>
        public class HotelDistance
        {
            public string description;
            public double distance;
            public string distanceUnit;
        }

        /// <summary>
        /// An HotelOffer-related object as returned by the HotelOffers API. </summary>
        /// <seealso cref= com.amadeus.shopping.HotelOffers#get() </seealso>
        public class RateFamily
        {
            public string code;
            public string type;
        }

        /// <summary>
        /// An HotelOffer-related object as returned by the HotelOffers API. </summary>
        /// <seealso cref= com.amadeus.shopping.HotelOffers#get() </seealso>
        public class Commission
        {
            public string percentage;
            public string amount;
            public TextWithLanguageType description;
        }

        /// <summary>
        /// An HotelOffer-related object as returned by the HotelOffers API. </summary>
        /// <seealso cref= com.amadeus.shopping.HotelOffers#get() </seealso>
        public class RoomDetails
        {
            public string type;
            public EstimatedRoomType typeEstimated;
            public TextWithLanguageType description;
        }

        /// <summary>
        /// An HotelOffer-related object as returned by the HotelOffers API. </summary>
        /// <seealso cref= com.amadeus.shopping.HotelOffers#get() </seealso>
        public class EstimatedRoomType
        {
            public string category;
            public int beds;
            public string bedType;
        }

        /// <summary>
        /// An HotelOffer-related object as returned by the HotelOffers API. </summary>
        /// <seealso cref= com.amadeus.shopping.HotelOffers#get() </seealso>
        public class HotelPrice
        {
            public string currency;
            public string total;
            public string @base;
            public HotelTax[] taxes;
            public PriceVariations variations;
        }

        /// <summary>
        /// An HotelOffer-related object as returned by the HotelOffers API. </summary>
        /// <seealso cref= com.amadeus.shopping.HotelOffers#get() </seealso>
        public class HotelTax
        {
            public string currency;
            public string amount;
            public string code;
            public string percentage;
            public bool included;
            public string description;
            public string pricingFrequency;
            public string pricingMode;
        }

        /// <summary>
        /// An HotelOffer-related object as returned by the HotelOffers API. </summary>
        /// <seealso cref= com.amadeus.shopping.HotelOffers#get() </seealso>
        public class PriceVariations
        {
            public BaseTotalAmount average;
            public PriceVariation[] changes;
        }

        /// <summary>
        /// An HotelOffer-related object as returned by the HotelOffers API. </summary>
        /// <seealso cref= com.amadeus.shopping.HotelOffers#get() </seealso>
        public class PriceVariation
        {
            public string startDate;
            public string endDate;
            public string @base;
            public string total;
        }

        /// <summary>
        /// An HotelOffer-related object as returned by the HotelOffers API. </summary>
        /// <seealso cref= com.amadeus.shopping.HotelOffers#get() </seealso>
        public class BaseTotalAmount
        {
            public string @base;
            public string total;
        }

        /// <summary>
        /// An HotelOffer-related object as returned by the HotelOffers API. </summary>
        /// <seealso cref= com.amadeus.shopping.HotelOffers#get() </seealso>
        public class Guests
        {
            public int adults;
            public int[] childAges;
        }

        /// <summary>
        /// An HotelOffer-related object as returned by the HotelOffers API. </summary>
        /// <seealso cref= com.amadeus.shopping.HotelOffers#get() </seealso>
        public class TextWithLanguageType
        {
            public string lang;
            public string text;
        }

        /// <summary>
        /// An HotelOffer-related object as returned by the HotelOffers API. </summary>
        /// <seealso cref= com.amadeus.shopping.HotelOffers#get() </seealso>
        public class MediaURI
        {
            public string uri;
            public string category;
        }

        /// <summary>
        /// An HotelOffer-related object as returned by the HotelOffers API. </summary>
        /// <seealso cref= com.amadeus.shopping.HotelOffers#get() </seealso>
        public class AddressType
        {
            public string[] lines;
            public string postalCode;
            public string cityName;
            public string countryCode;
            public string stateCode;
        }

        /// <summary>
        /// An HotelOffer-related object as returned by the HotelOffers API. </summary>
        /// <seealso cref= com.amadeus.shopping.HotelOffers#get() </seealso>
        public class HotelContact
        {
            public string phone;
            public string fax;
        }

        /// <summary>
        /// An HotelOffer-related object as returned by the HotelOffers API. </summary>
        /// <seealso cref= com.amadeus.shopping.HotelOffers#get() </seealso>
        public class PolicyDetails
        {
            public GuaranteePolicy guarantee;
            public GuaranteePolicy deposit;
            public GuaranteePolicy prepay;
            public GuaranteePolicy holdTime;
            public CancellationPolicy cancellation;
            public CheckInOutPolicy checkInOut;
        }

        /// <summary>
        /// An HotelOffer-related object as returned by the HotelOffers API. </summary>
        /// <seealso cref= com.amadeus.shopping.HotelOffers#get() </seealso>
        public class CheckInOutPolicy
        {
            public string checkIn;
            public TextWithLanguageType checkInDescription;
            public string checkOut;
            public TextWithLanguageType checkOutDescription;
        }

        /// <summary>
        /// An HotelOffer-related object as returned by the HotelOffers API. </summary>
        /// <seealso cref= com.amadeus.shopping.HotelOffers#get() </seealso>
        public class GuaranteePolicy
        {
            public string amount;
            public string deadline;
            public TextWithLanguageType description;
            public PaymentPolicy acceptedPayments;
        }

        /// <summary>
        /// An HotelOffer-related object as returned by the HotelOffers API. </summary>
        /// <seealso cref= com.amadeus.shopping.HotelOffers#get() </seealso>
        public class CancellationPolicy
        {
            public string type;
            public string amount;
            public int numberOfNights;
            public string percentage;
            public string deadline;
            public TextWithLanguageType description;
        }

        /// <summary>
        /// An HotelOffer-related object as returned by the HotelOffers API. </summary>
        /// <seealso cref= com.amadeus.shopping.HotelOffers#get() </seealso>
        public class PaymentPolicy
        {
            public string[] creditCards;
            public string method;
        }
    }
}