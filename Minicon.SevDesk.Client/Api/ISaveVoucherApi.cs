using Minicon.SevDesk.Client.Models;
using Refit;

namespace Minicon.SevDesk.Client.Api;

public interface ISaveVoucherApi
{
	// embed=accountingType,accountingType.accountingSystemNumber,supplier,object,additionalInfo,debit,acquisitionCostReference,propertyIsFirstVisit,accountDatev,propertyCateringTipForeignCurrency
	// &cft=e31a6df1c9b18aecb4b9c42044440bc1
	[Multipart]
	[Post("/Voucher/Factory/saveVoucher")]
	Task<SaveVoucherResponse> SaveVoucherAsync(
		SaveVoucher request
	);
}

