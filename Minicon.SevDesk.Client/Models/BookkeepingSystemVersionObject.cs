using Newtonsoft.Json;

namespace Minicon.SevDesk.Client.Models;

public class BookkeepingSystemVersionObject
{
    [JsonProperty("version")]
    public string Version { get; set; }
}