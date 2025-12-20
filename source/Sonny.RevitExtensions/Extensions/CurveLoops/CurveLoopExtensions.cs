// Licensed to the.NET Foundation under one or more agreements.
// The.NET Foundation licenses this file to you under the MIT license.

namespace Sonny.RevitExtensions.Extensions.CurveLoops ;

public static class CurveLoopExtensions
{
    /// <summary>
    ///     Gets all curves from the specified CurveLoop as an enumerable collection.
    /// </summary>
    /// <param name="curveLoop">The CurveLoop to extract curves from.</param>
    /// <returns>An enumerable collection of Curve objects. Null curves are skipped.</returns>
    public static IEnumerable<Curve> GetCurves(this CurveLoop curveLoop)
    {
        var curveLoopIterator = curveLoop.GetCurveLoopIterator() ;
        while (curveLoopIterator.MoveNext())
        {
            var curve = curveLoopIterator.Current ;
            if (curve == null)
            {
                continue ;
            }

            yield return curve ;
        }
    }
}
