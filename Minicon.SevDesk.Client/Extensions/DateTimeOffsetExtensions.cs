namespace Minicon.SevDesk.Client.Extensions;

public static class DateTimeOffsetExtensions
{
	public static string? ToSevDeskDate(this DateTimeOffset? offset)
	{
		return offset?.ToString("yyyy-MM-dd");
	}

	public static string ToSevDeskFormat(this DateTimeOffset offset)
	{
		return offset.ToString("yyyy-MM-dd");
	}
}
