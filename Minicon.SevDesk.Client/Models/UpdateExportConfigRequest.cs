using Newtonsoft.Json;

namespace Minicon.SevDesk.Client.Models;

public class UpdateExportConfigRequest
{
	[JsonProperty("accountantNumber")]
	public int AccountantNumber { get; set; }

	[JsonProperty("accountantClientNumber")]
	public int AccountantClientNumber { get; set; }

	[JsonProperty("accountingYearBegin")]
	public string AccountingYearBegin { get; set; }
}