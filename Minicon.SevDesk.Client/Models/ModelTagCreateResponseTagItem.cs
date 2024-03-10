using System.Runtime.Serialization;

namespace Minicon.SevDesk.Client.Models;

/// <summary>
///     The tag information
/// </summary>
[DataContract]
public class ModelTagCreateResponseTagItem
{
	/// <summary>
	///     Initializes a new instance of the <see cref="ModelTagCreateResponseTag" /> class.
	/// </summary>
	/// <param name="id">Unique identifier of the tag (required).</param>
	/// <param name="objectName">Model name, which is &#x27;Tag&#x27; (required).</param>
	/// <param name="additionalInformation"></param>
	/// <param name="create"></param>
	/// <param name="objectType"></param>
	/// <param name="sevDeskClient"></param>
	/// <param name="name"></param>
	public ModelTagCreateResponseTagItem(
		int id,
		string objectName,
		string additionalInformation,
		DateTime create,
		string objectType,
		object sevDeskClient,
		string name
	)
	{
		Id = id;
		ObjectName = objectName;
		AdditionalInformation = additionalInformation;
		Create = create;
		ObjectType = objectType;
		SevDeskClient = sevDeskClient;
		Name = name;
	}


	/// <summary>
	///     Unique identifier of the tag
	/// </summary>
	/// <value>Unique identifier of the tag</value>
	[DataMember(Name = "id", EmitDefaultValue = false)]
	public int Id { get; set; }

	/// <summary>
	///     Model name, which is &#x27;Tag&#x27;
	/// </summary>
	/// <value>Model name, which is &#x27;Tag&#x27;</value>
	[DataMember(Name = "objectName", EmitDefaultValue = false)]
	public string ObjectName { get; set; }

	[DataMember(Name = "additionalInformation", EmitDefaultValue = false)]
	public string AdditionalInformation { get; }

	[DataMember(Name = "create", EmitDefaultValue = false)]
	public DateTime Create { get; }

	[DataMember(Name = "objectType", EmitDefaultValue = false)]
	public string ObjectType { get; }

	[DataMember(Name = "sevDeskClient", EmitDefaultValue = false)]
	public object SevDeskClient { get; }

	[DataMember(Name = "name", EmitDefaultValue = false)]
	public string Name { get; }
}
