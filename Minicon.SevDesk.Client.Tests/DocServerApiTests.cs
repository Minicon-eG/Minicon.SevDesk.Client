using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Minicon.SevDesk.Client.Api;
using Minicon.SevDesk.Client.Models;

namespace Minicon.SevDesk.Client.Tests;

public class DocServerApiTests
{
	[Fact]
	public void DocServerApi_IsAvailable()
	{
		using var scope = new TestScope<IDocServerApi>();
		scope.Test(
			() => scope.ServiceScope.ServiceProvider.GetRequiredService<IDocServerApi>(),
			result => result.Should().NotBeNull()
		);
	}

	[Fact]
	public async Task GetLetterpapersWithThumbAsync_Returns_Letterpapers()
	{
		using var scope = new TestScope<GetLetterpapersWithThumbResponse>();
		await scope.TestAsync(
			async () => await scope.ServiceScope.ServiceProvider.GetRequiredService<IDocServerApi>()
				.GetLetterpapersWithThumbAsync(),
			result =>
			{
				result.Should().NotBeNull();
				// Note: Letterpapers may be null if no letterpapers are configured
			}
		);
	}

	[Fact]
	public async Task GetTemplatesWithThumbAsync_WithType_Returns_Templates()
	{
		using var scope = new TestScope<GetTemplatesResponse>();
		await scope.TestAsync(
			async () => await scope.ServiceScope.ServiceProvider.GetRequiredService<IDocServerApi>()
				.GetTemplatesAsync("Invoice"),
			result =>
			{
				result.Should().NotBeNull();
				// Note: Templates may be null if no templates are configured for this type
			}
		);
	}

	[Fact]
	public async Task GetTemplatesWithThumbAsync_AllTypes_Returns_Templates()
	{
		using var scope = new TestScope<GetTemplatesResponse>();
		var api = scope.ServiceScope.ServiceProvider.GetRequiredService<IDocServerApi>();
		
		// Test different template types
		var templateTypes = new[] { "Invoice", "Order", "CreditNote", "Voucher" };
		
		foreach (var type in templateTypes)
		{
			await scope.TestAsync(
				async () => await api.GetTemplatesAsync(type),
				result =>
				{
					result.Should().NotBeNull();
					// Note: Templates may be null if no templates are configured for this type
				}
			);
		}
	}
}