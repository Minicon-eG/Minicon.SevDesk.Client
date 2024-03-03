namespace Minicon.SevDesk.Client.Extensions;

public static class StringExtensions
{
	public static float? ToFloatOrNull(this string? origin)
	{
		return string.IsNullOrWhiteSpace(origin) ? null : float.Parse(origin);
	}
}
