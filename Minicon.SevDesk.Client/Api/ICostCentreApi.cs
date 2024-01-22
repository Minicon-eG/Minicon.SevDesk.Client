using Minicon.SevDesk.Client.Models;
using Refit;

namespace Minicon.SevDesk.Client.Api;

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
