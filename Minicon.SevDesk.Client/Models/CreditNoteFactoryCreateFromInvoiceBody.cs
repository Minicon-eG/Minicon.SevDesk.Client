using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Minicon.SevDesk.Client.Models;

/// <summary>
///     Request body for <c>POST /CreditNote/Factory/createFromInvoice</c>.
/// </summary>
[DataContract]
public class CreditNoteFactoryCreateFromInvoiceBody
{
	[DataMember(Name = "invoice", EmitDefaultValue = false)]
	[JsonProperty("invoice")]
	public InvoiceReference Invoice { get; set; } = new();

	[DataContract]
	public class InvoiceReference
	{
		[DataMember(Name = "id", EmitDefaultValue = false)]
		[JsonProperty("id")]
		public int Id { get; set; }

		[DataMember(Name = "objectName", EmitDefaultValue = false)]
		[JsonProperty("objectName")]
		public string ObjectName { get; set; } = "Invoice";
	}
}
