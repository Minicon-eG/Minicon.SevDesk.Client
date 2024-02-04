namespace Minicon.SevDesk.Client.Models;

public sealed class SaveVoucherRequest
{
	public bool ExistenceCheck { get; } = true;
	public List<ModelVoucherPosSave> VoucherPosSave { get; init; }
	public int Id { get; init; }

	public IEnumerable<KeyValuePair<string, string>> ToForm()
	{
		yield return new KeyValuePair<string, string>("existenceCheck", ExistenceCheck.ToString());
		yield return new KeyValuePair<string, string>("id", Id.ToString());

		for (int index = 0; index < VoucherPosSave.Count; index++)
		{
			yield return new KeyValuePair<string, string>(
				$"VoucherPosSave[{index}][id]",
				VoucherPosSave[index].Id
			);
			yield return new KeyValuePair<string, string>(
				$"VoucherPosSave[{index}][accountingType][id]",
				VoucherPosSave[index].AccountingType.Id
			);
			yield return new KeyValuePair<string, string>(
				$"VoucherPosSave[{index}][accountingType][objectName]",
				VoucherPosSave[index].AccountingType.ObjectName
			);
		}
	}
}
