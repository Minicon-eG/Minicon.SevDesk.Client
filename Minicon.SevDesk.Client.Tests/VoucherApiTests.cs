using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Minicon.SevDesk.Client.Api;
using Minicon.SevDesk.Client.Extensions.Models;
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

	[Fact]
	public async Task SaveVoucher()
	{
		using var scope = new TestScope<SaveVoucherResponse>();
		IVoucherPosApi sut = scope.ServiceScope.ServiceProvider.GetRequiredService<IVoucherPosApi>();
		IVoucherApi voucherApi = scope.ServiceScope.ServiceProvider.GetRequiredService<IVoucherApi>();
		ModelVoucherResponse voucher = (await voucherApi.GetVoucherByIdAsync(80659678)).Objects.Single();
		GetVoucherPositionsResponse pos = await sut.GetVoucherPositionsAsync(voucher.Id);
		await scope.TestAsync(
			async () =>
			{
				SaveVoucherResponse response = await voucherApi.CreateVoucherByFactoryAsync(
					voucher.ToSaveVoucher(pos)
				);

				return response;
			},
			result => { result.Should().NotBeNull(); }
		);
	}
}

public class VoucherApiTests
{
	[Fact]
	public async Task GetVouchersAsync_WithNoParameters_ReturnsVouchers()
	{
		using var scope = new TestScope<GetVoucherResponse>();
		IVoucherApi sut = scope.ServiceScope.ServiceProvider.GetRequiredService<IVoucherApi>();
		await scope.TestAsync(async () => await sut.GetVouchersAsync(
		), result => { result.Objects.Count.Should().BePositive(); });
	}

	[Fact]
	public async Task GetVouchersAsync_WithLimit_ReturnsAmountOfLimit()
	{
		using var scope = new TestScope<GetVoucherResponse>();
		int count = 5;
		IVoucherApi sut = scope.ServiceScope.ServiceProvider.GetRequiredService<IVoucherApi>();
		await scope.TestAsync(
			() => sut.GetVouchersAsync(limit: count),
			result => result.Objects.Count.Should().Be(count)
		);
	}

	[Fact]
	public async Task GetVoucherByIdAsync_WithExistingId_ReturnsVoucher()
	{
		using var scope = new TestScope<GetVoucherResponse>();
		IVoucherApi sut = scope.ServiceScope.ServiceProvider.GetRequiredService<IVoucherApi>();

		await scope.TestAsync(() => sut.GetVouchersAsync(),
			result => sut.GetVoucherByIdAsync(result.Objects.First().Id)
		);
	}
}
