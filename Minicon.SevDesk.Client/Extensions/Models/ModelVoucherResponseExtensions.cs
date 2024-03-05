using Minicon.SevDesk.Client.Models;

namespace Minicon.SevDesk.Client.Extensions.Models;

public static class ModelVoucherResponseExtensions
{
	public static async Task<SaveVoucher> ToSaveVoucherAsync(
		this ModelVoucherResponse origin,
		GetVoucherPositionsResponse pos,
		ISupplierResolver supplierResolver,
		SaveVoucherVoucherPosDelete[]? voucherPosDeletes = null
	)
	{
		return new SaveVoucher
		(
			await origin.ToModelVoucherAsync(supplierResolver),
			pos.ToModelVoucherPosArray(origin),
			voucherPosDeletes
		);
	}

	public static async Task<ModelVoucher> ToModelVoucherAsync(this ModelVoucherResponse origin,
		ISupplierResolver supplierResolver)
	{
#pragma warning disable CA2208
		if (origin.SupplierName is null)
		{
			if (origin.Supplier is null)
			{
				throw new ArgumentNullException(nameof(origin.Supplier) + " and " + nameof(origin.SupplierName));
			}
		}

		if (origin.VoucherType is null)
		{
			throw new ArgumentNullException(nameof(origin.VoucherType));
		}
#pragma warning restore CA2208

		return new ModelVoucher(
			id: origin.Id,
			currency: origin.Currency,
			description: origin.Description,
			document: origin.Document.ToModelVoucherUpdateDocument(),
			status: OriginStatus(origin),
			supplier: origin.Supplier!.ToModelVoucherSupplier(),
			costCentre: CostCentre(origin),
			createUser: CreateUser(origin),
			creditDebit: OriginCreditDebit(origin),
			deliveryDate: origin.DeliveryDate,
			payDate: origin.PayDate,
			paymentDeadline: origin.PaymentDeadline,
			sevClient: SevClient(origin),
			taxSet: TaxSet(origin),
			supplierName: origin.SupplierName ?? await supplierResolver.SupplierAsync(origin.Supplier!),
			taxType: origin.TaxType,
			voucherDate: origin.VoucherDate,
			voucherType: origin.VoucherType ?? VoucherTypeEnum.VOU,
			deliveryDateUntil: origin.DeliveryDateUntil,
			propertyExchangeRate: PropertyExchangeRate(origin),
			propertyForeignCurrencyDeadline: origin.PropertyForeignCurrencyDeadline
		);
	}

	private static CreditDebitEnum OriginCreditDebit(ModelVoucherResponse origin)
	{
		return origin.CreditDebit ?? CreditDebitEnum.C;
	}

	private static float? PropertyExchangeRate(ModelVoucherResponse origin)
	{
		return string.IsNullOrWhiteSpace(origin.PropertyExchangeRate) ? null : float.Parse(origin.PropertyExchangeRate);
	}

	private static VoucherStatusEnum OriginStatus(ModelVoucherResponse origin)
	{
		return origin.Status ?? VoucherStatusEnum.Draft;
	}

	private static ModelVoucherUpdateTaxSet? TaxSet(ModelVoucherResponse origin)
	{
		return origin.TaxSet is null ? null : new ModelVoucherUpdateTaxSet(int.Parse(origin.TaxSet.Id));
	}

	private static ModelVoucherSevClient SevClient(ModelVoucherResponse origin)
	{
		return new ModelVoucherSevClient(int.Parse(origin.SevClient.Id));
	}

	private static ModelVoucherUpdateCostCentre? CostCentre(ModelVoucherResponse origin)
	{
		return origin.CostCentre is null
			? null
			: new ModelVoucherUpdateCostCentre(int.Parse(origin.CostCentre!.Id));
	}

	private static ModelVoucherCreateUser CreateUser(ModelVoucherResponse origin)
	{
		return new ModelVoucherCreateUser(int.Parse(origin.CreateUser.Id));
	}
}
