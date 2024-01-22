using Minicon.SevDesk.Client.Models;
using Refit;

namespace Minicon.SevDesk.Client.Api;

/// <summary>
///     Represents a collection of functions to interact with the API endpoints
/// </summary>
public interface IInvoicePosApi
{
	/// <summary>
	///     Retrieve InvoicePos
	/// </summary>
	/// <remarks>
	///     There are a multitude of parameter which can be used to filter.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="id">Retrieve all InvoicePos with this InvoicePos id (optional)</param>
	/// <param name="invoiceId">
	///     Retrieve all invoices positions with this invoice. Must be provided with invoice[objectName]
	///     (optional)
	/// </param>
	/// <param name="invoiceObjectName">
	///     Only required if invoice[id] was provided. &#x27;Invoice&#x27; should be used as value.
	///     (optional)
	/// </param>
	/// <param name="partId">Retrieve all invoices positions with this part. Must be provided with part[objectName] (optional)</param>
	/// <param name="partObjectName">
	///     Only required if part[id] was provided. &#x27;Part&#x27; should be used as value.
	///     (optional)
	/// </param>
	/// <returns>Task of GetInvoicesPositionsResponse</returns>
	[Get("/InvoicePos")]
	Task<GetInvoicesPositionsResponse> GetInvoicePosAsync(
		decimal? id = null,
		decimal? invoiceId = null,
		string? invoiceObjectName = null,
		decimal? partId = null,
		string? partObjectName = null
	);
}
