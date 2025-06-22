using Newtonsoft.Json;

namespace Minicon.SevDesk.Client.Models;

public class UpdateExportConfigResponse
{
	[JsonProperty("status")]
	public string Status { get; set; }

	[JsonProperty("message")]
	public string Message { get; set; }
}