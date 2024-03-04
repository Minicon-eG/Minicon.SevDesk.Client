using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Minicon.SevDesk.Client.Api;
using Minicon.SevDesk.Client.Extensions.Models;
using Minicon.SevDesk.Client.Logging;
using Refit;

namespace Minicon.SevDesk.Client.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
	public static IServiceCollection AddSevdeskClient(this IServiceCollection services)
	{
		services.AddTransient<ISupplierResolver, SupplierResolver>();
		services.AddRefitClient<IAccountingContactApi>(RefitSettings())
			.ConfigureHttpClient(SetupRefitHttpClient);
		services.AddRefitClient<IAccountingTypeApi>(RefitSettings())
			.ConfigureHttpClient(SetupRefitHttpClient);
		services.AddRefitClient<ICheckAccountApi>(RefitSettings())
			.ConfigureHttpClient(SetupRefitHttpClient);
		services.AddRefitClient<ICheckAccountTransactionApi>(RefitSettings())
			.ConfigureHttpClient(SetupRefitHttpClient);
		services.AddRefitClient<ICommunicationWayApi>(RefitSettings())
			.ConfigureHttpClient(SetupRefitHttpClient);
		services.AddRefitClient<IContactAddressApi>(RefitSettings())
			.ConfigureHttpClient(SetupRefitHttpClient);

		services.AddTransient<LoggingHttpMessageHandler<IContactApi>>();
		services.AddRefitClient<IContactApi>(RefitSettings())
			.ConfigureHttpClient(SetupRefitHttpClient)
			.AddHttpMessageHandler<LoggingHttpMessageHandler<IContactApi>>();


		services.AddRefitClient<IContactFieldApi>(RefitSettings())
			.ConfigureHttpClient(SetupRefitHttpClient);
		services.AddRefitClient<ICostCentreApi>(RefitSettings())
			.ConfigureHttpClient(SetupRefitHttpClient);
		services.AddRefitClient<ICreditNoteApi>(RefitSettings())
			.ConfigureHttpClient(SetupRefitHttpClient);
		services.AddRefitClient<ICreditNotePosApi>(RefitSettings())
			.ConfigureHttpClient(SetupRefitHttpClient);
		services.AddRefitClient<IExportApi>(RefitSettings())
			.ConfigureHttpClient(SetupRefitHttpClient);
		services.AddRefitClient<IInvoiceApi>(RefitSettings())
			.ConfigureHttpClient(SetupRefitHttpClient);
		services.AddRefitClient<IInvoicePosApi>(RefitSettings())
			.ConfigureHttpClient(SetupRefitHttpClient);
		services.AddRefitClient<ILayoutApi>(RefitSettings())
			.ConfigureHttpClient(SetupRefitHttpClient);
		services.AddRefitClient<IOrderApi>(RefitSettings())
			.ConfigureHttpClient(SetupRefitHttpClient);
		services.AddRefitClient<IOrderPosApi>(RefitSettings())
			.ConfigureHttpClient(SetupRefitHttpClient);
		services.AddRefitClient<IPartApi>(RefitSettings())
			.ConfigureHttpClient(SetupRefitHttpClient);
		services.AddRefitClient<IReportApi>(RefitSettings())
			.ConfigureHttpClient(SetupRefitHttpClient);
		services.AddRefitClient<ISaveVoucherApi>(RefitSettings())
			.ConfigureHttpClient(SetupRefitHttpClient);
		services.AddRefitClient<ITagApi>(RefitSettings())
			.ConfigureHttpClient(SetupRefitHttpClient);
		services.AddRefitClient<IVoucherApi>(RefitSettings())
			.ConfigureHttpClient(SetupRefitHttpClient);
		services.AddRefitClient<IVoucherPosApi>(RefitSettings())
			.ConfigureHttpClient(SetupRefitHttpClient);
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
