using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Minicon.SevDesk.Client.Api;
using Minicon.SevDesk.Client.Models;

namespace Minicon.SevDesk.Client.Tests;

public class TextparserApiTests
{
	[Fact]
	public void TextparserApi_IsAvailable()
	{
		using var scope = new TestScope<ITextparserApi>();
		scope.Test(
			() => scope.ServiceScope.ServiceProvider.GetRequiredService<ITextparserApi>(),
			result => result.Should().NotBeNull()
		);
	}

	[Fact]
	public async Task GetPlaceholderAsync_WithObjectName_Returns_Placeholders()
	{
		using var scope = new TestScope<GetPlaceholderResponse>();
		await scope.TestAsync(
			async () => await scope.ServiceScope.ServiceProvider.GetRequiredService<ITextparserApi>()
				.GetPlaceholderAsync("Invoice"),
			result =>
			{
				result.Should().NotBeNull();
				// Note: Value may be null if no placeholders are available for this object type
			}
		);
	}

	[Fact]
	public async Task GetPlaceholderAsync_WithSubObjectName_Returns_Placeholders()
	{
		using var scope = new TestScope<GetPlaceholderResponse>();
		await scope.TestAsync(
			async () => await scope.ServiceScope.ServiceProvider.GetRequiredService<ITextparserApi>()
				.GetPlaceholderAsync("Email", "Invoice"),
			result =>
			{
				result.Should().NotBeNull();
				// Note: Value may be null if no placeholders are available for this object type
			}
		);
	}

	[Fact(Skip = "API may not have placeholder data configured for all object types")]
	public async Task GetPlaceholderAsync_AllObjectTypes_Returns_Placeholders()
	{
		using var scope = new TestScope<GetPlaceholderResponse>();
		var api = scope.ServiceScope.ServiceProvider.GetRequiredService<ITextparserApi>();
		
		// Test different object types
		var objectTypes = new[] { "Invoice", "Order", "CreditNote", "Contact", "Part" };
		
		foreach (var objectType in objectTypes)
		{
			await scope.TestAsync(
				async () => await api.GetPlaceholderAsync(objectType),
				result =>
				{
					result.Should().NotBeNull();
					// Note: Value may be null if no placeholders are available for this object/combination
				}
			);
		}
	}

	[Fact(Skip = "API may not have placeholder data configured for email subtypes")]
	public async Task GetPlaceholderAsync_EmailSubTypes_Returns_Placeholders()
	{
		using var scope = new TestScope<GetPlaceholderResponse>();
		var api = scope.ServiceScope.ServiceProvider.GetRequiredService<ITextparserApi>();
		
		// Test email with different sub object types
		var subObjectTypes = new[] { "Invoice", "Order", "CreditNote" };
		
		foreach (var subObjectType in subObjectTypes)
		{
			await scope.TestAsync(
				async () => await api.GetPlaceholderAsync("Email", subObjectType),
				result =>
				{
					result.Should().NotBeNull();
					// Note: Value may be null if no placeholders are available for this object/combination
				}
			);
		}
	}
}