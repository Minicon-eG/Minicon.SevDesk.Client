using Minicon.SevDesk.Client.Models;
using Refit;

namespace Minicon.SevDesk.Client.Api;

public interface IAccountingTypeApi
{
	/// <summary>
	///     Get current AccountingType's
	/// </summary>
	/// <param name="emptyState"></param>
	/// <param name="countAll"></param>
	/// <param name="useClientAccountingChart"></param>
	/// <param name="embed"></param>
	/// <param name="onlyOwn"></param>
	/// <param name="offset"></param>
	/// <param name="limit"></param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	[Get("/AccountingType")]
	Task<ObjectsResult<AccountingType>> GetAccountingTypeAsync(
		bool emptyState = false,
		bool countAll = true,
		bool useClientAccountingChart = true,
		string embed = "accountingSystemNumber",
		bool onlyOwn = false,
		int offset = 0,
		int limit = 50,
		CancellationToken cancellationToken = default
	);
}
