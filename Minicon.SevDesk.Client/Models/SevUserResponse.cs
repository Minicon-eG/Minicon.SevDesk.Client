using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Minicon.SevDesk.Client.Models;

/// <summary>
///     SevUser details from the API
/// </summary>
[DataContract]
public class SevUserResponse : IEquatable<SevUserResponse>, IValidatableObject
{
	/// <summary>
	///     Initializes a new instance of the <see cref="SevUserResponse" /> class.
	/// </summary>
	/// <param name="id">Unique identifier of the user.</param>
	/// <param name="objectName">Model name, which is 'SevUser'.</param>
	/// <param name="create">Date of user creation.</param>
	/// <param name="update">Date of last update.</param>
	/// <param name="username">Username of the user.</param>
	/// <param name="email">Email address of the user.</param>
	/// <param name="firstName">First name of the user.</param>
	/// <param name="lastName">Last name of the user.</param>
	/// <param name="fullName">Full name of the user.</param>
	/// <param name="sevClient">SevClient reference.</param>
	public SevUserResponse(
		string id = default,
		string objectName = default,
		DateTime? create = default,
		DateTime? update = default,
		string username = default,
		string email = default,
		string firstName = default,
		string lastName = default,
		string fullName = default,
		ModelContactResponseSevClient sevClient = default)
	{
		Id = id;
		ObjectName = objectName;
		Create = create;
		Update = update;
		Username = username;
		Email = email;
		FirstName = firstName;
		LastName = lastName;
		FullName = fullName;
		SevClient = sevClient;
	}

	/// <summary>
	///     Unique identifier of the user
	/// </summary>
	/// <value>Unique identifier of the user</value>
	[DataMember(Name = "id", EmitDefaultValue = false)]
	public string Id { get; set; }

	/// <summary>
	///     Model name, which is 'SevUser'
	/// </summary>
	/// <value>Model name, which is 'SevUser'</value>
	[DataMember(Name = "objectName", EmitDefaultValue = false)]
	public string ObjectName { get; set; }

	/// <summary>
	///     Date of user creation
	/// </summary>
	/// <value>Date of user creation</value>
	[DataMember(Name = "create", EmitDefaultValue = false)]
	public DateTime? Create { get; set; }

	/// <summary>
	///     Date of last update
	/// </summary>
	/// <value>Date of last update</value>
	[DataMember(Name = "update", EmitDefaultValue = false)]
	public DateTime? Update { get; set; }

	/// <summary>
	///     Username of the user
	/// </summary>
	/// <value>Username of the user</value>
	[DataMember(Name = "username", EmitDefaultValue = false)]
	public string Username { get; set; }

	/// <summary>
	///     Email address of the user
	/// </summary>
	/// <value>Email address of the user</value>
	[DataMember(Name = "email", EmitDefaultValue = false)]
	public string Email { get; set; }

	/// <summary>
	///     First name of the user
	/// </summary>
	/// <value>First name of the user</value>
	[DataMember(Name = "firstName", EmitDefaultValue = false)]
	public string FirstName { get; set; }

	/// <summary>
	///     Last name of the user
	/// </summary>
	/// <value>Last name of the user</value>
	[DataMember(Name = "lastName", EmitDefaultValue = false)]
	public string LastName { get; set; }

	/// <summary>
	///     Full name of the user
	/// </summary>
	/// <value>Full name of the user</value>
	[DataMember(Name = "fullName", EmitDefaultValue = false)]
	public string FullName { get; set; }

	/// <summary>
	///     Gets or Sets SevClient
	/// </summary>
	[DataMember(Name = "sevClient", EmitDefaultValue = false)]
	public ModelContactResponseSevClient SevClient { get; set; }

	/// <summary>
	///     Returns true if SevUserResponse instances are equal
	/// </summary>
	/// <param name="input">Instance of SevUserResponse to be compared</param>
	/// <returns>Boolean</returns>
	public bool Equals(SevUserResponse? input)
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
			) &&
			(
				Create == input.Create ||
				(Create != null &&
				 Create.Equals(input.Create))
			) &&
			(
				Update == input.Update ||
				(Update != null &&
				 Update.Equals(input.Update))
			) &&
			(
				Username == input.Username ||
				(Username != null &&
				 Username.Equals(input.Username))
			) &&
			(
				Email == input.Email ||
				(Email != null &&
				 Email.Equals(input.Email))
			) &&
			(
				FirstName == input.FirstName ||
				(FirstName != null &&
				 FirstName.Equals(input.FirstName))
			) &&
			(
				LastName == input.LastName ||
				(LastName != null &&
				 LastName.Equals(input.LastName))
			) &&
			(
				FullName == input.FullName ||
				(FullName != null &&
				 FullName.Equals(input.FullName))
			) &&
			(
				SevClient == input.SevClient ||
				(SevClient != null &&
				 SevClient.Equals(input.SevClient))
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
		sb.Append("class SevUserResponse {\n");
		sb.Append("  Id: ").Append(Id).Append('\n');
		sb.Append("  ObjectName: ").Append(ObjectName).Append('\n');
		sb.Append("  Create: ").Append(Create).Append('\n');
		sb.Append("  Update: ").Append(Update).Append('\n');
		sb.Append("  Username: ").Append(Username).Append('\n');
		sb.Append("  Email: ").Append(Email).Append('\n');
		sb.Append("  FirstName: ").Append(FirstName).Append('\n');
		sb.Append("  LastName: ").Append(LastName).Append('\n');
		sb.Append("  FullName: ").Append(FullName).Append('\n');
		sb.Append("  SevClient: ").Append(SevClient).Append('\n');
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
		return Equals(input as SevUserResponse);
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
			if (Id != null)
			{
				hashCode = hashCode * 59 + Id.GetHashCode();
			}

			if (ObjectName != null)
			{
				hashCode = hashCode * 59 + ObjectName.GetHashCode();
			}

			if (Create != null)
			{
				hashCode = hashCode * 59 + Create.GetHashCode();
			}

			if (Update != null)
			{
				hashCode = hashCode * 59 + Update.GetHashCode();
			}

			if (Username != null)
			{
				hashCode = hashCode * 59 + Username.GetHashCode();
			}

			if (Email != null)
			{
				hashCode = hashCode * 59 + Email.GetHashCode();
			}

			if (FirstName != null)
			{
				hashCode = hashCode * 59 + FirstName.GetHashCode();
			}

			if (LastName != null)
			{
				hashCode = hashCode * 59 + LastName.GetHashCode();
			}

			if (FullName != null)
			{
				hashCode = hashCode * 59 + FullName.GetHashCode();
			}

			if (SevClient != null)
			{
				hashCode = hashCode * 59 + SevClient.GetHashCode();
			}

			return hashCode;
		}
	}
}