using Minicon.SevDesk.Client.Api;

namespace Minicon.SevDesk.Client;

public interface ISevDeskClientFactory
{
    IAccountingContactApi CreateAccountingContactApi(SevDeskOptions options);
    IAccountingTypeApi CreateAccountingTypeApi(SevDeskOptions options);
    ICheckAccountApi CreateCheckAccountApi(SevDeskOptions options);
    ICheckAccountTransactionApi CreateCheckAccountTransactionApi(SevDeskOptions options);
    ICommunicationWayApi CreateCommunicationWayApi(SevDeskOptions options);
    IContactApi CreateContactApi(SevDeskOptions options);
    IContactAddressApi CreateContactAddressApi(SevDeskOptions options);
    IContactCustomFieldApi CreateContactCustomFieldApi(SevDeskOptions options);
    IContactCustomFieldSettingApi CreateContactCustomFieldSettingApi(SevDeskOptions options);
    IContactFieldApi CreateContactFieldApi(SevDeskOptions options);
    ICostCentreApi CreateCostCentreApi(SevDeskOptions options);
    ICreditNoteApi CreateCreditNoteApi(SevDeskOptions options);
    ICreditNotePosApi CreateCreditNotePosApi(SevDeskOptions options);
    IDocServerApi CreateDocServerApi(SevDeskOptions options);
    IExportApi CreateExportApi(SevDeskOptions options);
    IExportJobApi CreateExportJobApi(SevDeskOptions options);
    IInvoiceApi CreateInvoiceApi(SevDeskOptions options);
    IInvoicePosApi CreateInvoicePosApi(SevDeskOptions options);
    ILayoutApi CreateLayoutApi(SevDeskOptions options);
    IOrderApi CreateOrderApi(SevDeskOptions options);
    IOrderPosApi CreateOrderPosApi(SevDeskOptions options);
    IPartApi CreatePartApi(SevDeskOptions options);
    IProgressApi CreateProgressApi(SevDeskOptions options);
    IReceiptGuidanceApi CreateReceiptGuidanceApi(SevDeskOptions options);
    IReportApi CreateReportApi(SevDeskOptions options);
    ISaveVoucherApi CreateSaveVoucherApi(SevDeskOptions options);
    ISevClientApi CreateSevClientApi(SevDeskOptions options);
    ITagApi CreateTagApi(SevDeskOptions options);
    ITagRelationApi CreateTagRelationApi(SevDeskOptions options);
    ITextparserApi CreateTextparserApi(SevDeskOptions options);
    IToolsApi CreateToolsApi(SevDeskOptions options);
    IVoucherApi CreateVoucherApi(SevDeskOptions options);
    IVoucherPosApi CreateVoucherPosApi(SevDeskOptions options);
}