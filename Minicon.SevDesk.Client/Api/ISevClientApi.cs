using Minicon.SevDesk.Client.Models;
using Refit;

namespace Minicon.SevDesk.Client.Api;

/// <summary>
///     Represents a collection of functions to interact with the SevClient API endpoints
/// </summary>
public interface ISevClientApi
{
	/// <summary>
	///     Update export config
	/// </summary>
	/// <remarks>
	///     Update export config to export DATEV
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="sevClientId">id of sevClient</param>
	/// <param name="body">Specify the update</param>
	/// <returns>Task of UpdateExportConfigResponse</returns>
	[Put("/SevClient/{SevClientId}/updateExportConfig")]
	Task<UpdateExportConfigResponse> UpdateExportConfigAsync(
		[AliasAs("SevClientId")] int sevClientId,
		[Body] UpdateExportConfigRequest body,
		CancellationToken cancellationToken = default);
}