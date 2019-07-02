namespace Afonsoft.Amadeus.Resources
{
    /// <summary>
    /// An Location object as returned by the Locaion API. </summary>
    /// <seealso cref= com.amadeus.referenceData.Location#get() </seealso>

    //@ToString public class Location extends Resource
    public class Location : Resource
    {
        public string type;
        public string subType;
        public string name;
        public string detailedName;
        public string timeZoneOffset;
        public string iataCode;
        public GeoCode geoCode;
        public Address address;
        public Distance distance;
        public Analytics analytics;
        public double relevance;

        /// <summary>
        /// An Location-related object as returned by the Location API. </summary>
        /// <seealso cref= com.amadeus.referenceData.Location#get() </seealso>

        //@ToString public class GeoCode
        public class GeoCode
        {
            public double latitude;
            public double longitude;
        }

        /// <summary>
        /// An Location-related object as returned by the Location API. </summary>
        /// <seealso cref= com.amadeus.referenceData.Location#get() </seealso>
        public class Address
        {
            public string cityName;
            public string cityCode;
            public string countryName;
            public string countryCode;
            public string regionCode;
        }

        /// <summary>
        /// An Location-related object as returned by the Location API. </summary>
        /// <seealso cref= com.amadeus.referenceData.Location#get() </seealso>

        //@ToString public class Distance
        public class Distance
        {
            public double value;
            public string unit;
        }

        /// <summary>
        /// An Location-related object as returned by the Location API. </summary>
        /// <seealso cref= com.amadeus.referenceData.Location#get() </seealso>
        public class Analytics
        {
            public Flights flights;
            public Travelers travelers;

            /// <summary>
            /// An Location-related object as returned by the Location API. </summary>
            /// <seealso cref= com.amadeus.referenceData.Location#get() </seealso>
            public class Flights
            {
                public double score;
            }

            /// <summary>
            /// An Location-related object as returned by the Location API. </summary>
            /// <seealso cref= com.amadeus.referenceData.Location#get() </seealso>
            public class Travelers
            {
                public double score;
            }
        }
    }
}