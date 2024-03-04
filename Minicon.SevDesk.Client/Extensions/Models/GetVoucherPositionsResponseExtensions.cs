using Minicon.SevDesk.Client.Models;

namespace Minicon.SevDesk.Client.Extensions.Models;

public static class GetVoucherPositionsResponseExtensions
{
	public static async Task<SaveVoucher> ToSaveVoucherAsync(this GetVoucherPositionsResponse origin,
		ModelVoucherResponse modelVoucher, ISupplierResolver supplierResolver)
	{
		return new SaveVoucher
		(
			await modelVoucher.ToModelVoucherAsync(supplierResolver),
			origin.ToModelVoucherPosArray(modelVoucher)
		);
	}

	public static ModelVoucherPos[]? ToModelVoucherPosArray(this GetVoucherPositionsResponse? origin,
		ModelVoucherResponse modelVoucher)
	{
		return origin?.Objects.Select(x => x.ToModelVoucherPos(modelVoucher)).ToArray();
	}

	public static ModelVoucherPos ToModelVoucherPos(this ModelVoucherPosResponse origin,
		ModelVoucherResponse modelVoucher)
	{
		return new ModelVoucherPos
		(
			new ModelVoucherPosSevClient(origin.SevClient.Id),
			new ModelVoucherPosVoucher(modelVoucher.Id),
			new ModelVoucherPosAccountingType(origin.AccountingType.Id),
			new ModelVoucherPosEstimatedAccountingType(origin.EstimatedAccountingType.Id),
			origin.TaxRate.ToDecimal(),
			origin.Net,
			origin.SumNet.ToDecimal(),
			origin.IsAsset,
			origin.Comment,
			origin.SumGross.ToDecimal()
		);
	}
}
