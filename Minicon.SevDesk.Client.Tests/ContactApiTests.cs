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
		using (var scope = new TestScope())
		{
			IOptions<SevDeskOptions> config =
				scope.ServiceScope.ServiceProvider.GetRequiredService<IOptions<SevDeskOptions>>();
			config.Value.ApiKey.Should().NotBeNullOrWhiteSpace();
			config.Value.ApiUrl.Should().NotBeNullOrWhiteSpace();
		}
	}

	[Fact]
	public void ContactApi_IsAvailable()
	{
		using (var scope = new TestScope())
		{
			IContactApi sut = scope.ServiceScope.ServiceProvider.GetRequiredService<IContactApi>();
			sut.Should().NotBeNull();
		}
	}

	[Fact]
	public async Task GetContactsAsync_Returns_Contacts()
	{
		using (var scope = new TestScope())
		{
			IContactApi sut = scope.ServiceScope.ServiceProvider.GetRequiredService<IContactApi>();
			GetContactResponse result = await sut.GetContactsAsync();

			result.Objects.Count.Should().BePositive();
		}
	}
}
