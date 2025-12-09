namespace Sonny.RevitExtensions.Extensions ;

/// <summary>
///     Extension methods for Revit Category operations
/// </summary>
public static class CategoryExtensions
{
    /// <summary>
    ///     Determines whether the category matches the specified built-in category
    /// </summary>
    /// <param name="category">The category to check</param>
    /// <param name="document">The Revit document</param>
    /// <param name="builtInCategory">The built-in category to compare against</param>
    /// <returns>True if the category matches the built-in category, false otherwise</returns>
    /// <remarks>
    ///     For Revit 2023 and later, uses the BuiltInCategory property directly.
    ///     For earlier versions, compares category names as a fallback.
    /// </remarks>
    public static bool IsBuiltInCategory(this Category category,
        Document document,
        BuiltInCategory builtInCategory)
    {
#if REVIT2023_OR_GREATER
        return category.BuiltInCategory == builtInCategory ;
#else
    return category.Name == Category.GetCategory( document,
        builtInCategory ).Name ;
#endif
    }
}
