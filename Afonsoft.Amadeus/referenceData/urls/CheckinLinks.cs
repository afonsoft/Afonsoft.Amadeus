using Afonsoft.Amadeus.Resources;

namespace Afonsoft.Amadeus.referenceData.urls
{

	/// <summary>
	/// <para>
	///   A namespaced client for the
	///   <code>/v2/reference-data/urls/checkin-links</code> endpoints.
	/// </para>
	/// 
	/// <para>
	///   Access via the Amadeus client object.
	/// </para>
	/// 
	/// <pre>
	/// Amadeus amadeus = Amadeus.builder(API_KEY, API_SECRET).build();
	/// amadeus.referenceData.urls.checkinLinks;</pre>
	/// </summary>
	public class CheckinLinks
	{
	  private Amadeus client;

	  /// <summary>
	  /// Constructor.
	  /// @hide
	  /// </summary>
	  public CheckinLinks(Amadeus client)
	  {
		this.client = client;
	  }

	  /// <summary>
	  /// <para>
	  ///   Returns the checkin links for an airline, for the
	  ///   language of your choice.
	  /// </para>
	  /// 
	  /// <pre>
	  /// amadeus.referenceData.urls.checkinLinks.get(Params.with("airlineCode", "BA"));</pre>
	  /// </summary>
	  /// <param name="params"> the parameters to send to the API </param>
	  /// <returns> an API resource </returns>
	  /// <exception cref="ResponseException"> when an exception occurs </exception>
	  public virtual CheckinLink[] Get(Params @params)
	  {
		Response response = client.Get("/v2/reference-data/urls/checkin-links", @params);
		return (CheckinLink[]) Resource.FromArray(response, typeof(PointOfInterest[]));
	  }

	  /// <summary>
	  /// Convenience method for calling <code>get</code> without any parameters. </summary>
	  /// <seealso cref= CheckinLinks#get() </seealso>
	  public virtual CheckinLink[] Get()
	  {
		return Get(null);
	  }
	}

}