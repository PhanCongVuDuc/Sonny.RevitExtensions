// Licensed to the.NET Foundation under one or more agreements.
// The.NET Foundation licenses this file to you under the MIT license.

namespace Sonny.RevitExtensions.Extensions.GeometryObjects ;

public static class GeometryObjectExtensions
{
    /// <summary>
    /// Checks whether the geometry object belongs to the specified layer.
    /// </summary>
    /// <param name="geometryObject">The geometry object to check.</param>
    /// <param name="layer">The layer name to compare against.</param>
    /// <param name="document">The document containing the geometry object.</param>
    /// <returns>
    /// <c>true</c> if the geometry object's graphics style category name matches the specified layer;
    /// otherwise, <c>false</c>. Returns <c>false</c> if the graphics style cannot be retrieved.
    /// </returns>
    public static bool IsOnLayer(this GeometryObject geometryObject,
        string layer,
        Document document)
    {
        if (document.GetElement(geometryObject.GraphicsStyleId) is not GraphicsStyle graphicsStyle) {
            return false ;
        }

        var styleCategory = graphicsStyle.GraphicsStyleCategory ;
        return styleCategory.Name.Equals(layer) ;
    }
}
