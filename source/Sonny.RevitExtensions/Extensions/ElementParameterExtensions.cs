using Autodesk.Revit.Exceptions ;
using ArgumentOutOfRangeException = System.ArgumentOutOfRangeException ;
using InvalidOperationException = System.InvalidOperationException ;

namespace Sonny.RevitExtensions.Extensions ;

public static class ElementParameterExtensions
{
    private static IEnumerable<Definition> GetDefinitions(DefinitionBindingMap bindings)
    {
        using var it = bindings.ForwardIterator() ;
        while (it.MoveNext())
        {
            yield return it.Key ;
        }
    }

    public static void ClearParam(this Element elm,
        BuiltInParameter builtInParameter)
    {
        var parameter = elm.get_Parameter(builtInParameter) ;
        if (parameter == null)
        {
            return ;
        }

        parameter.ClearParam() ;
    }

    public static void ClearParam(this Element elm,
        string parameterName)
    {
        var parameter = elm.LookupParameter(parameterName) ;
        if (parameter == null)
        {
            return ;
        }

        parameter.ClearParam() ;
    }

    public static void ClearParam(this Element elm,
        Guid guid)
    {
        var parameter = elm.get_Parameter(guid) ;
        if (parameter == null)
        {
            return ;
        }

        parameter.ClearParam() ;
    }

    public static void ClearParam(this Parameter parameter)
    {
        if (parameter.IsReadOnly)
        {
            throw new InvalidOperationException($"Cannot write parameter {parameter.Definition.Name}.") ;
        }

        try
        {
            if (parameter.IsShared
                && parameter.ClearValue())
            {
                return ;
            }
        }
        catch (InvalidObjectException ex)
        {
        }

        switch (parameter.StorageType)
        {
            case StorageType.None :
                break ;
            case StorageType.Integer :
                parameter.Set(0) ;
                break ;
            case StorageType.Double :
                parameter.Set(0.0) ;
                break ;
            case StorageType.String :
                parameter.Set(string.Empty) ;
                break ;
            case StorageType.ElementId :
                parameter.Set(ElementId.InvalidElementId) ;
                break ;
            default :
                throw new ArgumentOutOfRangeException() ;
        }
    }

    public static void SetParam(this Element elm,
        BuiltInParameter builtInParameter,
        bool value)
    {
        if (! elm.TrySetParam(builtInParameter,
                value))
        {
            throw new InvalidOperationException(
                $"Parameter {typeof( BuiltInParameter ).FullName}.{builtInParameter} is not found.") ;
        }
    }

    public static void SetParam(this Element elm,
        string parameterName,
        bool value)
    {
        if (! elm.TrySetParam(parameterName,
                value))
        {
            throw new InvalidOperationException($"Parameter {parameterName} is not found.") ;
        }
    }

    public static void SetParam(this Element elm,
        Guid guid,
        bool value)
    {
        if (! elm.TrySetParam(guid,
                value))
        {
            throw new InvalidOperationException($"Parameter {guid} is not found.") ;
        }
    }

    public static void SetParam(this Element elm,
        BuiltInParameter builtInParameter,
        int value)
    {
        if (! elm.TrySetParam(builtInParameter,
                value))
        {
            throw new InvalidOperationException(
                $"Parameter {typeof( BuiltInParameter ).FullName}.{builtInParameter} is not found.") ;
        }
    }

    public static void SetParam(this Element elm,
        string parameterName,
        int value)
    {
        if (! elm.TrySetParam(parameterName,
                value))
        {
            throw new InvalidOperationException($"Parameter {parameterName} is not found.") ;
        }
    }

    public static void SetParam(this Element elm,
        Guid guid,
        int value)
    {
        if (! elm.TrySetParam(guid,
                value))
        {
            throw new InvalidOperationException($"Parameter {guid} is not found.") ;
        }
    }

    public static void SetParam(this Element elm,
        BuiltInParameter builtInParameter,
        double value)
    {
        if (! elm.TrySetParam(builtInParameter,
                value))
        {
            throw new InvalidOperationException(
                $"Parameter {typeof( BuiltInParameter ).FullName}.{builtInParameter} is not found.") ;
        }
    }

