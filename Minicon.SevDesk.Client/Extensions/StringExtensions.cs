using System.Globalization;
using Minicon.SevDesk.Client.Models;

namespace Minicon.SevDesk.Client.Extensions;

public static class StringExtensions
{
	public static TagFactoryCreateObject ToTagFactoryCreateObject(this string origin, int objectId,
		ObjectNameEnum objectName)
	{
		return new TagFactoryCreateObject(objectId, origin, objectName);
	}

	public static FactoryCreateBody ToFactoryCreateBody(this string origin)
	{
		return new FactoryCreateBody(origin, new ObjectInfo(-1, ObjectNameEnum.Voucher));
	}

	public static FactoryCreateBody ToFactoryCreateBody(this string origin, int objectId, ObjectNameEnum objectName)
	{
		return new FactoryCreateBody(origin, new ObjectInfo(objectId, objectName));
	}
	public static decimal? ToDecimalOrNull(this string? origin)
	{
		return string.IsNullOrWhiteSpace(origin) ? null : decimal.Parse(origin, CultureInfo.InvariantCulture);
	}

	public static decimal ToDecimal(this string origin)
	{
		return decimal.Parse(origin, CultureInfo.InvariantCulture);
	}

	public static int ToInt(this string origin)
	{
		return int.Parse(origin);
	}
}
