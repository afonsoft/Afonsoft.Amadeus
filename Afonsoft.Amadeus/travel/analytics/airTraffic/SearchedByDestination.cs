using Afonsoft.Amadeus.Resources;

namespace Afonsoft.Amadeus.travel.analytics.airTraffic
{
	/// <summary>
	/// <para>
	/// A namespaced client for the
	/// <code>/v1/travel/analytics/air-traffic/searched/by-destination</code> endpoints.
	/// </para>
	/// 
	/// <para>
	/// Access via the Amadeus client object.
	/// </para>
	/// 
	/// <pre>
	/// Amadeus amadeus = Amadeus.builder("API_KEY", "API_SECRET").build();
	/// amadeus.travel.analytics.airTraffis.SearchedByDestination;</pre>
	/// </summary>
	public class SearchedByDestination
	{

	  private Amadeus client;

	  /// <summary>
	  /// Constructor.
	  /// 
	  /// @hide
	  /// </summary>
	  public SearchedByDestination(Amadeus client)
	  {
		this.client = client;
	  }

	  /// <summary>
	  /// <para>
	  /// Returns a air traffic report based on the number of searches.
	  /// </para>
	  /// 
	  /// <pre>
	  /// amadeus.travel.analytics.airTraffic.searchedByDestination.get(Params
	  ///   .with("originCityCode", "MAD")
	  ///   .and("destinationCityCode", "NYC")
	  ///   .and("searchPeriod", "2017-08")
	  ///   .and("marketCountryCode", "ES"));</pre>
	  /// </summary>
	  /// <param name="params"> the parameters to send to the API </param>
	  /// <returns> an API response object </returns>
	  /// <exception cref="ResponseException"> when an exception occurs </exception>
	  public virtual SearchedDestination Get(Params @params)
	  {
		Response response = client.Get("/v1/travel/analytics/air-traffic/searched/by-destination", @params);
		return (SearchedDestination) Resource.FromObject(response, typeof(SearchedDestination));
	  }

	  /// <summary>
	  /// Convenience method for calling <code>get</code> without any parameters.
	  /// </summary>
	  /// <seealso cref= SearchedByDestination#get() </seealso>
	  public virtual SearchedDestination Get()
	  {
		return Get(null);
	  }
	}

}