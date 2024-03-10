

using System.Runtime.Serialization;

namespace Minicon.SevDesk.Client.Models;

[DataContract]
public class ModelTagCreateResponseTag
{
	[DataMember(Name = "objects")] public ModelTagCreateResponseTagItem? Objects { get; set; }
}
