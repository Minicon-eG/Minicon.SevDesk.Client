using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

/// <summary>
///     Model name
/// </summary>
/// <value>Model name</value>
[JsonConverter(typeof(StringEnumConverter))]
public enum ObjectNameEnum
{
	/// <summary>
	///     Enum Invoice for value: Invoice
	/// </summary>
	[EnumMember(Value = "Contact")] Contact = 1,

	/// <summary>
	///     Enum Invoice for value: Invoice
	/// </summary>
	[EnumMember(Value = "Invoice")] Invoice = 2,

	/// <summary>
	///     Enum Voucher for value: Voucher
	/// </summary>
	[EnumMember(Value = "Voucher")] Voucher = 4,

	/// <summary>
	///     Enum Order for value: Order
	/// </summary>
	[EnumMember(Value = "Order")] Order = 5,

	/// <summary>
	///     Enum CreditNote for value: CreditNote
	/// </summary>
	[EnumMember(Value = "CreditNote")] CreditNote = 5
}
