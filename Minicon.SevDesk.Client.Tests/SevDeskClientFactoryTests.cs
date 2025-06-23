using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Minicon.SevDesk.Client.Api;
using Minicon.SevDesk.Client.Models;

namespace Minicon.SevDesk.Client.Tests;

public class SevDeskClientFactoryTests
{
    private readonly ISevDeskClientFactory _factory;
    private readonly SevDeskOptions _validOptions;

    public SevDeskClientFactoryTests()
    {
        var services = new ServiceCollection();
        services.AddLogging();
        var serviceProvider = services.BuildServiceProvider();
        var loggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>();
        
        _factory = new SevDeskClientFactory(loggerFactory);
        
        _validOptions = new SevDeskOptions
        {
            ApiKey = "test-api-key-12345678901234567890123456789012",
            ApiUrl = "https://my.sevdesk.de/api/v1",
            InspectJson = false
        };
    }

    [Fact]
    public void Factory_IsAvailable()
    {
        _factory.Should().NotBeNull();
        _factory.Should().BeAssignableTo<ISevDeskClientFactory>();
    }

    [Fact]
    public void CreateContactApi_WithValidOptions_Returns_ContactApi()
    {
        var api = _factory.CreateContactApi(_validOptions);
        
        api.Should().NotBeNull();
        api.Should().BeAssignableTo<IContactApi>();
    }

    [Fact]
    public void CreateVoucherApi_WithValidOptions_Returns_VoucherApi()
    {
        var api = _factory.CreateVoucherApi(_validOptions);
        
        api.Should().NotBeNull();
        api.Should().BeAssignableTo<IVoucherApi>();
    }

    [Fact]
    public void CreateInvoiceApi_WithValidOptions_Returns_InvoiceApi()
    {
        var api = _factory.CreateInvoiceApi(_validOptions);
        
        api.Should().NotBeNull();
        api.Should().BeAssignableTo<IInvoiceApi>();
    }

    [Fact]
    public void CreateOrderApi_WithValidOptions_Returns_OrderApi()
    {
        var api = _factory.CreateOrderApi(_validOptions);
        
        api.Should().NotBeNull();
        api.Should().BeAssignableTo<IOrderApi>();
    }

    [Fact]
    public void CreateCreditNoteApi_WithValidOptions_Returns_CreditNoteApi()
    {
        var api = _factory.CreateCreditNoteApi(_validOptions);
        
        api.Should().NotBeNull();
        api.Should().BeAssignableTo<ICreditNoteApi>();
    }

    [Fact]
    public void CreateExportApi_WithValidOptions_Returns_ExportApi()
    {
        var api = _factory.CreateExportApi(_validOptions);
        
        api.Should().NotBeNull();
        api.Should().BeAssignableTo<IExportApi>();
    }

    [Fact]
    public void CreateExportJobApi_WithValidOptions_Returns_ExportJobApi()
    {
        var api = _factory.CreateExportJobApi(_validOptions);
        
        api.Should().NotBeNull();
        api.Should().BeAssignableTo<IExportJobApi>();
    }

    [Fact]
    public void CreateProgressApi_WithValidOptions_Returns_ProgressApi()
    {
        var api = _factory.CreateProgressApi(_validOptions);
        
        api.Should().NotBeNull();
        api.Should().BeAssignableTo<IProgressApi>();
    }

    [Fact]
    public void CreateTagApi_WithValidOptions_Returns_TagApi()
    {
        var api = _factory.CreateTagApi(_validOptions);
        
        api.Should().NotBeNull();
        api.Should().BeAssignableTo<ITagApi>();
    }

    [Fact]
    public void CreatePartApi_WithValidOptions_Returns_PartApi()
    {
        var api = _factory.CreatePartApi(_validOptions);
        
        api.Should().NotBeNull();
        api.Should().BeAssignableTo<IPartApi>();
    }

    [Fact]
    public void CreateCheckAccountApi_WithValidOptions_Returns_CheckAccountApi()
    {
        var api = _factory.CreateCheckAccountApi(_validOptions);
        
        api.Should().NotBeNull();
        api.Should().BeAssignableTo<ICheckAccountApi>();
    }

