using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Minicon.SevDesk.Client.Api;
using Minicon.SevDesk.Client.Models;

namespace Minicon.SevDesk.Client.Tests;

public class ReceiptGuidanceApiTests
{
	[Fact]
	public void ReceiptGuidanceApi_IsAvailable()
	{
		using var scope = new TestScope<IReceiptGuidanceApi>();
		scope.Test(
			() => scope.ServiceScope.ServiceProvider.GetRequiredService<IReceiptGuidanceApi>(),
			result => result.Should().NotBeNull()
		);
	}

	[Fact]
	public async Task GetAllAccountGuidesAsync_Returns_AccountGuides()
	{
		using var scope = new TestScope<ReceiptGuidanceResponse>();
		await scope.TestAsync(
			async () => await scope.ServiceScope.ServiceProvider.GetRequiredService<IReceiptGuidanceApi>()
				.GetAllAccountGuidesAsync(),
			result =>
			{
				result.Should().NotBeNull();
				result.Objects.Should().NotBeNull();
			}
		);
	}

	[Fact(Skip = "API endpoint returns 422 for account number queries in test environment")]
	public async Task GetGuidanceByAccountNumberAsync_WithValidAccountNumber_Returns_Guidance()
	{
		using var scope = new TestScope<ReceiptGuidanceResponse>();
		var api = scope.ServiceScope.ServiceProvider.GetRequiredService<IReceiptGuidanceApi>();
		
		// First get all guides to find a valid account number
		var allGuides = await api.GetAllAccountGuidesAsync();
		
		if (allGuides?.Objects?.Count > 0)
		{
			// Use the first available account number
			var firstAccountNumber = allGuides.Objects[0].AccountNumber;
			await scope.TestAsync(
				async () => await api.GetGuidanceByAccountNumberAsync(firstAccountNumber),
				result =>
				{
					result.Should().NotBeNull();
					result.Objects.Should().NotBeNull();
				}
			);
		}
	}

	[Fact]
	public async Task GetGuidanceByTaxRuleAsync_WithValidTaxRule_Returns_Guidance()
	{
		using var scope = new TestScope<ReceiptGuidanceResponse>();
		await scope.TestAsync(
			async () => await scope.ServiceScope.ServiceProvider.GetRequiredService<IReceiptGuidanceApi>()
				.GetGuidanceByTaxRuleAsync("USTPFL_UMS_EINN"),
			result =>
			{
				result.Should().NotBeNull();
				result.Objects.Should().NotBeNull();
			}
		);
	}

	[Fact]
	public async Task GetRevenueGuidanceAsync_Returns_RevenueGuidance()
	{
		using var scope = new TestScope<ReceiptGuidanceResponse>();
		await scope.TestAsync(
			async () => await scope.ServiceScope.ServiceProvider.GetRequiredService<IReceiptGuidanceApi>()
				.GetRevenueGuidanceAsync(),
			result =>
			{
				result.Should().NotBeNull();
				result.Objects.Should().NotBeNull();
			}
		);
	}

	[Fact]
	public async Task GetExpenseGuidanceAsync_Returns_ExpenseGuidance()
	{
		using var scope = new TestScope<ReceiptGuidanceResponse>();
		await scope.TestAsync(
			async () => await scope.ServiceScope.ServiceProvider.GetRequiredService<IReceiptGuidanceApi>()
				.GetExpenseGuidanceAsync(),
			result =>
			{
				result.Should().NotBeNull();
				result.Objects.Should().NotBeNull();
			}
		);
	}
}