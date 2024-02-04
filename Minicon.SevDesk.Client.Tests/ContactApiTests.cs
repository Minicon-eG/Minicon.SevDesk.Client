using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Minicon.SevDesk.Client.Api;
using Minicon.SevDesk.Client.Models;

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
}