    public static void SetParam(this Element elm,
        string parameterName,
        double value)
    {
        if (! elm.TrySetParam(parameterName,
                value))
        {
            throw new InvalidOperationException($"Parameter {parameterName} is not found.") ;
        }
    }

    public static void SetParam(this Element elm,
        Guid guid,
        double value)
    {
        if (! elm.TrySetParam(guid,
                value))
        {
            throw new InvalidOperationException($"Parameter {guid} is not found.") ;
        }
    }

    public static void SetParam(this Element elm,
        BuiltInParameter builtInParameter,
        string value)
    {
        if (! elm.TrySetParam(builtInParameter,
                value))
        {
            throw new InvalidOperationException(
                $"Parameter {typeof( BuiltInParameter ).FullName}.{builtInParameter} is not found.") ;
        }
    }

    public static void SetParam(this Element elm,
        string parameterName,
        string value)
    {
        if (! elm.TrySetParam(parameterName,
                value))
        {
            throw new InvalidOperationException($"Parameter {parameterName} is not found.") ;
        }
    }

    public static void SetParam(this Element elm,
        Guid guid,
        string value)
    {
        if (! elm.TrySetParam(guid,
                value))
        {
            throw new InvalidOperationException($"Parameter {guid} is not found.") ;
        }
    }


    public static void SetParam(this Element elm,
        BuiltInParameter builtInParameter,
        ElementId value)
    {
        if (! elm.TrySetParam(builtInParameter,
                value))
        {
            throw new InvalidOperationException(
                $"Parameter {typeof( BuiltInParameter ).FullName}.{builtInParameter} is not found.") ;
        }
    }

    public static void SetParam(this Element elm,
        string parameterName,
        ElementId value)
    {
        if (! elm.TrySetParam(parameterName,
                value))
        {
            throw new InvalidOperationException($"Parameter {parameterName} is not found.") ;
        }
    }

    public static void SetParam(this Element elm,
        Guid guid,
        ElementId value)
    {
        if (! elm.TrySetParam(guid,
                value))
        {
            throw new InvalidOperationException($"Parameter {guid} is not found.") ;
        }
    }

    public static void SetParam(this Element elm,
        BuiltInParameter builtInParameter,
        Element? value)
    {
        if (! elm.TrySetParam(builtInParameter,
                value))
        {
            throw new InvalidOperationException(
                $"Parameter {typeof( BuiltInParameter ).FullName}.{builtInParameter} is not found.") ;
        }
    }

    public static void SetParam(this Element elm,
        string parameterName,
        Element? value)
    {
        if (! elm.TrySetParam(parameterName,
                value))
        {
            throw new InvalidOperationException($"Parameter {parameterName} is not found.") ;
        }
    }

    public static void SetParam(this Element elm,
        Guid guid,
        Element? value)
    {
        if (! elm.TrySetParam(guid,
                value))
        {
            throw new InvalidOperationException($"Parameter {guid} is not found.") ;
        }
    }

    public static bool TrySetParam(this Element elm,
        BuiltInParameter builtInParameter,
        bool value)
    {
        var parameter = elm.get_Parameter(builtInParameter) ;
        return parameter != null && parameter.TrySetParam(value) ;
    }

    public static bool TrySetParam(this Element elm,
        string parameterName,
        bool value)
    {
        var parameter = elm.LookupParameter(parameterName) ;
        return parameter != null && parameter.TrySetParam(value) ;
    }

    public static bool TrySetParam(this Element elm,
        Guid guid,
        bool value)
    {
        var parameter = elm.get_Parameter(guid) ;
        return parameter != null && parameter.TrySetParam(value) ;
    }

    private static bool TrySetParam(this Parameter parameter,
        bool value)
    {
        if (parameter.IsReadOnly
            || StorageType.Integer != parameter.StorageType)
        {
            return false ;
        }

        parameter.Set(value ? 1 : 0) ;
        return true ;
    }

