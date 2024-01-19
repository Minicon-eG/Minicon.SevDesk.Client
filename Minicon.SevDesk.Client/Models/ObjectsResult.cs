namespace Minicon.SevDesk.Client.Models;

public record ObjectsResult<T>(List<T> Objects, string Total, int Offset, int Limit);
