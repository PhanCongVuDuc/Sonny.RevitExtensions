// Licensed to the.NET Foundation under one or more agreements.
// The.NET Foundation licenses this file to you under the MIT license.

namespace Sonny.RevitExtensions.RevitWrapper ;

public class GridWrapperBase(Grid grid) : ElementWrapperBase(grid)
{
    private Line? _line ;
    public Grid Grid { get ; } = grid ;
    public Line? Line => _line ??= Grid.Curve as Line ;
}
