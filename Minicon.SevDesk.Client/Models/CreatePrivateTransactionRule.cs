using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Minicon.SevDesk.Client.Models;

/// <summary>
///     Request body for <c>POST /PrivateTransactionRule</c>.
/// </summary>
[DataContract]
public class CreatePrivateTransactionRule
{
	[DataMember(Name = "objectName", EmitDefaultValue = false)]
	[JsonProperty("objectName")]
	public string ObjectName { get; set; } = "PrivateTransactionRule";

	[DataMember(Name = "paymentPurpose", EmitDefaultValue = false)]
	[JsonProperty("paymentPurpose")]
	public string? PaymentPurpose { get; set; }

	[DataMember(Name = "counterpartName", EmitDefaultValue = false)]
	[JsonProperty("counterpartName")]
	public string? CounterpartName { get; set; }
}
