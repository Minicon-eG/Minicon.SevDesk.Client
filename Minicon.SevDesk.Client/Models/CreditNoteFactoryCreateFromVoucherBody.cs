using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Minicon.SevDesk.Client.Models;

/// <summary>
///     Request body for <c>POST /CreditNote/Factory/createFromVoucher</c>.
///     Not supported with sevdesk-Update 2.0.
/// </summary>
[DataContract]
public class CreditNoteFactoryCreateFromVoucherBody
{
	[DataMember(Name = "voucher", EmitDefaultValue = false)]
	[JsonProperty("voucher")]
	public VoucherReference Voucher { get; set; } = new();

	[DataContract]
	public class VoucherReference
	{
		[DataMember(Name = "id", EmitDefaultValue = false)]
		[JsonProperty("id")]
		public int Id { get; set; }

		[DataMember(Name = "objectName", EmitDefaultValue = false)]
		[JsonProperty("objectName")]
		public string ObjectName { get; set; } = "Voucher";
	}
}
