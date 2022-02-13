namespace ApplicationEngine.Extensions;

internal static class EnumerableExtension
{
    public static void ForEach<T>(this IEnumerable<T> collection, Action<T> action)
    {
        foreach (var element in collection)
        {
            action(element);
        }
    }
}