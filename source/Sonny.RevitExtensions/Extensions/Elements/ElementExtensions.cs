namespace Sonny.RevitExtensions.Extensions.Elements ;

/// <summary>
///     Extension methods for Revit Element operations
/// </summary>
public static class ElementExtensions
{
    /// <summary>
    ///     Determines whether the element's category matches the specified built-in category
    /// </summary>
    /// <param name="element">The element to check</param>
    /// <param name="builtInCategory">The built-in category to compare against</param>
    /// <returns>True if the element's category matches the built-in category, false otherwise</returns>
    /// <remarks>
    ///     This method uses the CategoryExtensions.IsBuiltInCategory method internally.
    ///     Returns false if the element's category is null.
    /// </remarks>
    public static bool IsBuiltInCategory(this Element element,
        BuiltInCategory builtInCategory) =>
        element.Category.IsBuiltInCategory(element.Document,
            builtInCategory) ;
}
