using Minicon.SevDesk.Client.Models;
using Refit;

namespace Minicon.SevDesk.Client.Api;

/// <summary>
///     Represents a collection of functions to interact with the API endpoints
/// </summary>
public interface ICheckAccountApi
{
	/// <summary>
	///     Create a new check account
	/// </summary>
	/// <remarks>
	///     Creates a new banking account on which transactions can be created.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="body">
	///     Creation data. Please be aware, that you need to provide at least all required parameter
	///     of the CheckAccount model! (optional)
	/// </param>
	/// <param name="cancellationToken"></param>
	/// <returns>Task of InlineResponse20024</returns>
	[Post("/CheckAccount")]
	Task<GetCheckAccountResponse> CreateCheckAccountAsync(ModelCheckAccount body,
		CancellationToken cancellationToken = default);

	/// <summary>
	///     Deletes a check account
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="checkAccountId">Id of check account to delete</param>
	/// <param name="cancellationToken"></param>
	/// <returns>Task of InlineResponse2003</returns>
	[Delete("/CheckAccount/{checkAccountId}")]
	Task<DeleteResponse> DeleteCheckAccountAsync(int checkAccountId,
		CancellationToken cancellationToken = default);

	/// <summary>
	///     Get the balance at a given date
	/// </summary>
	/// <remarks>
	///     Get the balance, calculated as the sum of all transactions sevDesk knows, up to and including the given date. Note
	///     that this balance does not have to be the actual bank account balance, e.g. if sevDesk did not import old
	///     transactions.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="checkAccountId">ID of check account</param>
	/// <param name="date">Only consider transactions up to this date at 23:59:59</param>
	/// <param name="cancellationToken"></param>
	/// <returns>Task of GetBalanceAtDateResponse</returns>
	[Get("/CheckAccount/{checkAccountId}/balanceAtDate")]
	Task<GetBalanceAtDateResponse> GetBalanceAtDateAsync(int checkAccountId, DateTime date,
		CancellationToken cancellationToken = default);

	/// <summary>
	///     Find check account by ID
	/// </summary>
	/// <remarks>
	///     Retrieve an existing check account
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <returns>Task of InlineResponse20024</returns>
	[Get("/CheckAccount/")]
	Task<GetCheckAccountResponse> GetCheckAccountByIdAsync(
		int? checkAccountId = null,
		int limit = 10000,
		int offset = 0,
		bool countAll = true,
		CancellationToken cancellationToken = default
	);

	/// <summary>
	///     Update an existing check account
	/// </summary>
	/// <remarks>
	///     Update a check account
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="checkAccountId">ID of check account to update</param>
	/// <param name="body">Update data (optional)</param>
	/// <param name="cancellationToken"></param>
	/// <returns>Task of InlineResponse20024</returns>
	[Get("/CheckAccount/{checkAccountId}")]
	Task<GetCheckAccountResponse> UpdateCheckAccountAsync(int checkAccountId, ModelCheckAccountUpdate body,
		CancellationToken cancellationToken = default);
}
