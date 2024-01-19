using Minicon.SevDesk.Client.Models;
using Refit;

namespace Minicon.SevDesk.Client.Api;

public interface ICostCentreApi
{
	[Get("/CostCentre")]
	Task<ObjectsResult<CostCentreResponse>> GetCostCentreAsync(CancellationToken cancellationToken = default);
}
