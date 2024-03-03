using Minicon.SevDesk.Client.Models;
using Refit;

namespace Minicon.SevDesk.Client.Api;

/// <summary>
///     Represents a collection of functions to interact with the API endpoints
/// </summary>
public interface IVoucherPosApi
{
	/// <summary>
	///     Retrieve voucher positions
	/// </summary>
	/// <remarks>
	///     Retrieve all voucher positions depending on the filters defined in the query.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="voucherId">
	///     Retrieve all vouchers positions belonging to this voucher. Must be provided with
	///     voucher[objectName] (optional)
	/// </param>
	/// <param name="voucherObjectName">
	///     Only required if voucher[id] was provided. &#x27;Voucher&#x27; should be used as value.
	///     (optional)
	/// </param>
	/// <param name="limit"></param>
	/// <param name="offset"></param>
	/// <param name="countAll"></param>
	/// <returns>Task of GetVoucherPositionsResponse</returns>
	[Get("/VoucherPos")]
	Task<GetVoucherPositionsResponse> GetVoucherPositionsAsync(
		[AliasAs("voucher[id]")]
		int voucherId,
		[AliasAs("voucher[objectName]")]
		string voucherObjectName = "Voucher",
		int limit = 10000,
		int offset = 0,
		bool countAll = true);
}
