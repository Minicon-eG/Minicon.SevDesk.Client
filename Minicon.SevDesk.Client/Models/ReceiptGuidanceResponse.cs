using System.Collections.Generic;
using Newtonsoft.Json;

namespace Minicon.SevDesk.Client.Models;

public class ReceiptGuidanceResponse
{
	[JsonProperty("objects")]
	public List<ReceiptGuideDto> Objects { get; set; }
}