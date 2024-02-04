using Minicon.SevDesk.Client.Models;
using Refit;

namespace Minicon.SevDesk.Client.Api;

/// <summary>
///     Represents a collection of functions to interact with the API endpoints
/// </summary>
public interface IPartApi
{
	/// <summary>
	///     Create a new part
	/// </summary>
	/// <remarks>
	///     Creates a part in your sevDesk inventory.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="body">
	///     Creation data. Please be aware, that you need to provide at least all required parameter
	///     of the part model! (optional)
	/// </param>
	/// <returns>Task of GetPartResponse</returns>
	[Post("/Part")]
	Task<GetPartResponse> CreatePartAsync(ModelPart body);

	/// <summary>
	///     Find part by ID
	/// </summary>
	/// <remarks>
	///     Returns a single part
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="partId">ID of part to return</param>
	/// <returns>Task of GetPartResponse</returns>
	[Get("/Part/{partId}")]
	Task<GetPartResponse> GetPartByIdAsync(int partId);

	/// <summary>
	///     Retrieve parts
	/// </summary>
	/// <remarks>
	///     Retrieve all parts in your sevDesk inventory according to the applied filters.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="partNumber">Retrieve all parts with this part number (optional)</param>
	/// <param name="name">Retrieve all parts with this name (optional)</param>
	/// <param name="limit"></param>
	/// <param name="offset"></param>
	/// <param name="countAll"></param>
	/// <returns>Task of GetPartResponse</returns>
	[Get("/Part")]
	Task<GetPartResponse> GetPartsAsync(
		string? partNumber = null,
		string? name = null,
		int limit = 10000,
		int offset = 0,
		bool countAll = true
	);

	/// <summary>
	///     Get stock of a part
	/// </summary>
	/// <remarks>
	///     Returns the current stock amount of the given part.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="partId">ID of part for which you want the current stock.</param>
	/// <returns>Task of PartGetStockResponse</returns>
	[Get("/Part/{partId}/getStock")]
	Task<PartGetStockResponse> PartGetStockAsync(int? partId);

	/// <summary>
	///     Update an existing part
	/// </summary>
	/// <remarks>
	///     Update a part
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="partId">ID of part to update</param>
	/// <param name="body">Update data (optional)</param>
	/// <returns>Task of GetPartResponse</returns>
	[Put("/Part/{partId}")]
	Task<GetPartResponse> UpdatePartAsync(int partId, ModelPartUpdate body);
}
