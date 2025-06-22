using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Minicon.SevDesk.Client.Models;

[DataContract]
public record ObjectInfo
{
    [JsonConstructor]
    public ObjectInfo(int id, string objectName)
    {
        Id = id;
        ObjectName = objectName;
    }

    public ObjectInfo(int id, ObjectNameEnum objectName)
        : this(id, objectName.ToString())
    {
    }

    [DataMember(Name = "objectName", EmitDefaultValue = false)]
    public string ObjectName { get; set; }

    [DataMember(Name = "id", EmitDefaultValue = false)]
    public int Id { get; set; }
}