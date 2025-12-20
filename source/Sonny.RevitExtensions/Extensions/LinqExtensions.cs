#if REVIT2025_OR_GREATER
#else
// Use MoreLINQ.DistinctBy for .NET Framework 4.8 (Revit 2021-2024)
using MoreLinq ;
#endif

namespace Sonny.RevitExtensions.Extensions ;

/// <summary>
///     LINQ extension methods for compatibility across .NET Framework versions
/// </summary>
public static class LinqExtensions
{
    /// <summary>
    ///     Returns distinct elements from a sequence according to a specified key selector function.
    ///     Uses MoreLINQ for .NET Framework 4.8 (Revit 2021-2024) and System.Linq for .NET 8.0 (Revit 2025-2026)
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of source</typeparam>
    /// <typeparam name="TKey">The type of the key returned by keySelector</typeparam>
    /// <param name="source">The sequence to remove duplicate elements from</param>
    /// <param name="keySelector">A function to extract the key for each element</param>
    /// <returns>An IEnumerable that contains distinct elements from the source sequence</returns>
    public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source,
        Func<TSource, TKey> keySelector)
    {
        if (source == null)
        {
            throw new ArgumentNullException(nameof( source )) ;
        }

        if (keySelector == null)
        {
            throw new ArgumentNullException(nameof( keySelector )) ;
        }

#if REVIT2025_OR_GREATER
        // Use built-in System.Linq.DistinctBy for .NET 8.0 (Revit 2025-2026)
        return Enumerable.DistinctBy(source, keySelector) ;
#else
        // Use MoreLINQ.DistinctBy for .NET Framework 4.8 (Revit 2021-2024)
        return MoreEnumerable.DistinctBy(source,
            keySelector) ;
#endif
    }

    /// <summary>
    ///     Filters out null elements from a sequence, returning only non-null elements.
    /// </summary>
    /// <typeparam name="TElement">The type of the elements in the collection. Must be a reference type.</typeparam>
    /// <param name="col">The sequence that may contain null elements.</param>
    /// <returns>An IEnumerable that contains only non-null elements from the source sequence.</returns>
    public static IEnumerable<TElement> NonNull<TElement>(this IEnumerable<TElement?> col) where TElement : class
    {
        foreach (var element in col)
        {
            if (element == null)
            {
                continue ;
            }

            yield return element ;
        }
    }
}
