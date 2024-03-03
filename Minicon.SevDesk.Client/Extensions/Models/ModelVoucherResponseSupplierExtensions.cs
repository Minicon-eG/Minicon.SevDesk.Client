using Minicon.SevDesk.Client.Models;

namespace Minicon.SevDesk.Client.Extensions.Models;

public static class ModelVoucherResponseSupplierExtensions
{
	public static ModelVoucherSupplier? ToModelVoucherSupplier(this ModelVoucherResponseSupplier? origin)
	{
		return origin is null ? null : new ModelVoucherSupplier(int.Parse(origin.Id));
	}
}
