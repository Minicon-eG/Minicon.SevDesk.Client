using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Minicon.SevDesk.Client.Api;
using Minicon.SevDesk.Client.Models;

namespace Minicon.SevDesk.Client.Tests;

public class ContactCustomFieldSettingApiTests
{
	[Fact]
	public void ContactCustomFieldSettingApi_IsAvailable()
	{
		using var scope = new TestScope<IContactCustomFieldSettingApi>();
		scope.Test(
			() => scope.ServiceScope.ServiceProvider.GetRequiredService<IContactCustomFieldSettingApi>(),
			result => result.Should().NotBeNull()
		);
	}

	[Fact]
	public async Task GetContactCustomFieldSettingsAsync_Returns_ContactCustomFieldSettings()
	{
		using var scope = new TestScope<GetContactFieldSettingByIdResponse>();
		await scope.TestAsync(
			async () => await scope.ServiceScope.ServiceProvider.GetRequiredService<IContactCustomFieldSettingApi>()
				.GetContactFieldSettingsAsync(),
			result =>
			{
				result.Should().NotBeNull();
				result.Objects.Should().NotBeNull();
			}
		);
	}

	[Fact]
	public async Task GetContactCustomFieldSettingByIdAsync_WithValidId_Returns_ContactCustomFieldSetting()
	{
		using var scope = new TestScope<GetContactFieldSettingByIdResponse>();
		var api = scope.ServiceScope.ServiceProvider.GetRequiredService<IContactCustomFieldSettingApi>();
		
		// First get any contact custom field setting
		var settings = await api.GetContactFieldSettingsAsync();
		
		if (settings?.Objects?.Count > 0)
		{
			var firstSettingId = settings.Objects[0].Id;
			await scope.TestAsync(
				async () => await api.GetContactFieldSettingByIdAsync(int.Parse(firstSettingId)),
				result =>
				{
					result.Should().NotBeNull();
					result.Objects.Should().NotBeEmpty();
					result.Objects[0].Id.Should().Be(firstSettingId);
				}
			);
		}
	}

	[Fact]
	public async Task GetReferenceCountAsync_WithValidId_Returns_ReferenceCount()
	{
		using var scope = new TestScope<GetReferenceCountResponse>();
		var api = scope.ServiceScope.ServiceProvider.GetRequiredService<IContactCustomFieldSettingApi>();
		
		// First get any contact custom field setting
		var settings = await api.GetContactFieldSettingsAsync();
		
		if (settings?.Objects?.Count > 0)
		{
			var firstSettingId = int.Parse(settings.Objects[0].Id);
			await scope.TestAsync(
				async () => await api.GetReferenceCountAsync(firstSettingId),
				result =>
				{
					result.Should().NotBeNull();
					result.Objects.Should().NotBeNull();
				}
			);
		}
	}
}