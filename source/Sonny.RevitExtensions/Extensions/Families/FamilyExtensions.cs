// Licensed to the.NET Foundation under one or more agreements.
// The.NET Foundation licenses this file to you under the MIT license.

namespace Sonny.RevitExtensions.Extensions.Families ;

/// <summary>
/// Provides extension methods for <see cref="T:Autodesk.Revit.DB.Family"/> objects in Revit API.
/// </summary>
public static class FamilyExtensions
{
    /// <summary>
    /// Gets all family symbols associated with the family.
    /// </summary>
    /// <param name="family">The family to get symbols from.</param>
    /// <returns>An enumerable collection of <see cref="T:Autodesk.Revit.DB.FamilySymbol"/> objects.</returns>
    /// <remarks>
    /// This method iterates through all family symbol IDs and retrieves the corresponding <see cref="T:Autodesk.Revit.DB.FamilySymbol"/> elements.
    /// Returns an empty collection if the family has no symbols.
    /// </remarks>
    public static IEnumerable<FamilySymbol> GetAllFamilySymbol(this Family family)
    {
        foreach (var familySymbolId in family.GetFamilySymbolIds())
        {
            yield return family.Document.GetElementById<FamilySymbol>(familySymbolId)! ;
        }
    }
}
