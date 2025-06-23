using Minicon.SevDesk.Client.Models;
using Refit;

namespace Minicon.SevDesk.Client.Api;

/// <summary>
///     Represents a collection of functions to interact with the API endpoints
/// </summary>
public interface IContactApi
{
	/// <summary>
	///     Check if a customer number is available
	/// </summary>
	/// <remarks>
	///     Checks if a given customer number is available or already used.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="customerNumber">The customer number to be checked. (optional)</param>
	/// <returns>Task of GetIsInvoicePartiallyPaidResponse</returns>
	[Get("/Contact/Mapper/checkCustomerNumberAvailability")]
	Task<GetIsInvoicePartiallyPaidResponse> ContactCustomerNumberAvailabilityCheckAsync(string customerNumber);

	/// <summary>
	///     Create a new contact
	/// </summary>
	/// <remarks>
	///     Creates a new contact.&lt;br&gt;       For adding addresses and communication ways, you will need to use the
	///     ContactAddress and CommunicationWay endpoints.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="body">Creation data (optional)</param>
	/// <returns>Task of CreateContactResponse</returns>
	[Post("/Contact")]
	Task<CreateContactResponse> CreateContactAsync(ModelContact body);

	/// <summary>
	///     Deletes a contact
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="contactId">Id of contact resource to delete</param>
	/// <returns>Task of InlineResponse2003</returns>
	[Delete("/Contact/{contactId}")]
	Task<DeleteResponse> DeleteContactAsync(int contactId);

	/// <summary>
	///     Find contact by ID
	/// </summary>
	/// <remarks>
	///     Returns a single contact
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="contactId">ID of contact to return</param>
	/// <param name="limit"></param>
	/// <param name="offset"></param>
	/// <returns>Task of GetContactResponse</returns>
	[Get("/Contact/{contactId}")]
	Task<GetContactResponse> GetContactByIdAsync(int? contactId, int limit = 10000, int offset = 0);

	/// <summary>
	///     Get number of all items
	/// </summary>
	/// <remarks>
	///     Get number of all invoices, orders, etc. of a specified contact
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="contactId">ID of contact to return</param>
	/// <returns>Task of InlineResponse20018</returns>
	[Get("/Contact/{contactId}/getTabsItemCount")]
	Task<GetContactTabsItemCountByIdResponse> GetContactTabsItemCountByIdAsync(int contactId);

	/// <summary>
	///     Retrieve contacts
	/// </summary>
	/// <remarks>
	///     There are a multitude of parameter which can be used to filter.&lt;br&gt;       A few of them are attached but
	///     for a complete list please check out &lt;a href&#x3D;&#x27;
	///     https://api.sevdesk.de/#section/How-to-filter-for-certain-contacts&#x27;&gt;this&lt;/a&gt; list
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="depth">
	///     Defines if both organizations &lt;b&gt;and&lt;/b&gt; persons should be returned.&lt;br&gt;
	///     &#x27;0&#x27; -&gt; only organizations, &#x27;1&#x27; -&gt; organizations and persons (optional)
	/// </param>
	/// <param name="customerNumber">Retrieve all contacts with this customer number (optional)</param>
	/// <param name="limit"></param>
	/// <param name="offset"></param>
	/// <param name="cancellationToken"></param>
	/// <returns>Task of GetContactResponse</returns>
	[Get("/Contact")]
	Task<GetContactResponse> GetContactsAsync(
		string? depth = null,
		string? customerNumber = null,
		int limit = 1000,
		int offset = 0,
		CancellationToken cancellationToken = default
	);

	/// <summary>
	///     Get next free customer number
	/// </summary>
	/// <remarks>
	///     Retrieves the next available customer number. Avoids duplicates.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <returns>Task of InlineResponse20035</returns>
	[Get("/Contact/Factory/getNextCustomerNumber")]
	Task<GetNextCustomerNumberResponse> GetNextCustomerNumberAsync(
		CancellationToken cancellationToken = default);

	/// <summary>
	///     Update a existing contact
	/// </summary>
	/// <remarks>
	///     Update a contact
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="contactId">ID of contact to update</param>
	/// <param name="body">Update data (optional)</param>
	/// <param name="cancellationToken"></param>
	/// <returns>Task of GetContactResponse</returns>
	[Put("/Contact/{contactId}")]
	Task<GetContactResponse> UpdateContactAsync(int contactId, ModelContactUpdate body,
		CancellationToken cancellationToken = default);

	/// <summary>
	///     Find contacts by custom field value
	/// </summary>
	/// <remarks>
	///     Returns an array of contacts having a certain custom field value set.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="value">The value to be checked.</param>
	/// <param name="customFieldSettingId">ID of ContactCustomFieldSetting for which the value has to be checked. (optional)</param>
	/// <param name="customFieldSettingObjectName">Object name of ContactCustomFieldSetting for which the value has to be checked. (optional)</param>
	/// <returns>Task of GetContactResponse</returns>
	[Get("/Contact/Factory/findContactsByCustomFieldValue")]
	Task<GetContactResponse> FindContactsByCustomFieldValueAsync(
		[AliasAs("value")] string value,
		[AliasAs("customFieldSetting[id]")] string? customFieldSettingId = null,
		[AliasAs("customFieldSetting[objectName]")] string? customFieldSettingObjectName = null,
		CancellationToken cancellationToken = default);
}
