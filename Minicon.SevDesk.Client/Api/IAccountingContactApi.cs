using Minicon.SevDesk.Client.Models;
using Refit;

namespace Minicon.SevDesk.Client.Api;

/// <summary>
///     Represents a collection of functions to interact with the API endpoints
/// </summary>
public interface IAccountingContactApi
{
	/// <summary>
	///     Create a new accounting contact
	/// </summary>
	/// <remarks>
	///     Creates a new accounting contact.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="body">Creation data (optional)</param>
	/// <returns>Task of GetAccountContactResponse</returns>
	[Post("/AccountingContact")]
	Task<GetAccountContactResponse> CreateAccountingContactAsync(ModelAccountingContact? body);

	/// <summary>
	///     Deletes an accounting contact
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="accountingContactId">Id of accounting contact resource to delete</param>
	/// <param name="cancellationToken"></param>
	/// <returns>Task of InlineResponse2003</returns>
	[Delete("/AccountingContact/{accountingContactId}")]
	Task<DeleteResponse> DeleteAccountingContactAsync(int accountingContactId,
		CancellationToken cancellationToken = default);

	/// <summary>
	///     Retrieve accounting contact
	/// </summary>
	/// <remarks>
	///     Returns all accounting contact which have been added up until now. Filters can be added.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="contactId">ID of contact for which you want the accounting contact. (optional)</param>
	/// <param name="contactObjectName">Object name. Only needed if you also defined the ID of a contact. (optional)</param>
	/// <param name="limit"></param>
	/// <param name="offset"></param>
	/// <param name="countAll"></param>
	/// <param name="cancellationToken"></param>
	/// <returns>Task of GetAccountContactResponse</returns>
	[Get("/AccountingContact")]
	Task<GetAccountContactResponse> GetAccountingContactAsync(
		[AliasAs("id")] string? contactId = null,
		[AliasAs("objectName")] string? contactObjectName = null,
		int limit = 10000,
		int offset = 0,
		bool countAll = true,
		CancellationToken cancellationToken = default
	);

	/// <summary>
	///     Find accounting contact by ID
	/// </summary>
	/// <remarks>
	///     Returns a single accounting contact
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="accountingContactId">ID of accounting contact to return</param>
	/// <param name="cancellationToken"></param>
	/// <returns>Task of GetAccountContactResponse</returns>
	[Get("/AccountingContact/{accountingContactId}")]
	Task<GetAccountContactResponse> GetAccountingContactByIdAsync(int accountingContactId,
		CancellationToken cancellationToken = default);

	/// <summary>
	///     Update an existing accounting contact
	/// </summary>
	/// <remarks>
	///     Update an accounting contact
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="accountingContactId">ID of accounting contact to update</param>
	/// <param name="body">Update data (optional)</param>
	/// <param name="cancellationToken"></param>
	/// <returns>Task of GetAccountContactResponse</returns>
	[Put("/AccountingContact/{accountingContactId}")]
	Task<GetAccountContactResponse> UpdateAccountingContactAsync(
		int accountingContactId,
		ModelAccountingContactUpdate body,
		CancellationToken cancellationToken = default
	);
}
