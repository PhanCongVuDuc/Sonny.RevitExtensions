// Licensed to the.NET Foundation under one or more agreements.
// The.NET Foundation licenses this file to you under the MIT license.

using Sonny.RevitExtensions.Extensions.XYZs ;

namespace Sonny.RevitExtensions.EqualityComparers ;

public class ParallelXyzEqualityComparer : IEqualityComparer<XYZ>
{
    public bool Equals(XYZ? x,
        XYZ? y)
    {
        if (ReferenceEquals(x,
                y))
        {
            return true ;
        }

        if (x is null)
        {
            return false ;
        }

        if (y is null)
        {
            return false ;
        }

        if (x.GetType() == y.GetType())
        {
            if (x.IsParallel(y))
            {
                return true ;
            }
        }

        return false ;
    }

    public int GetHashCode(XYZ obj) => 0 ;
}
