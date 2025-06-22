using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Minicon.SevDesk.Client.Api;
using Minicon.SevDesk.Client.Logging;
using Refit;
using System.Net.Http;

namespace Minicon.SevDesk.Client;

public class SevDeskClientFactory : ISevDeskClientFactory
{
    private readonly ILoggerFactory _loggerFactory;
    private readonly IServiceProvider _serviceProvider;

    public SevDeskClientFactory(ILoggerFactory loggerFactory, IServiceProvider serviceProvider)
    {
        _loggerFactory = loggerFactory;
        _serviceProvider = serviceProvider;
    }

    public IAccountingContactApi CreateAccountingContactApi(SevDeskOptions options) => CreateApiClient<IAccountingContactApi>(options);
    public IAccountingTypeApi CreateAccountingTypeApi(SevDeskOptions options) => CreateApiClient<IAccountingTypeApi>(options);
    public ICheckAccountApi CreateCheckAccountApi(SevDeskOptions options) => CreateApiClient<ICheckAccountApi>(options);
    public ICheckAccountTransactionApi CreateCheckAccountTransactionApi(SevDeskOptions options) => CreateApiClient<ICheckAccountTransactionApi>(options);
    public ICommunicationWayApi CreateCommunicationWayApi(SevDeskOptions options) => CreateApiClient<ICommunicationWayApi>(options);
    public IContactApi CreateContactApi(SevDeskOptions options) => CreateApiClient<IContactApi>(options);
    public IContactAddressApi CreateContactAddressApi(SevDeskOptions options) => CreateApiClient<IContactAddressApi>(options);
    public IContactFieldApi CreateContactFieldApi(SevDeskOptions options) => CreateApiClient<IContactFieldApi>(options);
    public ICostCentreApi CreateCostCentreApi(SevDeskOptions options) => CreateApiClient<ICostCentreApi>(options);
    public ICreditNoteApi CreateCreditNoteApi(SevDeskOptions options) => CreateApiClient<ICreditNoteApi>(options);
    public ICreditNotePosApi CreateCreditNotePosApi(SevDeskOptions options) => CreateApiClient<ICreditNotePosApi>(options);
    public IExportApi CreateExportApi(SevDeskOptions options) => CreateApiClient<IExportApi>(options);
    public IExportJobApi CreateExportJobApi(SevDeskOptions options) => CreateApiClient<IExportJobApi>(options);
    public IInvoiceApi CreateInvoiceApi(SevDeskOptions options) => CreateApiClient<IInvoiceApi>(options);
    public IInvoicePosApi CreateInvoicePosApi(SevDeskOptions options) => CreateApiClient<IInvoicePosApi>(options);
    public ILayoutApi CreateLayoutApi(SevDeskOptions options) => CreateApiClient<ILayoutApi>(options);
    public IOrderApi CreateOrderApi(SevDeskOptions options) => CreateApiClient<IOrderApi>(options);
    public IOrderPosApi CreateOrderPosApi(SevDeskOptions options) => CreateApiClient<IOrderPosApi>(options);
    public IPartApi CreatePartApi(SevDeskOptions options) => CreateApiClient<IPartApi>(options);
    public IProgressApi CreateProgressApi(SevDeskOptions options) => CreateApiClient<IProgressApi>(options);
    public IReportApi CreateReportApi(SevDeskOptions options) => CreateApiClient<IReportApi>(options);
    public ISaveVoucherApi CreateSaveVoucherApi(SevDeskOptions options) => CreateApiClient<ISaveVoucherApi>(options);
    public ITagApi CreateTagApi(SevDeskOptions options) => CreateApiClient<ITagApi>(options);
    public IVoucherApi CreateVoucherApi(SevDeskOptions options) => CreateApiClient<IVoucherApi>(options);
    public IVoucherPosApi CreateVoucherPosApi(SevDeskOptions options) => CreateApiClient<IVoucherPosApi>(options);

    private T CreateApiClient<T>(SevDeskOptions options)
    {
        var primaryHandler = CreateHttpMessageHandler(options);
        var loggingHandler = new LoggingHttpMessageHandler<T>(_loggerFactory.CreateLogger<T>())
        {
            InnerHandler = primaryHandler
        };

        var httpClient = new HttpClient(loggingHandler)
        {
            BaseAddress = new Uri(options.ApiUrl)
        };
        
        httpClient.DefaultRequestHeaders.Add("Authorization", options.ApiKey);

        var refitSettings = new RefitSettings(new NewtonsoftJsonContentSerializer());
        return RestService.For<T>(httpClient, refitSettings);
    }

    private HttpMessageHandler CreateHttpMessageHandler(SevDeskOptions options)
    {
        var handler = new HttpClientHandler();
        
        if (options.InspectJson)
        {
            var logger = _loggerFactory.CreateLogger<JsonInspectingHandler>();
            var optionsWrapper = new OptionsWrapper<SevDeskOptions>(options);
            var optionsMonitor = new OptionsMonitor<SevDeskOptions>(optionsWrapper);
            
            return new JsonInspectingHandler(logger, optionsMonitor)
            {
                InnerHandler = handler
            };
        }
        
        return handler;
    }
}

internal class OptionsMonitor<T> : IOptionsMonitor<T> where T : class
{
    private readonly IOptions<T> _options;

    public OptionsMonitor(IOptions<T> options)
    {
        _options = options;
    }

    public T CurrentValue => _options.Value;

    public T Get(string name) => _options.Value;

    public IDisposable OnChange(Action<T, string> listener) => new NullDisposable();

    private class NullDisposable : IDisposable
    {
        public void Dispose() { }
    }
}