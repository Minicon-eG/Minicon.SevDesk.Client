using Minicon.SevDesk.Client.Models;
using Refit;

namespace Minicon.SevDesk.Client.Api;

/// <summary>
///     Rules for automatically marking transactions as private.
///     Endpoint group introduced in sevDesk API spec 2.0.0.
/// </summary>
public interface IPrivateTransactionRuleApi
{
	/// <summary>
	///     List all existing rules for automated marking of private transactions.
	/// </summary>
	[Get("/PrivateTransactionRule")]
	Task<GetPrivateTransactionRuleResponse> ListPrivateTransactionRulesAsync(
		CancellationToken cancellationToken = default);

	/// <summary>
	///     Create a new rule for automated marking of private transactions.
	/// </summary>
	[Post("/PrivateTransactionRule")]
	Task<PrivateTransactionRuleResponse> CreatePrivateTransactionRuleAsync(
		CreatePrivateTransactionRule body,
		CancellationToken cancellationToken = default);

	/// <summary>
	///     Delete a rule by id.
	/// </summary>
	[Delete("/PrivateTransactionRule/{id}")]
	Task DeletePrivateTransactionRuleAsync(int id, CancellationToken cancellationToken = default);
}
