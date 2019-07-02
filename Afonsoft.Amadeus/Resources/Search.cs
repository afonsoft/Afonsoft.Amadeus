namespace Afonsoft.Amadeus.Resources
{

    //@ToString public class Search extends Resource
    public class Search : Resource
    {
        public string subType;
        public string destination;
        public Analytics analytics;

        /// <summary>
        /// An Search-related object as returned by the AirTraffic API.
        /// </summary>
        /// <seealso cref= Searched#get() </seealso>
        public class Analytics
        {
            public Searches searches;
        }

        /// <summary>
        /// An Search-related object as returned by the AirTraffic API.
        /// </summary>
        /// <seealso cref= Searched#get() </seealso>
        public class Searches
        {

            public double score;
        }
    }
}