# Changelog

All notable changes to the Minicon.SevDesk.Client library will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased]

### Added
- **ISevUserApi**: New API interface for retrieving current user information
  - `GetCurrentUserAsync()` - Get details about the currently authenticated user
  - Response models: `GetSevUserResponse`, `SevUserResponse`
  - Comprehensive unit tests for SevUser API functionality
  - Factory method support in `ISevDeskClientFactory` and `SevDeskClientFactory`

### Fixed
- **VoucherUploadFileAsync**: Fixed file upload functionality
  - Changed from `FactoryUploadTempFileBody` to `StreamPart` for proper multipart/form-data support
  - Updated response models to handle single object response instead of array
  - Added support for PDF file uploads
  - Removed unused `FactoryUploadTempFileBody` model

### Changed
- **Dependencies**: Upgraded all NuGet packages to version 9.0.6
  - Microsoft.Extensions.Options → 9.0.6
  - Microsoft.Extensions.Logging → 9.0.6
  - Microsoft.Extensions.Logging.Abstractions → 9.0.6
  - Microsoft.Extensions.Logging.Configuration → 9.0.6
  - Microsoft.Extensions.Logging.Console → 9.0.6
  - Microsoft.Extensions.DependencyInjection → 9.0.6
  - Microsoft.Extensions.Configuration → 9.0.6
  - Microsoft.Extensions.Http → 9.0.6
  - FluentAssertions → 6.12.2
  - Microsoft.NET.Test.Sdk → 17.12.0
  - xunit → 2.9.3
  - xunit.runner.visualstudio → 3.0.0

### Development
- Added `.DS_Store` to `.gitignore` for macOS development
- Enhanced `request.http` file with SevUser endpoint examples

## [1.0.0] - Previous Release

### Added
- Initial release of the SevDesk .NET client library
- Core API implementations:
  - AccountingContact API
  - CheckAccount API
  - Contact API
  - ContactCustomField API
  - ContactCustomFieldSetting API
  - DocServer API
  - Export API (with DATEV export support)
  - ExportJob API
  - Invoice API
  - Order API
  - Part API
  - Progress API
  - Receipt Guidance API
  - Report API
  - SaveVoucher API
  - SevClient API
  - Tag API
  - TagRelation API
  - Textparser API
  - Tools API
  - Voucher API
  - VoucherPos API
  
### Features
- Full async/await support
- Dependency injection integration with `IServiceCollection`
- Factory pattern for creating API clients
- Comprehensive logging support
- Request/response inspection capabilities
- Multi-targeting for .NET 6.0, 7.0, 8.0, and 9.0
- Refit-based type-safe HTTP client generation
- JSON serialization with Newtonsoft.Json
- Configurable through `SevDeskOptions`

### Infrastructure
- HTTP message handlers for logging and JSON inspection
- Extension methods for model transformations
- Supplier resolver pattern for polymorphic types
- Comprehensive test suite with integration tests

## API Coverage Status

### Fully Implemented with Tests
- ✅ AccountingContact
- ✅ CheckAccount
- ✅ Contact
- ✅ ContactCustomField
- ✅ ContactCustomFieldSetting
- ✅ DocServer
- ✅ ReceiptGuidance
- ✅ SevUser (NEW)
- ✅ Tag
- ✅ TagRelation
- ✅ Textparser
- ✅ Tools
- ✅ Voucher
- ✅ VoucherPos

### Implemented without Tests
- ⚠️ AccountingType
- ⚠️ CheckAccountTransaction
- ⚠️ CommunicationWay
- ⚠️ ContactAddress
- ⚠️ ContactField
- ⚠️ CostCentre
- ⚠️ CreditNote
- ⚠️ CreditNotePos
- ⚠️ Export
- ⚠️ ExportJob
- ⚠️ Invoice
- ⚠️ InvoicePos
- ⚠️ Layout
- ⚠️ Order
- ⚠️ OrderPos
- ⚠️ Part
- ⚠️ Progress
- ⚠️ Report
- ⚠️ SaveVoucher
- ⚠️ SevClient

## Known Issues
- Some API endpoints are missing comprehensive test coverage
- Package compatibility warnings when using .NET 6.0 and 7.0 (packages are optimized for .NET 8.0+)

## Migration Guide

### Upgrading from 1.0.0 to Unreleased

#### File Upload Changes
If you're using the `VoucherUploadFileAsync` method, you'll need to update your code:

**Before:**
```csharp
var body = new FactoryUploadTempFileBody { file = fileContent };
var result = await voucherApi.VoucherUploadFileAsync(body);
```

**After:**
```csharp
using var stream = new MemoryStream(fileContent);
var file = new StreamPart(stream, "filename.pdf", "application/pdf");
var result = await voucherApi.VoucherUploadFileAsync(file);
```

#### New User API
To get current user information:

```csharp
var sevUserApi = serviceProvider.GetRequiredService<ISevUserApi>();
var userResponse = await sevUserApi.GetCurrentUserAsync();
var user = userResponse.Objects.First();

// Create ModelVoucherCreateUser from the response
var createUser = new ModelVoucherCreateUser(
    id: int.Parse(user.Id),
    objectName: "SevUser"
);
```

## Contributing
Please ensure all new API implementations include comprehensive unit tests. Run all tests before submitting pull requests.

## License
This project is licensed under the MIT License - see the LICENSE file for details.