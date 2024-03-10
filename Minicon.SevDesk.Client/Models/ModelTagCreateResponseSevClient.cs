using System.Runtime.Serialization;

namespace Minicon.SevDesk.Client.Models;

/// <summary>
///     Client to which invoice belongs. Will be filled automatically
/// </summary>
[DataContract]
public record ModelTagCreateResponseSevClient : ObjectInfo
{
	/// <summary>
	///     Initializes a new instance of the <see cref="ModelTagCreateResponseSevClient" /> class.
	/// </summary>
	/// <param name="id">Unique identifier of the client (required).</param>
	/// <param name="objectName">Model name, which is &#x27;SevClientReference&#x27; (required).</param>
	public ModelTagCreateResponseSevClient(int id, string objectName)
		: base(id, objectName)
	{

	}
}
