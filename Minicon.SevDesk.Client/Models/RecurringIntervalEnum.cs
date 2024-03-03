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
[JsonConverter(typeof(StringEnumConverter))]
public enum RecurringIntervalEnum
{
	/// <summary>
	///     Enum P0Y0M1W for value: P0Y0M1W
	/// </summary>
	[EnumMember(Value = "P0Y0M1W")] P0Y0M1W = 1,

	/// <summary>
	///     Enum P0Y0M2W for value: P0Y0M2W
	/// </summary>
	[EnumMember(Value = "P0Y0M2W")] P0Y0M2W = 2,

	/// <summary>
	///     Enum P0Y1M0W for value: P0Y1M0W
	/// </summary>
	[EnumMember(Value = "P0Y1M0W")] P0Y1M0W = 3,

	/// <summary>
	///     Enum P0Y3M0W for value: P0Y3M0W
	/// </summary>
	[EnumMember(Value = "P0Y3M0W")] P0Y3M0W = 4,

	/// <summary>
	///     Enum P0Y6M0W for value: P0Y6M0W
	/// </summary>
	[EnumMember(Value = "P0Y6M0W")] P0Y6M0W = 5,

	/// <summary>
	///     Enum P1Y0M0W for value: P1Y0M0W
	/// </summary>
	[EnumMember(Value = "P1Y0M0W")] P1Y0M0W = 6,

	/// <summary>
	///     Enum P2Y0M0W for value: P2Y0M0W
	/// </summary>
	[EnumMember(Value = "P2Y0M0W")] P2Y0M0W = 7,

	/// <summary>
	///     Enum P3Y0M0W for value: P3Y0M0W
	/// </summary>
	[EnumMember(Value = "P3Y0M0W")] P3Y0M0W = 8,

	/// <summary>
	///     Enum P4Y0M0W for value: P4Y0M0W
	/// </summary>
	[EnumMember(Value = "P4Y0M0W")] P4Y0M0W = 9,

	/// <summary>
	///     Enum P5Y0M0W for value: P5Y0M0W
	/// </summary>
	[EnumMember(Value = "P5Y0M0W")] P5Y0M0W = 10
}
