using Afonsoft.Amadeus.Resources;

namespace Afonsoft.Amadeus.shopping
{
	/// <summary>
	/// <para>
	///   A namespaced client for the
	///   <code>/v1/shopping/flight-dates</code> endpoints.
	/// </para>
	/// 
	/// <para>
	///   Access via the Amadeus client object.
	/// </para>
	/// 
	/// <pre>
	/// Amadeus amadeus = Amadeus.builder("clientId", "secret").build();
	/// amadeus.shopping.flightDates;</pre>
	/// </summary>
	public class FlightDates
	{
	  private Amadeus client;

	  /// <summary>
	  /// Constructor.
	  /// @hide
	  /// </summary>
	  public FlightDates(Amadeus client)
	  {
		this.client = client;
	  }

	  /// <summary>
	  /// <para>
	  ///   Find the cheapest flight dates from an
	  ///   origin to a destination.
	  /// </para>
	  /// 
	  /// <pre>
	  /// amadeus.shopping.flightDates.get(Params
	  ///   .with("origin", "LHR")
	  ///   .and("destination", "PAR"));</pre>
	  /// </summary>
	  /// <param name="params"> the parameters to send to the API </param>
	  /// <returns> an API response object </returns>
	  /// <exception cref="ResponseException"> when an exception occurs </exception>
	  public virtual FlightDate[] Get(Params @params)
	  {
		Response response = client.Get("/v1/shopping/flight-dates", @params);
		return (FlightDate[]) Resource.FromArray(response, typeof(FlightDate[]));
	  }

	  /// <summary>
	  /// Convenience method for calling <code>get</code> without any parameters. </summary>
	  /// <seealso cref= FlightDates#get() </seealso>
	  public virtual FlightDate[] Get()
	  {
		return Get(null);
	  }
	}

}