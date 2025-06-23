using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Minicon.SevDesk.Client.Models;

/// <summary>
/// The objects wrapper in SaveVoucherResponse
/// </summary>
[DataContract]
public class SaveVoucherResponseObjects : IEquatable<SaveVoucherResponseObjects>, IValidatableObject
{
	/// <summary>
	/// Initializes a new instance of the <see cref="SaveVoucherResponseObjects" /> class.
	/// </summary>
	public SaveVoucherResponseObjects(
		ModelVoucherResponse voucher = default,
		List<ModelVoucherPosResponse> voucherPos = default,
		ModelDocumentResponse document = default,
		string vatdrop = default
	)
	{
		Voucher = voucher;
		VoucherPos = voucherPos ?? new List<ModelVoucherPosResponse>();
		Document = document;
		Vatdrop = vatdrop;
	}

	/// <summary>
	/// Gets or Sets Voucher
	/// </summary>
	[DataMember(Name = "voucher", EmitDefaultValue = false)]
	public ModelVoucherResponse Voucher { get; set; }

	/// <summary>
	/// Gets or Sets VoucherPos array
	/// </summary>
	[DataMember(Name = "voucherPos", EmitDefaultValue = false)]
	public List<ModelVoucherPosResponse> VoucherPos { get; set; }

	/// <summary>
	/// Gets or Sets Document
	/// </summary>
	[DataMember(Name = "document", EmitDefaultValue = false)]
	public ModelDocumentResponse Document { get; set; }

	/// <summary>
	/// Gets or Sets Vatdrop
	/// </summary>
	[DataMember(Name = "vatdrop", EmitDefaultValue = false)]
	public string Vatdrop { get; set; }

	/// <summary>
	/// Returns true if SaveVoucherResponseObjects instances are equal
	/// </summary>
	/// <param name="input">Instance of SaveVoucherResponseObjects to be compared</param>
	/// <returns>Boolean</returns>
	public bool Equals(SaveVoucherResponseObjects? input)
	{
		if (input == null)
		{
			return false;
		}

		return
			(
				Voucher == input.Voucher ||
				(Voucher != null &&
				 Voucher.Equals(input.Voucher))
			) &&
			(
				VoucherPos == input.VoucherPos ||
				(VoucherPos != null &&
				 VoucherPos.SequenceEqual(input.VoucherPos))
			) &&
			(
				Document == input.Document ||
				(Document != null &&
				 Document.Equals(input.Document))
			) &&
			(
				Vatdrop == input.Vatdrop ||
				(Vatdrop != null &&
				 Vatdrop.Equals(input.Vatdrop))
			);
	}

	/// <summary>
	/// To validate all properties of the instance
	/// </summary>
	/// <param name="validationContext">Validation context</param>
	/// <returns>Validation Result</returns>
	IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
	{
		yield break;
	}

	/// <summary>
	/// Returns the string presentation of the object
	/// </summary>
	/// <returns>String presentation of the object</returns>
	public override string ToString()
	{
		var sb = new StringBuilder();
		sb.Append("class SaveVoucherResponseObjects {\n");
		sb.Append("  Voucher: ").Append(Voucher).Append('\n');
		sb.Append("  VoucherPos: ").Append(VoucherPos).Append('\n');
		sb.Append("  Document: ").Append(Document).Append('\n');
		sb.Append("  Vatdrop: ").Append(Vatdrop).Append('\n');
		sb.Append("}\n");
		return sb.ToString();
	}

	/// <summary>
	/// Returns the JSON string presentation of the object
	/// </summary>
	/// <returns>JSON string presentation of the object</returns>
	public virtual string ToJson()
	{
		return JsonConvert.SerializeObject(this, Formatting.Indented);
	}

	/// <summary>
	/// Returns true if objects are equal
	/// </summary>
	/// <param name="input">Object to be compared</param>
	/// <returns>Boolean</returns>
	public override bool Equals(object input)
	{
		return Equals(input as SaveVoucherResponseObjects);
	}

	/// <summary>
	/// Gets the hash code
	/// </summary>
	/// <returns>Hash code</returns>
	public override int GetHashCode()
	{
		unchecked // Overflow is fine, just wrap
		{
			int hashCode = 41;
			if (Voucher != null)
			{
				hashCode = hashCode * 59 + Voucher.GetHashCode();
			}

			if (VoucherPos != null)
			{
				hashCode = hashCode * 59 + VoucherPos.GetHashCode();
			}

			if (Document != null)
			{
				hashCode = hashCode * 59 + Document.GetHashCode();
			}

			if (Vatdrop != null)
			{
				hashCode = hashCode * 59 + Vatdrop.GetHashCode();
			}

			return hashCode;
		}
	}
}