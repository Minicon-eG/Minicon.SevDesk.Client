namespace Minicon.SevDesk.Client.Models;

public class AccountingSystemNumber
{
	public string Id { get; init; }
	public string ObjectName { get; init; }
	public object AdditionalInformation { get; init; }
	public DateTime Create { get; init; }
	public DateTime Update { get; init; }
	public SevClientReference SevClientReference { get; init; }
	public string Number { get; init; }
	public object NumberDepreciation { get; init; }
	public AccountingTypeReference AccountingTypeReference { get; init; }
	public AccountingSystemReference AccountingSystemReference { get; init; }
	public object BookingType { get; init; }
}
