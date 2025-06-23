using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Minicon.SevDesk.Client.Models;

/// <summary>
/// Document model for responses
/// </summary>
[DataContract]
public class ModelDocumentResponse : IEquatable<ModelDocumentResponse>, IValidatableObject
{
	/// <summary>
	/// Initializes a new instance of the <see cref="ModelDocumentResponse" /> class.
	/// </summary>
	public ModelDocumentResponse()
	{
	}

	/// <summary>
	/// The document id
	/// </summary>
	[DataMember(Name = "id", EmitDefaultValue = false)]
	public string Id { get; set; }

	/// <summary>
	/// The document object name
	/// </summary>
	[DataMember(Name = "objectName", EmitDefaultValue = false)]
	public string ObjectName { get; set; }

	/// <summary>
	/// Additional information for the document
	/// </summary>
	[DataMember(Name = "additionalInformation", EmitDefaultValue = false)]
	public string AdditionalInformation { get; set; }

	/// <summary>
	/// Date of document creation
	/// </summary>
	[DataMember(Name = "create", EmitDefaultValue = false)]
	public DateTime? Create { get; set; }

	/// <summary>
	/// Date of last update
	/// </summary>
	[DataMember(Name = "update", EmitDefaultValue = false)]
	public DateTime? Update { get; set; }

	/// <summary>
	/// Document number
	/// </summary>
	[DataMember(Name = "documentNumber", EmitDefaultValue = false)]
	public string DocumentNumber { get; set; }

	/// <summary>
	/// Create user
	/// </summary>
	[DataMember(Name = "createUser", EmitDefaultValue = false)]
	public object CreateUser { get; set; }

	/// <summary>
	/// Update user
	/// </summary>
	[DataMember(Name = "updateUser", EmitDefaultValue = false)]
	public object UpdateUser { get; set; }

	/// <summary>
	/// Mime type
	/// </summary>
	[DataMember(Name = "mimeType", EmitDefaultValue = false)]
	public string MimeType { get; set; }

	/// <summary>
	/// Description
	/// </summary>
	[DataMember(Name = "description", EmitDefaultValue = false)]
	public string Description { get; set; }

	/// <summary>
	/// SevClient
	/// </summary>
	[DataMember(Name = "sevClient", EmitDefaultValue = false)]
	public object SevClient { get; set; }

	/// <summary>
	/// Filename (hash)
	/// </summary>
	[DataMember(Name = "filename", EmitDefaultValue = false)]
	public string Filename { get; set; }

	/// <summary>
	/// Status
	/// </summary>
	[DataMember(Name = "status", EmitDefaultValue = false)]
	public string Status { get; set; }

	/// <summary>
	/// File extension
	/// </summary>
	[DataMember(Name = "extension", EmitDefaultValue = false)]
	public string Extension { get; set; }

	/// <summary>
	/// File size in bytes
	/// </summary>
	[DataMember(Name = "filesize", EmitDefaultValue = false)]
	public string Filesize { get; set; }

	/// <summary>
	/// Content hash
	/// </summary>
	[DataMember(Name = "contentHash", EmitDefaultValue = false)]
	public string ContentHash { get; set; }

	/// <summary>
	/// Returns true if ModelDocumentResponse instances are equal
	/// </summary>
	/// <param name="input">Instance of ModelDocumentResponse to be compared</param>
	/// <returns>Boolean</returns>
	public bool Equals(ModelDocumentResponse? input)
	{
		if (input == null)
		{
			return false;
		}

		return
			(
				Id == input.Id ||
				(Id != null &&
				 Id.Equals(input.Id))
			) &&
			(
				ObjectName == input.ObjectName ||
				(ObjectName != null &&
				 ObjectName.Equals(input.ObjectName))
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
		sb.Append("class ModelDocumentResponse {\n");
		sb.Append("  Id: ").Append(Id).Append('\n');
		sb.Append("  ObjectName: ").Append(ObjectName).Append('\n');
		sb.Append("  Filename: ").Append(Filename).Append('\n');
		sb.Append("  Extension: ").Append(Extension).Append('\n');
		sb.Append("  Filesize: ").Append(Filesize).Append('\n');
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
		return Equals(input as ModelDocumentResponse);
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
			if (Id != null)
			{
				hashCode = hashCode * 59 + Id.GetHashCode();
			}

			if (ObjectName != null)
			{
				hashCode = hashCode * 59 + ObjectName.GetHashCode();
			}

			if (Filename != null)
			{
				hashCode = hashCode * 59 + Filename.GetHashCode();
			}

			return hashCode;
		}
	}
}