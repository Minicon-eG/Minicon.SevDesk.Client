# SevDesk API Client Verification Report

**Last verified:** 2026-05-12 against sevDesk OpenAPI spec **2.0.0**
(`https://api.sevdesk.de/openapi.yaml`)

## Summary

All path/operation combinations defined in the official OpenAPI specification are
implemented in `Minicon.SevDesk.Client`. The previous version of this report listed
several "missing" endpoint groups (ContactCustomField, DocServer, ReceiptGuidance,
Tools, SevClient, TagRelation, Textparser) — those are all implemented today.

## API Base URLs

- Production: `https://my.sevdesk.de/api/v1`
- Development: `http://sevdesk.local/api/v1`

## Authentication

API Key in `Authorization` header (32-character hexadecimal token).

## Changes added in this verification round

### New endpoints implemented

| Endpoint                                            | Interface                       |
|-----------------------------------------------------|---------------------------------|
| `PUT /CheckAccountTransaction/{id}/enshrine`        | `ICheckAccountTransactionApi`   |
| `PUT /CreditNote/{id}/enshrine`                     | `ICreditNoteApi`                |
| `PUT /CreditNote/{id}/resetToOpen`                  | `ICreditNoteApi`                |
| `PUT /CreditNote/{id}/resetToDraft`                 | `ICreditNoteApi`                |
| `POST /CreditNote/Factory/createFromInvoice`        | `ICreditNoteApi`                |
| `POST /CreditNote/Factory/createFromVoucher`        | `ICreditNoteApi`                |
| `GET  /PrivateTransactionRule`                      | `IPrivateTransactionRuleApi` *  |
| `POST /PrivateTransactionRule`                      | `IPrivateTransactionRuleApi` *  |
| `DELETE /PrivateTransactionRule/{id}`               | `IPrivateTransactionRuleApi` *  |

\* new interface; registered in `ServiceCollectionExtensions.AddSevdeskClient()`.

### Bugs fixed

- `ICreditNoteApi.UpdateCreditNoteAsync` route was `"/CreditNote/{creditNoteId"` (missing closing brace).
- `ICreditNoteApi.SendCreditNoteByPrintingAsync` path used lowercase `/creditNote/...`
  (sevDesk routes are case-sensitive).
- `IReportApi.ReportContactAsync` was missing the `[Get("/Report/contactlist")]` attribute,
  so the call would never have reached the API.

### Legacy / undocumented interfaces (marked `[Obsolete]`)

These interfaces are not present in the official OpenAPI spec but are retained for
backwards compatibility:

| Interface            | Path              | Recommendation                                                                 |
|----------------------|-------------------|--------------------------------------------------------------------------------|
| `IAccountingTypeApi` | `/AccountingType` | May be removed by sevDesk without notice.                                      |
| `ICostCentreApi`     | `/CostCentre`     | May be removed by sevDesk without notice.                                      |
| `ILayoutApi`         | `/Layout`         | Use `IDocServerApi` (documented).                                              |
| `ISevUserApi`        | `/SevUser`        | May be removed by sevDesk without notice.                                      |
| `IContactFieldApi`   | (aggregate)       | Use `IContactCustomFieldApi`/`IContactCustomFieldSettingApi`/`ITextparserApi`. |

DI registration in `ServiceCollectionExtensions` suppresses `CS0618` so existing
consumers keep working without compiler warnings.

## Verification method

```bash
curl -sL https://api.sevdesk.de/openapi.yaml -o /tmp/sevdesk-openapi.yaml
grep -E '^  /[A-Z]' /tmp/sevdesk-openapi.yaml | sort -u
# diff against:
grep -rohE '"/[A-Z][^"]*"' Minicon.SevDesk.Client/Api/ | sort -u
```

Spec version: 2.0.0.
