using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Minicon.SevDesk.Client.Models;

/// <summary>
///     Type of the voucher. For more information on the different types, check       &lt;a href&#x3D;&#x27;
///     https://api.sevdesk.de/#section/Types-and-status-of-vouchers&#x27;&gt;this&lt;/a&gt;
/// </summary>
/// <value>
///     Type of the voucher. For more information on the different types, check       &lt;a href&#x3D;&#x27;
///     https://api.sevdesk.de/#section/Types-and-status-of-vouchers&#x27;&gt;this&lt;/a&gt;
/// </value>
[JsonConverter(typeof(StringEnumConverter))]
public enum VoucherTypeEnum
{
	/// <summary>
	///     Enum VOU for value: VOU
	/// </summary>
	[EnumMember(Value = "VOU")] VOU = 1,

	/// <summary>
	///     Enum RV for value: RV
	/// </summary>
	[EnumMember(Value = "RV")] RV = 2,

	/// <summary>
	///     Enum VU for value: VU. Returned by the sevDesk API for vouchers in
	///     the &quot;voucher&quot; list (observed on /Voucher responses); not
	///     formally documented in the OpenAPI spec but appears on legacy /
	///     auto-imported vouchers. Without this member, Newtonsoft.Json fails
	///     the whole response with &quot;Requested value 'VU' was not found&quot;.
	/// </summary>
	[EnumMember(Value = "VU")] VU = 3
}
