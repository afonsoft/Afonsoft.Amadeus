using Afonsoft.Amadeus.referenceData.urls;

namespace Afonsoft.Amadeus.referenceData
{

	/// <summary>
	/// <para>
	///   A namespaced client for the
	///   <code>/v2/reference-data/urls</code> endpoints.
	/// </para>
	/// 
	/// <para>
	///   Access via the Amadeus client object
	/// </para>
	/// 
	/// <pre>
	/// Amadeus amadeus = Amadeus.builder("clientId", "secret").build();
	/// amadeus.referenceData.urls;</pre>
	/// 
	/// @hide
	/// </summary>
	public class Urls
	{
	  /// <summary>
	  /// <para>
	  ///   A namespaced client for the
	  ///   <code>/v2/reference-data/urls/checkin-links</code> endpoints.
	  /// </para>
	  /// </summary>
	  public CheckinLinks checkinLinks;

	  /// <summary>
	  /// Constructor.
	  /// @hide
	  /// </summary>
	  public Urls(Amadeus client)
	  {
		this.checkinLinks = new CheckinLinks(client);
	  }
	}

}