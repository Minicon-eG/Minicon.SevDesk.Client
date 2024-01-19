using Minicon.SevDesk.Client.Models;
using Refit;

namespace Minicon.SevDesk.Client.Api;

/// <summary>
///     Represents a collection of functions to interact with the API endpoints
/// </summary>
public interface ILayoutApi
{
	/// <summary>
	///     Retrieve letterpapers
	/// </summary>
	/// <remarks>
	///     Retrieve all letterpapers with Thumb
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <returns>Task of InlineResponse20015</returns>
	Task<InlineResponse20015> GetLetterpapersWithThumbAsync();

	/// <summary>
	///     Retrieve templates
	/// </summary>
	/// <remarks>
	///     Retrieve all templates
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="type">Type of the templates you want to get. (optional)</param>
	/// <returns>Task of InlineResponse20037</returns>
	Task<InlineResponse20037> GetTemplatesAsync(string type = null);

	/// <summary>
	///     Update an of credit note template
	/// </summary>
	/// <remarks>
	///     Update an existing of credit note template
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="creditNoteId">ID of credit note to update</param>
	/// <param name="body">Change Layout (optional)</param>
	/// <returns>Task of InlineResponse20017</returns>
	Task<InlineResponse20017> UpdateCreditNoteTemplateAsync(int? creditNoteId, ModelChangeLayout body = null);

	/// <summary>
	///     Update an invoice template
	/// </summary>
	/// <remarks>
	///     Update an existing invoice template
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="invoiceId">ID of invoice to update</param>
	/// <param name="body">Change Layout (optional)</param>
	/// <returns>Task of InlineResponse20017</returns>
	Task<InlineResponse20017> UpdateInvoiceTemplateAsync(int? invoiceId, ModelChangeLayout body = null);

	/// <summary>
	///     Update an order template
	/// </summary>
	/// <remarks>
	///     Update an existing order template
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="orderId">ID of order to update</param>
	/// <param name="body">Change Layout (optional)</param>
	/// <returns>Task of InlineResponse20017</returns>
	Task<InlineResponse20017> UpdateOrderTemplateAsync(int? orderId, ModelChangeLayout body = null);
}
