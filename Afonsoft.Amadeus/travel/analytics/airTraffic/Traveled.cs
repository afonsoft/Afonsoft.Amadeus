using Afonsoft.Amadeus.Resources;

namespace Afonsoft.Amadeus.travel.analytics.airTraffic
{
	/// <summary>
	/// <para>
	///   A namespaced client for the
	///   <code>/v1/travel/analytics/air-traffic/traveled</code> endpoints.
	/// </para>
	/// 
	/// <para>
	///   Access via the Amadeus client object.
	/// </para>
	/// 
	/// <pre>
	/// Amadeus amadeus = Amadeus.builder("clientId", "secret").build();
	/// amadeus.travel.analytics.airTraffis.traveled;</pre>
	/// </summary>
	public class Traveled
	{
	  private Amadeus client;

	  /// <summary>
	  /// Constructor.
	  /// @hide
	  /// </summary>
	  public Traveled(Amadeus client)
	  {
		this.client = client;
	  }

	  /// <summary>
	  /// <para>
	  ///   Returns a list of air traffic reports.
	  /// </para>
	  /// 
	  /// <pre>
	  /// amadeus.travel.analytics.airTraffic.traveled.get(Params
	  ///   .with("originCityCode", "LHR")
	  ///   .and("period", "2017-03"));</pre>
	  /// </summary>
	  /// <param name="params"> the parameters to send to the API </param>
	  /// <returns> an API response object </returns>
	  /// <exception cref="ResponseException"> when an exception occurs </exception>

//public com.amadeus.resources.AirTraffic[] get(com.amadeus.Params params) throws com.amadeus.exceptions.ResponseException
	  public virtual Afonsoft.Amadeus.Resources.AirTraffic[] Get(Params @params)
	  {
		Response response = client.Get("/v1/travel/analytics/air-traffic/traveled", @params);
		return (Afonsoft.Amadeus.Resources.AirTraffic[]) Resource.FromArray(response, typeof(Afonsoft.Amadeus.Resources.AirTraffic[]));
	  }

	  /// <summary>
	  /// Convenience method for calling <code>get</code> without any parameters. </summary>
	  /// <seealso cref= Traveled#get() </seealso>

//public com.amadeus.resources.AirTraffic[] get() throws com.amadeus.exceptions.ResponseException
	  public virtual Afonsoft.Amadeus.Resources.AirTraffic[] Get()
	  {
		return Get(null);
	  }
	}

}