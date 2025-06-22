# Minicon.SevDesk.Client

## Overview

Minicon.SevDesk.Client is a specialized C# application aimed at seamlessly integrating and
managing various operations related to SevDesk vouchers, invoices, and credit notes. Core
functionalities include generating invoices from orders, updating voucher details, and
handling multi-currency transactions.

## Setup

1. **System Requirements**:
	- Ensure that .NET[]() SDK version 9.0.0 or a compatible version is installed. This
	  requirement is defined in the [global.json](global.json) specification.
2. **Repository Cloning**:
   ```bash
   git clone https://github.com/Minicon-eG/Minicon.SevDesk.Client
   cd Minicon.SevDesk.Client
   ```
3. **Project Compilation**:
   Utilize Visual Studio or the .NET CLI to compile the project.
   ```bash
   dotnet build
   ```
4. **Testing (Optional)**:
   Execute unit tests to verify the project's functionality.
   ```bash
   dotnet test Minicon.SevDesk.Client.Tests
   ```

## Features

- The library provides data models for managing vouchers and invoices such as
  [`ModelVoucherUpdate`](src/Models/ModelVoucherUpdate.cs), [`ModelVoucher`](src/Models/ModelVoucher.cs),
  [`ModelInvoiceUpdate`](src/Models/ModelInvoiceUpdate.cs), and [`ModelCreditNote`](src/Models/ModelCreditNote.cs).
- Key operations include setting tax configurations, overseeing payment terms, and managing
  recurring vouchers for diverse clientele.
- **NEW**: DATEV export support for both CSV and XML formats
- **NEW**: Export job tracking and progress monitoring
- **NEW**: E-invoice XML retrieval for electronic invoicing compliance
- Updated tax system: `taxType = noteu` replaced with `taxRule: 17` for non-EU transactions

### Usage Examples

For comprehensive usage details, refer to the model-specific documentation or examine the test
case implementations.

```csharp
   public void ConfigureServices(IServiceCollection services)
   {
       // Register other services...
       services.AddSevdeskClient(options =>
       {
           options.ApiKey = "YOUR_API_KEY"; // Set the required API key
           options.BaseUrl = "https://api.sevdesk.de"; // Set the base URL if different
       });
   }
 ```

```csharp
   public class InvoiceController : ControllerBase
   {
       private readonly IVoucherApi _voucherApi;
       private readonly IExportApi _exportApi;
       private readonly IExportJobApi _exportJobApi;

       public InvoiceController(IVoucherApi voucherApi, IExportApi exportApi, IExportJobApi exportJobApi)
       {
           _voucherApi = voucherApi;
           _exportApi = exportApi;
           _exportJobApi = exportJobApi;
       }

       [HttpPost]
       public async Task<IActionResult> GetVoucher(int id)
       {
           var voucher = await _voucherApi.GetVoucherByIdAsync(id);
           return Ok(voucher);
       }

       [HttpPost]
       public async Task<IActionResult> ExportDatevCsv([FromBody] CreateDatevCsvExportRequest request)
       {
           // Create DATEV export job
           var jobResponse = await _exportApi.CreateDatevCsvZipExportJobAsync(request);
           
           // Get download info
           var downloadInfo = await _exportJobApi.GetJobDownloadInfoAsync(jobResponse.Objects.JobId);
           
           return Ok(downloadInfo);
       }
   }
```
## System Configuration

- Confirm your environment is configured to utilize .NET SDK 9.0.0 as specified by the
  [global.json](global.json) file.
- Modify the build configuration (Debug/Release) within the Visual Studio Solution:
  [Minicon.SevDesk.Client.sln](Minicon.SevDesk.Client.sln).

## Contributing

Contributions are welcome! Please review our guidelines and adhere to the coding standards.
Submit a pull request with a well-documented summary of your modifications.

## License

Include your project's licensing information (e.g., MIT License).