    public static bool TrySetParam(this Element elm,
        BuiltInParameter builtInParameter,
        int value)
    {
        var parameter = elm.get_Parameter(builtInParameter) ;
        return parameter != null && parameter.TrySetParam(value) ;
    }

    public static bool TrySetParam(this Element elm,
        string parameterName,
        int value)
    {
        var parameter = elm.LookupParameter(parameterName) ;
        return parameter != null && parameter.TrySetParam(value) ;
    }

    public static bool TrySetParam(this Element elm,
        Guid guid,
        int value)
    {
        var parameter = elm.get_Parameter(guid) ;
        return parameter != null && parameter.TrySetParam(value) ;
    }

    private static bool TrySetParam(this Parameter parameter,
        int value)
    {
        if (parameter.IsReadOnly)
        {
            return false ;
        }

        if (StorageType.Double == parameter.StorageType)
        {
            parameter.Set((double)value) ;
            return true ;
        }

        if (StorageType.Integer != parameter.StorageType)
        {
            return false ;
        }

        parameter.Set(value) ;
        return true ;
    }

    public static bool TrySetParam(this Element elm,
        BuiltInParameter builtInParameter,
        double value)
    {
        var parameter = elm.get_Parameter(builtInParameter) ;
        return parameter != null && parameter.TrySetParam(value) ;
    }

    public static bool TrySetParam(this Element elm,
        string parameterName,
        double value)
    {
        var parameter = elm.LookupParameter(parameterName) ;
        return parameter != null && parameter.TrySetParam(value) ;
    }

    public static bool TrySetParam(this Element elm,
        Guid guid,
        double value)
    {
        var parameter = elm.get_Parameter(guid) ;
        return parameter != null && parameter.TrySetParam(value) ;
    }

    private static bool TrySetParam(this Parameter parameter,
        double value)
    {
        if (parameter.IsReadOnly
            || StorageType.Double != parameter.StorageType)
        {
            return false ;
        }

        parameter.Set(value) ;
        return true ;
    }

    public static bool TrySetParam(this Element elm,
        BuiltInParameter builtInParameter,
        string value)
    {
        var parameter = elm.get_Parameter(builtInParameter) ;
        return parameter != null && parameter.TrySetParam(value) ;
    }

    public static bool TrySetParam(this Element elm,
        string parameterName,
        string value)
    {
        var parameter = elm.LookupParameter(parameterName) ;
        return parameter != null && parameter.TrySetParam(value) ;
    }

    public static bool TrySetParam(this Element elm,
        Guid guid,
        string value)
    {
        var parameter = elm.get_Parameter(guid) ;
        return parameter != null && parameter.TrySetParam(value) ;
    }

    private static bool TrySetParam(this Parameter parameter,
        string value)
    {
        if (parameter.IsReadOnly
            || StorageType.String != parameter.StorageType)
        {
            return false ;
        }

        parameter.Set(value) ;
        return true ;
    }

    public static bool TrySetParam(this Element elm,
        BuiltInParameter builtInParameter,
        ElementId value)
    {
        var parameter = elm.get_Parameter(builtInParameter) ;
        return parameter != null && parameter.TrySetParam(value) ;
    }

    public static bool TrySetParam(this Element elm,
        string parameterName,
        ElementId value)
    {
        var parameter = elm.LookupParameter(parameterName) ;
        return parameter != null && parameter.TrySetParam(value) ;
    }

    public static bool TrySetParam(this Element elm,
        Guid guid,
        ElementId value)
    {
        var parameter = elm.get_Parameter(guid) ;
        return parameter != null && parameter.TrySetParam(value) ;
    }

    private static bool TrySetParam(this Parameter parameter,
        ElementId value)
    {
        if (parameter.IsReadOnly
            || StorageType.ElementId != parameter.StorageType)
        {
            return false ;
        }

        parameter.Set(value) ;
        return true ;
    }

