using System.Collections.Generic;

namespace Afonsoft.Amadeus.Resources
{

    /// <summary>
    /// An SearchedDestination object as returned by the SearchedByDestination API. </summary>
    /// <seealso cref= SearchedByDestination#get() </seealso>
    public class SearchedDestination : Resource
    {
        public string destination;
        public string subType;
        public Analytics analytics;

        /// <summary>
        /// An AirTraffic-related object as returned by the AirTraffic API. </summary>
        /// <seealso cref= SearchedByDestination#get() </seealso>
        public class Analytics
        {
            public Searches searches;
        }

        /// <summary>
        /// An AirTraffic-related object as returned by the AirTraffic API. </summary>
        /// <seealso cref= SearchedByDestination#get() </seealso>
        public class Searches
        {
            public NumberOfSearches numberOfSearches;
        }

        /// <summary>
        /// An SearchedDestination-related object as returned by the SearchedByDestination API. </summary>
        /// <seealso cref= SearchedByDestination#get() </seealso>
        public class NumberOfSearches
        {
            public Dictionary<string, int> perTripDuration;
            public Dictionary<string, int> perDaysInAdvance;
        }
    }
}