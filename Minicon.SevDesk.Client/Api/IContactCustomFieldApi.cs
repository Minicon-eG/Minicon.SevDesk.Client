using Minicon.SevDesk.Client.Models;
using Refit;

namespace Minicon.SevDesk.Client.Api;

/// <summary>
///     Represents a collection of functions to interact with the ContactCustomField API endpoints
/// </summary>
public interface IContactCustomFieldApi
{
	/// <summary>
	///     Retrieve contact fields
	/// </summary>
	/// <remarks>
	///     Retrieve all contact fields
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <returns>Task of GetContactFieldResponse</returns>
	[Get("/ContactCustomField")]
	Task<GetContactFieldResponse> GetContactFieldsAsync(CancellationToken cancellationToken = default);

	/// <summary>
	///     Retrieve contact fields
	/// </summary>
	/// <remarks>
	///     Retrieve all contact fields
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="contactCustomFieldId">id of the contact field</param>
	/// <returns>Task of GetContactFieldResponse</returns>
	[Get("/ContactCustomField/{contactCustomFieldId}")]
	Task<GetContactFieldResponse> GetContactFieldsByIdAsync(int contactCustomFieldId, CancellationToken cancellationToken = default);

	/// <summary>
	///     Create contact field
	/// </summary>
	/// <remarks>
	///     Create a new contact field
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="body">Contact field data</param>
	/// <returns>Task of ModelContactCustomFieldResponse</returns>
	[Post("/ContactCustomField")]
	Task<ModelContactCustomFieldResponse> CreateContactCustomFieldAsync(ModelContactCustomField body, CancellationToken cancellationToken = default);

	/// <summary>
	///     Update contact field
	/// </summary>
	/// <remarks>
	///     Update an existing contact field
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="contactCustomFieldId">ID of contact field to update</param>
	/// <param name="body">Update data</param>
	/// <returns>Task of ModelContactCustomFieldResponse</returns>
	[Put("/ContactCustomField/{contactCustomFieldId}")]
	Task<ModelContactCustomFieldResponse> UpdateContactCustomFieldAsync(int contactCustomFieldId, ModelContactCustomFieldUpdate body, CancellationToken cancellationToken = default);

	/// <summary>
	///     Delete contact field
	/// </summary>
	/// <remarks>
	///     Delete an existing contact field
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="contactCustomFieldId">ID of contact field to delete</param>
	/// <returns>Task of DeleteResponse</returns>
	[Delete("/ContactCustomField/{contactCustomFieldId}")]
	Task<DeleteResponse> DeleteContactCustomFieldAsync(int contactCustomFieldId, CancellationToken cancellationToken = default);
}