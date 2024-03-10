namespace Minicon.SevDesk.Client.Extensions;

public static class ObjectExtensions
{
	public static T[] AsArray<T>(this T obj)
	{
		return new[] { obj };
	}
}
