using Minicon.SevDesk.Client.Models;

namespace Minicon.SevDesk.Client.Extensions.Models;

public interface ISupplierResolver
{
	Task<string> SupplierAsync(ModelVoucherSupplier supplier);
	Task<string> SupplierAsync(ModelVoucherResponseSupplier supplier);
	Task<ModelVoucherResponseSupplier?> SupplierAsync(string supplier);
	Task<ModelVoucherSupplier> ToModelVoucherSupplierAsync(ModelVoucherResponseSupplier supplier);
}
