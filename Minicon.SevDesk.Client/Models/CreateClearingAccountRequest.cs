using Newtonsoft.Json;

namespace Minicon.SevDesk.Client.Models;

public class CreateClearingAccountRequest
{
	[JsonProperty("name")]
	public string Name { get; set; }

	[JsonProperty("type")]
	public string Type { get; set; } = "offline";

	[JsonProperty("currency")]
	public string Currency { get; set; } = "EUR";

	[JsonProperty("sevClient")]
	public SevClientReference SevClient { get; set; }
}