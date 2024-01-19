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
	Task<InlineResponse20014> CreateContactFieldAsync(ModelContactCustomField body = null);

	/// <summary>
	///     Create contact field setting
	/// </summary>
	/// <remarks>
	///     Create contact field setting
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="body"> (optional)</param>
	/// <returns>Task of InlineResponse2006</returns>
	Task<InlineResponse2006> CreateContactFieldSettingAsync(ModelContactCustomFieldSetting body = null);

	/// <summary>
	///     delete a contact field
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="contactCustomFieldId">Id of contact field</param>
	/// <returns>Task of InlineResponse2003</returns>
	Task<InlineResponse2003> DeleteContactCustomFieldIdAsync(int? contactCustomFieldId);

	/// <summary>
	///     Deletes a contact field setting
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="contactCustomFieldSettingId">Id of contact field to delete</param>
	/// <returns>Task of InlineResponse2003</returns>
	Task<InlineResponse2003> DeleteContactFieldSettingAsync(int? contactCustomFieldSettingId);

	/// <summary>
	///     Find contact field setting by ID
	/// </summary>
	/// <remarks>
	///     Returns a single contact field setting
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="contactCustomFieldSettingId">ID of contact field to return</param>
	/// <returns>Task of InlineResponse2006</returns>
	Task<InlineResponse2006> GetContactFieldSettingByIdAsync(int? contactCustomFieldSettingId);

	/// <summary>
	///     Retrieve contact field settings
	/// </summary>
	/// <remarks>
	///     Retrieve all contact field settings
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <returns>Task of InlineResponse2006</returns>
	Task<InlineResponse2006> GetContactFieldSettingsAsync();

	/// <summary>
	///     Retrieve contact fields
	/// </summary>
	/// <remarks>
	///     Retrieve all contact fields
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <returns>Task of InlineResponse20014</returns>
	Task<InlineResponse20014> GetContactFieldsAsync();

	/// <summary>
	///     Retrieve contact fields
	/// </summary>
	/// <remarks>
	///     Retrieve all contact fields
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="contactCustomFieldId">id of the contact field</param>
	/// <returns>Task of InlineResponse20014</returns>
	Task<InlineResponse20014> GetContactFieldsByIdAsync(decimal? contactCustomFieldId);

	/// <summary>
	///     Retrieve Placeholders
	/// </summary>
	/// <remarks>
	///     Retrieve all Placeholders
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="objectName">Model name</param>
	/// <param name="subObjectName">Sub model name, required if you have \&quot;Email\&quot; at objectName (optional)</param>
	/// <returns>Task of InlineResponse20028</returns>
	Task<InlineResponse20028> GetPlaceholderAsync(string objectName, string subObjectName = null);

	/// <summary>
	///     Receive count reference
	/// </summary>
	/// <remarks>
	///     Receive count reference
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="contactCustomFieldSettingId">ID of contact field you want to get the reference count</param>
	/// <returns>Task of InlineResponse20034</returns>
	Task<InlineResponse20034> GetReferenceCountAsync(int? contactCustomFieldSettingId);

	/// <summary>
	///     Update contact field setting
	/// </summary>
	/// <remarks>
	///     Update an existing contact field  setting
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="contactCustomFieldSettingId">ID of contact field setting you want to update</param>
	/// <param name="body"> (optional)</param>
	/// <returns>Task of InlineResponse2006</returns>
	Task<InlineResponse2006> UpdateContactFieldSettingAsync(int? contactCustomFieldSettingId,
		ModelContactCustomFieldSettingUpdate body = null);

	/// <summary>
	///     Update a contact field
	/// </summary>
	/// <remarks>
	///     Update a contact field
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="contactCustomFieldId">id of the contact field</param>
	/// <param name="body">Update data (optional)</param>
	/// <returns>Task of InlineResponse20014</returns>
	Task<InlineResponse20014> UpdateContactfieldAsync(decimal? contactCustomFieldId,
		ModelContactCustomFieldUpdate body = null);
}
