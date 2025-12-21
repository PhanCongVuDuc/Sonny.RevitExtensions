// Licensed to the.NET Foundation under one or more agreements.
// The.NET Foundation licenses this file to you under the MIT license.

using MoreLinq ;
using Sonny.RevitExtensions.Extensions.GeometryObjects.Solids ;

namespace Sonny.RevitExtensions.Extensions ;

public static class ImportInstanceExtensions
{
    /// <summary>
    /// Gets all unique layer names from the CAD import instance geometry.
    /// Extracts layer names from graphics styles associated with geometry objects.
    /// </summary>
    /// <param name="cadInstance">The CAD import instance to extract layer names from.</param>
    /// <param name="includeSolid">If true, includes layer names from solid geometry. If false, only includes layer names from non-solid geometry (lines, arcs, polylines, etc.). Default is false.</param>
    /// <returns>A HashSet containing all unique layer names found in the CAD instance geometry.</returns>
    /// <remarks>
    /// This method iterates through all geometry objects in the CAD instance and extracts layer names
    /// from their associated GraphicsStyle categories. For solid geometry, it extracts layer names from
    /// all planar faces of the solid. For other geometry types, it extracts the layer name directly
    /// from the geometry object's GraphicsStyle.
    /// </remarks>
    public static HashSet<string> GetAllLayerNames(this ImportInstance cadInstance,
        bool includeSolid = false)
    {
        var option = new Options() ;
        var layerNames = new HashSet<string>() ;
        foreach (var geoObject in cadInstance.get_Geometry(option))
        {
            if (geoObject is not GeometryInstance geometryInstance)
            {
                continue ;
            }

            foreach (var geometryObject in geometryInstance.GetInstanceGeometry())
            {
                if (geometryObject is Solid solid)
                {
                    if (! includeSolid)
                    {
                        continue ;
                    }

                    var planarFaces = solid.GetPlanarFaces()
                        .ToList() ;
                    if (planarFaces.Count == 0)
                    {
                        continue ;
                    }

                    var graphicsStyles = planarFaces.Select(x =>
                            cadInstance.Document.GetElementById<GraphicsStyle>(x.GraphicsStyleId))
                        .NonNull() ;
                    graphicsStyles.ForEach(x => layerNames.Add(x.GraphicsStyleCategory.Name)) ;
                }
                else
                {
                    if (cadInstance.Document.GetElementById<GraphicsStyle>(geometryObject.GraphicsStyleId) is not
                        { } graphicsStyle)
                    {
                        continue ;
                    }

                    layerNames.Add(graphicsStyle.GraphicsStyleCategory.Name) ;
                }
            }
        }

        return layerNames ;
    }

    /// <summary>
    /// Gets all solid geometry objects from the CAD import instance.
    /// </summary>
    /// <param name="cadInstance">The CAD import instance to extract solids from.</param>
    /// <returns>An IEnumerable of Solid objects found in the CAD instance geometry. Only returns solids that have at least one face.</returns>
    /// <remarks>
    /// This method iterates through all geometry instances in the CAD import and filters for Solid objects.
    /// Only solids with at least one face (Faces.Size > 0) are returned. Other geometry types such as
    /// arcs, lines, polylines, and points are skipped.
    /// </remarks>
    public static IEnumerable<Solid> GetSolids(this ImportInstance cadInstance)
    {
        var option = new Options() ;
        foreach (var geoObject in cadInstance.get_Geometry(option))
        {
            if (geoObject is not GeometryInstance geoInstance)
            {
                continue ;
            }

            // Geometry objects can be Arc, Line, PolyLine, Point, or Solid
            foreach (var geometryObject in geoInstance.GetInstanceGeometry())
            {
                if (geometryObject is not Solid solid)
                {
                    continue ;
                }

                if (solid.Faces.Size <= 0)
                {
                    continue ;
                }

                yield return solid ;
            }
        }
    }
}
