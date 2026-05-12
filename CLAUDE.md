# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Build and Test Commands

```bash
# Build the solution
dotnet build

# Run tests
dotnet test

# Create NuGet package
dotnet pack --configuration Release

# Run specific test
dotnet test --filter "FullyQualifiedName~ContactApiTests"
```

## Architecture Overview

This is a .NET client library for the SevDesk API, built using Refit for type-safe HTTP client generation.

### Key Components

1. **API Interfaces** (`/Api/`): Refit-decorated interfaces defining all SevDesk API endpoints. Each interface corresponds to a specific API domain (e.g., `IVoucherApi`, `IContactApi`).

2. **Models** (`/Models/`): DTOs for API requests/responses following the naming pattern:
   - `Model{Entity}` - Base request models
   - `Model{Entity}Response` - Response models
   - `Model{Entity}Update` - Update request models

3. **Extensions** (`/Extensions/`): 
   - `ServiceCollectionExtensions`: DI registration for all API services
   - Model extensions for transforming between representations
   - `ISupplierResolver`: Pattern for resolving polymorphic supplier types

4. **HTTP Pipeline**:
   - `LoggingHttpMessageHandler`: Request/response logging
   - `JsonInspectingHandler`: Optional JSON inspection (controlled by `SevDeskOptions.InspectJson`)

### Configuration

Services are registered using:
```csharp
services.AddSevdeskClient();
```

Configuration via `SevDeskOptions`:
```csharp
{
  "SevDesk": {
    "ApiKey": "your-api-key",
    "ApiUrl": "https://my.sevdesk.de/api/v1",
    "InspectJson": false
  }
}
```

### API Implementation Status

Verified against sevDesk OpenAPI spec **2.0.0** (`https://api.sevdesk.de/openapi.yaml`, retrieved 2026-05-12). All documented endpoints are implemented.

Legacy / undocumented interfaces (marked `[Obsolete]`, kept for backwards compatibility):
- `IAccountingTypeApi` — `/AccountingType` (not in spec)
- `ICostCentreApi` — `/CostCentre` (not in spec)
- `ILayoutApi` — `/Layout` (superseded by `IDocServerApi`)
- `ISevUserApi` — `/SevUser` (not in spec)
- `IContactFieldApi` — redundant aggregate of `IContactCustomFieldApi`, `IContactCustomFieldSettingApi`, `ITextparserApi`

### Recent Updates

- Verified completeness against OpenAPI spec 2.0.0 (2026-05-12)
- New: `IPrivateTransactionRuleApi` (`GET/POST /PrivateTransactionRule`, `DELETE /PrivateTransactionRule/{id}`)
- New: `CreditNote` lifecycle endpoints — `enshrine`, `resetToOpen`, `resetToDraft`, `Factory/createFromInvoice`, `Factory/createFromVoucher`
- New: `CheckAccountTransaction/{id}/enshrine`
- Fix: `IReportApi.ReportContactAsync` was missing `[Get("/Report/contactlist")]` route attribute
- Fix: `ICreditNoteApi.UpdateCreditNoteAsync` route was `"/CreditNote/{creditNoteId"` (missing `}`)
- Fix: `ICreditNoteApi.SendCreditNoteByPrintingAsync` path used lowercase `/creditNote/...` (sevDesk routes are case-sensitive)
- DATEV export jobs (`/Export/createDatevCsv/XmlZipExportJob`), `/ExportJob/jobDownloadInfo`, `/Progress/*`, `/Invoice/{id}/getXml`
- Tax system changes: `taxType = noteu` replaced with `taxRule: 17`

### Testing Approach

Integration tests use real API calls configured via `appsettings.json` and user secrets. Test isolation is handled through `TestScope<T>` pattern.