    public static bool TrySetParam(this Element elm,
        BuiltInParameter builtInParameter,
        Element? value)
    {
        var parameter = elm.get_Parameter(builtInParameter) ;
        return parameter != null && parameter.TrySetParam(value) ;
    }

    public static bool TrySetParam(this Element elm,
        string parameterName,
        Element? value)
    {
        var parameter = elm.LookupParameter(parameterName) ;
        return parameter != null && parameter.TrySetParam(value) ;
    }

    public static bool TrySetParam(this Element elm,
        Guid guid,
        Element? value)
    {
        var parameter = elm.get_Parameter(guid) ;
        return parameter != null && parameter.TrySetParam(value) ;
    }

    private static bool TrySetParam(this Parameter parameter,
        Element? value)
    {
        if (parameter.IsReadOnly)
        {
            return false ;
        }

        if (StorageType.ElementId == parameter.StorageType)
        {
            // value.GetValidId()
            // parameter.Set(value.GetValidId()) ;
            parameter.Set(value.Id) ;

            return true ;
        }

        if (StorageType.String != parameter.StorageType)
        {
            return false ;
        }

        parameter.Set(value?.UniqueId ?? string.Empty) ;
        return true ;
    }

    public static bool GetParamBool(this Element elm,
        BuiltInParameter builtInParameter)
    {
        bool propertyBool ;
        if (! elm.TryGetParam(builtInParameter,
                out propertyBool))
        {
            throw new InvalidOperationException() ;
        }

        return propertyBool ;
    }

    public static bool GetParamBool(this Element elm,
        string parameterName)
    {
        bool propertyBool ;
        if (! elm.TryGetParam(parameterName,
                out propertyBool))
        {
            throw new InvalidOperationException() ;
        }

        return propertyBool ;
    }

    public static bool GetParamBool(this Element elm,
        Guid guid)
    {
        bool propertyBool ;
        if (! elm.TryGetParam(guid,
                out propertyBool))
        {
            throw new InvalidOperationException() ;
        }

        return propertyBool ;
    }

    public static int GetParamInt(this Element elm,
        BuiltInParameter builtInParameter)
    {
        int propertyInt ;
        if (! elm.TryGetParam(builtInParameter,
                out propertyInt))
        {
            throw new InvalidOperationException() ;
        }

        return propertyInt ;
    }

    public static int GetParamInt(this Element elm,
        string parameterName)
    {
        int propertyInt ;
        if (! elm.TryGetParam(parameterName,
                out propertyInt))
        {
            throw new InvalidOperationException() ;
        }

        return propertyInt ;
    }

    public static int GetParamInt(this Element elm,
        Guid guid)
    {
        int propertyInt ;
        if (! elm.TryGetParam(guid,
                out propertyInt))
        {
            throw new InvalidOperationException() ;
        }

        return propertyInt ;
    }

    public static double GetParamDouble(this Element elm,
        BuiltInParameter builtInParameter)
    {
        double propertyDouble ;
        if (! elm.TryGetParam(builtInParameter,
                out propertyDouble))
        {
            throw new InvalidOperationException() ;
        }

        return propertyDouble ;
    }

    public static double GetParamDouble(this Element elm,
        string parameterName)
    {
        double propertyDouble ;
        if (! elm.TryGetParam(parameterName,
                out propertyDouble))
        {
            throw new InvalidOperationException() ;
        }

        return propertyDouble ;
    }

    public static double GetParamDouble(this Element elm,
        Guid guid)
    {
        double propertyDouble ;
        if (! elm.TryGetParam(guid,
                out propertyDouble))
        {
            throw new InvalidOperationException() ;
        }

        return propertyDouble ;
    }

    public static string? GetParamString(this Element elm,
        BuiltInParameter builtInParameter)
    {
        string propertyString ;
        if (! elm.TryGetParam(builtInParameter,
                out propertyString))
        {
            throw new InvalidOperationException() ;
        }

        return propertyString ;
    }

