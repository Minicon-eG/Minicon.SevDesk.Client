using Minicon.SevDesk.Client.Models;
using Refit;

namespace Minicon.SevDesk.Client.Api;

/// <summary>
///     Represents a collection of functions to interact with the API endpoints
/// </summary>
public interface ICommunicationWayApi
{
	/// <summary>
	///     Create a new contact communication way
	/// </summary>
	/// <remarks>
	///     Creates a new contact communication way.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="body">Creation data (optional)</param>
	/// <returns>Task of InlineResponse20025</returns>
	[Post("/CommunicationWay")]
	Task<GetCommunicationWaysResponse> CreateCommunicationWayAsync(ModelCommunicationWay body);

	/// <summary>
	///     Deletes a communication way
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="communicationWayId">Id of communication way resource to delete</param>
	/// <returns>Task of InlineResponse2003</returns>
	[Delete("/CommunicationWay/{communicationWayId}")]
	Task<DeleteResponse> DeleteCommunicationWayAsync(int communicationWayId);

	/// <summary>
	///     Find communication way by ID
	/// </summary>
	/// <remarks>
	///     Returns a single communication way
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="communicationWayId">ID of communication way to return</param>
	/// <returns>Task of InlineResponse20025</returns>
	[Get("/CommunicationWay/{communicationWayId}")]
	Task<GetCommunicationWaysResponse> GetCommunicationWayByIdAsync(int communicationWayId);

	/// <summary>
	///     Retrieve communication way keys
	/// </summary>
	/// <remarks>
	///     Returns all communication way keys.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <returns>Task of InlineResponse20016</returns>
	[Get("/CommunicationWayKey")]
	Task<GetCommunicationWayKeysResponse> GetCommunicationWayKeysAsync();

	/// <summary>
	///     Retrieve communication ways
	/// </summary>
	/// <remarks>
	///     Returns all communication ways which have been added up until now. Filters can be added.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="contactId">ID of contact for which you want the communication ways. (optional)</param>
	/// <param name="contactObjectName">Object name. Only needed if you also defined the ID of a contact. (optional)</param>
	/// <param name="type">Type of the communication ways you want to get. (optional)</param>
	/// <param name="main">Define if you only want the main communication way. (optional)</param>
	/// <returns>Task of InlineResponse20025</returns>
	[Get("/CommunicationWay")]
	Task<GetCommunicationWaysResponse> GetCommunicationWaysAsync(
		string? contactId = null,
		string? contactObjectName = null,
		string? type = null,
		string? main = null
	);

	/// <summary>
	///     Update a existing communication way
	/// </summary>
	/// <remarks>
	///     Update a communication way
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="communicationWayId">ID of CommunicationWay to update</param>
	/// <param name="body">Update data (optional)</param>
	/// <returns>Task of InlineResponse20025</returns>
	[Put("/CommunicationWay/{communicationWayId}")]
	Task<GetCommunicationWaysResponse> UpdateCommunicationWayAsync(
		int communicationWayId,
		ModelCommunicationWayUpdate body
	);
}