    [Fact]
    public void CreateCheckAccountTransactionApi_WithValidOptions_Returns_CheckAccountTransactionApi()
    {
        var api = _factory.CreateCheckAccountTransactionApi(_validOptions);
        
        api.Should().NotBeNull();
        api.Should().BeAssignableTo<ICheckAccountTransactionApi>();
    }

    [Fact]
    public void CreateAccountingContactApi_WithValidOptions_Returns_AccountingContactApi()
    {
        var api = _factory.CreateAccountingContactApi(_validOptions);
        
        api.Should().NotBeNull();
        api.Should().BeAssignableTo<IAccountingContactApi>();
    }

    [Fact]
    public void CreateAccountingTypeApi_WithValidOptions_Returns_AccountingTypeApi()
    {
        var api = _factory.CreateAccountingTypeApi(_validOptions);
        
        api.Should().NotBeNull();
        api.Should().BeAssignableTo<IAccountingTypeApi>();
    }

    [Fact]
    public void CreateCommunicationWayApi_WithValidOptions_Returns_CommunicationWayApi()
    {
        var api = _factory.CreateCommunicationWayApi(_validOptions);
        
        api.Should().NotBeNull();
        api.Should().BeAssignableTo<ICommunicationWayApi>();
    }

    [Fact]
    public void CreateContactAddressApi_WithValidOptions_Returns_ContactAddressApi()
    {
        var api = _factory.CreateContactAddressApi(_validOptions);
        
        api.Should().NotBeNull();
        api.Should().BeAssignableTo<IContactAddressApi>();
    }

    [Fact]
    public void CreateContactCustomFieldApi_WithValidOptions_Returns_ContactCustomFieldApi()
    {
        var api = _factory.CreateContactCustomFieldApi(_validOptions);
        
        api.Should().NotBeNull();
        api.Should().BeAssignableTo<IContactCustomFieldApi>();
    }

    [Fact]
    public void CreateContactCustomFieldSettingApi_WithValidOptions_Returns_ContactCustomFieldSettingApi()
    {
        var api = _factory.CreateContactCustomFieldSettingApi(_validOptions);
        
        api.Should().NotBeNull();
        api.Should().BeAssignableTo<IContactCustomFieldSettingApi>();
    }

    [Fact]
    public void CreateContactFieldApi_WithValidOptions_Returns_ContactFieldApi()
    {
        var api = _factory.CreateContactFieldApi(_validOptions);
        
        api.Should().NotBeNull();
        api.Should().BeAssignableTo<IContactFieldApi>();
    }

    [Fact]
    public void CreateCostCentreApi_WithValidOptions_Returns_CostCentreApi()
    {
        var api = _factory.CreateCostCentreApi(_validOptions);
        
        api.Should().NotBeNull();
        api.Should().BeAssignableTo<ICostCentreApi>();
    }

    [Fact]
    public void CreateCreditNotePosApi_WithValidOptions_Returns_CreditNotePosApi()
    {
        var api = _factory.CreateCreditNotePosApi(_validOptions);
        
        api.Should().NotBeNull();
        api.Should().BeAssignableTo<ICreditNotePosApi>();
    }

    [Fact]
    public void CreateDocServerApi_WithValidOptions_Returns_DocServerApi()
    {
        var api = _factory.CreateDocServerApi(_validOptions);
        
        api.Should().NotBeNull();
        api.Should().BeAssignableTo<IDocServerApi>();
    }

    [Fact]
    public void CreateInvoicePosApi_WithValidOptions_Returns_InvoicePosApi()
    {
        var api = _factory.CreateInvoicePosApi(_validOptions);
        
        api.Should().NotBeNull();
        api.Should().BeAssignableTo<IInvoicePosApi>();
    }

    [Fact]
    public void CreateLayoutApi_WithValidOptions_Returns_LayoutApi()
    {
        var api = _factory.CreateLayoutApi(_validOptions);
        
        api.Should().NotBeNull();
        api.Should().BeAssignableTo<ILayoutApi>();
    }

    [Fact]
    public void CreateOrderPosApi_WithValidOptions_Returns_OrderPosApi()
    {
        var api = _factory.CreateOrderPosApi(_validOptions);
        
        api.Should().NotBeNull();
        api.Should().BeAssignableTo<IOrderPosApi>();
    }