    public static string? GetParamString(this Element elm,
        string parameterName)
    {
        string propertyString ;
        if (! elm.TryGetParam(parameterName,
                out propertyString))
        {
            throw new InvalidOperationException() ;
        }

        return propertyString ;
    }

    public static string? GetParamString(this Element elm,
        Guid guid)
    {
        string propertyString ;
        if (! elm.TryGetParam(guid,
                out propertyString))
        {
            throw new InvalidOperationException() ;
        }

        return propertyString ;
    }

    public static ElementId GetParamElementId(this Element elm,
        BuiltInParameter builtInParameter)
    {
        ElementId propertyElementId ;
        if (! elm.TryGetParam(builtInParameter,
                out propertyElementId))
        {
            throw new InvalidOperationException() ;
        }

        return propertyElementId ;
    }

    public static ElementId GetParamElementId(this Element elm,
        string parameterName)
    {
        ElementId propertyElementId ;
        if (! elm.TryGetParam(parameterName,
                out propertyElementId))
        {
            throw new InvalidOperationException() ;
        }

        return propertyElementId ;
    }

    public static ElementId GetParamElementId(this Element elm,
        Guid guid)
    {
        ElementId propertyElementId ;
        if (! elm.TryGetParam(guid,
                out propertyElementId))
        {
            throw new InvalidOperationException() ;
        }

        return propertyElementId ;
    }

    public static Element? GetParamElement(this Element elm,
        BuiltInParameter builtInParameter)
    {
        Element propertyElement ;
        if (! elm.TryGetParam(builtInParameter,
                out propertyElement))
        {
            throw new InvalidOperationException() ;
        }

        return propertyElement ;
    }

    public static Element? GetParamElement(this Element elm,
        string parameterName)
    {
        Element propertyElement ;
        if (! elm.TryGetParam(parameterName,
                out propertyElement))
        {
            throw new InvalidOperationException() ;
        }

        return propertyElement ;
    }

    public static Element? GetParamElement(this Element elm,
        Guid guid)
    {
        Element propertyElement ;
        if (! elm.TryGetParam(guid,
                out propertyElement))
        {
            throw new InvalidOperationException() ;
        }

        return propertyElement ;
    }

    public static TElement? GetParamElement<TElement>(this Element elm,
        BuiltInParameter builtInParameter) where TElement : Element
    {
        TElement propertyElement ;
        if (! elm.TryGetParam(builtInParameter,
                out propertyElement))
        {
            throw new InvalidOperationException() ;
        }

        return propertyElement ;
    }

    public static TElement? GetParamElement<TElement>(this Element elm,
        string parameterName) where TElement : Element
    {
        TElement propertyElement ;
        if (! elm.TryGetParam(parameterName,
                out propertyElement))
        {
            throw new InvalidOperationException() ;
        }

        return propertyElement ;
    }

    public static TElement? GetParamElement<TElement>(this Element elm,
        Guid guid) where TElement : Element
    {
        TElement propertyElement ;
        if (! elm.TryGetParam(guid,
                out propertyElement))
        {
            throw new InvalidOperationException() ;
        }

        return propertyElement ;
    }

    public static bool TryGetParam(this Element elm,
        BuiltInParameter builtInParameter,
        out bool value)
    {
        value = false ;
        int num ;
        if (! elm.TryGetParam(builtInParameter,
                out num))
        {
            return false ;
        }

        value = num != 0 ;
        return true ;
    }

    public static bool TryGetParam(this Element elm,
        string parameterName,
        out bool value)
    {
        value = false ;
        int num ;
        if (! elm.TryGetParam(parameterName,
                out num))
        {
            return false ;
        }

        value = num != 0 ;
        return true ;
    }

    public static bool TryGetParam(this Element elm,
        Guid guid,
        out bool value)
    {
        value = false ;
        int num ;
        if (! elm.TryGetParam(guid,
                out num))
        {
            return false ;
        }

        value = num != 0 ;
        return true ;
    }


    public static bool TryGetParam(this Element elm,
        BuiltInParameter builtInParameter,
        out int value)
    {
        value = 0 ;
        var parameter = elm.get_Parameter(builtInParameter) ;
        return parameter != null && parameter.TryGetParam(out value) ;
    }

