using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Minicon.SevDesk.Client.Api;
using Minicon.SevDesk.Client.Models;

namespace Minicon.SevDesk.Client.Tests;

public class AccountingContactApiTests
{
	[Fact]
	public void AccountingContactApi_IsAvailable()
	{
		using var scope = new TestScope<IAccountingContactApi>();
		scope.Test(
			() => scope.ServiceScope.ServiceProvider.GetRequiredService<IAccountingContactApi>(),
			result => result.Should().NotBeNull()
		);
	}

	[Fact]
	public async Task GetAccountingContactAsync_Returns_AccountingContacts()
	{
		using var scope = new TestScope<GetAccountContactResponse>();
		await scope.TestAsync(
			async () => await scope.ServiceScope.ServiceProvider.GetRequiredService<IAccountingContactApi>()
				.GetAccountingContactAsync(),
			result => result.Should().NotBeNull()
		);
	}

	[Fact]
	public async Task GetAccountingContactAsync_WithContactFilter_Returns_FilteredContacts()
	{
		using var scope = new TestScope<GetAccountContactResponse>();
		// Note: This test assumes there's at least one contact in the system
		// In a real scenario, you might want to create a contact first
		var contacts = await scope.ServiceScope.ServiceProvider.GetRequiredService<IAccountingContactApi>()
			.GetAccountingContactAsync();
		var item = contacts.Objects.First();
		
		await scope.TestAsync(
			async () => await scope.ServiceScope.ServiceProvider.GetRequiredService<IAccountingContactApi>()
				.GetAccountingContactAsync(contactId: item.Id, contactObjectName: "Contact"),
			result => result.Should().NotBeNull()
		);
	}

	[Fact]
	public async Task GetAccountingContactByIdAsync_WithValidId_Returns_AccountingContact()
	{
		using var scope = new TestScope<GetAccountContactResponse>();
		// First get any accounting contact
		var api = scope.ServiceScope.ServiceProvider.GetRequiredService<IAccountingContactApi>();
		var contacts = await api.GetAccountingContactAsync(limit: 1);
		
		if (contacts?.Objects?.Count > 0)
		{
			var firstContactId = contacts.Objects[0].Id;
			await scope.TestAsync(
				async () => await api.GetAccountingContactByIdAsync(int.Parse(firstContactId)),
				result =>
				{
					result.Should().NotBeNull();
					result.Objects.Should().NotBeEmpty();
					result.Objects[0].Id.Should().Be(firstContactId);
				}
			);
		}
	}
}