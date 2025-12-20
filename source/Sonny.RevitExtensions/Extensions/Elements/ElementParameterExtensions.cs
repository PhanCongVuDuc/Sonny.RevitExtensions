// Licensed to the.NET Foundation under one or more agreements.
// The.NET Foundation licenses this file to you under the MIT license.

namespace Sonny.RevitExtensions.Extensions.Elements ;

/// <summary>
///     Extension methods for retrieving element type parameters
/// </summary>
public static class ElementParameterExtensions
{
    /// <summary>
    ///     Gets all type parameter names from the specified element.
    ///     If the element is an ElementType, returns its parameters directly.
    ///     Otherwise, returns parameters from the element's ElementType.
    /// </summary>
    /// <param name="element">The element to get type parameters from.</param>
    /// <returns>An enumerable collection of parameter names. Returns empty collection if element type is not found.</returns>
    public static IEnumerable<string> GetAllTypeParameters(this Element element)
    {
        if (element is ElementType)
        {
            foreach (Parameter parameter in element.Parameters)
            {
                yield return parameter.Definition.Name ;
            }
        }
        else
        {
            var elementType = element.Document.GetElement(element.GetTypeId()) ;
            if (elementType == null)
            {
                yield break ;
            }

            foreach (Parameter parameter in elementType.Parameters)
            {
                yield return parameter.Definition.Name ;
            }
        }
    }
}
