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
			typeof(IContactFieldApi), typeof(ICostCentreApi), typeof(ICreditNoteApi), typeof(ICreditNotePosApi),
			typeof(IExportApi), typeof(IInvoiceApi), typeof(IInvoicePosApi), typeof(ILayoutApi), typeof(IOrderApi),
			typeof(IOrderPosApi), typeof(IPartApi), typeof(IReportApi), typeof(ISaveVoucherApi), typeof(ITagApi),
			typeof(IVoucherApi), typeof(IVoucherPosApi), typeof(IContactApi)
		};

		services.AddTransient<ISupplierResolver, SupplierResolver>();

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
		httpClient.DefaultRequestHeaders.Add("Authorization", options.ApiKey);
	}
}
