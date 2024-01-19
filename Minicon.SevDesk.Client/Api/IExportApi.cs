using Minicon.SevDesk.Client.Models;
using Refit;

namespace Minicon.SevDesk.Client.Api;

/// <summary>
///     Represents a collection of functions to interact with the API endpoints
/// </summary>
public interface IExportApi
{
	/// <summary>
	///     Export contact
	/// </summary>
	/// <remarks>
	///     Contact export as csv
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="sevQuery"></param>
	/// <param name="download"> (optional)</param>
	/// <returns>Task of Object</returns>
	Task<object> ExportContactAsync(SevQuery9 sevQuery, bool? download = null);

	/// <summary>
	///     Export creditNote
	/// </summary>
	/// <remarks>
	///     Export all credit notes as csv
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="sevQuery"></param>
	/// <param name="download"> (optional)</param>
	/// <returns>Task of Object</returns>
	Task<object> ExportCreditNoteAsync(SevQuery6 sevQuery, bool? download = null);

	/// <summary>
	///     Export datev
	/// </summary>
	/// <remarks>
	///     Datev export as zip with csv´s
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="startDate">the start date of the export as timestamp</param>
	/// <param name="endDate">the end date of the export as timestamp</param>
	/// <param name="scope">
	///     Define what you want to include in the datev export. This parameter takes a string of 5 letters.
	///     Each stands for a model that should be included. Possible letters are: ‘E’ (Earnings), ‘X’ (Expenditure), ‘T’
	///     (Transactions), ‘C’ (Cashregister), ‘D’ (Assets). By providing one of those letter you specify that it should be
	///     included in the datev export. Some combinations are: ‘EXTCD’, ‘EXTD’ …
	/// </param>
	/// <param name="download">Specifies if the document is downloaded (optional)</param>
	/// <param name="withUnpaidDocuments">include unpaid documents (optional)</param>
	/// <param name="withEnshrinedDocuments">include enshrined documents (optional)</param>
	/// <param name="enshrine">Specify if you want to enshrine all models which were included in the export (optional)</param>
	/// <returns>Task of Object</returns>
	Task<object> ExportDatevAsync(int? startDate, int? endDate, string scope, bool? download = null,
		bool? withUnpaidDocuments = null, bool? withEnshrinedDocuments = null, bool? enshrine = null);

	/// <summary>
	///     Export invoice
	/// </summary>
	/// <remarks>
	///     Export all invoices as csv
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="sevQuery"></param>
	/// <param name="download"> (optional)</param>
	/// <returns>Task of Object</returns>
	Task<object> ExportInvoiceAsync(SevQuery sevQuery, bool? download = null);

	/// <summary>
	///     Export Invoice as zip
	/// </summary>
	/// <remarks>
	///     Export all invoices as zip
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="sevQuery"></param>
	/// <param name="download"> (optional)</param>
	/// <returns>Task of Object</returns>
	Task<object> ExportInvoiceZipAsync(SevQuery8 sevQuery, bool? download = null);

	/// <summary>
	///     Export transaction
	/// </summary>
	/// <remarks>
	///     Export all transactions as csv
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="sevQuery"></param>
	/// <param name="download"> (optional)</param>
	/// <returns>Task of Object</returns>
	Task<object> ExportTransactionsAsync(SevQuery4 sevQuery, bool? download = null);

	/// <summary>
	///     Export voucher as zip
	/// </summary>
	/// <remarks>
	///     Export all vouchers as zip
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="sevQuery"></param>
	/// <param name="download"> (optional)</param>
	/// <returns>Task of Object</returns>
	Task<object> ExportVoucherAsync(SevQuery1 sevQuery, bool? download = null);

	/// <summary>
	///     Export voucher zip
	/// </summary>
	/// <remarks>
	///     export all vouchers as zip
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="sevQuery"></param>
	/// <param name="download"> (optional)</param>
	/// <returns>Task of Object</returns>
	Task<object> ExportVoucherZipAsync(SevQuery10 sevQuery, bool? download = null);
}
