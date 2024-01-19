namespace Minicon.SevDesk.Client.Models;

public class AccountingType
{
	public string Id { get; init; }
	public string ObjectName { get; init; }
	public string AdditionalInformation { get; init; }
	public string Uuid { get; init; }
	public string Uuid5 { get; init; }
	public string Create { get; init; }
	public string Update { get; init; }
	public SevClientReference SevClientReference { get; init; }
	public string Name { get; init; }
	public object Skr03 { get; init; }
	public object Skr03Depreciation { get; init; }
	public AccountingChartReference AccountingChartReference { get; init; }
	public object Skr04 { get; init; }
	public object Skr04Depreciation { get; init; }
	public object SkrAt { get; init; }
	public object SkrAtDepreciation { get; init; }
	public object SkrCh { get; init; }
	public object SkrChDepreciation { get; init; }
	public object SkrGr { get; init; }
	public object SkrGrDepreciation { get; init; }
	public string Type { get; init; }
	public string TranslationCode { get; init; }
	public string DescriptionTranslationCode { get; init; }
	public string ConnotationTranslationCode { get; init; }
	public string BookingType { get; init; }
	public string AssetType { get; init; }
	public string Status { get; init; }
	public string CorrectionType { get; init; }
	public string TaxCodeType { get; init; }
	public string Special { get; init; }
	public string ContraAccount { get; init; }
	public string Hidden { get; init; }
	public AccountingSystemNumber AccountingSystemNumber { get; init; }
}
