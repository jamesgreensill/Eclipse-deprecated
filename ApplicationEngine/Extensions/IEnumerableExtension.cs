﻿namespace ApplicationEngine.Extensions;

static class IEnumerableExtension
{
    public static void ForEach<T>(this IEnumerable<T> collection, Action<T> action)
    {
        foreach (var element in collection)
        {
            action(element);
        }
    }
}