using Minicon.SevDesk.Client.Models;

namespace Minicon.SevDesk.Client.Extensions.Models;

public static class GetVoucherPositionsResponseExtensions
{
	public static async Task<SaveVoucher> ToSaveVoucherAsync(
		this GetVoucherPositionsResponse origin,
		ModelVoucherResponse modelVoucher,
		ISupplierResolver supplierResolver,
		SaveVoucherVoucherPosDelete[]? voucherPosDeletes = null
	)
	{
		return new SaveVoucher
		(
			await modelVoucher.ToModelVoucherAsync(supplierResolver),
			origin.ToModelVoucherPosArray(modelVoucher),
			voucherPosDeletes

		);
	}

	public static ModelVoucherPos[] ToModelVoucherPosArray
	(this GetVoucherPositionsResponse origin,
		ModelVoucherResponse modelVoucher
	)
	{
		return origin.Objects?.Select(x => x.ToModelVoucherPos(modelVoucher)).ToArray()
		       ?? Array.Empty<ModelVoucherPos>();
	}

	public static ModelVoucherPos ToModelVoucherPos(this ModelVoucherPosResponse origin,
		ModelVoucherResponse modelVoucher)
	{
		return new ModelVoucherPos
		(
			new ModelVoucherPosSevClient(origin.SevClient.Id),
			new ModelVoucherPosVoucher(modelVoucher.Id),
			origin.AccountingType is null ? null : new ModelVoucherPosAccountingType(origin.AccountingType.Id),
			origin.EstimatedAccountingType is null
				? null
				: new ModelVoucherPosEstimatedAccountingType(origin.EstimatedAccountingType.Id),
			origin.TaxRate.ToDecimal(),
			origin.Net,
			origin.SumNet.ToDecimal(),
			origin.IsAsset,
			origin.Comment,
			origin.SumGross.ToDecimal()
		);
	}
}
