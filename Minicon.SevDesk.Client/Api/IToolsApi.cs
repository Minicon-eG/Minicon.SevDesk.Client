using Minicon.SevDesk.Client.Models;
using Refit;

namespace Minicon.SevDesk.Client.Api;

/// <summary>
///     Represents a collection of functions to interact with the Tools API endpoints
/// </summary>
public interface IToolsApi
{
	/// <summary>
	///     Retrieve bookkeeping system version
	/// </summary>
	/// <remarks>
	///     To check if you already received the update to version 2.0 you can use this endpoint.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <returns>Task of BookkeepingSystemVersionResponse</returns>
	[Get("/Tools/bookkeepingSystemVersion")]
	Task<BookkeepingSystemVersionResponse> GetBookkeepingSystemVersionAsync(CancellationToken cancellationToken = default);
}