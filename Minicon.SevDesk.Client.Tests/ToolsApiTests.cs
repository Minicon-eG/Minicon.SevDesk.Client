using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Minicon.SevDesk.Client.Api;
using Minicon.SevDesk.Client.Models;

namespace Minicon.SevDesk.Client.Tests;

public class ToolsApiTests
{
	[Fact]
	public void ToolsApi_IsAvailable()
	{
		using var scope = new TestScope<IToolsApi>();
		scope.Test(
			() => scope.ServiceScope.ServiceProvider.GetRequiredService<IToolsApi>(),
			result => result.Should().NotBeNull()
		);
	}

	[Fact]
	public async Task GetBookkeepingSystemVersionAsync_Returns_Version()
	{
		using var scope = new TestScope<BookkeepingSystemVersionResponse>();
		await scope.TestAsync(
			async () => await scope.ServiceScope.ServiceProvider.GetRequiredService<IToolsApi>()
				.GetBookkeepingSystemVersionAsync(),
			result =>
			{
				result.Should().NotBeNull();
				result.Objects.Should().NotBeNull();
			}
		);
	}
}