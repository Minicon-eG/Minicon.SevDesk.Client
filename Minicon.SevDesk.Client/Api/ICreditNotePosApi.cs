using Minicon.SevDesk.Client.Models;
using Refit;

namespace Minicon.SevDesk.Client.Api;

/// <summary>
///     Represents a collection of functions to interact with the API endpoints
/// </summary>
public interface ICreditNotePosApi
{
	/// <summary>
	///     Retrieve creditNote positions
	/// </summary>
	/// <remarks>
	///     Retrieve all creditNote positions depending on the filters defined in the query.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="creditNoteId">
	///     Retrieve all creditNote positions belonging to this creditNote. Must be provided with
	///     creditNote[objectName] (optional)
	/// </param>
	/// <param name="creditNoteObjectName">
	///     Only required if creditNote[id] was provided. &#x27;creditNote&#x27; should be used
	///     as value. (optional)
	/// </param>
	/// <returns>Task of InlineResponse20033</returns>
	[Get("/creditNotePos")]
	Task<InlineResponse20033> GetCreditNotePositionsAsync(int? creditNoteId = null, string creditNoteObjectName = null);
}
