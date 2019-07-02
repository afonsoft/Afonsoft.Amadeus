namespace Afonsoft.Amadeus.Resources
{

    /// <summary>
    /// An AirTraffic object as returned by the AirTraffic API. </summary>
    /// <seealso cref= Traveled#get() </seealso>
    public class AirTraffic : Resource
    {
        public string type;
        public string subType;
        public string destination;
        public Analytics analytics;

        /// <summary>
        /// An AirTraffic-related object as returned by the AirTraffic API. </summary>
        /// <seealso cref= Traveled#get() </seealso>

        //@ToString public class Analytics
        public class Analytics
        {
            public Flights flights;
            public Travelers travelers;

            /// <summary>
            /// An AirTraffic-related object as returned by the AirTraffic API. </summary>
            /// <seealso cref= Traveled#get() </seealso>
            public class Flights
            {
                public double score;
            }

            /// <summary>
            /// An AirTraffic-related object as returned by the AirTraffic API. </summary>
            /// <seealso cref= Traveled#get() </seealso>
            public class Travelers
            {
                public double score;
            }
        }
    }
}