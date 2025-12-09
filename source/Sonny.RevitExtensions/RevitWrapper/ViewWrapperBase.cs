// Licensed to the.NET Foundation under one or more agreements.
// The.NET Foundation licenses this file to you under the MIT license.

using Sonny.RevitExtensions.Extensions ;
using Sonny.RevitExtensions.Extensions.XYZs ;

namespace Sonny.RevitExtensions.RevitWrapper ;

public class ViewWrapperBase(View view) : ElementWrapperBase(view)
{
    private List<Element>? _elements ;

    private List<ElementWrapperBase>? _elementWrappers ;

    private List<FamilyInstanceWrapperBase>? _familyInstanceWrappers ;

    private List<GridWrapperBase>? _gridWrappers ;
    private bool? _isViewPlan ;

    public View View { get ; } = view ;

    public bool IsViewPlan =>
        _isViewPlan ??= View.ViewDirection.IsAlmostEqual3D(XYZ.BasisZ)
                        || View.ViewDirection.IsAlmostEqual3D(XYZ.BasisZ.Negate()) ;

    public List<Element> Elements =>
        _elements ??= View.Document
            .GetAllElements<Element>(View)
            .ToList() ;

    public List<GridWrapperBase> GridWrappers =>
        _gridWrappers ??= Elements.OfType<Grid>()
            .Select(x => new GridWrapperBase(x))
            .ToList() ;

    public List<ElementWrapperBase> ElementWrappers =>
        _elementWrappers ??= Elements.Select(x => new ElementWrapperBase(x))
            .ToList() ;

    public List<FamilyInstanceWrapperBase> FamilyInstanceWrappers =>
        _familyInstanceWrappers ??= Elements.OfType<FamilyInstance>()
            .Select(x => new FamilyInstanceWrapperBase(x))
            .ToList() ;
}
