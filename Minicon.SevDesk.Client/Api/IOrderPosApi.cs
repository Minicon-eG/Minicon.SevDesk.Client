using Minicon.SevDesk.Client.Models;
using Refit;

namespace Minicon.SevDesk.Client.Api;

/// <summary>
///     Represents a collection of functions to interact with the API endpoints
/// </summary>
public interface IOrderPosApi
{
	/// <summary>
	///     Deletes an order Position
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="orderPosId">Id of order position resource to delete</param>
	/// <returns>Task of InlineResponse2003</returns>
	[Delete("/OrderPos/{orderPosId}")]
	Task<DeleteResponse> DeleteOrderPosAsync(int orderPosId);

	/// <summary>
	///     Find order position by ID
	/// </summary>
	/// <remarks>
	///     Returns a single order position
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="orderPosId">ID of order position to return</param>
	/// <returns>Task of GetOrderPositionsByIdResponse</returns>
	[Get("/OrderPos/{orderPosId}")]
	Task<GetOrderPositionsByIdResponse> GetOrderPositionByIdAsync(int orderPosId);

	/// <summary>
	///     Retrieve order positions
	/// </summary>
	/// <remarks>
	///     Retrieve all order positions depending on the filters defined in the query.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="orderId">
	///     Retrieve all order positions belonging to this order. Must be provided with voucher[objectName]
	///     (optional)
	/// </param>
	/// <param name="orderObjectName">
	///     Only required if order[id] was provided. &#x27;Order&#x27; should be used as value.
	///     (optional)
	/// </param>
	/// <param name="limit"></param>
	/// <param name="offset"></param>
	/// <param name="countAll"></param>
	/// <returns>Task of GetOrderPositionsByIdResponse</returns>
	[Get("/OrderPos")]
	Task<GetOrderPositionsByIdResponse> GetOrderPositionsAsync(
		int? orderId = null,
		string orderObjectName = "Order",
		int limit = 10000,
		int offset = 0,
		bool countAll = true
	);

	/// <summary>
	///     Update an existing order position
	/// </summary>
	/// <remarks>
	///     Update an order position
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="orderPosId">ID of order position to update</param>
	/// <param name="body">Update data (optional)</param>
	/// <returns>Task of GetOrderPositionsByIdResponse</returns>
	[Put("/OrderPos/{orderPosId}")]
	Task<GetOrderPositionsByIdResponse> UpdateOrderPositionAsync(int orderPosId, ModelOrderPosUpdate body);
}
