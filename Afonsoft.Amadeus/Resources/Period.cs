namespace Afonsoft.Amadeus.Resources
{

    /// <summary>
    /// An Period object as returned by the BusiestPeriod API. </summary>
    /// <seealso cref= Traveled#get() </seealso>
    public class Period : Resource
    {
        public string type;
        public string period;
        public Analytics analytics;

        /// <summary>
        /// An Period-related object as returned by the Busiest Period API. </summary>
        /// <seealso cref= Traveled#get() </seealso>
        public class Analytics
        {
            public Travelers travelers;

            /// <summary>
            /// An Period-related object as returned by the BusiestPeriod API. </summary>
            /// <seealso cref= Traveled#get() </seealso>
            public class Travelers
            {
                public double score;
            }
        }
    }
}