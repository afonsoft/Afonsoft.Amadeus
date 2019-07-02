using Afonsoft.Amadeus.Resources;

namespace Afonsoft.Amadeus.travel.analytics.airTraffic
{
	/// <summary>
	/// <para>
	///   A namespaced client for the
	///   <code>/v1/travel/analytics/air-traffic/busiest-period</code> endpoints.
	/// </para>
	/// 
	/// <para>
	///   Access via the Amadeus client object.
	/// </para>
	/// 
	/// <pre>
	/// Amadeus amadeus = Amadeus.builder("clientId", "secret").build();
	/// amadeus.travel.analytics.airTraffis.busiestPeriod;</pre>
	/// </summary>
	public class BusiestPeriod
	{
	  private Amadeus client;
	  public const string ARRIVING = "ARRIVING";
	  public const string DEPARTING = "DEPARTING";

	  /// <summary>
	  /// Constructor.
	  /// @hide
	  /// </summary>
	  public BusiestPeriod(Amadeus client)
	  {
		this.client = client;
	  }

	  /// <summary>
	  /// <para>
	  ///   Returns a list of busiest periods reports.
	  /// </para>
	  /// 
	  /// <pre>
	  /// amadeus.travel.analytics.airTraffic.busiestPeriod.get(Params
	  ///   .with("cityCode", "PAR")
	  ///   .and("period", "2017"));</pre>
	  /// </summary>
	  /// <param name="params"> the parameters to send to the API </param>
	  /// <returns> an API response object </returns>
	  /// <exception cref="ResponseException"> when an exception occurs </exception>
	  public virtual Period[] Get(Params @params)
	  {
		Response response = client.Get("/v1/travel/analytics/air-traffic/busiest-period", @params);
		return (Period[]) Resource.FromArray(response, typeof(Period[]));
	  }

	  /// <summary>
	  /// Convenience method for calling <code>get</code> without any parameters. </summary>
	  /// <seealso cref= Traveled#get() </seealso>
	  public virtual Period[] Get()
	  {
		return Get(null);
	  }
	}

}