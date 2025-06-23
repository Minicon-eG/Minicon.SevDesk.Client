using Minicon.SevDesk.Client.Models;
using Refit;

namespace Minicon.SevDesk.Client.Api;

/// <summary>
///     Represents a collection of functions to interact with the SevUser API endpoints
/// </summary>
public interface ISevUserApi
{
	/// <summary>
	///     Get current user information
	/// </summary>
	/// <remarks>
	///     Returns information about the user associated with the current API token.
	///     This endpoint is not officially documented but is available in the SevDesk API.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <returns>Task of GetSevUserResponse</returns>
	[Get("/SevUser")]
	Task<GetSevUserResponse> GetCurrentUserAsync(CancellationToken cancellationToken = default);
}