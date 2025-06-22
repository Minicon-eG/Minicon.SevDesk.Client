using Newtonsoft.Json;

namespace Minicon.SevDesk.Client.Models;

public class CreateFileImportAccountRequest
{
	[JsonProperty("name")]
	public string Name { get; set; }

	[JsonProperty("type")]
	public string Type { get; set; } = "online";

	[JsonProperty("importType")]
	public string ImportType { get; set; } = "CSV";

	[JsonProperty("currency")]
	public string Currency { get; set; } = "EUR";

	[JsonProperty("sevClient")]
	public SevClientReference SevClient { get; set; }
}