    public static bool TryGetParam(this Element elm,
        string parameterName,
        out int value)
    {
        value = 0 ;
        var parameter = elm.LookupParameter(parameterName) ;
        return parameter != null && parameter.TryGetParam(out value) ;
    }

    public static bool TryGetParam(this Element elm,
        Guid guid,
        out int value)
    {
        value = 0 ;
        var parameter = elm.get_Parameter(guid) ;
        return parameter != null && parameter.TryGetParam(out value) ;
    }

    public static bool TryGetParam(this Parameter parameter,
        out int value)
    {
        value = 0 ;
        if (parameter.StorageType != StorageType.Integer)
        {
            return false ;
        }

        value = parameter.AsInteger() ;
        return true ;
    }


    public static bool TryGetParam(this Element elm,
        BuiltInParameter builtInParameter,
        out double value)
    {
        value = 0.0 ;
        var parameter = elm.get_Parameter(builtInParameter) ;
        return parameter != null && parameter.TryGetParam(out value) ;
    }

    public static bool TryGetParam(this Element elm,
        string parameterName,
        out double value)
    {
        value = 0.0 ;
        var parameter = elm.LookupParameter(parameterName) ;
        return parameter != null && parameter.TryGetParam(out value) ;
    }

    public static bool TryGetParam(this Element elm,
        Guid guid,
        out double value)
    {
        value = 0.0 ;
        var parameter = elm.get_Parameter(guid) ;
        return parameter != null && parameter.TryGetParam(out value) ;
    }

    public static bool TryGetParam(this Parameter parameter,
        out double value)
    {
        value = 0.0 ;
        switch (parameter.StorageType)
        {
            case StorageType.Integer :
                value = parameter.AsInteger() ;
                return true ;
            case StorageType.Double :
                value = parameter.AsDouble() ;
                return true ;
            default :
                return false ;
        }
    }

    public static bool TryGetParam(this Element elm,
        BuiltInParameter builtInParameter,
        out string? value)
    {
        value = null ;
        var parameter = elm.get_Parameter(builtInParameter) ;
        return parameter != null && parameter.TryGetParam(out value) ;
    }

    public static bool TryGetParam(this Element elm,
        string parameterName,
        out string? value)
    {
        value = null ;
        var parameter = elm.LookupParameter(parameterName) ;
        return parameter != null && parameter.TryGetParam(out value) ;
    }

    public static bool TryGetParam(this Element elm,
        Guid guid,
        out string? value)
    {
        value = null ;
        var parameter = elm.get_Parameter(guid) ;
        return parameter != null && parameter.TryGetParam(out value) ;
    }

    public static bool TryGetParam(this Parameter parameter,
        out string? value)
    {
        value = null ;
        if (parameter.StorageType != StorageType.String)
        {
            return false ;
        }

        value = parameter.AsString() ;
        return true ;
    }

    public static bool TryGetParam(this Element elm,
        BuiltInParameter builtInParameter,
        out ElementId value)
    {
        value = ElementId.InvalidElementId ;
        var parameter = elm.get_Parameter(builtInParameter) ;
        return parameter != null && parameter.TryGetParam(out value) ;
    }

    public static bool TryGetParam(this Element elm,
        string parameterName,
        out ElementId value)
    {
        value = ElementId.InvalidElementId ;
        var parameter = elm.LookupParameter(parameterName) ;
        return parameter != null && parameter.TryGetParam(out value) ;
    }

    public static bool TryGetParam(this Element elm,
        Guid guid,
        out ElementId value)
    {
        value = ElementId.InvalidElementId ;
        var parameter = elm.get_Parameter(guid) ;
        return parameter != null && parameter.TryGetParam(out value) ;
    }

    public static bool TryGetParam(this Parameter parameter,
        out ElementId value)
    {
        value = ElementId.InvalidElementId ;
        if (parameter.StorageType != StorageType.ElementId)
        {
            return false ;
        }

        value = parameter.AsElementId() ;
        return true ;
    }


