using Minicon.SevDesk.Client.Models;

namespace Minicon.SevDesk.Client.Extensions.Models;

public static class ModelVoucherResponseDocumentExtensions
{
	public static ModelVoucherUpdateDocument ToModelVoucherUpdateDocument(this ModelVoucherResponseDocument origin)
	{
		return new ModelVoucherUpdateDocument(int.Parse(origin.Id));
	}
}
