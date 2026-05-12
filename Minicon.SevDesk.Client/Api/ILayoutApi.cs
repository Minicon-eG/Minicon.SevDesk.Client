using Minicon.SevDesk.Client.Models;
using Refit;

namespace Minicon.SevDesk.Client.Api;

/// <summary>
///     Represents a collection of functions to interact with the API endpoints
/// </summary>
/// <summary>
///     Legacy / undocumented endpoint: <c>/Layout</c> is not part of the official sevDesk OpenAPI spec
///     (verified against spec 2.0.0).
/// </summary>
/// <remarks>
///     <b>Alternative:</b> Use <see cref="IDocServerApi"/> — 1:1 replacement, sevDesk only renamed the path.
///     <list type="bullet">
///         <item><c>/Layout/getLetterpapersWithThumb</c> → <c>/DocServer/getLetterpapersWithThumb</c></item>
///         <item><c>/Layout/getTemplatesWithThumb</c> → <c>/DocServer/getTemplatesWithThumb</c></item>
///     </list>
/// </remarks>
/// <seealso cref="IDocServerApi"/>
[Obsolete("Replaced by IDocServerApi: /Layout/getLetterpapersWithThumb → /DocServer/getLetterpapersWithThumb, /Layout/getTemplatesWithThumb → /DocServer/getTemplatesWithThumb. 1:1 drop-in replacement.")]
public interface ILayoutApi
{
	/// <summary>
	///     Retrieve letterpapers
	/// </summary>
	/// <remarks>
	///     Retrieve all letterpapers with Thumb
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <returns>Task of GetLetterpapersWithThumbResponse</returns>
	Task<GetLetterpapersWithThumbResponse> GetLetterpapersWithThumbAsync();

	/// <summary>
	///     Retrieve templates
	/// </summary>
	/// <remarks>
	///     Retrieve all templates
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="type">Type of the templates you want to get. (optional)</param>
	/// <returns>Task of GetTemplatesResponse</returns>
	[Get("/DocServer/getTemplatesWithThumb")]
	Task<GetTemplatesResponse> GetTemplatesAsync(string? type = null);

	/// <summary>
	///     Update an of credit note template
	/// </summary>
	/// <remarks>
	///     Update an existing of credit note template
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="creditNoteId">ID of credit note to update</param>
	/// <param name="body">Change Layout (optional)</param>
	/// <returns>Task of UpdateTemplateResponse</returns>
	[Put("/CreditNote/{creditNoteId}/changeParameter")]
	Task<UpdateTemplateResponse> UpdateCreditNoteTemplateAsync(int creditNoteId, ModelChangeLayout body);

	/// <summary>
	///     Update an invoice template
	/// </summary>
	/// <remarks>
	///     Update an existing invoice template
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="invoiceId">ID of invoice to update</param>
	/// <param name="body">Change Layout (optional)</param>
	/// <returns>Task of UpdateTemplateResponse</returns>
	[Put("/Invoice/{invoiceId}/changeParameter")]
	Task<UpdateTemplateResponse> UpdateInvoiceTemplateAsync(int invoiceId, ModelChangeLayout body);

	/// <summary>
	///     Update an order template
	/// </summary>
	/// <remarks>
	///     Update an existing order template
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="orderId">ID of order to update</param>
	/// <param name="body">Change Layout (optional)</param>
	/// <returns>Task of UpdateTemplateResponse</returns>
	[Put("/Order/{orderId}/changeParameter")]
	Task<UpdateTemplateResponse> UpdateOrderTemplateAsync(int orderId, ModelChangeLayout body);
}
