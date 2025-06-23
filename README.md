# Minicon.SevDesk.Client

## Overview

Minicon.SevDesk.Client is a specialized C# application aimed at seamlessly integrating and
managing various operations related to SevDesk vouchers, invoices, and credit notes. Core
functionalities include generating invoices from orders, updating voucher details, and
handling multi-currency transactions.

📋 **[View Changelog](CHANGELOG.md)** for recent updates and version history.

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
- **NEW**: User API support for retrieving current user information
- **NEW**: DATEV export support for both CSV and XML formats
- **NEW**: Export job tracking and progress monitoring
- **NEW**: E-invoice XML retrieval for electronic invoicing compliance
- Updated tax system: `taxType = noteu` replaced with `taxRule: 17` for non-EU transactions
- Enhanced file upload functionality with proper multipart/form-data support

### Usage Examples

For comprehensive usage details, refer to the model-specific documentation or examine the test
case implementations.

#### Dependency Injection Registration

```csharp
public void ConfigureServices(IServiceCollection services)
{
    // Register other services...
    services.AddSevdeskClient();
    
    // Configure options via appsettings.json or user secrets
    services.Configure<SevDeskOptions>(configuration.GetSection("SevDesk"));
}
```

#### Configuration via appsettings.json

```json
{
  "SevDesk": {
    "ApiKey": "your-sevdesk-api-key",
    "ApiUrl": "https://my.sevdesk.de/api/v1",
    "InspectJson": false
  }
}
```

```csharp
   public class InvoiceController : ControllerBase
   {
       private readonly IVoucherApi _voucherApi;
       private readonly IExportApi _exportApi;
       private readonly IExportJobApi _exportJobApi;
       private readonly ISevUserApi _sevUserApi;

       public InvoiceController(IVoucherApi voucherApi, IExportApi exportApi, 
           IExportJobApi exportJobApi, ISevUserApi sevUserApi)
       {
           _voucherApi = voucherApi;
           _exportApi = exportApi;
           _exportJobApi = exportJobApi;
           _sevUserApi = sevUserApi;
       }

       [HttpGet("user")]
       public async Task<IActionResult> GetCurrentUser()
       {
           var userResponse = await _sevUserApi.GetCurrentUserAsync();
           var user = userResponse.Objects.First();
           
           // Use for creating vouchers
           var createUser = new ModelVoucherCreateUser(
               id: int.Parse(user.Id),
               objectName: "SevUser"
           );
           
           return Ok(user);
       }

       [HttpPost]
       public async Task<IActionResult> GetVoucher(int id)
       {
           var voucher = await _voucherApi.GetVoucherByIdAsync(id);
           return Ok(voucher);
       }

       [HttpPost("upload")]
       public async Task<IActionResult> UploadVoucherFile(IFormFile file)
       {
           using var stream = file.OpenReadStream();
           var streamPart = new StreamPart(stream, file.FileName, file.ContentType);
           var result = await _voucherApi.VoucherUploadFileAsync(streamPart);
           return Ok(result);
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

#### Using the Factory Pattern

The `ISevDeskClientFactory` allows you to create API clients with custom configurations on-demand, which is useful for:
- Multi-tenant applications with different API keys
- Runtime configuration changes
- Testing scenarios with different endpoints

```csharp
public class MultiTenantService
{
    private readonly ISevDeskClientFactory _clientFactory;
    
    public MultiTenantService(ISevDeskClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
    }
    
    public async Task<GetVoucherResponse> GetVoucherForTenant(string tenantApiKey, int voucherId)
    {
        var options = new SevDeskOptions
        {
            ApiKey = tenantApiKey,
            ApiUrl = "https://my.sevdesk.de/api/v1",
            InspectJson = false
        };
        
        var voucherApi = _clientFactory.CreateVoucherApi(options);
        return await voucherApi.GetVoucherByIdAsync(voucherId);
    }
    
    public async Task ProcessMultipleTenants(Dictionary<string, string> tenantApiKeys)
    {
        foreach (var (tenantId, apiKey) in tenantApiKeys)
        {
            var options = new SevDeskOptions { ApiKey = apiKey, ApiUrl = "https://my.sevdesk.de/api/v1" };
            
            // Create specific API clients for this tenant
            var contactApi = _clientFactory.CreateContactApi(options);
            var invoiceApi = _clientFactory.CreateInvoiceApi(options);
            
            // Process tenant-specific data
            var contacts = await contactApi.GetContactsAsync();
            var invoices = await invoiceApi.GetInvoicesAsync();
            
            // Process data...
        }
    }
}
```

#### Factory vs Dependency Injection

**Use Dependency Injection when:**
- You have a single SevDesk account/configuration
- Configuration is static and known at startup
- You want automatic logging and HTTP client management

**Use Factory Pattern when:**
- You need to support multiple SevDesk accounts (multi-tenant)
- Configuration changes at runtime
- You need different settings per operation
- Testing with different endpoints or mock configurations

```csharp
// DI approach - single configuration
public class SingleTenantService
{
    private readonly IVoucherApi _voucherApi;
    
    public SingleTenantService(IVoucherApi voucherApi)
    {
        _voucherApi = voucherApi; // Configured via DI
    }
}

// Factory approach - multiple configurations
public class MultiTenantService
{
    private readonly ISevDeskClientFactory _factory;
    
    public MultiTenantService(ISevDeskClientFactory factory)
    {
        _factory = factory; // Create clients as needed
    }
}
```

#### Available Factory Methods

The factory provides creation methods for all SevDesk API interfaces:

```csharp
// Core business entities
var contactApi = factory.CreateContactApi(options);
var invoiceApi = factory.CreateInvoiceApi(options);
var voucherApi = factory.CreateVoucherApi(options);
var orderApi = factory.CreateOrderApi(options);
var creditNoteApi = factory.CreateCreditNoteApi(options);

// User and authentication
var sevUserApi = factory.CreateSevUserApi(options);

// Financial management
var checkAccountApi = factory.CreateCheckAccountApi(options);
var checkAccountTransactionApi = factory.CreateCheckAccountTransactionApi(options);
var accountingContactApi = factory.CreateAccountingContactApi(options);

// Export and reporting
var exportApi = factory.CreateExportApi(options);
var exportJobApi = factory.CreateExportJobApi(options);
var reportApi = factory.CreateReportApi(options);

// And many more... (see ISevDeskClientFactory for complete list)
```

#### Factory Registration

To use the factory pattern, register it in your DI container:

```csharp
public void ConfigureServices(IServiceCollection services)
{
    // Register logging
    services.AddLogging();
    
    // Register the factory
    services.AddSingleton<ISevDeskClientFactory, SevDeskClientFactory>();
    
    // Optional: also register for DI approach
    services.AddSevdeskClient();
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
