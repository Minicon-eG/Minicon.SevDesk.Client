using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Minicon.SevDesk.Client.Api;
using Minicon.SevDesk.Client.Models;

namespace Minicon.SevDesk.Client.Tests;

public class ContactCustomFieldApiTests
{
	[Fact]
	public void ContactCustomFieldApi_IsAvailable()
	{
		using var scope = new TestScope<IContactCustomFieldApi>();
		scope.Test(
			() => scope.ServiceScope.ServiceProvider.GetRequiredService<IContactCustomFieldApi>(),
			result => result.Should().NotBeNull()
		);
	}

	[Fact]
	public async Task GetContactCustomFieldsAsync_Returns_ContactCustomFields()
	{
		using var scope = new TestScope<GetContactFieldResponse>();
		await scope.TestAsync(
			async () => await scope.ServiceScope.ServiceProvider.GetRequiredService<IContactCustomFieldApi>()
				.GetContactFieldsAsync(),
			result =>
			{
				result.Should().NotBeNull();
				result.Objects.Should().NotBeNull();
			}
		);
	}

	[Fact]
	public async Task GetContactCustomFieldByIdAsync_WithValidId_Returns_ContactCustomField()
	{
		using var scope = new TestScope<GetContactFieldResponse>();
		var api = scope.ServiceScope.ServiceProvider.GetRequiredService<IContactCustomFieldApi>();
		
		// First get any contact custom field
		var fields = await api.GetContactFieldsAsync();
		
		if (fields?.Objects?.Count > 0)
		{
			var firstFieldId = fields.Objects[0].Id;
			await scope.TestAsync(
				async () => await api.GetContactFieldsByIdAsync(int.Parse(firstFieldId)),
				result =>
				{
					result.Should().NotBeNull();
					result.Objects.Should().NotBeEmpty();
					result.Objects[0].Id.Should().Be(firstFieldId);
				}
			);
		}
	}
}