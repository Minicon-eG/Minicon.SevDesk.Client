using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Minicon.SevDesk.Client.Api;
using Minicon.SevDesk.Client.Extensions;
using Minicon.SevDesk.Client.Extensions.Models;
using Minicon.SevDesk.Client.Models;
using Refit;

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
	public async Task GetVouchersAsync_WithMax_ReturnsAmountOfLimit()
	{
		using var scope = new TestScope<GetVoucherResponse>();
		int count = 10;
		IVoucherApi sut = scope.ServiceScope.ServiceProvider.GetRequiredService<IVoucherApi>();
		await scope.TestAsync(
			() => sut.GetVouchersAsync(limit: 10, status: 100), // 100 = Draft status
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

	[Fact]
	public async Task VoucherUploadFileAsync_WithValidFile_ReturnsUploadedFileInfo()
	{
		using var scope = new TestScope<UploadFileResponse>();
		IVoucherApi sut = scope.ServiceScope.ServiceProvider.GetRequiredService<IVoucherApi>();

		// Create a minimal valid PDF file
		var pdfContent = new byte[] {
			0x25, 0x50, 0x44, 0x46, 0x2D, 0x31, 0x2E, 0x33, // %PDF-1.3
			0x0A, 0x25, 0xC4, 0xE5, 0xF2, 0xE5, 0xEB, 0xA7, // .%......
			0xF3, 0xA0, 0xD0, 0xC4, 0xC6, 0x0A, 0x31, 0x20, // ......1 
			0x30, 0x20, 0x6F, 0x62, 0x6A, 0x0A, 0x3C, 0x3C, // 0 obj.<<
			0x2F, 0x54, 0x79, 0x70, 0x65, 0x2F, 0x43, 0x61, // /Type/Ca
			0x74, 0x61, 0x6C, 0x6F, 0x67, 0x2F, 0x50, 0x61, // talog/Pa
			0x67, 0x65, 0x73, 0x20, 0x32, 0x20, 0x30, 0x20, // ges 2 0 
			0x52, 0x3E, 0x3E, 0x0A, 0x65, 0x6E, 0x64, 0x6F, // R>>.endo
			0x62, 0x6A, 0x0A, 0x32, 0x20, 0x30, 0x20, 0x6F, // bj.2 0 o
			0x62, 0x6A, 0x0A, 0x3C, 0x3C, 0x2F, 0x54, 0x79, // bj.<</Ty
			0x70, 0x65, 0x2F, 0x50, 0x61, 0x67, 0x65, 0x73, // pe/Pages
			0x2F, 0x43, 0x6F, 0x75, 0x6E, 0x74, 0x20, 0x30, // /Count 0
			0x3E, 0x3E, 0x0A, 0x65, 0x6E, 0x64, 0x6F, 0x62, // >>.endob
			0x6A, 0x0A, 0x78, 0x72, 0x65, 0x66, 0x0A, 0x30, // j.xref.0
			0x20, 0x33, 0x0A, 0x30, 0x30, 0x30, 0x30, 0x30, //  3.00000
			0x30, 0x30, 0x30, 0x30, 0x30, 0x20, 0x36, 0x35, // 00000 65
			0x35, 0x33, 0x35, 0x20, 0x66, 0x0A, 0x30, 0x30, // 535 f.00
			0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x31, 0x35, // 00000015
			0x20, 0x30, 0x30, 0x30, 0x30, 0x30, 0x20, 0x6E, //  00000 n
			0x0A, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, // .0000000
			0x36, 0x38, 0x20, 0x30, 0x30, 0x30, 0x30, 0x30, // 68 00000
			0x20, 0x6E, 0x0A, 0x74, 0x72, 0x61, 0x69, 0x6C, //  n.trail
			0x65, 0x72, 0x0A, 0x3C, 0x3C, 0x2F, 0x53, 0x69, // er.<</Si
			0x7A, 0x65, 0x20, 0x33, 0x2F, 0x52, 0x6F, 0x6F, // ze 3/Roo
			0x74, 0x20, 0x31, 0x20, 0x30, 0x20, 0x52, 0x3E, // t 1 0 R>
			0x3E, 0x0A, 0x73, 0x74, 0x61, 0x72, 0x74, 0x78, // >.startx
			0x72, 0x65, 0x66, 0x0A, 0x31, 0x31, 0x30, 0x0A, // ref.110.
			0x25, 0x25, 0x45, 0x4F, 0x46                    // %%EOF
		};
		
		using var stream = new MemoryStream(pdfContent);
		var file = new StreamPart(stream, "test_receipt.pdf", "application/pdf");

		await scope.TestAsync(
			async () => await sut.VoucherUploadFileAsync(file),
			result =>
			{
				result.Should().NotBeNull();
				result.Objects.Should().NotBeNull();
				result.Objects.Filename.Should().NotBeNullOrEmpty();
				result.Objects.MimeType.Should().NotBeNullOrEmpty();
				// The API should return a hash filename
				result.Objects.Filename.Should().EndWith(".pdf");
			}
		);
	}
}
