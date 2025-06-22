using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Minicon.SevDesk.Client.Api;
using Minicon.SevDesk.Client.Models;

namespace Minicon.SevDesk.Client.Tests;

public class CheckAccountApiTests
{
	[Fact]
	public void CheckAccountApi_IsAvailable()
	{
		using var scope = new TestScope<ICheckAccountApi>();
		scope.Test(
			() => scope.ServiceScope.ServiceProvider.GetRequiredService<ICheckAccountApi>(),
			result => result.Should().NotBeNull()
		);
	}

	[Fact]
	public async Task GetCheckAccountsAsync_Returns_CheckAccounts()
	{
		using var scope = new TestScope<GetCheckAccountResponse>();
		await scope.TestAsync(
			async () => await scope.ServiceScope.ServiceProvider.GetRequiredService<ICheckAccountApi>()
				.GetCheckAccountsAsync(),
			result =>
			{
				result.Should().NotBeNull();
				result.Objects.Should().NotBeNull();
			}
		);
	}

	[Fact]
	public async Task GetCheckAccountByIdAsync_WithValidId_Returns_CheckAccount()
	{
		using var scope = new TestScope<GetCheckAccountResponse>();
		var api = scope.ServiceScope.ServiceProvider.GetRequiredService<ICheckAccountApi>();
		
		// First get any check account
		var accounts = await api.GetCheckAccountsAsync(limit: 1);
		
		if (accounts?.Objects?.Count > 0)
		{
			var firstAccountId = accounts.Objects[0].Id;
			await scope.TestAsync(
				async () => await api.GetCheckAccountByIdAsync(int.Parse(firstAccountId)),
				result =>
				{
					result.Should().NotBeNull();
					result.Objects.Should().NotBeEmpty();
					result.Objects[0].Id.Should().Be(firstAccountId);
				}
			);
		}
	}

	[Fact]
	public async Task GetBalanceAtDateAsync_WithValidIdAndDate_Returns_Balance()
	{
		using var scope = new TestScope<GetBalanceAtDateResponse>();
		var api = scope.ServiceScope.ServiceProvider.GetRequiredService<ICheckAccountApi>();
		
		// First get any check account
		var accounts = await api.GetCheckAccountsAsync(limit: 1);
		
		if (accounts?.Objects?.Count > 0)
		{
			var firstAccountId = int.Parse(accounts.Objects[0].Id);
			await scope.TestAsync(
				async () => await api.GetBalanceAtDateAsync(firstAccountId, DateTime.Now),
				result =>
				{
					result.Should().NotBeNull();
					result.Objects.Should().NotBeNull();
				}
			);
		}
	}
}