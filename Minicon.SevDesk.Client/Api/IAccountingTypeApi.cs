using Minicon.SevDesk.Client.Models;
using Refit;

namespace Minicon.SevDesk.Client.Api;

/// <summary>
///     Legacy / undocumented endpoint: <c>/AccountingType</c> is not part of the official sevDesk OpenAPI spec
///     (verified against spec 2.0.0).
/// </summary>
/// <remarks>
///     <b>No direct alternative.</b> sevDesk dropped SKR booking accounts from the public API. Closest documented
///     concept is <see cref="ICheckAccountApi"/> (<c>/CheckAccount</c>) — but that covers <i>bank/cash accounts</i>,
///     not bookkeeping (SKR) accounts. If you genuinely need SKR accounts, keep using this legacy endpoint at your
///     own risk; sevDesk may remove it without notice.
/// </remarks>
/// <seealso cref="ICheckAccountApi"/>
[Obsolete("Not in the official sevDesk OpenAPI spec (2.0.0). No direct replacement — /CheckAccount (ICheckAccountApi) covers bank/cash accounts but NOT SKR bookkeeping accounts. May be removed by sevDesk without notice.")]
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
