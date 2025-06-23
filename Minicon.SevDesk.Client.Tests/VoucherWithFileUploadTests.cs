using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Minicon.SevDesk.Client.Api;
using Minicon.SevDesk.Client.Models;
using Refit;
using System.Net;

namespace Minicon.SevDesk.Client.Tests;

public class VoucherWithFileUploadTests
{
	[Fact]
	public async Task CreateVoucherWithUploadedFile_CompleteWorkflow()
	{
		using var scope = new TestScope<SaveVoucherResponse>();
		var voucherApi = scope.ServiceScope.ServiceProvider.GetRequiredService<IVoucherApi>();
		var contactApi = scope.ServiceScope.ServiceProvider.GetRequiredService<IContactApi>();
		var accountingTypeApi = scope.ServiceScope.ServiceProvider.GetRequiredService<IAccountingTypeApi>();
		var sevUserApi = scope.ServiceScope.ServiceProvider.GetRequiredService<ISevUserApi>();

		// Step 1: Create a test PDF file
		var pdfContent = CreateTestPdfContent();
		using var stream = new MemoryStream(pdfContent);
		var file = new StreamPart(stream, "test_invoice.pdf", "application/pdf");

		// Step 2: Upload the file
		var uploadResponse = await voucherApi.VoucherUploadFileAsync(file);
		uploadResponse.Should().NotBeNull();
		uploadResponse.Objects.Should().NotBeNull();
		uploadResponse.Objects.Filename.Should().NotBeNullOrEmpty();
		
		// Store the uploaded filename for later use
		var uploadedFilename = uploadResponse.Objects.Filename;

		try
		{
			// Step 3: Get necessary data for voucher creation
			// Get current user for SevClient info
			var currentUser = await sevUserApi.GetCurrentUserAsync();
			var user = currentUser.Objects.First();
			
			var contacts = await contactApi.GetContactsAsync(limit: 1, depth: "0");
			var supplier = contacts.Objects.First();
			
			var accountingTypes = await accountingTypeApi.GetAccountingTypeAsync(limit: 1);
			var accountingType = accountingTypes.Objects.First();

			// Step 4: Create the voucher with the uploaded file
			var voucher = new ModelVoucher(
				sevClient: new ModelVoucherSevClient(user.SevClient.Id, user.SevClient.ObjectName),
				createUser: new ModelVoucherCreateUser(int.Parse(user.Id), user.ObjectName),
				voucherDate: DateTime.Now,
				supplier: new ModelVoucherSupplier(int.Parse(supplier.Id), supplier.ObjectName),
				supplierName: supplier.Name,
				description: "Test voucher with uploaded file",
				status: VoucherStatusEnum.Draft,
				taxType: "default",
				creditDebit: CreditDebitEnum.D,
				voucherType: VoucherTypeEnum.VOU,
				currency: "EUR"
			);

			// Create voucher positions
			var voucherPositions = new[]
			{
				new ModelVoucherPos(
					sevClient: new ModelVoucherPosSevClient(user.SevClient.Id),
					voucher: null,
					accountingType: new ModelVoucherPosAccountingType(accountingType.Id),
					estimatedAccountingType: null,
					taxRate: 19,
					net: false,
					sumGross: 119.00m,
					isAsset: false,
					comment: null,
					sumNet: 100.00m
				)
			};

			// Create the SaveVoucher request with the uploaded filename
			var saveVoucherRequest = new SaveVoucher(
				voucher: voucher,
				voucherPosSave: voucherPositions,
				voucherPosDelete: null,
				mapAll: true,
				filename: uploadedFilename
			);

			// Step 5: Save the voucher
			var saveResponse = await voucherApi.CreateVoucherByFactoryAsync(saveVoucherRequest);
			
			// Verify the voucher was created successfully
			saveResponse.Should().NotBeNull();
			saveResponse.Objects.Should().NotBeNull();
			saveResponse.Objects.Voucher.Should().NotBeNull();
			saveResponse.Objects.Voucher.Id.Should().BeGreaterThan(0);
			saveResponse.Objects.Document.Should().NotBeNull();
			saveResponse.Objects.Document.Filename.Should().NotBeNullOrEmpty();

			var createdVoucherId = saveResponse.Objects.Voucher.Id;
			// Step 6: Verify the voucher has the attached file
			var createdVoucher = await voucherApi.GetVoucherByIdAsync(createdVoucherId);
			createdVoucher.Should().NotBeNull();
			createdVoucher.Objects.Should().NotBeEmpty();
			
			// Step 7: Clean up - Try to reset voucher to draft status if it's not already draft
			// In SevDesk, vouchers are typically not deleted but reset to draft or cancelled
			if (saveResponse.Objects.Voucher.Status != VoucherStatusEnum.Draft)
			{
				try
				{
					await voucherApi.ResetVoucherToDraftAsync(createdVoucherId);
					
					// Verify the voucher is back in draft status
					var resetVoucher = await voucherApi.GetVoucherByIdAsync(createdVoucherId);
					resetVoucher.Objects.First().Status.Should().Be(VoucherStatusEnum.Draft);
				}
				catch (Refit.ApiException ex) when (ex.StatusCode == System.Net.HttpStatusCode.BadRequest)
				{
					// If reset fails with bad request, it might already be in draft status or have other issues
					// Log and continue - the test succeeded in its main purpose
					Console.WriteLine($"Failed to reset voucher to draft: {ex.Message}");
				}
			}
		}
		catch(Exception ex)
		{
			// If any error occurs, we should still try to clean up
			// Note: In a real scenario, you might want to track created resources
			// and ensure cleanup in a finally block
			Console.WriteLine(ex.Message);
			throw;
		}
	}