    public static bool TryGetParam<TElement>(this Element elm,
        BuiltInParameter builtInParameter,
        out TElement? value) where TElement : Element
    {
        value = default ;
        var parameter = elm.get_Parameter(builtInParameter) ;
        return parameter != null && parameter.TryGetParam(out value) ;
    }

    public static bool TryGetParam<TElement>(this Element elm,
        string parameterName,
        out TElement? value) where TElement : Element
    {
        value = default ;
        var parameter = elm.LookupParameter(parameterName) ;
        return parameter != null && parameter.TryGetParam(out value) ;
    }

    public static bool TryGetParam<TElement>(this Element elm,
        Guid guid,
        out TElement? value) where TElement : Element
    {
        value = default ;
        var parameter = elm.get_Parameter(guid) ;
        return parameter != null && parameter.TryGetParam(out value) ;
    }

    private static bool TryGetParam<TElement>(this Parameter parameter,
        out TElement? value) where TElement : Element
    {
        value = default ;
        switch (parameter.StorageType)
        {
            case StorageType.String :
                value = parameter.Element.Document.GetElementById<TElement>(parameter.AsString()) ;
                return true ;
            case StorageType.ElementId :
                value = parameter.Element.Document.GetElementById<TElement>(parameter.AsElementId()) ;
                return true ;
            default :
                return false ;
        }
    }

    public static bool HasParameter(this Element elm,
        BuiltInParameter builtInParameter) =>
        elm.get_Parameter(builtInParameter) != null ;

    public static bool HasParameter(this Element elm,
        string parameterName) =>
        elm.LookupParameter(parameterName) != null ;

    public static bool HasParameter(this Element elm,
        Guid guid) =>
        elm.get_Parameter(guid) != null ;

    public static bool HasParameter(this Element elm,
        BuiltInParameter builtInParameter,
        StorageType type)
    {
        var parameter = elm.get_Parameter(builtInParameter) ;
        return parameter != null && parameter.StorageType == type ;
    }

    public static bool HasParameter(this Element elm,
        string parameterName,
        StorageType type)
    {
        var parameter = elm.LookupParameter(parameterName) ;
        return parameter != null && parameter.StorageType == type ;
    }

    public static bool HasParameter(this Element elm,
        Guid guid,
        StorageType type)
    {
        var parameter = elm.get_Parameter(guid) ;
        return parameter != null && parameter.StorageType == type ;
    }

    public static bool HasParameterValue(this Element elm,
        BuiltInParameter builtInParameter)
    {
        var parameter = elm.get_Parameter(builtInParameter) ;
        return parameter != null && parameter.HasValue ;
    }

    public static bool HasParameterValue(this Element elm,
        string parameterName)
    {
        var parameter = elm.LookupParameter(parameterName) ;
        return parameter != null && parameter.HasValue ;
    }

    public static bool HasParameterValue(this Element elm,
        Guid guid)
    {
        var parameter = elm.get_Parameter(guid) ;
        return parameter != null && parameter.HasValue ;
    }

    public static bool HasParameterValue(this Element elm,
        BuiltInParameter builtInParameter,
        StorageType type)
    {
        var parameter = elm.get_Parameter(builtInParameter) ;
        return parameter != null && parameter.HasValue && parameter.StorageType == type ;
    }

    public static bool HasParameterValue(this Element elm,
        string parameterName,
        StorageType type)
    {
        var parameter = elm.LookupParameter(parameterName) ;
        return parameter != null && parameter.HasValue && parameter.StorageType == type ;
    }


    public static Parameter? GetParameter(this Element elm,
        BuiltInParameter builtInParameter) =>
        elm.get_Parameter(builtInParameter) ;

    public static Parameter? GetParameter(this Element elm,
        string parameterName) =>
        elm.LookupParameter(parameterName) ;

    public static Parameter? GetParameter(this Element elm,
        Guid guid) =>
        elm.get_Parameter(guid) ;
}
