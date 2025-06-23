using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Minicon.SevDesk.Client.Models;

/// <summary>
///     SaveVoucherResponse
/// </summary>
[DataContract]
public class SaveVoucherResponse : IEquatable<SaveVoucherResponse>, IValidatableObject
{
	/// <summary>
	///     Initializes a new instance of the <see cref="SaveVoucherResponse" /> class.
	/// </summary>
	/// <param name="objects">The response objects wrapper</param>
	public SaveVoucherResponse(SaveVoucherResponseObjects objects = default)
	{
		Objects = objects;
	}

	/// <summary>
	///     Gets or Sets Objects wrapper containing voucher, voucherPos array, document and vatdrop
	/// </summary>
	[DataMember(Name = "objects", EmitDefaultValue = false)]
	public SaveVoucherResponseObjects Objects { get; set; }

	/// <summary>
	///     Returns true if SaveVoucherResponse instances are equal
	/// </summary>
	/// <param name="input">Instance of SaveVoucherResponse to be compared</param>
	/// <returns>Boolean</returns>
	public bool Equals(SaveVoucherResponse? input)
	{
		if (input == null)
		{
			return false;
		}

		return
			(
				Objects == input.Objects ||
				(Objects != null &&
				 Objects.Equals(input.Objects))
			);
	}

	/// <summary>
	///     To validate all properties of the instance
	/// </summary>
	/// <param name="validationContext">Validation context</param>
	/// <returns>Validation Result</returns>
	IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
	{
		yield break;
	}

	/// <summary>
	///     Returns the string presentation of the object
	/// </summary>
	/// <returns>String presentation of the object</returns>
	public override string ToString()
	{
		var sb = new StringBuilder();
		sb.Append("class SaveVoucherResponse {\n");
		sb.Append("  Objects: ").Append(Objects).Append('\n');
		sb.Append("}\n");
		return sb.ToString();
	}

	/// <summary>
	///     Returns the JSON string presentation of the object
	/// </summary>
	/// <returns>JSON string presentation of the object</returns>
	public virtual string ToJson()
	{
		return JsonConvert.SerializeObject(this, Formatting.Indented);
	}

	/// <summary>
	///     Returns true if objects are equal
	/// </summary>
	/// <param name="input">Object to be compared</param>
	/// <returns>Boolean</returns>
	public override bool Equals(object input)
	{
		return Equals(input as SaveVoucherResponse);
	}

	/// <summary>
	///     Gets the hash code
	/// </summary>
	/// <returns>Hash code</returns>
	public override int GetHashCode()
	{
		unchecked // Overflow is fine, just wrap
		{
			int hashCode = 41;
			if (Objects != null)
			{
				hashCode = hashCode * 59 + Objects.GetHashCode();
			}

			return hashCode;
		}
	}
}