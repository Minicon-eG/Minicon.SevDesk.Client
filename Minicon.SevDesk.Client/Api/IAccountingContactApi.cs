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
	Task<GetAccountContactResponse> CreateAccountingContactAsync(ModelAccountingContact body = null);

	/// <summary>
	///     Deletes an accounting contact
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="accountingContactId">Id of accounting contact resource to delete</param>
	/// <returns>Task of InlineResponse2003</returns>
	Task<InlineResponse2003> DeleteAccountingContactAsync(int? accountingContactId);

	/// <summary>
	///     Deletes an accounting contact
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="accountingContactId">Id of accounting contact resource to delete</param>
	/// <returns>Task of ApiResponse (InlineResponse2003)</returns>
	Task<ApiResponse<InlineResponse2003>> DeleteAccountingContactAsyncWithHttpInfo(int? accountingContactId);

	/// <summary>
	///     Retrieve accounting contact
	/// </summary>
	/// <remarks>
	///     Returns all accounting contact which have been added up until now. Filters can be added.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="contactId">ID of contact for which you want the accounting contact. (optional)</param>
	/// <param name="contactObjectName">Object name. Only needed if you also defined the ID of a contact. (optional)</param>
	/// <returns>Task of GetAccountContactResponse</returns>
	Task<GetAccountContactResponse> GetAccountingContactAsync(string contactId = null, string contactObjectName = null);

	/// <summary>
	///     Find accounting contact by ID
	/// </summary>
	/// <remarks>
	///     Returns a single accounting contac
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="accountingContactId">ID of accounting contact to return</param>
	/// <returns>Task of GetAccountContactResponse</returns>
	Task<GetAccountContactResponse> GetAccountingContactByIdAsync(int? accountingContactId);

	/// <summary>
	///     Update an existing accounting contact
	/// </summary>
	/// <remarks>
	///     Update an accounting contact
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="accountingContactId">ID of accounting contact to update</param>
	/// <param name="body">Update data (optional)</param>
	/// <returns>Task of GetAccountContactResponse</returns>
	Task<GetAccountContactResponse> UpdateAccountingContactAsync(
		int? accountingContactId,
		ModelAccountingContactUpdate body = null
	);

}
