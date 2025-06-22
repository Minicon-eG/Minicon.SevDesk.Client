using Minicon.SevDesk.Client.Models;
using Refit;

namespace Minicon.SevDesk.Client.Api;

/// <summary>
///     Represents a collection of functions to interact with the ReceiptGuidance API endpoints
/// </summary>
public interface IReceiptGuidanceApi
{
	/// <summary>
	///     Get all account guides
	/// </summary>
	/// <remarks>
	///     You can use this endpoint to help you decide which accounts you can use when creating a voucher
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <returns>Task of ReceiptGuidanceResponse</returns>
	[Get("/ReceiptGuidance/forAllAccounts")]
	Task<ReceiptGuidanceResponse> GetAllAccountGuidesAsync(CancellationToken cancellationToken = default);

	/// <summary>
	///     Get guidance by account number
	/// </summary>
	/// <remarks>
	///     You can use this endpoint to get additional information about the account that you may want to use.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="accountNumber">The datev account number you want to get additional information of</param>
	/// <returns>Task of ReceiptGuidanceResponse</returns>
	[Get("/ReceiptGuidance/forAccountNumber")]
	Task<ReceiptGuidanceResponse> GetGuidanceByAccountNumberAsync(
		[AliasAs("accountNumber")] int accountNumber,
		CancellationToken cancellationToken = default);

	/// <summary>
	///     Get guidance by Tax Rule
	/// </summary>
	/// <remarks>
	///     You can use this endpoint to get additional information about the tax rule (for example, USTPFL_UMS_EINN) that you may want to use.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <param name="taxRule">The code of the tax rule you want to get guidance for.</param>
	/// <returns>Task of ReceiptGuidanceResponse</returns>
	[Get("/ReceiptGuidance/forTaxRule")]
	Task<ReceiptGuidanceResponse> GetGuidanceByTaxRuleAsync(
		[AliasAs("taxRule")] string taxRule,
		CancellationToken cancellationToken = default);

	/// <summary>
	///     Get guidance for revenue accounts
	/// </summary>
	/// <remarks>
	///     Provides all possible combinations for revenue accounts to be used with revenue receipts/vouchers.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <returns>Task of ReceiptGuidanceResponse</returns>
	[Get("/ReceiptGuidance/forRevenue")]
	Task<ReceiptGuidanceResponse> GetRevenueGuidanceAsync(CancellationToken cancellationToken = default);

	/// <summary>
	///     Get guidance for expense accounts
	/// </summary>
	/// <remarks>
	///     Provides all possible combinations for expense accounts to be used with expense receipts/vouchers.
	/// </remarks>
	/// <exception cref="ApiException">Thrown when fails to make API call</exception>
	/// <returns>Task of ReceiptGuidanceResponse</returns>
	[Get("/ReceiptGuidance/forExpense")]
	Task<ReceiptGuidanceResponse> GetExpenseGuidanceAsync(CancellationToken cancellationToken = default);
}