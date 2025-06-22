using Newtonsoft.Json;

namespace Minicon.SevDesk.Client.Models;

public class CreateFileImportAccountResponse
{
	[JsonProperty("objects")]
	public ModelCheckAccountResponse Objects { get; set; }
}