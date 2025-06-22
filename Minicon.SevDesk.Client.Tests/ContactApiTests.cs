using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Minicon.SevDesk.Client.Api;
using Minicon.SevDesk.Client.Models;
using Refit;

namespace Minicon.SevDesk.Client.Tests;

public class ContactApiTests
{
	[Fact]
	public void Configuration_IsNotEmpty()
	{
		using var scope = new TestScope<IOptions<SevDeskOptions>>();
		scope.Test(
			() => scope.ServiceScope.ServiceProvider.GetRequiredService<IOptions<SevDeskOptions>>(),
			result =>
			{
				result.Value.ApiKey.Should().NotBeNullOrWhiteSpace();
				result.Value.ApiUrl.Should().NotBeNullOrWhiteSpace();
			}
		);
	}

	[Fact]
	public void ContactApi_IsAvailable()
	{
		using var scope = new TestScope<IContactApi>();
		scope.Test(
			() => scope.ServiceScope.ServiceProvider.GetRequiredService<IContactApi>(),
			result => result.Should().NotBeNull()
		);
	}

	[Fact]
	public async Task GetContactsAsync_Returns_Contacts()
	{
		using var scope = new TestScope<GetContactResponse>();
		await scope.TestAsync(
			async () => await scope.ServiceScope.ServiceProvider.GetRequiredService<IContactApi>().GetContactsAsync(),
			result => result.Objects.Count.Should().BePositive()
		);
	}

	[Fact]
	public async Task GetContactByIdAsync_WithValidId_Returns_Contact()
	{
		using var scope = new TestScope<GetContactResponse>();
		var api = scope.ServiceScope.ServiceProvider.GetRequiredService<IContactApi>();
		
		// First get any contact
		var contacts = await api.GetContactsAsync(limit: 1);
		
		if (contacts?.Objects?.Count > 0)
		{
			var firstContactId = contacts.Objects[0].Id;
			await scope.TestAsync(
				async () => await api.GetContactByIdAsync(int.Parse(firstContactId)),
				result =>
				{
					result.Should().NotBeNull();
					result.Objects.Should().NotBeEmpty();
					result.Objects[0].Id.Should().Be(firstContactId);
				}
			);
		}
	}

	[Fact]
	public async Task GetNextCustomerNumberAsync_Returns_NextNumber()
	{
		using var scope = new TestScope<GetNextCustomerNumberResponse>();
		await scope.TestAsync(
			async () => await scope.ServiceScope.ServiceProvider.GetRequiredService<IContactApi>()
				.GetNextCustomerNumberAsync(),
			result =>
			{
				result.Should().NotBeNull();
				result.Objects.Should().NotBeNullOrEmpty();
			}
		);
	}

	[Fact]
	public async Task ContactCustomerNumberAvailabilityCheckAsync_WithNumber_Returns_Availability()
	{
		using var scope = new TestScope<GetIsInvoicePartiallyPaidResponse>();
		await scope.TestAsync(
			async () => await scope.ServiceScope.ServiceProvider.GetRequiredService<IContactApi>()
				.ContactCustomerNumberAvailabilityCheckAsync("TEST-99999"),
			result =>
			{
				result.Should().NotBeNull();
			}
		);
	}

	[Fact]
	public async Task GetContactTabsItemCountByIdAsync_WithValidId_Returns_TabCounts()
	{
		using var scope = new TestScope<GetContactTabsItemCountByIdResponse>();
		var api = scope.ServiceScope.ServiceProvider.GetRequiredService<IContactApi>();
		
		// First get any contact
		var contacts = await api.GetContactsAsync(limit: 1);
		
		if (contacts?.Objects?.Count > 0)
		{
			var firstContactId = int.Parse(contacts.Objects[0].Id);
			await scope.TestAsync(
				async () => await api.GetContactTabsItemCountByIdAsync(firstContactId),
				result =>
				{
					result.Should().NotBeNull();
				}
			);
		}
	}

	[Fact(Skip = "Requires custom fields to be configured in SevDesk")]
	public async Task FindContactsByCustomFieldValueAsync_WithValue_Returns_Contacts()
	{
		using var scope = new TestScope<GetContactResponse>();
		await scope.TestAsync(
			async () => await scope.ServiceScope.ServiceProvider.GetRequiredService<IContactApi>()
				.FindContactsByCustomFieldValueAsync("test"),
			result =>
			{
				result.Should().NotBeNull();
				result.Objects.Should().NotBeNull();
			}
		);
	}

	[Fact(Skip = "Requires custom fields to be configured in SevDesk")]
	public async Task FindContactsByCustomFieldValueAsync_WithCustomFieldSetting_Returns_Contacts()
	{
		using var scope = new TestScope<GetContactResponse>();
		var api = scope.ServiceScope.ServiceProvider.GetRequiredService<IContactApi>();
		
		// First check if custom field settings exist
		var customFieldApi = scope.ServiceScope.ServiceProvider.GetRequiredService<IContactCustomFieldApi>();
		var customFields = await customFieldApi.GetContactFieldsAsync();
		if (customFields?.Objects?.Count > 0)
		{
			var firstFieldId = customFields.Objects[0].ContactCustomFieldSetting.Id;
			await scope.TestAsync(
				async () => await api.FindContactsByCustomFieldValueAsync(
					"test",
					customFieldSettingId: firstFieldId,
					customFieldSettingObjectName: "ContactCustomFieldSetting"
				),
				result =>
				{
					result.Should().NotBeNull();
					result.Objects.Should().NotBeNull();
				}
			);
		}
	}
}
