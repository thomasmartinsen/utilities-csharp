﻿namespace Extensions;

/// <summary>
/// Extension methods for enabling async LINQ operations on IAsyncEnumerable sequence.
/// </summary>
public static class IAsyncEnumerableExtensions
{
    /// <summary>
    /// Creates a List<T> from an IAsyncEnumerable<T> by enumerating it asynchronously.
    /// </summary>
    public static async Task<List<T>> ToListAsync<T>(this IAsyncEnumerable<T> source)
    {
        var result = new List<T>();
        await foreach (var item in source.ConfigureAwait(false))
        {
            result.Add(item);
        }

        return result;
    }
}
