using Afonsoft.Amadeus.travel.analytics.airTraffic;

namespace Afonsoft.Amadeus.travel.analytics
{

	/// <summary>
	/// <para>
	///   A namespaced client for the
	///   <code>/v1/travel/analytics/air-traffic</code> endpoints.
	/// </para>
	/// 
	/// <para>
	///   Access via the Amadeus client object.
	/// </para>
	/// 
	/// <pre>
	/// Amadeus amadeus = Amadeus.builder("clientId", "secret").build();
	/// amadeus.travel.analytics.airTraffic;</pre>
	/// 
	/// @hide
	/// </summary>
	public class AirTraffic
	{
	  /// <summary>
	  /// <para>
	  ///   A namespaced client for the
	  ///   <code>/v1/travel/analytics/air-traffic/searched</code> endpoints.
	  /// </para>
	  /// </summary>
	  public Searched searched;

	  /// <summary>
	  /// <para>
	  ///   A namespaced client for the
	  ///   <code>/v1/travel/analytics/air-traffic/searched/by-destination</code> endpoints.
	  /// </para>
	  /// </summary>
	  public SearchedByDestination searchedByDestination;

	  /// <summary>
	  /// <para>
	  ///   A namespaced client for the
	  ///   <code>/v1/travel/analytics/air-traffic/traveled</code> endpoints.
	  /// </para>
	  /// </summary>
	  public Traveled traveled;

	  /// <summary>
	  /// <para>
	  ///   A namespaced client for the
	  ///   <code>/v1/travel/analytics/air-traffic/booked</code> endpoints.
	  /// </para>
	  /// </summary>
	  public Booked booked;

	  /// <summary>
	  /// <para>
	  ///   A namespaced client for the
	  ///   <code>/v1/travel/analytics/air-traffic/busiest-period</code> endpoints.
	  /// </para>
	  /// </summary>
	  public BusiestPeriod busiestPeriod;

	  /// <summary>
	  /// Constructor.
	  /// @hide
	  /// </summary>
	  public AirTraffic(Amadeus client)
	  {
		this.searched = new Searched(client);
		this.searchedByDestination = new SearchedByDestination(client);
		this.traveled = new Traveled(client);
		this.booked = new Booked(client);
		this.busiestPeriod = new BusiestPeriod(client);
	  }
	}

}