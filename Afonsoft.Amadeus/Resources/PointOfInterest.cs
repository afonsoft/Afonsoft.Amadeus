namespace Afonsoft.Amadeus.Resources
{
    /// <summary>
    /// An PointOfInterest object as returned by the Locaion API. </summary>
    /// <seealso cref= com.amadeus.referenceData.locations.PointOfInterest#get() </seealso>
    public class PointOfInterest : Resource
    {
        public string type;
        public string subType;
        public string name;
        public GeoCode geoCode;
        public string category;
        public string[] tags;

        /// <summary>
        /// An PointOfInterest-related object as returned by the PointOfInterest API. </summary>
        /// <seealso cref= com.amadeus.referenceData.locations.PointOfInterest#get() </seealso>
        public class GeoCode
        {
            public double latitude;
            public double longitude;
        }

    }
}