using Minicon.SevDesk.Client.Models;
using Refit;

namespace Minicon.SevDesk.Client.Api;

/// <summary>
///     Represents a collection of functions to interact with the API endpoints
/// </summary>
public interface IOrderApi
{
	/// <summary>
	///     Create contract note from order
	/// </summary>
	/// <remarks>
	///     Create contract note from order
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="orderId">the id of the order</param>
	/// <param name="orderObjectName">Model name, which is &#x27;Order&#x27;</param>
	/// <param name="body">Create contract note (optional)</param>
	/// <returns>Task of GetOrderResponse</returns>
	[Post("/Order/Factory/createContractNoteFromOrder")]
	Task<GetOrderResponse> CreateContractNoteFromOrderAsync(
		int orderId,
		string orderObjectName,
		ModelCreatePackingListFromOrder body
	);

	/// <summary>
	///     Create a new order
	/// </summary>
	/// <remarks>
	///     Creates an order to which positions can be added later.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="body">
	///     Creation data. Please be aware, that you need to provide at least all required parameter
	///     of the order model! (optional)
	/// </param>
	/// <returns>Task of SaveOrderResponse</returns>
	[Post("/Order/Factory/saveOrder")]
	Task<SaveOrderResponse> CreateOrderAsync(SaveOrder body);

	/// <summary>
	///     Create packing list from order
	/// </summary>
	/// <remarks>
	///     Create packing list from order
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="orderId">the id of the order</param>
	/// <param name="orderObjectName">Model name, which is &#x27;Order&#x27;</param>
	/// <param name="body">Create packing list (optional)</param>
	/// <returns>Task of GetOrderResponse</returns>
	[Post("/Order/Factory/createPackingListFromOrder")]
	Task<GetOrderResponse> CreatePackingListFromOrderAsync(
		int orderId,
		string orderObjectName,
		ModelCreatePackingListFromOrder body
	);

	/// <summary>
	///     Deletes an order
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="orderId">Id of order resource to delete</param>
	/// <returns>Task of InlineResponse2003</returns>
	[Delete("/Order/{orderId}")]
	Task<DeleteResponse> DeleteOrderAsync(int orderId);

	/// <summary>
	///     Find order discounts
	/// </summary>
	/// <remarks>
	///     Returns all discounts of an order
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="orderId">ID of order to return the positions</param>
	/// <param name="limit">limits the number of entries returned (optional)</param>
	/// <param name="offset">set the index where the returned entries start (optional)</param>
	/// <param name="embed">
	///     Get some additional information. Embed can handle multiple values, they must be separated by comma.
	///     (optional)
	/// </param>
	/// <returns>Task of GetDiscountsResponse</returns>
	[Get("/Order/{orderId}/getDiscounts")]
	Task<GetDiscountsResponse> GetDiscountsAsync(
		int orderId,
		int limit = 100,
		int offset = 0,
		List<string>? embed = null
	);

	/// <summary>
	///     Find order by ID
	/// </summary>
	/// <remarks>
	///     Returns a single order
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="orderId">ID of order to return</param>
	/// <returns>Task of GetOrderResponse</returns>
	[Delete("/Order/{orderId}")]
	Task<GetOrderResponse> GetOrderByIdAsync(int orderId);

	/// <summary>
	///     Find order positions
	/// </summary>
	/// <remarks>
	///     Returns all positions of an order
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="orderId">ID of order to return the positions</param>
	/// <param name="limit">limits the number of entries returned (optional)</param>
	/// <param name="offset">set the index where the returned entries start (optional)</param>
	/// <param name="embed">
	///     Get some additional information. Embed can handle multiple values, they must be separated by comma.
	///     (optional)
	/// </param>
	/// <returns>Task of GetOrderPositionsByIdResponse</returns>
	[Get("/Order/{orderId}/getPositions")]
	Task<GetOrderPositionsByIdResponse> GetOrderPositionsByIdAsync(
		int orderId,
		int limit = 100,
		int offset = 0,
		List<string>? embed = null
	);

