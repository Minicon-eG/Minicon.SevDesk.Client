using Minicon.SevDesk.Client.Models;
using Refit;

namespace Minicon.SevDesk.Client.Api;

/// <summary>
///     Represents a collection of functions to interact with the API endpoints
/// </summary>
public interface IContactFieldApi
{
	/// <summary>
	///     Create contact field
	/// </summary>
	/// <remarks>
	///     Create contact field
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="body"> (optional)</param>
	/// <returns>Task of InlineResponse20014</returns>
	[Post("/ContactCustomField")]
	Task<GetContactFieldResponse> CreateContactFieldAsync(ModelContactCustomField body);

	/// <summary>
	///     Create contact field setting
	/// </summary>
	/// <remarks>
	///     Create contact field setting
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="body"> (optional)</param>
	/// <returns>Task of InlineResponse2006</returns>
	[Post("/ContactCustomFieldSetting")]
	Task<GetContactFieldSettingByIdResponse> CreateContactFieldSettingAsync(ModelContactCustomFieldSetting body);

	/// <summary>
	///     delete a contact field
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="contactCustomFieldId">Id of contact field</param>
	/// <returns>Task of DeleteResponse</returns>
	[Delete("/ContactCustomField/{contactCustomFieldId}")]
	Task<DeleteResponse> DeleteContactCustomFieldIdAsync(int contactCustomFieldId);

	/// <summary>
	///     Deletes a contact field setting
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="contactCustomFieldSettingId">Id of contact field to delete</param>
	/// <returns>Task of InlineResponse2003</returns>
	[Delete("/ContactCustomFieldSetting/{contactCustomFieldSettingId}")]
	Task<DeleteResponse> DeleteContactFieldSettingAsync(int contactCustomFieldSettingId);

	/// <summary>
	///     Find contact field setting by ID
	/// </summary>
	/// <remarks>
	///     Returns a single contact field setting
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="contactCustomFieldSettingId">ID of contact field to return</param>
	/// <returns>Task of InlineResponse2006</returns>
	[Get("/ContactCustomFieldSetting/{contactCustomFieldSettingId}")]
	Task<GetContactFieldSettingByIdResponse> GetContactFieldSettingByIdAsync(int contactCustomFieldSettingId);

	/// <summary>
	///     Retrieve contact field settings
	/// </summary>
	/// <remarks>
	///     Retrieve all contact field settings
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <returns>Task of GetContactFieldSettingByIdResponse</returns>
	[Get("/ContactCustomFieldSetting")]
	Task<GetContactFieldSettingByIdResponse> GetContactFieldSettingsAsync();

	/// <summary>
	///     Retrieve contact fields
	/// </summary>
	/// <remarks>
	///     Retrieve all contact fields
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <returns>Task of CreateContactFieldResponse</returns>
	[Post("/ContactCustomField")]
	Task<GetContactFieldResponse> GetContactFieldsAsync();

	/// <summary>
	///     Retrieve contact fields
	/// </summary>
	/// <remarks>
	///     Retrieve all contact fields
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="contactCustomFieldId">id of the contact field</param>
	/// <returns>Task of CreateContactFieldResponse</returns>
	[Get("/ContactCustomField/{contactCustomFieldId}")]
	Task<GetContactFieldResponse> GetContactFieldsByIdAsync(int contactCustomFieldId);

	/// <summary>
	///     Retrieve Placeholders
	/// </summary>
	/// <remarks>
	///     Retrieve all Placeholders
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="objectName">Model name</param>
	/// <param name="subObjectName">Sub model name, required if you have \&quot;Email\&quot; at objectName (optional)</param>
	/// <returns>Task of GetPlaceholderResponse</returns>
	[Get("/Textparser/fetchDictionaryEntriesByType")]
	Task<GetPlaceholderResponse> GetPlaceholderAsync(string objectName, string? subObjectName = null);

	/// <summary>
	///     Receive count reference
	/// </summary>
	/// <remarks>
	///     Receive count reference
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="contactCustomFieldSettingId">ID of contact field you want to get the reference count</param>
	/// <returns>Task of GetReferenceCountResponse</returns>
	[Get("/ContactCustomFieldSetting/{contactCustomFieldSettingId}/getReferenceCount")]
	Task<GetReferenceCountResponse> GetReferenceCountAsync(int contactCustomFieldSettingId);

	/// <summary>
	///     Update contact field setting
	/// </summary>
	/// <remarks>
	///     Update an existing contact field  setting
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="contactCustomFieldSettingId">ID of contact field setting you want to update</param>
	/// <param name="body"> (optional)</param>
	/// <returns>Task of GetContactFieldSettingByIdResponse</returns>
	[Put("/ContactCustomFieldSetting/{contactCustomFieldSettingId}")]
	Task<GetContactFieldSettingByIdResponse> UpdateContactFieldSettingAsync(
		int contactCustomFieldSettingId,
		ModelContactCustomFieldSettingUpdate body
	);

	/// <summary>
	///     Update a contact field
	/// </summary>
	/// <remarks>
	///     Update a contact field
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="contactCustomFieldId">id of the contact field</param>
	/// <param name="body">Update data (optional)</param>
	/// <returns>Task of CreateContactFieldResponse</returns>
	[Put("/ContactCustomField/{contactCustomFieldId}")]
	Task<GetContactFieldResponse> UpdateContactfieldAsync(int contactCustomFieldId,
		ModelContactCustomFieldUpdate body
	);
}
