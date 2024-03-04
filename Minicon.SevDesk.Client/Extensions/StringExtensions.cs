using System.Globalization;

namespace Minicon.SevDesk.Client.Extensions;

public static class StringExtensions
{
	public static decimal? ToDecimalOrNull(this string? origin)
	{
		return string.IsNullOrWhiteSpace(origin) ? null : decimal.Parse(origin, CultureInfo.InvariantCulture);
	}

	public static int ToInt32(this string origin)
	{
		return int.Parse(origin);
	}
}
