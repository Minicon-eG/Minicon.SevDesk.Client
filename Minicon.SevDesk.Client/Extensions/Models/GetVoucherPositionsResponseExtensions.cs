using Minicon.SevDesk.Client.Models;

namespace Minicon.SevDesk.Client.Extensions.Models;

public static class GetVoucherPositionsResponseExtensions
{
	public static SaveVoucher ToSaveVoucher(this GetVoucherPositionsResponse origin, ModelVoucherResponse modelVoucher)
	{
		return new SaveVoucher
		(
			modelVoucher.ToModelVoucher(),
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
			TaxRateToFloatOrNull(origin),
			origin.Net,
			origin.IsAsset,
			origin.SumNet.ToFloatOrNull(),
			origin.SumGross.ToFloatOrNull(),
			origin.Comment
		);
	}

	private static float? TaxRateToFloatOrNull(ModelVoucherPosResponse origin)
	{
		return string.IsNullOrWhiteSpace(origin.TaxRate) ? null : float.Parse(origin.TaxRate);
	}
}