	private static byte[] CreateTestPdfContent()
	{
		// Create a minimal valid PDF file
		return new byte[]
		{
			0x25, 0x50, 0x44, 0x46, 0x2D, 0x31, 0x2E, 0x33, // %PDF-1.3
			0x0A, 0x25, 0xC4, 0xE5, 0xF2, 0xE5, 0xEB, 0xA7,
			0xF3, 0xA0, 0xD0, 0xC4, 0xC6, 0x0A, 0x31, 0x20,
			0x30, 0x20, 0x6F, 0x62, 0x6A, 0x0A, 0x3C, 0x3C,
			0x2F, 0x54, 0x79, 0x70, 0x65, 0x2F, 0x43, 0x61,
			0x74, 0x61, 0x6C, 0x6F, 0x67, 0x2F, 0x50, 0x61,
			0x67, 0x65, 0x73, 0x20, 0x32, 0x20, 0x30, 0x20,
			0x52, 0x3E, 0x3E, 0x0A, 0x65, 0x6E, 0x64, 0x6F,
			0x62, 0x6A, 0x0A, 0x32, 0x20, 0x30, 0x20, 0x6F,
			0x62, 0x6A, 0x0A, 0x3C, 0x3C, 0x2F, 0x54, 0x79,
			0x70, 0x65, 0x2F, 0x50, 0x61, 0x67, 0x65, 0x73,
			0x2F, 0x43, 0x6F, 0x75, 0x6E, 0x74, 0x20, 0x30,
			0x3E, 0x3E, 0x0A, 0x65, 0x6E, 0x64, 0x6F, 0x62,
			0x6A, 0x0A, 0x78, 0x72, 0x65, 0x66, 0x0A, 0x30,
			0x20, 0x33, 0x0A, 0x30, 0x30, 0x30, 0x30, 0x30,
			0x30, 0x30, 0x30, 0x30, 0x30, 0x20, 0x36, 0x35,
			0x35, 0x33, 0x35, 0x20, 0x66, 0x0A, 0x30, 0x30,
			0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x31, 0x35,
			0x20, 0x30, 0x30, 0x30, 0x30, 0x30, 0x20, 0x6E,
			0x0A, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30,
			0x36, 0x38, 0x20, 0x30, 0x30, 0x30, 0x30, 0x30,
			0x20, 0x6E, 0x0A, 0x74, 0x72, 0x61, 0x69, 0x6C,
			0x65, 0x72, 0x0A, 0x3C, 0x3C, 0x2F, 0x53, 0x69,
			0x7A, 0x65, 0x20, 0x33, 0x2F, 0x52, 0x6F, 0x6F,
			0x74, 0x20, 0x31, 0x20, 0x30, 0x20, 0x52, 0x3E,
			0x3E, 0x0A, 0x73, 0x74, 0x61, 0x72, 0x74, 0x78,
			0x72, 0x65, 0x66, 0x0A, 0x31, 0x31, 0x30, 0x0A,
			0x25, 0x25, 0x45, 0x4F, 0x46
		};
	}
}