using Minicon.SevDesk.Client.Models;
using Refit;

namespace Minicon.SevDesk.Client.Api;

/// <summary>
///     Represents a collection of functions to interact with the API endpoints
/// </summary>
public interface IContactAddressApi
{
	/// <summary>
	///     Find contact address by ID
	/// </summary>
	/// <remarks>
	///     Returns a single contact address
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="contactAddressId">ID of contact address to return</param>
	/// <param name="cancellationToken"></param>
	/// <returns>Task of InlineResponse20013</returns>
	[Get("/ContactAddress/{contactAddressId}")]
	Task<GetContactAddressResponse> GetContactAddressIdAsync(int? contactAddressId,
		CancellationToken cancellationToken = default);

	/// <summary>
	///     Create a new contact address
	/// </summary>
	/// <remarks>
	///     Creates a new contact address.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="body">Creation data (optional)</param>
	/// <param name="cancellationToken"></param>
	/// <returns>Task of InlineResponse20013</returns>
	[Post("/ContactAddress")]
	Task<GetContactAddressResponse> CreateContactAddressAsync(ModelContactAddress body,
		CancellationToken cancellationToken = default);

	/// <summary>
	///     Deletes a contact address
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="contactAddressId">Id of contact address resource to delete</param>
	/// <param name="cancellationToken"></param>
	/// <returns>Task of InlineResponse2003</returns>
	[Delete("/ContactAddress/{contactAddressId}")]
	Task<DeleteResponse> DeleteContactAddressAsync(int contactAddressId, CancellationToken cancellationToken = default);

	/// <summary>
	///     Retrieve contact addresses
	/// </summary>
	/// <remarks>
	///     Retrieve all contact addresses
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <returns>Task of InlineResponse20013</returns>
	[Get("/ContactAddress")]
	Task<GetContactAddressResponse> GetContactAddressesAsync(CancellationToken cancellationToken = default);

	/// <summary>
	///     update a existing contact address
	/// </summary>
	/// <remarks>
	///     update a existing contact address.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="contactAddressId">ID of contact address to return</param>
	/// <param name="body">Creation data (optional)</param>
	/// <param name="cancellationToken"></param>
	/// <returns>Task of InlineResponse20013</returns>
	[Put("/ContactAddress/{contactAddressId}")]
	Task<GetContactAddressResponse> UpdateContactAddressAsync(
		int contactAddressId,
		ModelContactAddressUpdate body,
		CancellationToken cancellationToken = default
	);
}