	/// <summary>
	///     Retrieve orders
	/// </summary>
	/// <remarks>
	///     There are a multitude of parameter which can be used to filter. A few of them are attached but      for a complete
	///     list please check out &lt;a href&#x3D;&#x27;https://api.sevdesk.de/#section/How-to-filter-for-certain-orders&#x27;
	///     &gt;this&lt;/a&gt; list
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="status">Status of the order (optional)</param>
	/// <param name="orderNumber">Retrieve all orders with this order number (optional)</param>
	/// <param name="startDate">Retrieve all orders with a date equal or higher (optional)</param>
	/// <param name="endDate">Retrieve all orders with a date equal or lower (optional)</param>
	/// <param name="contactId">Retrieve all orders with this contact. Must be provided with contact[objectName] (optional)</param>
	/// <param name="contactObjectName">
	///     Only required if contact[id] was provided. &#x27;Contact&#x27; should be used as value.
	///     (optional)
	/// </param>
	/// <param name="limit"></param>
	/// <param name="offset"></param>
	/// <param name="countAll"></param>
	/// <returns>Task of GetOrderResponse</returns>
	[Get("/Order")]
	Task<GetOrderResponse> GetOrdersAsync(
		int? status = null,
		string? orderNumber = null,
		int? startDate = null,
		int? endDate = null,
		int? contactId = null,
		string? contactObjectName = null,
		int limit = 10000,
		int offset = 0,
		bool countAll = true
	);

	/// <summary>
	///     Find related objects
	/// </summary>
	/// <remarks>
	///     Get related objects of a specified order
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="orderId">ID of order to return the positions</param>
	/// <param name="includeItself">Define if the related objects include the order itself (optional)</param>
	/// <param name="sortByType">Define if you want the related objects sorted by type (optional)</param>
	/// <param name="embed">
	///     Get some additional information. Embed can handle multiple values, they must be separated by comma.
	///     (optional)
	/// </param>
	/// <param name="limit"></param>
	/// <param name="offset"></param>
	/// <param name="countAll"></param>
	/// <returns>Task of GetRelatedObjectsResponse</returns>
	[Get("/Order/{orderId}/getRelatedObjects")]
	Task<GetRelatedObjectsResponse> GetRelatedObjectsAsync(int orderId,
		bool? includeItself = null,
		bool? sortByType = null,
		List<string>? embed = null,
		int limit = 10000,
		int offset = 0,
		bool countAll = true
	);

	/// <summary>
	///     Retrieve pdf document of an order
	/// </summary>
	/// <remarks>
	///     Retrieves the pdf document of an order with additional metadata and commit the order.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="orderId">ID of order from which you want the pdf</param>
	/// <param name="download">If u want to download the pdf of the order. (optional)</param>
	/// <param name="preventSendBy">Defines if u want to send the order. (optional)</param>
	/// <returns>Task of CreditNoteGetPdfResponse</returns>
	[Get("/Order/{orderId}/getPdf")]
	Task<Base64EncodedFileResponse> OrderGetPdfAsync(
		int orderId,
		bool? download = null,
		bool? preventSendBy = null
	);

	/// <summary>
	///     Mark order as sent
	/// </summary>
	/// <remarks>
	///     Marks an order as sent by a chosen send type.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="orderId">ID of order to mark as sent</param>
	/// <param name="body">Specify the send type (optional)</param>
	/// <returns>Task of OrderSendByResponse</returns>
	[Put("/Order/{orderId}/sendBy")]
	Task<OrderSendByResponse> OrderSendByAsync(int orderId, OrderIdSendByBody body);

	/// <summary>
	///     Send order via email
	/// </summary>
	/// <remarks>
	///     This endpoint sends the specified order to a customer via email.&lt;br&gt;      This will automatically mark the
	///     order as sent.&lt;br&gt;      Please note, that in production an order is not allowed to be changed after this
	///     happened!
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="orderId">ID of order to be sent via email</param>
	/// <param name="body">Mail data (optional)</param>
	/// <returns>Task of SendOrderViaEMailResponse</returns>
	[Get("/Order/{orderId}/sendViaEmail")]
	Task<SendOrderViaEMailResponse> SendOrderViaEMailAsync(int orderId, OrderIdSendViaEmailBody body);

	/// <summary>
	///     Update an existing order
	/// </summary>
	/// <remarks>
	///     Update an order
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="orderId">ID of order to update</param>
	/// <param name="body">Update data (optional)</param>
	/// <returns>Task of GetOrderResponse</returns>
	[Put("/Order/{orderId}")]
	Task<GetOrderResponse> UpdateOrderAsync(int orderId, ModelOrderUpdate body);
}
