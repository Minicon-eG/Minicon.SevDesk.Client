using Minicon.SevDesk.Client.Models;
using Refit;

namespace Minicon.SevDesk.Client.Api;

/// <summary>
///     Represents a collection of functions to interact with the API endpoints
/// </summary>
public interface ICheckAccountApi
{
	#region Synchronous Operations

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
	/// <returns>InlineResponse20024</returns>
	InlineResponse20024 CreateCheckAccount(ModelCheckAccount body = null);

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
	/// <returns>ApiResponse of InlineResponse20024</returns>
	ApiResponse<InlineResponse20024> CreateCheckAccountWithHttpInfo(ModelCheckAccount body = null);

	/// <summary>
	///     Deletes a check account
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="checkAccountId">Id of check account to delete</param>
	/// <returns>InlineResponse2003</returns>
	InlineResponse2003 DeleteCheckAccount(int? checkAccountId);

	/// <summary>
	///     Deletes a check account
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="checkAccountId">Id of check account to delete</param>
	/// <returns>ApiResponse of InlineResponse2003</returns>
	ApiResponse<InlineResponse2003> DeleteCheckAccountWithHttpInfo(int? checkAccountId);

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
	/// <returns>InlineResponse20036</returns>
	InlineResponse20036 GetBalanceAtDate(int? checkAccountId, DateTime? date);

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
	/// <returns>ApiResponse of InlineResponse20036</returns>
	ApiResponse<InlineResponse20036> GetBalanceAtDateWithHttpInfo(int? checkAccountId, DateTime? date);

	/// <summary>
	///     Find check account by ID
	/// </summary>
	/// <remarks>
	///     Retrieve an existing check account
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="checkAccountId">ID of check account</param>
	/// <returns>InlineResponse20024</returns>
	InlineResponse20024 GetCheckAccountById(int? checkAccountId);

	/// <summary>
	///     Find check account by ID
	/// </summary>
	/// <remarks>
	///     Retrieve an existing check account
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="checkAccountId">ID of check account</param>
	/// <returns>ApiResponse of InlineResponse20024</returns>
	ApiResponse<InlineResponse20024> GetCheckAccountByIdWithHttpInfo(int? checkAccountId);

	/// <summary>
	///     Retrieve check accounts
	/// </summary>
	/// <remarks>
	///     Retrieve all check accounts
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <returns>InlineResponse20024</returns>
	InlineResponse20024 GetCheckAccounts();

	/// <summary>
	///     Retrieve check accounts
	/// </summary>
	/// <remarks>
	///     Retrieve all check accounts
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <returns>ApiResponse of InlineResponse20024</returns>
	ApiResponse<InlineResponse20024> GetCheckAccountsWithHttpInfo();

	/// <summary>
	///     Update an existing check account
	/// </summary>
	/// <remarks>
	///     Update a check account
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="checkAccountId">ID of check account to update</param>
	/// <param name="body">Update data (optional)</param>
	/// <returns>InlineResponse20024</returns>
	InlineResponse20024 UpdateCheckAccount(int? checkAccountId, ModelCheckAccountUpdate body = null);

	/// <summary>
	///     Update an existing check account
	/// </summary>
	/// <remarks>
	///     Update a check account
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="checkAccountId">ID of check account to update</param>
	/// <param name="body">Update data (optional)</param>
	/// <returns>ApiResponse of InlineResponse20024</returns>
	ApiResponse<InlineResponse20024> UpdateCheckAccountWithHttpInfo(int? checkAccountId,
		ModelCheckAccountUpdate body = null);

	#endregion Synchronous Operations

	#region Asynchronous Operations

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
	/// <returns>Task of InlineResponse20024</returns>
	Task<InlineResponse20024> CreateCheckAccountAsync(ModelCheckAccount body = null);

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
	/// <returns>Task of ApiResponse (InlineResponse20024)</returns>
	Task<ApiResponse<InlineResponse20024>> CreateCheckAccountAsyncWithHttpInfo(ModelCheckAccount body = null);

	/// <summary>
	///     Deletes a check account
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="checkAccountId">Id of check account to delete</param>
	/// <returns>Task of InlineResponse2003</returns>
	Task<InlineResponse2003> DeleteCheckAccountAsync(int? checkAccountId);

	/// <summary>
	///     Deletes a check account
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="checkAccountId">Id of check account to delete</param>
	/// <returns>Task of ApiResponse (InlineResponse2003)</returns>
	Task<ApiResponse<InlineResponse2003>> DeleteCheckAccountAsyncWithHttpInfo(int? checkAccountId);

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
	/// <returns>Task of InlineResponse20036</returns>
	Task<InlineResponse20036> GetBalanceAtDateAsync(int? checkAccountId, DateTime? date);

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
	/// <returns>Task of ApiResponse (InlineResponse20036)</returns>
	Task<ApiResponse<InlineResponse20036>> GetBalanceAtDateAsyncWithHttpInfo(int? checkAccountId, DateTime? date);

	/// <summary>
	///     Find check account by ID
	/// </summary>
	/// <remarks>
	///     Retrieve an existing check account
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="checkAccountId">ID of check account</param>
	/// <returns>Task of InlineResponse20024</returns>
	Task<InlineResponse20024> GetCheckAccountByIdAsync(int? checkAccountId);

	/// <summary>
	///     Find check account by ID
	/// </summary>
	/// <remarks>
	///     Retrieve an existing check account
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="checkAccountId">ID of check account</param>
	/// <returns>Task of ApiResponse (InlineResponse20024)</returns>
	Task<ApiResponse<InlineResponse20024>> GetCheckAccountByIdAsyncWithHttpInfo(int? checkAccountId);

	/// <summary>
	///     Retrieve check accounts
	/// </summary>
	/// <remarks>
	///     Retrieve all check accounts
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <returns>Task of InlineResponse20024</returns>
	Task<InlineResponse20024> GetCheckAccountsAsync();

	/// <summary>
	///     Retrieve check accounts
	/// </summary>
	/// <remarks>
	///     Retrieve all check accounts
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <returns>Task of ApiResponse (InlineResponse20024)</returns>
	Task<ApiResponse<InlineResponse20024>> GetCheckAccountsAsyncWithHttpInfo();

	/// <summary>
	///     Update an existing check account
	/// </summary>
	/// <remarks>
	///     Update a check account
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="checkAccountId">ID of check account to update</param>
	/// <param name="body">Update data (optional)</param>
	/// <returns>Task of InlineResponse20024</returns>
	Task<InlineResponse20024> UpdateCheckAccountAsync(int? checkAccountId, ModelCheckAccountUpdate body = null);

	/// <summary>
	///     Update an existing check account
	/// </summary>
	/// <remarks>
	///     Update a check account
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="checkAccountId">ID of check account to update</param>
	/// <param name="body">Update data (optional)</param>
	/// <returns>Task of ApiResponse (InlineResponse20024)</returns>
	Task<ApiResponse<InlineResponse20024>> UpdateCheckAccountAsyncWithHttpInfo(int? checkAccountId,
		ModelCheckAccountUpdate body = null);

	#endregion Asynchronous Operations
}
