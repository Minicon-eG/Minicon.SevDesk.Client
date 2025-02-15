using System.ComponentModel.DataAnnotations;

namespace Minicon.SevDesk.Client;

public class SevDeskOptions
{
	public const string SectionName = "SevDesk";

	[Required]
	[StringLength(32, MinimumLength = 32)]
	public string ApiKey { get; init; } = "";

	[Required] [Url] public string ApiUrl { get; init; } = "";
	public bool InspectJson { get; set; }
}
