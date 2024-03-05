using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Minicon.SevDesk.Client.Api;
using Minicon.SevDesk.Client.Extensions;
using Minicon.SevDesk.Client.Extensions.Models;
using Minicon.SevDesk.Client.Models;

namespace Minicon.SevDesk.Client.Tests;

public class VoucherApiTests
{
	[Fact]
	public async Task SaveVoucherAsync()
	{
		using var scope = new TestScope<SaveVoucherResponse>();
		IVoucherPosApi sut = scope.ServiceScope.ServiceProvider.GetRequiredService<IVoucherPosApi>();
		IVoucherApi voucherApi = scope.ServiceScope.ServiceProvider.GetRequiredService<IVoucherApi>();
		ModelVoucherResponse voucher = (await voucherApi.GetVoucherByIdAsync(80659657)).Objects.Single();
		GetVoucherPositionsResponse pos = await sut.GetVoucherPositionsAsync(voucher.Id);
		ISupplierResolver supplierResolver = scope.ServiceScope.ServiceProvider.GetRequiredService<ISupplierResolver>();

		SaveVoucherVoucherPosDelete[] posDeletes =
			pos.Objects.Skip(1).Select(x => new SaveVoucherVoucherPosDelete(x.Id.ToInt())).ToArray();
		await scope.TestAsync(
			async () =>
			{
				var request = new SaveVoucher(
					await voucher.ToModelVoucherAsync(supplierResolver),
					Array.Empty<ModelVoucherPos>(),
					posDeletes
				);

				SaveVoucherResponse response = await voucherApi.CreateVoucherByFactoryAsync(
					request
				);

				return response;
			},
			result => { result.Should().NotBeNull(); }
		);
		GetVoucherResponse v = await voucherApi.GetVoucherByIdAsync(voucher.Id);
		GetVoucherPositionsResponse p = await sut.GetVoucherPositionsAsync(voucher.Id);
		p.Objects.Count.Should().Be(1);
	}

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
