// Licensed to the.NET Foundation under one or more agreements.
// The.NET Foundation licenses this file to you under the MIT license.

namespace Sonny.RevitExtensions.RevitWrapper ;

public class DimensionWrapperBase(Dimension dimension) : ElementWrapperBase(dimension)
{
    public Dimension Dimension { get ; } = dimension ;
}
