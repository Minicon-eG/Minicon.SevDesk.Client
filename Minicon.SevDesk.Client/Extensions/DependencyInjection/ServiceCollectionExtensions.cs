using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Minicon.SevDesk.Client.Api;
using Minicon.SevDesk.Client.Extensions.Models;
using Refit;

namespace Minicon.SevDesk.Client.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
	public static IServiceCollection AddSevdeskClient(this IServiceCollection services)
	{
		var apiInterfaces = new Type[]
		{
			typeof(IAccountingContactApi), typeof(IAccountingTypeApi), typeof(ICheckAccountApi),
			typeof(ICheckAccountTransactionApi), typeof(ICommunicationWayApi), typeof(IContactAddressApi),
			typeof(IContactApi), typeof(IContactCustomFieldApi), typeof(IContactCustomFieldSettingApi),
			typeof(IContactFieldApi), typeof(ICostCentreApi), typeof(ICreditNoteApi), typeof(ICreditNotePosApi),
			typeof(IDocServerApi), typeof(IExportApi), typeof(IExportJobApi), typeof(IInvoiceApi), typeof(IInvoicePosApi),
			typeof(ILayoutApi), typeof(IOrderApi), typeof(IOrderPosApi), typeof(IPartApi), typeof(IProgressApi),
			typeof(IReceiptGuidanceApi), typeof(IReportApi), typeof(ISaveVoucherApi), typeof(ISevClientApi),
			typeof(ISevUserApi), typeof(ITagApi), typeof(ITagRelationApi), typeof(ITextparserApi), typeof(IToolsApi),
			typeof(IVoucherApi), typeof(IVoucherPosApi)
		};

		services.AddTransient<ISupplierResolver, SupplierResolver>();
		services.AddTransient<JsonInspectingHandler>();
		services.AddSingleton<ISevDeskClientFactory, SevDeskClientFactory>();
		
		foreach (Type apiInterface in apiInterfaces)
		{
			services.AddRefitClient(apiInterface, RefitSettings())
				.ConfigureHttpClient(SetupRefitHttpClient)
				.AddHttpMessageHandler<JsonInspectingHandler>();
		}

		return services;
	}

	private static RefitSettings RefitSettings()
	{
		return new RefitSettings(new NewtonsoftJsonContentSerializer());
	}

	private static void SetupRefitHttpClient(IServiceProvider serviceProvider, HttpClient httpClient)
	{
		SevDeskOptions options = serviceProvider.GetRequiredService<IOptions<SevDeskOptions>>().Value;
		httpClient.BaseAddress = new Uri(options.ApiUrl);
		httpClient.DefaultRequestHeaders.Add(nameof(httpClient.DefaultRequestHeaders.Authorization), options.ApiKey);
	}
}
