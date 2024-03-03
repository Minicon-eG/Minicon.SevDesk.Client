using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Minicon.SevDesk.Client.Models;

/// <summary>
///     Defines if your voucher is a credit (C) or debit (D)
/// </summary>
/// <value>Defines if your voucher is a credit (C) or debit (D)</value>
[JsonConverter(typeof(StringEnumConverter))]
public enum CreditDebitEnum
{
	/// <summary>
	///     Enum C for value: C
	/// </summary>
	[EnumMember(Value = "C")] C = 1,

	/// <summary>
	///     Enum D for value: D
	/// </summary>
	[EnumMember(Value = "D")] D = 2
}
