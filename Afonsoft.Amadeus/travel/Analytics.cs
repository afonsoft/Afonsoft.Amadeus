namespace Afonsoft.Amadeus.travel.analytics
{

	/// <summary>
	/// <para>
	///   A namespaced client for the
	///   <code>/v1/travel/analytics</code> endpoints.
	/// </para>
	/// 
	/// <para>
	///   Access via the Amadeus client object.
	/// </para>
	/// 
	/// <pre>
	/// Amadeus amadeus = Amadeus.builder("clientId", "secret").build();
	/// amadeus.travel.analytics;</pre>
	/// 
	/// @hide
	/// </summary>
	public class Analytics
	{
	  /// <summary>
	  /// <para>
	  ///   A namespaced client for the
	  ///   <code>/v1/travel/analytics/air-traffics</code> endpoints.
	  /// </para>
	  /// </summary>
	  public AirTraffic airTraffic;


	  /// <summary>
	  /// Constructor.
	  /// @hide
	  /// </summary>
	  public Analytics(Amadeus client)
	  {
		this.airTraffic = new AirTraffic(client);
	  }
	}

}