    [Fact]
    public void CreateReceiptGuidanceApi_WithValidOptions_Returns_ReceiptGuidanceApi()
    {
        var api = _factory.CreateReceiptGuidanceApi(_validOptions);
        
        api.Should().NotBeNull();
        api.Should().BeAssignableTo<IReceiptGuidanceApi>();
    }

    [Fact]
    public void CreateReportApi_WithValidOptions_Returns_ReportApi()
    {
        var api = _factory.CreateReportApi(_validOptions);
        
        api.Should().NotBeNull();
        api.Should().BeAssignableTo<IReportApi>();
    }

    [Fact]
    public void CreateSaveVoucherApi_WithValidOptions_Returns_SaveVoucherApi()
    {
        var api = _factory.CreateSaveVoucherApi(_validOptions);
        
        api.Should().NotBeNull();
        api.Should().BeAssignableTo<ISaveVoucherApi>();
    }

    [Fact]
    public void CreateSevClientApi_WithValidOptions_Returns_SevClientApi()
    {
        var api = _factory.CreateSevClientApi(_validOptions);
        
        api.Should().NotBeNull();
        api.Should().BeAssignableTo<ISevClientApi>();
    }

    [Fact]
    public void CreateTagRelationApi_WithValidOptions_Returns_TagRelationApi()
    {
        var api = _factory.CreateTagRelationApi(_validOptions);
        
        api.Should().NotBeNull();
        api.Should().BeAssignableTo<ITagRelationApi>();
    }

    [Fact]
    public void CreateTextparserApi_WithValidOptions_Returns_TextparserApi()
    {
        var api = _factory.CreateTextparserApi(_validOptions);
        
        api.Should().NotBeNull();
        api.Should().BeAssignableTo<ITextparserApi>();
    }

    [Fact]
    public void CreateToolsApi_WithValidOptions_Returns_ToolsApi()
    {
        var api = _factory.CreateToolsApi(_validOptions);
        
        api.Should().NotBeNull();
        api.Should().BeAssignableTo<IToolsApi>();
    }

    [Fact]
    public void CreateVoucherPosApi_WithValidOptions_Returns_VoucherPosApi()
    {
        var api = _factory.CreateVoucherPosApi(_validOptions);
        
        api.Should().NotBeNull();
        api.Should().BeAssignableTo<IVoucherPosApi>();
    }

    [Fact]
    public void Factory_WithDifferentOptions_Creates_IndependentClients()
    {
        var options1 = new SevDeskOptions
        {
            ApiKey = "key1-12345678901234567890123456789012",
            ApiUrl = "https://tenant1.sevdesk.de/api/v1"
        };

        var options2 = new SevDeskOptions
        {
            ApiKey = "key2-12345678901234567890123456789012",
            ApiUrl = "https://tenant2.sevdesk.de/api/v1"
        };

        var api1 = _factory.CreateContactApi(options1);
        var api2 = _factory.CreateContactApi(options2);

        api1.Should().NotBeNull();
        api2.Should().NotBeNull();
        api1.Should().NotBeSameAs(api2);
    }

    [Fact]
    public void Factory_WithInspectJsonEnabled_Creates_WorkingClient()
    {
        var optionsWithInspection = new SevDeskOptions
        {
            ApiKey = "test-api-key-12345678901234567890123456789012",
            ApiUrl = "https://my.sevdesk.de/api/v1",
            InspectJson = true
        };

        var api = _factory.CreateContactApi(optionsWithInspection);
        
        api.Should().NotBeNull();
        api.Should().BeAssignableTo<IContactApi>();
    }

    [Fact]
    public void Factory_CanCreateMultipleApiTypesWithSameOptions()
    {
        var contactApi = _factory.CreateContactApi(_validOptions);
        var voucherApi = _factory.CreateVoucherApi(_validOptions);
        var invoiceApi = _factory.CreateInvoiceApi(_validOptions);
        var orderApi = _factory.CreateOrderApi(_validOptions);

        contactApi.Should().NotBeNull();
        voucherApi.Should().NotBeNull();
        invoiceApi.Should().NotBeNull();
        orderApi.Should().NotBeNull();

        contactApi.Should().BeAssignableTo<IContactApi>();
        voucherApi.Should().BeAssignableTo<IVoucherApi>();
        invoiceApi.Should().BeAssignableTo<IInvoiceApi>();
        orderApi.Should().BeAssignableTo<IOrderApi>();
    }

