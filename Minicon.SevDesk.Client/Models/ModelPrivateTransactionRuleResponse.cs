using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Minicon.SevDesk.Client.Models;

/// <summary>
///     A rule defining which transactions to mark as private automatically.
/// </summary>
[DataContract]
public class ModelPrivateTransactionRuleResponse
{
	[DataMember(Name = "id", EmitDefaultValue = false)]
	[JsonProperty("id")]
	public string? Id { get; set; }

	[DataMember(Name = "objectName", EmitDefaultValue = false)]
	[JsonProperty("objectName")]
	public string? ObjectName { get; set; }

	[DataMember(Name = "create", EmitDefaultValue = false)]
	[JsonProperty("create")]
	public DateTime? Create { get; set; }

	[DataMember(Name = "update", EmitDefaultValue = false)]
	[JsonProperty("update")]
	public DateTime? Update { get; set; }

	[DataMember(Name = "sevClient", EmitDefaultValue = false)]
	[JsonProperty("sevClient")]
	public SevClientReference? SevClient { get; set; }

	/// <summary>The payment purpose of transactions to match.</summary>
	[DataMember(Name = "paymentPurpose", EmitDefaultValue = false)]
	[JsonProperty("paymentPurpose")]
	public string? PaymentPurpose { get; set; }

	/// <summary>The counterpart name of transactions to match.</summary>
	[DataMember(Name = "counterpartName", EmitDefaultValue = false)]
	[JsonProperty("counterpartName")]
	public string? CounterpartName { get; set; }

	[DataContract]
	public class SevClientReference
	{
		[DataMember(Name = "id", EmitDefaultValue = false)]
		[JsonProperty("id")]
		public string? Id { get; set; }

		[DataMember(Name = "objectName", EmitDefaultValue = false)]
		[JsonProperty("objectName")]
		public string? ObjectName { get; set; }
	}
}

/// <summary>
///     Wrapper response for collections of <see cref="ModelPrivateTransactionRuleResponse"/>.
/// </summary>
[DataContract]
public class GetPrivateTransactionRuleResponse
{
	[DataMember(Name = "objects", EmitDefaultValue = false)]
	[JsonProperty("objects")]
	public List<ModelPrivateTransactionRuleResponse>? Objects { get; set; }
}

/// <summary>
///     Wrapper response for a single <see cref="ModelPrivateTransactionRuleResponse"/>.
/// </summary>
[DataContract]
public class PrivateTransactionRuleResponse
{
	[DataMember(Name = "objects", EmitDefaultValue = false)]
	[JsonProperty("objects")]
	public ModelPrivateTransactionRuleResponse? Objects { get; set; }
}
