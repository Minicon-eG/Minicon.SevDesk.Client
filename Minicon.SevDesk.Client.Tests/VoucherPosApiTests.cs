using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Minicon.SevDesk.Client.Api;
using Minicon.SevDesk.Client.Models;

namespace Minicon.SevDesk.Client.Tests;

public class VoucherPosApiTests
{
	[Fact]
	public async Task GetVoucherPosAsync_WithNoParameters_ReturnsVoucherPos()
	{
		using var scope = new TestScope<GetVoucherPositionsResponse>();
		IVoucherPosApi sut = scope.ServiceScope.ServiceProvider.GetRequiredService<IVoucherPosApi>();
		IVoucherApi voucherApi = scope.ServiceScope.ServiceProvider.GetRequiredService<IVoucherApi>();
		GetVoucherResponse firstVoucher = await voucherApi.GetVouchersAsync(limit: 1);
		await scope.TestAsync(
			async () => await sut.GetVoucherPositionsAsync(firstVoucher.Objects.Single().Id),
			result => { result.Objects.Count.Should().BePositive(); }
		);
	}
}
