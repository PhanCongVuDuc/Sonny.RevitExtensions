# Sonny.RevitExtensions

Open-source library providing extension methods for Autodesk Revit API to simplify geometric operations.

## About

This library was originally written in 2021 as part of the AlphaBIM project. This was during my early days of coding, so
please bear with me if there are bugs or issues with the methods.

Starting from November 13, 2025, I decided to open-source the code I have written, including these extension methods,
rather than letting it sit unused for years. While these methods have been in use for some time, they can be improved
and refined through community contributions and feedback.

## Features

- Extension method style API for Revit classes
- **XYZ Extensions** (`Extensions/XYZs/`)
    - `XYZComparisonExtensions`, `XYZDistanceExtensions`, `XYZGeometryExtensions`
    - `XYZTransformExtensions`, `XYZUtilityExtensions`, `XYZVectorExtensions`
- **Curve Extensions** (`Extensions/GeometryObjects/Curves/`)
    - `CurveExtensions`, `CurvePointExtensions`, `LineExtensions`
- **Face Extensions** (`Extensions/GeometryObjects/Faces/`)
    - `FaceExtensions`, `FaceCurveExtensions`, `FacePointExtensions`
    - `PlanarFaceExtensions`, `CylindricalFaceExtensions`
- **Solid Extensions** (`Extensions/GeometryObjects/Solids/`)
    - `SolidCurveExtensions`, `SolidFaceExtensions`, `SolidPointExtensions`
- **Element Extensions** (`Extensions/Elements/`)
    - `ElementExtensions`, `ElementCurveExtensions`, `ElementFaceExtensions`
    - `ElementPointExtensions`, `ElementSolidExtensions`
- **Document Extensions** (`Extensions/`)
    - `DocumentExtension` - Element query and retrieval methods
    - `ElementQuery` - Lazy-evaluated query for filtering Revit elements
- **Category Extensions** (`Extensions/`)
    - `CategoryExtensions` - Built-in category checking
- **Dimension Extensions** (`Extensions/`)
    - `DimensionExtension` - Dimension segment removal and processing
- **Element Parameter Extensions** (`Extensions/`)
    - `ElementParameterExtensions` - Parameter and property management
- **Reference Extensions** (`Extensions/`)
    - `ReferenceExtensions` - Reference array operations
- **View Extensions** (`Extensions/Views/`)
    - `ViewExtensions` - View-related operations
- **Other Extensions**
    - `ToleranceConstants` - Predefined tolerance values for geometric comparisons
    - `LinqExtensions` - Additional LINQ operations
    - `GeometryElementUtils` - Geometry element utilities
- **RevitWrapper** (`RevitWrapper/`)
    - Base wrapper classes for Column, Dimension, Element, FamilyInstance, Grid, View
- **Utilities** (`Utilities/`)
    - `CreateElement` - Element creation utilities
    - `DimensionOptions` - Dimension operation configuration
- **Processors** (`Processors/`)
    - `DimensionProcessor` - Dimension processing logic
- Supports Revit 2021-2026 (.NET Framework 4.8 / .NET 8.0)

## Installation

Build the project and reference `Sonny.RevitExtensions.dll` in your Revit add-in project.

## Available Extensions

### XYZ Extensions (`Sonny.RevitExtensions.Extensions.XYZs`)

- `XYZComparisonExtensions` - Point comparison operations
- `XYZDistanceExtensions` - Distance calculations
- `XYZGeometryExtensions` - Geometric operations (centroid, intersection, point-in-polygon)
- `XYZTransformExtensions` - Transformation operations
- `XYZUtilityExtensions` - Utility methods
- `XYZVectorExtensions` - Vector operations

### Curve Extensions (`Sonny.RevitExtensions.Extensions.GeometryObjects.Curves`)

- `CurveExtensions` - Operations for Curve class
- `CurvePointExtensions` - Point extraction from curves
- `LineExtensions` - Operations for Line class

### Face Extensions (`Sonny.RevitExtensions.Extensions.GeometryObjects.Faces`)

- `FaceExtensions` - Operations for Face class
- `FaceCurveExtensions` - Curve extraction from faces
- `FacePointExtensions` - Point extraction from faces
- `PlanarFaceExtensions` - Operations for PlanarFace class
- `CylindricalFaceExtensions` - Operations for CylindricalFace class

### Solid Extensions (`Sonny.RevitExtensions.Extensions.GeometryObjects.Solids`)

- `SolidCurveExtensions` - Curve extraction from solids
- `SolidFaceExtensions` - Face extraction from solids
- `SolidPointExtensions` - Point extraction from solids

### Element Extensions (`Sonny.RevitExtensions.Extensions.Elements`)

- `ElementExtensions` - General element operations
- `ElementCurveExtensions` - Curve extraction from elements
- `ElementFaceExtensions` - Face extraction from elements
- `ElementPointExtensions` - Point extraction from elements
- `ElementSolidExtensions` - Solid extraction from elements

### Document Extensions (`Sonny.RevitExtensions.Extensions`)

- `DocumentExtension` - Element query and retrieval methods (GetElementById, GetAllElements, GetInstances, EnumerateInstances)
- `ElementQuery<TElement>` - Lazy-evaluated query for filtering Revit elements

### Category Extensions (`Sonny.RevitExtensions.Extensions`)

- `CategoryExtensions` - Built-in category checking operations

### Dimension Extensions (`Sonny.RevitExtensions.Extensions`)

- `DimensionExtension` - Dimension segment removal and processing

### Element Parameter Extensions (`Sonny.RevitExtensions.Extensions`)

- `ElementParameterExtensions` - Parameter and property management (ClearParam, SetParam, GetParamBool, GetParamInt, GetParamDouble, GetParamString, GetParamElementId, GetParamElement, TrySetParam, TryGetParam, etc.)

### Reference Extensions (`Sonny.RevitExtensions.Extensions`)

- `ReferenceExtensions` - Reference array operations for dimension creation

### View Extensions (`Sonny.RevitExtensions.Extensions.Views`)

- `ViewExtensions` - View-related operations (CreateDimensionOptions)

### Other Extensions

- `ToleranceConstants` - Predefined tolerance constants for geometric comparisons
- `LinqExtensions` - Additional LINQ operations
- `GeometryElementUtils` - Geometry element utilities

### RevitWrapper (`Sonny.RevitExtensions.RevitWrapper`)

- `ColumnWrapperBase` - Base wrapper for Column elements
- `DimensionWrapperBase` - Base wrapper for Dimension elements
- `ElementWrapperBase` - Base wrapper for Element class
- `FamilyInstanceWrapperBase` - Base wrapper for FamilyInstance elements
- `GridWrapperBase` - Base wrapper for Grid elements
- `ViewWrapperBase` - Base wrapper for View elements

### Utilities (`Sonny.RevitExtensions.Utilities`)

- `CreateElement` - Element creation utilities
- `DimensionOptions` - Dimension operation configuration

### Processors (`Sonny.RevitExtensions.Processors`)

- `DimensionProcessor` - Dimension processing logic for segment removal

## Contributing

Contributions welcome! Follow existing code style, add XML documentation, and ensure compatibility across all Revit
versions.
