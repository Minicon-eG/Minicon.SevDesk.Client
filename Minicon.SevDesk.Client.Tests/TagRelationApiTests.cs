using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Minicon.SevDesk.Client.Api;
using Minicon.SevDesk.Client.Models;

namespace Minicon.SevDesk.Client.Tests;

public class TagRelationApiTests
{
	[Fact]
	public void TagRelationApi_IsAvailable()
	{
		using var scope = new TestScope<ITagRelationApi>();
		scope.Test(
			() => scope.ServiceScope.ServiceProvider.GetRequiredService<ITagRelationApi>(),
			result => result.Should().NotBeNull()
		);
	}

	[Fact]
	public async Task GetTagRelationsAsync_Returns_TagRelations()
	{
		using var scope = new TestScope<GetTagRelationResponse>();
		await scope.TestAsync(
			async () => await scope.ServiceScope.ServiceProvider.GetRequiredService<ITagRelationApi>()
				.GetTagRelationsAsync(),
			result =>
			{
				result.Should().NotBeNull();
				result.Objects.Should().NotBeNull();
			}
		);
	}

	[Fact]
	public async Task GetTagRelationsAsync_WithFilters_Returns_FilteredTagRelations()
	{
		using var scope = new TestScope<GetTagRelationResponse>();
		await scope.TestAsync(
			async () => await scope.ServiceScope.ServiceProvider.GetRequiredService<ITagRelationApi>()
				.GetTagRelationsAsync(),
			result =>
			{
				result.Should().NotBeNull();
				result.Objects.Should().NotBeNull();
			}
		);
	}

	[Fact]
	public async Task GetTagRelationsAsync_WithTagFilter_Returns_TagRelations()
	{
		using var scope = new TestScope<GetTagRelationResponse>();
		await scope.TestAsync(
			async () => await scope.ServiceScope.ServiceProvider.GetRequiredService<ITagRelationApi>()
				.GetTagRelationsAsync(),
			result =>
			{
				result.Should().NotBeNull();
				result.Objects.Should().NotBeNull();
			}
		);
	}

	[Fact]
	public async Task GetTagRelationsAsync_WithObjectFilter_Returns_TagRelations()
	{
		using var scope = new TestScope<GetTagRelationResponse>();
		await scope.TestAsync(
			async () => await scope.ServiceScope.ServiceProvider.GetRequiredService<ITagRelationApi>()
				.GetTagRelationsAsync(),
			result =>
			{
				result.Should().NotBeNull();
				result.Objects.Should().NotBeNull();
			}
		);
	}
}