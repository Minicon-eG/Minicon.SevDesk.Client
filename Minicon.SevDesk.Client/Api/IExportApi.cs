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
	/// <param name="cancellationToken"></param>
	/// <returns>Task of Object</returns>
	[Get("/Export/contactListCsv")]
	Task<object> ExportContactAsync(ExportContactRequests sevQuery, bool? download = null,
		CancellationToken cancellationToken = default);

	/// <summary>
	///     Export creditNote
	/// </summary>
	/// <remarks>
	///     Export all credit notes as csv
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="sevQuery"></param>
	/// <param name="download"> (optional)</param>
	/// <param name="cancellationToken"></param>
	/// <returns>Task of Object</returns>
	[Get("/Export/creditNoteCsv")]
	Task<object> ExportCreditNoteAsync(ExportCreditNoteRequest sevQuery, bool? download = null,
		CancellationToken cancellationToken = default);

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
	/// <param name="cancellationToken"></param>
	/// <returns>Task of Object</returns>
	[Get("/Export/datevCSV")]
	Task<object> ExportDatevAsync(
		int? startDate,
		int? endDate,
		string scope,
		bool? download = null,
		bool? withUnpaidDocuments = null,
		bool? withEnshrinedDocuments = null,
		bool? enshrine = null,
		CancellationToken cancellationToken = default
	);

	/// <summary>
	///     Export invoice
	/// </summary>
	/// <remarks>
	///     Export all invoices as csv
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="exportInvoiceRequest"></param>
	/// <param name="download"> (optional)</param>
	/// <param name="cancellationToken"></param>
	/// <returns>Task of Object</returns>
	[Get("/Export/invoiceCsv")]
	Task<object> ExportInvoiceAsync(ExportInvoiceRequest exportInvoiceRequest, bool? download = null,
		CancellationToken cancellationToken = default);

	/// <summary>
	///     Export Invoice as zip
	/// </summary>
	/// <remarks>
	///     Export all invoices as zip
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="sevQuery"></param>
	/// <param name="download"> (optional)</param>
	/// <param name="cancellationToken"></param>
	/// <returns>Task of Object</returns>
	[Get("/Export/invoiceZip")]
	Task<object> ExportInvoiceZipAsync(ExportInvoiceZipRequest sevQuery, bool? download = null,
		CancellationToken cancellationToken = default);

	/// <summary>
	///     Export transaction
	/// </summary>
	/// <remarks>
	///     Export all transactions as csv
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="sevQuery"></param>
	/// <param name="download"> (optional)</param>
	/// <param name="cancellationToken"></param>
	/// <returns>Task of Object</returns>
	[Get("/Export/transactionsCsv")]
	Task<object> ExportTransactionsAsync(ExportTransactionsRequest sevQuery, bool? download = null,
		CancellationToken cancellationToken = default);

	/// <summary>
	///     Export voucher as zip
	/// </summary>
	/// <remarks>
	///     Export all vouchers as zip
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="sevQuery"></param>
	/// <param name="download"> (optional)</param>
	/// <param name="cancellationToken"></param>
	/// <returns>Task of Object</returns>
	[Get("/Export/voucherListCsv")]
	Task<object> ExportVoucherAsync(ExportVoucherRequest sevQuery, bool? download = null,
		CancellationToken cancellationToken = default);

	/// <summary>
	///     Export voucher zip
	/// </summary>
	/// <remarks>
	///     export all vouchers as zip
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="sevQuery"></param>
	/// <param name="download"> (optional)</param>
	/// <param name="cancellationToken"></param>
	/// <returns>Task of Object</returns>
	[Get("/Export/voucherZip")]
	Task<object> ExportVoucherZipAsync(ExportVoucherZipRequsts sevQuery, bool? download = null,
		CancellationToken cancellationToken = default);

	/// <summary>
	///     Create DATEV CSV export job
	/// </summary>
	/// <remarks>
	///     Creates a DATEV export job for booking data in CSV format.
	///     Returns a job ID that can be used to track the export progress.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="request">Export parameters</param>
	/// <param name="cancellationToken"></param>
	/// <returns>Task of CreateDatevExportJobResponse</returns>
	[Post("/Export/createDatevCsvZipExportJob")]
	Task<CreateDatevExportJobResponse> CreateDatevCsvZipExportJobAsync(
		[Body] CreateDatevCsvExportRequest request,
		CancellationToken cancellationToken = default);

	/// <summary>
	///     Create DATEV XML export job
	/// </summary>
	/// <remarks>
	///     Creates a DATEV export job for invoice data in XML format.
	///     Returns a job ID that can be used to track the export progress.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="request">Export parameters</param>
	/// <param name="cancellationToken"></param>
	/// <returns>Task of CreateDatevExportJobResponse</returns>
	[Post("/Export/createDatevXmlZipExportJob")]
	Task<CreateDatevExportJobResponse> CreateDatevXmlZipExportJobAsync(
		[Body] CreateDatevXmlExportRequest request,
		CancellationToken cancellationToken = default);
}
