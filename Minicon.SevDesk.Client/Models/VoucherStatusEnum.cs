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
public enum VoucherStatusEnum
{
	[EnumMember(Value = "50")] Draft = 1,
	[EnumMember(Value = "100")] UnpaidDue = 2,
	[EnumMember(Value = "150")] Transferred = 3,
	[EnumMember(Value = "750")] PartlyPaid = 4,
	[EnumMember(Value = "1000")] OPaid = 5
}