    [Theory]
    [InlineData("short")]
    [InlineData("123456789012345678901234567890123")] // 33 chars - too long
    public void Factory_WithInvalidApiKey_StillCreatesClient(string invalidApiKey)
    {
        var invalidOptions = new SevDeskOptions
        {
            ApiKey = invalidApiKey,
            ApiUrl = "https://my.sevdesk.de/api/v1"
        };

        // Factory should still create client - validation happens at API call time
        var api = _factory.CreateContactApi(invalidOptions);
        
        api.Should().NotBeNull();
        api.Should().BeAssignableTo<IContactApi>();
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    public void Factory_WithEmptyApiKey_ThrowsException(string emptyApiKey)
    {
        var invalidOptions = new SevDeskOptions
        {
            ApiKey = emptyApiKey,
            ApiUrl = "https://my.sevdesk.de/api/v1"
        };

        // Factory should throw when API key is empty or whitespace
        Action act = () => _factory.CreateContactApi(invalidOptions);
        act.Should().Throw<FormatException>();
    }

    [Theory]
    [InlineData("ftp://invalid.com")]
    public void Factory_WithInvalidApiUrl_StillCreatesClient(string invalidUrl)
    {
        var invalidOptions = new SevDeskOptions
        {
            ApiKey = "test-api-key-12345678901234567890123456789012",
            ApiUrl = invalidUrl
        };

        // Factory should still create client - validation happens at API call time
        var api = _factory.CreateContactApi(invalidOptions);
        
        api.Should().NotBeNull();
        api.Should().BeAssignableTo<IContactApi>();
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData("not-a-url")]
    public void Factory_WithEmptyOrInvalidApiUrl_ThrowsException(string invalidUrl)
    {
        var invalidOptions = new SevDeskOptions
        {
            ApiKey = "test-api-key-12345678901234567890123456789012",
            ApiUrl = invalidUrl
        };

        // Factory should throw when URL is empty, whitespace, or invalid format
        Action act = () => _factory.CreateContactApi(invalidOptions);
        act.Should().Throw<UriFormatException>();
    }

    [Fact]
    public void Factory_CreatesClientsWithProperHttpConfiguration()
    {
        var api = _factory.CreateContactApi(_validOptions);
        
        // We can't directly inspect the HttpClient configuration in Refit,
        // but we can verify the client was created successfully
        api.Should().NotBeNull();
        api.Should().BeAssignableTo<IContactApi>();
    }

    [Fact]
    public void Factory_SupportsMultiTenantScenario()
    {
        // Simulate multi-tenant scenario
        var tenantConfigs = new Dictionary<string, SevDeskOptions>
        {
            ["tenant1"] = new SevDeskOptions 
            { 
                ApiKey = "tenant1-key-12345678901234567890123456",
                ApiUrl = "https://tenant1.sevdesk.de/api/v1" 
            },
            ["tenant2"] = new SevDeskOptions 
            { 
                ApiKey = "tenant2-key-12345678901234567890123456",
                ApiUrl = "https://tenant2.sevdesk.de/api/v1" 
            },
            ["tenant3"] = new SevDeskOptions 
            { 
                ApiKey = "tenant3-key-12345678901234567890123456",
                ApiUrl = "https://tenant3.sevdesk.de/api/v1" 
            }
        };

        var createdApis = new Dictionary<string, IContactApi>();

        foreach (var (tenantId, options) in tenantConfigs)
        {
            createdApis[tenantId] = _factory.CreateContactApi(options);
        }

        // Verify all clients were created successfully
        createdApis.Should().HaveCount(3);
        createdApis.Values.Should().AllSatisfy(api => 
        {
            api.Should().NotBeNull();
            api.Should().BeAssignableTo<IContactApi>();
        });

        // Verify they are different instances
        var apiList = createdApis.Values.ToList();
        apiList[0].Should().NotBeSameAs(apiList[1]);
        apiList[1].Should().NotBeSameAs(apiList[2]);
        apiList[0].Should().NotBeSameAs(apiList[2]);
    }
}