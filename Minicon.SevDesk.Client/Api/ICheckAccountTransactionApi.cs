using Minicon.SevDesk.Client.Models;
using Refit;

namespace Minicon.SevDesk.Client.Api;

/// <summary>
///     Represents a collection of functions to interact with the API endpoints
/// </summary>
public interface ICheckAccountTransactionApi
{
	/// <summary>
	///     Create a new transaction
	/// </summary>
	/// <remarks>
	///     Creates a new transaction on a check account.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="body">
	///     Creation data. Please be aware, that you need to provide at least all required parameter
	///     of the CheckAccountTransaction model! (optional)
	/// </param>
	/// <returns>Task of GetTransactionResponse</returns>
	[Post("/CheckAccountTransaction")]
	Task<GetTransactionResponse> CreateTransactionAsync(ModelCheckAccountTransaction body);

	/// <summary>
	///     Deletes a check account transaction
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="checkAccountTransactionId">Id of check account transaction to delete</param>
	/// <returns>Task of DeleteResponse</returns>
	[Delete("/CheckAccountTransaction/{checkAccountTransactionId}")]
	Task<DeleteResponse> DeleteCheckAccountTransactionAsync(int checkAccountTransactionId);

	/// <summary>
	///     Find check account transaction by ID
	/// </summary>
	/// <remarks>
	///     Retrieve an existing check account transaction
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="checkAccountTransactionId">ID of check account transaction</param>
	/// <returns>Task of GetTransactionResponse</returns>
	[Post("/CheckAccountTransaction/{checkAccountTransactionId}")]
	Task<GetTransactionResponse> GetCheckAccountTransactionByIdAsync(int checkAccountTransactionId);

	/// <summary>
	///     Retrieve transactions
	/// </summary>
	/// <remarks>
	///     Retrieve all transactions depending on the filters defined in the query.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="checkAccountId">
	///     Retrieve all transactions on this check account. Must be provided with
	///     checkAccount[objectName] (optional)
	/// </param>
	/// <param name="checkAccountObjectName">
	///     Only required if checkAccount[id] was provided. &#x27;CheckAccount&#x27; should be
	///     used as value. (optional)
	/// </param>
	/// <param name="isBooked">Only retrieve booked transactions (optional)</param>
	/// <param name="paymtPurpose">Only retrieve transactions with this payment purpose (optional)</param>
	/// <param name="startDate">Only retrieve transactions from this date on (optional)</param>
	/// <param name="endDate">Only retrieve transactions up to this date (optional)</param>
	/// <param name="payeePayerName">Only retrieve transactions with this payee / payer (optional)</param>
	/// <param name="onlyCredit">Only retrieve credit transactions (optional)</param>
	/// <param name="onlyDebit">Only retrieve debit transactions (optional)</param>
	/// <param name="limit"></param>
	/// <param name="offset"></param>
	/// <param name="countAll"></param>
	/// <param name="cancellationToken"></param>
	/// <returns>Task of CheckAccountTransaction</returns>
	[Get("/CheckAccountTransaction")]
	Task<GetTransactionResponse> GetTransactionsAsync(
		int? checkAccountId = null,
		string? checkAccountObjectName = null,
		bool? isBooked = null,
		string? paymtPurpose = null,
		DateTime? startDate = null,
		DateTime? endDate = null,
		string? payeePayerName = null,
		bool? onlyCredit = null,
		bool? onlyDebit = null,
		int limit = 10000,
		int offset = 0,
		bool countAll = true,
		CancellationToken cancellationToken = default
	);

	/// <summary>
	///     Update an existing check account transaction
	/// </summary>
	/// <remarks>
	///     Update a check account transaction
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="checkAccountTransactionId">ID of check account to update transaction</param>
	/// <param name="body">Update data (optional)</param>
	/// <param name="cancellationToken"></param>
	/// <returns>Task of GetTransactionResponse</returns>
	[Put("/CheckAccountTransaction/{checkAccountTransactionId}")]
	Task<GetTransactionResponse> UpdateCheckAccountTransactionAsync(
		int checkAccountTransactionId,
		ModelCheckAccountTransactionUpdate body,
		CancellationToken cancellationToken = default
	);
}
