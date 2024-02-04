namespace Minicon.SevDesk.Client.Extensions;

public static class DateTimeExtensions
{
	public static int? ToSevDeskInt(this DateTime? dateTime)
	{
		return dateTime is null
			? null
			: int.Parse(dateTime.Value.ToString("yyyyMMdd"));
	}

	public static int ToSevDeskInt(this DateTime dateTime)
	{
		return int.Parse(dateTime.ToString("yyyyMMdd"));
	}
}
