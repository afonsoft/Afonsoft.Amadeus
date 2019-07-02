using Afonsoft.Amadeus.Resources;

namespace Afonsoft.Amadeus.referenceData.locations.pointsOfInterest
{

	/// <summary>
	/// <para>
	///   A namespaced client for the
	///   <code>/v1/reference-data/locations/pois/by-square</code> endpoints.
	/// </para>
	/// 
	/// <para>
	///   Access via the Amadeus client object.
	/// </para>
	/// 
	/// <pre>
	/// Amadeus amadeus = Amadeus.builder("clientId", "secret").build();
	/// amadeus.referenceData.locations.pointsOfInterest.bySquare;</pre>
	/// </summary>
	public class BySquare
	{
	  private Amadeus client;

	  /// <summary>
	  /// Constructor.
	  /// @hide
	  /// </summary>
	  public BySquare(Amadeus client)
	  {
		this.client = client;
	  }

	  /// <summary>
	  /// <para>
	  ///   Returns a list of relevant point of interests within a square defined by
	  ///   cardinal points.
	  /// </para>
	  /// 
	  /// <pre>
	  /// amadeus.referenceData.locations.pointsOfInterest.bySquare.get(Params
	  ///   .with("north", 41.397158)
	  ///   .and("west", 2.160873)
	  ///   .and("south", 41.394582)
	  ///   .and("east", 2.177181));</pre>
	  /// </summary>
	  /// <param name="params"> the parameters to send to the API </param>
	  /// <returns> an API response object </returns>
	  /// <exception cref="ResponseException"> when an exception occurs </exception>

//public com.amadeus.resources.PointOfInterest[] get(com.amadeus.Params params) throws com.amadeus.exceptions.ResponseException
	  public virtual PointOfInterest[] Get(Params @params)
	  {
		Response response = client.Get("/v1/reference-data/locations/pois/by-square", @params);
		return (PointOfInterest[]) Resource.FromArray(response, typeof(PointOfInterest[]));
	  }

	  /// <summary>
	  /// Convenience method for calling <code>get</code> without any parameters. </summary>
	  /// <seealso cref= PointsOfInterest#get() </seealso>

//public com.amadeus.resources.PointOfInterest[] get() throws com.amadeus.exceptions.ResponseException
	  public virtual PointOfInterest[] Get()
	  {
		return Get(null);
	  }
	}

}