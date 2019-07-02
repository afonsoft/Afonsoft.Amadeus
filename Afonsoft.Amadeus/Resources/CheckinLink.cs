namespace Afonsoft.Amadeus.Resources
{

    /// <summary>
    /// An CheckinLink object as returned by the CheckinLink API. </summary>
    /// <seealso cref= com.amadeus.referenceData.urls.CheckinLinks#get() </seealso>
    public class CheckinLink : Resource
    {
        public string type;
        public string id;
        public string href;
        public string channel;
    }
}