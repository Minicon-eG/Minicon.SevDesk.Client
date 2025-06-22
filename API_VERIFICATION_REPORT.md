# SevDesk API Client Verification Report

## Summary

This report compares the Minicon.SevDesk.Client implementation against the official SevDesk API documentation.

## API Base URLs

### OpenAPI Specification (Local)
- Production: `https://my.sevdesk.de/api/v1`
- Local: `http://sevdesk.local/api/v1`

## Authentication

### OpenAPI Specification
- **Type**: API Key
- **Header Name**: `Authorization`
- **Description**: Uses a 32-character hexadecimal API token

## Missing API Endpoints in Client

The following endpoints are defined in the OpenAPI specification but are NOT implemented in the client:

1. **CommunicationWayKey** - `/CommunicationWayKey`
2. **ContactCustomField** - `/ContactCustomField` and `/ContactCustomField/{contactCustomFieldId}`
3. **ContactCustomFieldSetting** - `/ContactCustomFieldSetting` and related endpoints
4. **DocServer** - `/DocServer/getLetterpapersWithThumb` and `/DocServer/getTemplatesWithThumb`
5. **ReceiptGuidance** - Multiple endpoints:
   - `/ReceiptGuidance/forAllAccounts`
   - `/ReceiptGuidance/forAccountNumber`
   - `/ReceiptGuidance/forTaxRule`
   - `/ReceiptGuidance/forRevenue`
   - `/ReceiptGuidance/forExpense`
6. **SevClient** - `/SevClient/{SevClientId}/updateExportConfig`
7. **TagRelation** - `/TagRelation`
8. **Textparser** - `/Textparser/fetchDictionaryEntriesByType`
9. **Tools** - `/Tools/bookkeepingSystemVersion`

## Potentially Extra/Undocumented APIs in Client

The following API interfaces exist in the client but don't have direct endpoint matches in the OpenAPI specification:

1. **IAccountingTypeApi** - `/AccountingType` endpoint
2. **IContactFieldApi** - Appears to be implementing ContactCustomField functionality
3. **ICostCentreApi** - Cost Centre related operations
4. **ILayoutApi** - Layout related operations

## Special Cases

1. **ISaveVoucherApi** - This correctly implements `/Voucher/Factory/saveVoucher` endpoint

## API Naming Discrepancies

1. **ContactField vs ContactCustomField**: The client uses `IContactFieldApi` while the OpenAPI spec defines `ContactCustomField` endpoints
2. **CheckAccount**: There appears to be a whitespace issue in the endpoint list ("CheckAccount  " with trailing spaces)

## Model Count

- The client has **328 model files** in the Models directory

## Recommendations

1. **Add Missing Endpoints**: Implement the missing endpoints listed above, particularly:
   - CommunicationWayKey (for complete communication way functionality)
   - ContactCustomField endpoints (or verify if IContactFieldApi covers this)
   - ReceiptGuidance endpoints (important for sevdesk-Update 2.0)
   - Tools endpoint (for checking bookkeeping system version)

2. **Verify Undocumented Endpoints**: Check if the following are still valid:
   - AccountingType endpoint
   - CostCentre endpoint
   - Layout endpoint

3. **Naming Consistency**: Consider renaming `IContactFieldApi` to `IContactCustomFieldApi` to match the OpenAPI specification

4. **Documentation**: Add XML documentation to indicate which endpoints might be using older/undocumented API versions

## Notes

- The OpenAPI specification version is 2.0.0
- The API supports both XML and JSON responses
- The API includes support for sevdesk-Update 2.0 with changes to tax rules and booking accounts
- Some endpoints have been deprecated or removed in sevdesk-Update 2.0