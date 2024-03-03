using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Minicon.SevDesk.Client.Models;

/// <summary>
///     The DateInterval in which recurring vouchers are generated.&lt;br&gt;       Necessary attribute for all recurring
///     vouchers.
/// </summary>
/// <value>
///     The DateInterval in which recurring vouchers are generated.&lt;br&gt;       Necessary attribute for all
///     recurring vouchers.
/// </value>
/// <summary>
///     Please have a look in       &lt;a href&#x3D;&#x27;https://api.sevdesk.de/#section/Types-and-status-of-vouchers
///     &#x27;&gt;status of vouchers&lt;/a&gt;      to see what the different status codes mean
/// </summary>
/// <value>
///     Please have a look in       &lt;a href&#x3D;&#x27;https://api.sevdesk.de/#section/Types-and-status-of-vouchers
///     &#x27;&gt;status of vouchers&lt;/a&gt;      to see what the different status codes mean
/// </value>
[JsonConverter(typeof(StringEnumConverter))]
public enum StatusEnum
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
