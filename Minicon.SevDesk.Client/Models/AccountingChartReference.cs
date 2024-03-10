namespace Minicon.SevDesk.Client.Models;

public record AccountingChartReference : ObjectInfo
{
	public AccountingChartReference(int id)
		: base(id, "AccountingChart")
	{
	}
}
