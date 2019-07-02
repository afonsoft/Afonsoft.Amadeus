namespace Afonsoft.Amadeus.Resources
{
    /// <summary>
    /// An Airline object as returned by the Airline Code LookUp API. </summary>
    /// <seealso cref= com.amadeus.referenceData.airlines#get() </seealso>

    //@ToString public class Airline extends Resource
    public class Airline : Resource
    {
        public string type;
        public string iataCode;
        public string icaoCode;
        public string businessName;
        public string commonName;
    }

}