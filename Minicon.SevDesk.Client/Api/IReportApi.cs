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
	Task<object> ReportContactAsync(ReportContactRequest sevQuery, bool? download = null);

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
	[Get("/Report/invoicelist")]
	Task<object> ReportInvoiceAsync(ReportInvoiceRequest sevQuery, bool? download = null);

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
	[Get("/Report/orderlist")]
	Task<object> ReportOrderAsync(ReportOrderRequest sevQuery, bool? download = null);

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
	[Get("/Report/voucherlist")]
	Task<object> ReportVoucherAsync(ReportVoucherRequest sevQuery, bool? download = null);
}
