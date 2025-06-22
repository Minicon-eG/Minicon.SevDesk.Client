using Newtonsoft.Json;

namespace Minicon.SevDesk.Client.Models;

public class CreateClearingAccountResponse
{
	[JsonProperty("objects")]
	public ModelCheckAccountResponse Objects { get; set; }
}