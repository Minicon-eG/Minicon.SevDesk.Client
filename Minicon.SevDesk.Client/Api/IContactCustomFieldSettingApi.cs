using Minicon.SevDesk.Client.Models;
using Refit;

namespace Minicon.SevDesk.Client.Api;

/// <summary>
///     Represents a collection of functions to interact with the ContactCustomFieldSetting API endpoints
/// </summary>
public interface IContactCustomFieldSettingApi
{
	/// <summary>
	///     Retrieve contact field settings
	/// </summary>
	/// <remarks>
	///     Retrieve all contact field settings
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <returns>Task of GetContactFieldSettingByIdResponse</returns>
	[Get("/ContactCustomFieldSetting")]
	Task<GetContactFieldSettingByIdResponse> GetContactFieldSettingsAsync(CancellationToken cancellationToken = default);

	/// <summary>
	///     Find contact field setting by ID
	/// </summary>
	/// <remarks>
	///     Returns a single contact field setting
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="contactCustomFieldSettingId">ID of contact field to return</param>
	/// <returns>Task of GetContactFieldSettingByIdResponse</returns>
	[Get("/ContactCustomFieldSetting/{contactCustomFieldSettingId}")]
	Task<GetContactFieldSettingByIdResponse> GetContactFieldSettingByIdAsync(int contactCustomFieldSettingId, CancellationToken cancellationToken = default);

	/// <summary>
	///     Create contact field setting
	/// </summary>
	/// <remarks>
	///     Create contact field setting
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="body">Contact field setting data</param>
	/// <returns>Task of ModelContactCustomFieldSettingResponse</returns>
	[Post("/ContactCustomFieldSetting")]
	Task<ModelContactCustomFieldSettingResponse> CreateContactFieldSettingAsync(ModelContactCustomFieldSetting body, CancellationToken cancellationToken = default);

	/// <summary>
	///     Update contact field setting
	/// </summary>
	/// <remarks>
	///     Update an existing contact field setting
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="contactCustomFieldSettingId">ID of contact field setting to update</param>
	/// <param name="body">Update data</param>
	/// <returns>Task of ModelContactCustomFieldSettingResponse</returns>
	[Put("/ContactCustomFieldSetting/{contactCustomFieldSettingId}")]
	Task<ModelContactCustomFieldSettingResponse> UpdateContactFieldSettingAsync(int contactCustomFieldSettingId, ModelContactCustomFieldSettingUpdate body, CancellationToken cancellationToken = default);

	/// <summary>
	///     Delete contact field setting
	/// </summary>
	/// <remarks>
	///     Delete an existing contact field setting
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="contactCustomFieldSettingId">ID of contact field setting to delete</param>
	/// <returns>Task of DeleteResponse</returns>
	[Delete("/ContactCustomFieldSetting/{contactCustomFieldSettingId}")]
	Task<DeleteResponse> DeleteContactFieldSettingAsync(int contactCustomFieldSettingId, CancellationToken cancellationToken = default);

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
	Task<GetReferenceCountResponse> GetReferenceCountAsync(int contactCustomFieldSettingId, CancellationToken cancellationToken = default);
}