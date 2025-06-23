using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Minicon.SevDesk.Client.Api;
using Minicon.SevDesk.Client.Models;

namespace Minicon.SevDesk.Client.Tests;

public class SevUserApiTests
{
	[Fact]
	public async Task GetCurrentUserAsync_ReturnsCurrentUserInfo()
	{
		using var scope = new TestScope<GetSevUserResponse>();
		ISevUserApi sut = scope.ServiceScope.ServiceProvider.GetRequiredService<ISevUserApi>();

		await scope.TestAsync(
			async () => await sut.GetCurrentUserAsync(),
			result =>
			{
				result.Should().NotBeNull();
				result.Objects.Should().NotBeNull();
				result.Objects.Should().NotBeEmpty();
				
				var user = result.Objects.First();
				user.Id.Should().NotBeNullOrEmpty();
				user.ObjectName.Should().Be("SevUser");
				user.Username.Should().NotBeNullOrEmpty();
				user.Email.Should().NotBeNullOrEmpty();
				user.SevClient.Should().NotBeNull();
				user.SevClient.Id.Should().NotBeNull().And.BeGreaterThan(0);
			}
		);
	}

	[Fact]
	public async Task GetCurrentUserAsync_CanExtractUserIdForCreateUser()
	{
		using var scope = new TestScope<GetSevUserResponse>();
		ISevUserApi sut = scope.ServiceScope.ServiceProvider.GetRequiredService<ISevUserApi>();

		await scope.TestAsync(
			async () => await sut.GetCurrentUserAsync(),
			result =>
			{
				result.Should().NotBeNull();
				result.Objects.Should().NotBeEmpty();
				
				var user = result.Objects.First();
				
				// Verify we can create a ModelVoucherCreateUser from the response
				var createUser = new ModelVoucherCreateUser(
					id: int.Parse(user.Id),
					objectName: "SevUser"
				);
				
				createUser.Should().NotBeNull();
				createUser.Id.Should().BeGreaterThan(0);
				createUser.ObjectName.Should().Be("SevUser");
			}
		);
	}

	[Fact]
	public async Task CreateSevUserApi_WithFactory_ReturnsWorkingClient()
	{
		using var scope = new TestScope<GetSevUserResponse>();
		var factory = scope.ServiceScope.ServiceProvider.GetRequiredService<ISevDeskClientFactory>();
		var options = scope.ServiceScope.ServiceProvider.GetRequiredService<Microsoft.Extensions.Options.IOptions<SevDeskOptions>>().Value;
		
		var sut = factory.CreateSevUserApi(options);
		
		var result = await sut.GetCurrentUserAsync();
		
		result.Should().NotBeNull();
		result.Objects.Should().NotBeEmpty();
		result.Objects.First().ObjectName.Should().Be("SevUser");
	}
}