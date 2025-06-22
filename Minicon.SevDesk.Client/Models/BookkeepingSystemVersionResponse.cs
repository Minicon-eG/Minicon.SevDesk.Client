using Newtonsoft.Json;

namespace Minicon.SevDesk.Client.Models;

public class BookkeepingSystemVersionResponse
{
	[JsonProperty("objects")]
	public BookkeepingSystemVersionObject Objects { get; set; }
}