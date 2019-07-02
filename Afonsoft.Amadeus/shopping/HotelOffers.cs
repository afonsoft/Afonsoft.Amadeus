using Afonsoft.Amadeus.Resources;

namespace Afonsoft.Amadeus.shopping
{

	/// <summary>
	/// <para>
	///   A namespaced client for the
	///   <code>/v1/shopping/hotel-offers</code> endpoints.
	/// </para>
	/// 
	/// <para>
	///   Access via the Amadeus client object.
	/// </para>
	/// 
	/// <pre>
	/// Amadeus amadeus = Amadeus.builder("clientId", "secret").build();
	/// amadeus.shopping.hotelOffers;</pre>
	/// </summary>
	public class HotelOffers
	{
	  private Amadeus client;

	  /// <summary>
	  /// Constructor.
	  /// @hide
	  /// </summary>
	  public HotelOffers(Amadeus client)
	  {
		this.client = client;
	  }

	  /// <summary>
	  /// <para>
	  ///   Search for hotels and retrieve availability and rates information.
	  /// </para>
	  /// 
	  /// <pre>
	  /// amadeus.shopping.hotelOffers.get(Params
	  ///   .with("cityCode", "PAR"));</pre>
	  /// </summary>
	  /// <param name="params"> the parameters to send to the API </param>
	  /// <returns> an API response object </returns>
	  /// <exception cref="ResponseException"> when an exception occurs </exception>

//public com.amadeus.resources.HotelOffer[] get(com.amadeus.Params params) throws com.amadeus.exceptions.ResponseException
	  public virtual Afonsoft.Amadeus.Resources.HotelOffer[] Get(Params @params)
	  {
		Response response = client.Get("/v2/shopping/hotel-offers", @params);
		return (Afonsoft.Amadeus.Resources.HotelOffer[]) Resource.FromArray(response, typeof(Afonsoft.Amadeus.Resources.HotelOffer[]));
	  }

	  /// <summary>
	  /// Convenience method for calling <code>get</code> without any parameters. </summary>
	  /// <seealso cref= HotelOffers#get() </seealso>
//public com.amadeus.resources.HotelOffer[] get() throws com.amadeus.exceptions.ResponseException
	  public virtual Afonsoft.Amadeus.Resources.HotelOffer[] Get()
	  {
		return Get(null);
	  }
	}

}