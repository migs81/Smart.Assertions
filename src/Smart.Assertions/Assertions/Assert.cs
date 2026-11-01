using System.Runtime.CompilerServices;

namespace Smart.Assertions.Assertions;

public static partial class Assert
{
    #region Null, NotNull
    
    public static void Null<T>(T value, 
        [CallerArgumentExpression(nameof(value))] string? expression = null)
    {
        if (value is not null)
            throw new AssertionException($"{nameof(Assert)}.{nameof(Null)}({expression}) failed.",
                $"Expected: null",
                $"Actual: {value}");
    }
    
    public static void NotNull<T>(T value, 
        [CallerArgumentExpression(nameof(value))] string? expression = null)
    {
        if (value is null)
            throw new AssertionException($"{nameof(Assert)}.{nameof(NotNull)}({expression}) failed.",
                $"Expected: not null",
                $"Actual: null");
    }
    
    #endregion
    
    #region Equal, NotEqual
    
    public static void Equal<T>(T expected, T actual, 
        [CallerArgumentExpression(nameof(expected))] string? expectedExpression = null, 
        [CallerArgumentExpression(nameof(actual))] string? actualExpression = null)
    {
        if (!EqualityComparer<T>.Default.Equals(expected, actual))
            throw new AssertionException($"{nameof(Assert)}.{nameof(Equal)}({expectedExpression}, {actualExpression}) failed.",
                $"Expected: {expected}",
                $"Actual: {actual}");
    }
    
    public static void NotEqual<T>(T expected, T actual, 
        [CallerArgumentExpression(nameof(expected))] string? expectedExpression = null, 
        [CallerArgumentExpression(nameof(actual))] string? actualExpression = null)
    {
        if (EqualityComparer<T>.Default.Equals(expected, actual))
            throw new AssertionException($"{nameof(Assert)}.{nameof(NotEqual)}({expectedExpression}, {actualExpression}) failed.",
                $"Expected: not {expected}",
                $"Actual: {actual}");
    }
    
    #endregion
}

public static partial class AssertExtensions
{
    #region ShouldBeNull, ShouldNotBeNull

    public static T ShouldBeNull<T>(this T value, 
        [CallerArgumentExpression(nameof(value))] string? expression = null)
    {
        if (value is not null)
            throw new AssertionException($"{expression}.{nameof(ShouldBeNull)}() failed.",
                $"Expected: null",
                $"Actual: {value}");
        
        return value;
    }
    
    public static T ShouldNotBeNull<T>(this T value, 
        [CallerArgumentExpression(nameof(value))] string? expression = null)
    {
        if (value is null)
            throw new AssertionException($"{expression}.{nameof(ShouldNotBeNull)}() failed.",
                $"Expected: not null",
                $"Actual: null");
        
        return value;
    }

    #endregion

    #region ShouldEqual, ShouldNotEqual

    public static T ShouldEqual<T>(this T actual, T expected, 
        [CallerArgumentExpression(nameof(expected))] string? expectedExpression = null, 
        [CallerArgumentExpression(nameof(actual))] string? actualExpression = null)
    {
        if (!EqualityComparer<T>.Default.Equals(expected, actual))
            throw new AssertionException($"{actualExpression}.{nameof(ShouldEqual)}({expectedExpression}) failed.",
                $"Expected: {expected}",
                $"Actual: {actual}");
        
        return actual;
    }
    
    public static T ShouldNotEqual<T>(this T actual, T expected, 
        [CallerArgumentExpression(nameof(expected))] string? expectedExpression = null, 
        [CallerArgumentExpression(nameof(actual))] string? actualExpression = null)
    {
        if (EqualityComparer<T>.Default.Equals(expected, actual))
            throw new AssertionException($"{expectedExpression}.{nameof(ShouldNotEqual)}({expectedExpression}) failed.",
                $"Expected: not {expected}",
                $"Actual: {actual}");
        
        return actual;
    }

    #endregion
}