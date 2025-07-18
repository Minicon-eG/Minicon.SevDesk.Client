using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Minicon.SevDesk.Client.Models;

/// <summary>
///     GetSevUserResponse
/// </summary>
[DataContract]
public class GetSevUserResponse : Pageable, IEquatable<GetSevUserResponse>, IValidatableObject
{
	/// <summary>
	///     Initializes a new instance of the <see cref="GetSevUserResponse" /> class.
	/// </summary>
	/// <param name="objects">objects.</param>
	public GetSevUserResponse(List<SevUserResponse> objects = default)
	{
		Objects = objects;
	}

	/// <summary>
	///     Gets or Sets Objects
	/// </summary>
	[DataMember(Name = "objects", EmitDefaultValue = false)]
	public List<SevUserResponse> Objects { get; set; }

	/// <summary>
	///     Returns true if GetSevUserResponse instances are equal
	/// </summary>
	/// <param name="input">Instance of GetSevUserResponse to be compared</param>
	/// <returns>Boolean</returns>
	public bool Equals(GetSevUserResponse? input)
	{
		if (input == null)
		{
			return false;
		}

		return
			Objects == input.Objects ||
			(Objects != null &&
			 input.Objects != null &&
			 Objects.SequenceEqual(input.Objects));
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
		sb.Append("class GetSevUserResponse {\n");
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
		return Equals(input as GetSevUserResponse);
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