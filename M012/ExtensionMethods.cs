namespace M012;

internal static class ExtensionMethods //Class must be static
{
	public static int CrossSum(this int x) //with this at the first parameter we can specify which type should get this function
	{
		return x.ToString().ToCharArray().Sum(e => (int) char.GetNumericValue(e));
	}

	public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> list)
	{
		return list.OrderBy(e => Random.Shared.Next());
	}
}
