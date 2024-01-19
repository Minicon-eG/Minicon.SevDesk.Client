using Minicon.SevDesk.Client.Models;
using Refit;

namespace Minicon.SevDesk.Client.Api;

/// <summary>
///     Represents a collection of functions to interact with the API endpoints
/// </summary>
public interface IReportApi
{
	/// <summary>
	///     Export contact list
	/// </summary>
	/// <remarks>
	///     Export contact list
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="sevQuery"></param>
	/// <param name="download"> (optional)</param>
	/// <returns>Task of Object</returns>
	Task<object> ReportContactAsync(SevQuery7 sevQuery, bool? download = null);

	/// <summary>
	///     Export invoice list
	/// </summary>
	/// <remarks>
	///     Export invoice list
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="sevQuery"></param>
	/// <param name="download"> (optional)</param>
	/// <returns>Task of Object</returns>
	Task<object> ReportInvoiceAsync(SevQuery2 sevQuery, bool? download = null);

	/// <summary>
	///     Export order list
	/// </summary>
	/// <remarks>
	///     Export order list
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="sevQuery"></param>
	/// <param name="download"> (optional)</param>
	/// <returns>Task of Object</returns>
	Task<object> ReportOrderAsync(SevQuery3 sevQuery, bool? download = null);

	/// <summary>
	///     Export voucher list
	/// </summary>
	/// <remarks>
	///     Export voucher list
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="sevQuery"></param>
	/// <param name="download"> (optional)</param>
	/// <returns>Task of Object</returns>
	Task<object> ReportVoucherAsync(SevQuery5 sevQuery, bool? download = null);
}
