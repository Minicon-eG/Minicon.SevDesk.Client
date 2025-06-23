using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Minicon.SevDesk.Client.Models;

/// <summary>
/// Response model for creating a contact
/// </summary>
[DataContract]
public class CreateContactResponse : IEquatable<CreateContactResponse>, IValidatableObject
{
	/// <summary>
	/// Initializes a new instance of the <see cref="CreateContactResponse" /> class.
	/// </summary>
	/// <param name="objects">The created contact object.</param>
	public CreateContactResponse(ModelContactResponse objects = default)
	{
		Objects = objects;
	}

	/// <summary>
	/// Gets or Sets the created contact object
	/// </summary>
	[DataMember(Name = "objects", EmitDefaultValue = false)]
	public ModelContactResponse Objects { get; set; }

	/// <summary>
	/// Returns true if CreateContactResponse instances are equal
	/// </summary>
	/// <param name="input">Instance of CreateContactResponse to be compared</param>
	/// <returns>Boolean</returns>
	public bool Equals(CreateContactResponse? input)
	{
		if (input == null)
		{
			return false;
		}

		return
			Objects == input.Objects ||
			(Objects != null &&
			 Objects.Equals(input.Objects));
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
		sb.Append("class CreateContactResponse {\n");
		sb.Append("  Objects: ").Append(Objects).Append('\n');
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
		return Equals(input as CreateContactResponse);
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
			if (Objects != null)
			{
				hashCode = hashCode * 59 + Objects.GetHashCode();
			}

			return hashCode;
		}
	}
}