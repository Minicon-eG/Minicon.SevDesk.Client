using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Minicon.SevDesk.Client.Models;

[JsonConverter(typeof(StringEnumConverter))]
public enum InvoiceStatusEnum
{
	/// <summary>
	///     Enum _50 for value: 50
	/// </summary>
	[EnumMember(Value = "50")] DeactivatedRecurringInvoice = 1,

	/// <summary>
	///     Enum _100 for value: 100
	/// </summary>
	[EnumMember(Value = "100")] Draft = 2,

	/// <summary>
	///     Enum _100 for value: 100
	/// </summary>
	[EnumMember(Value = "200")] OpenOrDue = 3,

	/// <summary>
	///     Enum _1000 for value: 1000
	/// </summary>
	[EnumMember(Value = "1000")] Payed = 4
}
