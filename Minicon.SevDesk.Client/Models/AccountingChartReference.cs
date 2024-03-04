namespace Minicon.SevDesk.Client.Models;

public class AccountingChartReference
{
	public AccountingChartReference(string id, string objectName = "AccountingChart")
	{
		Id = id;
		ObjectName = objectName;
	}
	public string Id { get; init; }
	public string ObjectName { get; init; }
}
