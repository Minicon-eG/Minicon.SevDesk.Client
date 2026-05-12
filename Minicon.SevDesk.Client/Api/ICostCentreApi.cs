using Minicon.SevDesk.Client.Models;
using Refit;

namespace Minicon.SevDesk.Client.Api;

/// <summary>
///     Legacy / undocumented endpoint: <c>/CostCentre</c> is not part of the official sevDesk OpenAPI spec
///     (verified against spec 2.0.0).
/// </summary>
/// <remarks>
///     <b>No alternative.</b> Cost centres were removed from the public sevDesk API. If you need this functionality,
///     keep using the legacy endpoint at your own risk — sevDesk may remove it without notice.
/// </remarks>
[Obsolete("Not in the official sevDesk OpenAPI spec (2.0.0). No replacement — cost centres were removed from the public API. May be removed by sevDesk without notice.")]
public interface ICostCentreApi
{
	/// <summary>
	///     Retrieve cost centres
	/// </summary>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	[Get("/CostCentre")]
	Task<ObjectsResult<CostCentreResponse>> GetCostCentreAsync(CancellationToken cancellationToken = default);
}
