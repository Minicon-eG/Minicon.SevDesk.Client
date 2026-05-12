using Minicon.SevDesk.Client.Models;
using Refit;

namespace Minicon.SevDesk.Client.Api;

/// <summary>
///     Represents a collection of functions to interact with the SevUser API endpoints
/// </summary>
/// <summary>
///     Legacy / undocumented endpoint: <c>/SevUser</c> is not part of the official sevDesk OpenAPI spec
///     (verified against spec 2.0.0).
/// </summary>
/// <remarks>
///     <b>No alternative.</b> User/account info has no documented replacement.
///     <see cref="ISevClientApi"/> only exposes <c>/SevClient/{id}/updateExportConfig</c> (client-level export
///     config), not user details. Keep using the legacy endpoint at your own risk — sevDesk may remove it.
/// </remarks>
/// <seealso cref="ISevClientApi"/>
[Obsolete("Not in the official sevDesk OpenAPI spec (2.0.0). No replacement for current-user info — ISevClientApi exposes only client export config, not user details. May be removed by sevDesk without notice.")]
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